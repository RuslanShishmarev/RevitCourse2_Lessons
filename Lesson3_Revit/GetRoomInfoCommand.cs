using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

using System;
using System.Linq;
using System.Windows;

namespace Lesson3_Revit
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class GetRoomInfoCommand : IExternalCommand
    {
        private const string APPART_AREA = "AppartArea";

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;
            var allRooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).Cast<Room>();

            var allRoomsByAppartNum_Linq = allRooms.GroupBy(x => x.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString());

            var transact = new Transaction(doc, "Set appart area");
            transact.Start();

            foreach (var group in allRoomsByAppartNum_Linq)
            {
                string appart = group.Key;
                var areaSum = group.Sum(x => x.Area * Math.Pow(304.8 / 1000, 2));
                var appartArea = Math.Round(areaSum, 2);

                foreach (var room in group)
                {                    
                    room.LookupParameter(APPART_AREA).Set(appartArea);
                }
            }

            transact.Commit();
            transact.Dispose();

            MessageBox.Show("Готово!");
            return Result.Succeeded;
        }
    }
}
