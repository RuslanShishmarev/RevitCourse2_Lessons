using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Lesson3_Revit.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Document _doc;
        private IEnumerable<Element> _levels;
        private int _indentX = 100;
        private int _indentY = 0;

        private bool _isModal;
        private MyCreationHandler _creationHandler;

        public MainWindow(Document doc, bool isModal = true, MyCreationHandler creationHandler = null)
        {
            InitializeComponent();
            _doc = doc;
            _isModal = isModal;
            _creationHandler = creationHandler;

            _levels = new FilteredElementCollector(_doc)
                .OfClass(typeof(Level))
                .OrderBy(x => (x as Level).Elevation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XYZ start = new XYZ(0, _indentY, 0);
            XYZ end = new XYZ(start.X + _indentX, _indentY, start.Z);

            var baseLine = Line.CreateBound(start, end);

            var first = _levels.FirstOrDefault();

            var action = new Action(() => 
            {
                var myNewWall = MyRevitActions.CreateWall(_doc, first.Id, baseLine, $"Test x+={_indentX} y+={_indentY}"); 
                this.info.Text += $"New wall: {myNewWall?.Id}\n";
            });

            if (!_isModal)
            {
                try
                {
                    _creationHandler.SetAction(action);
                    _creationHandler.Raise();
                }
                catch(Exception ex) 
                {
                    this.info.Text = ex.Message;
                }
            }
            else
            {
                action.Invoke();
            }


            _indentY += 5;
        }
    }
}
