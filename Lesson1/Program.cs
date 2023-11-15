// See https://aka.ms/new-console-template for more information

using Lesson1.Models;

MyPoint point3D = new MyPoint(5, 10, 15);

MyPoint point3DCopy = new MyPoint(50, 100, 0);

MyLine line1 = MyLine.Create(point3D, point3DCopy);

MyPoint p1 = MyPoint.Zero;
MyPoint p2 = new MyPoint(10, 20, 0);
MyPoint p3 = new MyPoint(2, 15, 0);

MyArc arc1 = MyArc.Create(p1, p2, p3);

var allCurves = new List<MyCurve>();

allCurves.Add(line1);
allCurves.Add(arc1);

var newOffsets = GetNewOffsetForCurves(allCurves, new MyPoint(1,0,0), 12);

List<MyCurve> GetNewOffsetForCurves(IEnumerable<MyCurve> curves, MyPoint vector, double distance)
{
    var result = new List<MyCurve>();

    foreach (MyCurve curve in curves)
	{
        var offset = curve.CreateOffset(vector, distance);
        result.Add(offset);
    }

    return result;
}


List<MyLayMaterial> myMaterials= new List<MyLayMaterial>();

MyLayMaterial material1 = new MyLayMaterial(
    id: 1,
    name: "Железобетон",
    thickness: 50);
