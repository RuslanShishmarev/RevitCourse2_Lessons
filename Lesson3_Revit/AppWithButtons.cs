using Autodesk.Revit.UI;

using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace Lesson3_Revit
{
    internal class AppWithButtons : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "RevitCourse 2";

            application.CreateRibbonTab(tabName);

            RibbonPanel panel1 = application.CreateRibbonPanel(tabName, "All commands");

            var thisAssembly = Assembly.GetExecutingAssembly().Location;

            CreateButton(
                panel: panel1,
                name: "btn1",
                text: nameof(HelloCommand),
                assembly: thisAssembly,
                className: typeof(HelloCommand).FullName,
                imageName: @"C:\Users\Admin\Desktop\InfoCoder\logo.ico");

            panel1.AddSeparator();

            CreateButton(
                panel: panel1,
                name: "btn2",
                text: nameof(DocumentChanged_ElementType_Command),
                assembly: thisAssembly,
                className: typeof(DocumentChanged_ElementType_Command).FullName,
                imageName: @"C:\Users\Admin\Desktop\InfoCoder\revit.ico");

            CreateButton(
                panel: panel1,
                name: "btn3",
                text: nameof(DocumentChanged_Instances_Command),
                assembly: thisAssembly,
                className: typeof(DocumentChanged_Instances_Command).FullName,
                imageName: @"C:\Users\Admin\Desktop\InfoCoder\mem.ico");


            RibbonPanel panel2 = application.CreateRibbonPanel(tabName, "Info");

            CreateButton(
               panel: panel2,
               name: "btnWalls",
               text: nameof(GetWallsCommand),
               assembly: thisAssembly,
               className: typeof(GetWallsCommand).FullName,
               imageName: @"C:\Users\Admin\Desktop\InfoCoder\icon-drawing-32.ico");

            CreateButton(
               panel: panel2,
               name: "btnRooms",
               text: nameof(GetRoomInfoCommand),
               assembly: thisAssembly,
               className: typeof(GetRoomInfoCommand).FullName,
               imageName: @"C:\Users\Admin\Desktop\InfoCoder\icon-drawing-32.ico");

            panel2.AddSeparator();

            var modalWndData = new PushButtonData(
                name: "modalWnd",
                text: nameof(ModalWndCommand),
                assemblyName: thisAssembly,
                className: typeof(ModalWndCommand).FullName);

            modalWndData.LargeImage =
                new BitmapImage(new Uri(@"C:\Users\Admin\Desktop\InfoCoder\logo.ico"));

            var modalessWndData = new PushButtonData(
                name: "modalessWnd",
                text: nameof(ModalessWndCommand),
                assemblyName: thisAssembly,
                className: typeof(ModalessWndCommand).FullName);

            modalessWndData.LargeImage =
                new BitmapImage(new Uri(@"C:\Users\Admin\Desktop\InfoCoder\logo.ico"));

            SplitButtonData windowsButtons = new SplitButtonData("splitButton1", "windows");
            SplitButton sb = panel2.AddItem(windowsButtons) as SplitButton;
            sb.AddPushButton(modalWndData);
            sb.AddPushButton(modalessWndData);

            return Result.Succeeded;
        }

        private void CreateButton(
            RibbonPanel panel,
            string name,
            string text,
            string assembly,
            string className,
            string imageName)
        {
            var newBtnData = new PushButtonData(
                name: name,
                text: text,
                assemblyName: assembly,
                className: className);

            RibbonButton newBtn = panel.AddItem(newBtnData) as RibbonButton;
            newBtn.LargeImage = new BitmapImage(new Uri(imageName));
        }
    }
}
