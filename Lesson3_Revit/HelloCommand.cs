using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
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
    public class HelloCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var userAnswer = TaskDialog.Show(nameof(HelloCommand), "Привет всем из команды!", TaskDialogCommonButtons.Yes);
            if (userAnswer == TaskDialogResult.Yes)
            {
                TaskDialog.Show(nameof(HelloCommand), "Вы нажали ок!");
            }

            else
            {
                TaskDialog.Show(nameof(HelloCommand), "очень жаль...");
            }

            MessageBox.Show("Привет из стандартного окна!!!");

            return Result.Succeeded;
        }
    }
}
