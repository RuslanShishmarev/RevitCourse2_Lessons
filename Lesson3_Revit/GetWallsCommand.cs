using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson3_Revit
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class GetWallsCommand : IExternalCommand
    {
        private void SomeMethod(object s, DocumentChangedEventArgs args)
        {

        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;


            commandData.Application.Application.DocumentChanged += new EventHandler<Autodesk.Revit.DB.Events.DocumentChangedEventArgs>((s,a) =>
            {

            });

            var wallCollector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType();

            var walls = wallCollector.ToElements();
            //ShowInfo("Walls", walls.Count.ToString());

            var wallTypes = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsElementType()
                .ToElements();
            //ShowInfo("Walls types", wallTypes.Count.ToString());

            var floors = new FilteredElementCollector(doc).OfClass(typeof(Floor)).ToElements();
            //ShowInfo("Floors", floors.Count.ToString());

            var wallsByType = new FilteredElementCollector(doc)
                .OfClass(typeof(Wall))
                .Where(x => x.Name.Contains("Типовой"));

            //ShowInfo("Типовые стены", wallsByType.Count().ToString());

            Element firstWall = wallsByType.First();
            var wallGeometry = firstWall.get_Geometry(new Options()).FirstOrDefault() as Solid;


            double maxArea = 0;
            foreach (PlanarFace face in wallGeometry.Faces)
            {
                if (maxArea < face.Area)
                {
                    maxArea = face.Area;
                }
            }

            ShowInfo("Максимальная площадь", Math.Round(maxArea * Math.Pow(304.8, 2), 2).ToString());

            ElementId levelOfWallId = firstWall.LevelId;

            Element levelElement = doc.GetElement(levelOfWallId);
            var level = levelElement as Level;

            return Result.Succeeded;
        }

        private void ShowInfo(string header, string message)
        {
            MessageBox.Show(message, header);
        }
    }
}
