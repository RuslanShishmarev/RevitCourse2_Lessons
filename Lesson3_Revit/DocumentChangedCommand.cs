using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_Revit
{
    [Transaction(TransactionMode.ReadOnly)]
    [Regeneration(RegenerationOption.Manual)]
    internal class DocumentChanged_ElementType_Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Application app = commandData.Application.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            var wallTypeForPlacement = new FilteredElementCollector(doc).OfClass(typeof(WallType)).FirstOrDefault(x => x.Name.StartsWith("Типовой")) as WallType;

            uidoc.PostRequestForElementTypePlacement(wallTypeForPlacement);

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class DocumentChanged_Instances_Command : IExternalCommand
    {
        private List<Element> _newElements = new List<Element>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Application app = commandData.Application.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            EventHandler<DocumentChangedEventArgs> getNewElemets = new EventHandler<DocumentChangedEventArgs>(AddNewElementsToDatalist);

            app.DocumentChanged += getNewElemets;

            var wind = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Windows)
                .WhereElementIsElementType()
                .FirstOrDefault(x => x.Name == "400х1800h") as FamilySymbol;

            var placeOptions = new PromptForFamilyInstancePlacementOptions();

            try
            {
                uidoc.PromptForFamilyInstancePlacement(wind, placeOptions);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                app.DocumentChanged -= getNewElemets;
            }

            TaskDialog.Show("Count", _newElements.Count.ToString());
            
            return Result.Succeeded;
        }

        private void AddNewElementsToDatalist(object sender, DocumentChangedEventArgs args)
        {
            var doc = args.GetDocument();
            var newElements = args.GetAddedElementIds().Select(id => doc.GetElement(id));
            _newElements.AddRange(newElements);
        }
    }
}
