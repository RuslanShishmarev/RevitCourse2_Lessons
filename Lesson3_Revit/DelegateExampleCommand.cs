using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_Revit
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class DelegateExampleCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            MyMainClass mainClass = new MyMainClass();
            mainClass.ActionAfterExecution += () =>
            {
                string docName2 = GeUpdatedDocumentName(doc, NameUpdater.Updater2); ;
                TaskDialog.Show("Doc name Updater 2", docName2);
            };

            mainClass.ActionAfterExecution += () =>
            {
                string docName2 = GeUpdatedDocumentName(doc, NameUpdater.Updater2); ;
                TaskDialog.Show("Doc name Updater 2", docName2);
            };

            mainClass.Execute();

            return Result.Succeeded;
        }

        private string GeUpdatedDocumentName(Document doc, Func<string,string> updater)
        {
            string updatedName = updater.Invoke(doc.Title);
            return updatedName;
        }
    }

    class MyMainClass
    {
        public event Action ActionAfterExecution;

        public void Execute()
        {
            // Логика работы execute

            ActionAfterExecution.Invoke();
        }
    }
}
