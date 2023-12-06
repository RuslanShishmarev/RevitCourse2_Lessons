using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using Lesson3_Revit.Views;

using System;

namespace Lesson3_Revit
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class ModalessWndCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            var myHandler = new MyCreationHandler() ;

            var window = new MainWindow(doc, false, myHandler);
            window.Show();

            return Result.Succeeded;
        }
    }

    public class MyCreationHandler : IExternalEventHandler
    {
        private ExternalEvent _externalEvent;
        private Action _raiseAction;
        public MyCreationHandler()
        {
            _externalEvent = ExternalEvent.Create(this);
        }

        public void SetAction(Action raiseAction)
        {
            _raiseAction = raiseAction;
        }

        public void Execute(UIApplication app)
        {
            _raiseAction?.Invoke();
        }

        public void Raise()
        {
            _externalEvent.Raise();
        }

        public string GetName() => nameof(MyCreationHandler);
    }
}
