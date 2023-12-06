using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Lesson3_Revit
{
    internal static class MyRevitActions
    {
        public static Wall CreateWall(Document doc, ElementId levelId, Curve baseLine, string transactionName)
        {
            using (var transact = new Transaction(doc, transactionName))
            {
                transact.Start();
                var myNewWall = Wall.Create(document: doc, curve: baseLine, levelId: levelId, structural: false);
                transact.Commit();

                return myNewWall;
            }
        }
    }
}
