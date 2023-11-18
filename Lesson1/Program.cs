// See https://aka.ms/new-console-template for more information

using Lesson1.API.Models;
using System.Reflection;

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
    thickness: 200);
myMaterials.Add(material1);

MyLayMaterial material2 = new MyLayMaterial(
    id: 2,
    name: "Термоплиты",
    thickness: 150);
myMaterials.Add(material2);

MyLayMaterial material3 = new MyLayMaterial(
    id: 3,
    name: "Штукатурка",
    thickness: 30);
myMaterials.Add(material3);

MyLayMaterial material4 = new MyLayMaterial(
    id: 4,
    name: "Кирпич фасадный",
    thickness: 120);
myMaterials.Add(material4);

MyWallType wallType1 = new MyWallType(
    id: 1,
    name: "Стена наружная 500мм",
    materials: myMaterials);

MyPoint startWall = new MyPoint(1, 1, 0);

MyPoint endWall = new MyPoint(50, 100, 0);

MyLine wallLine = MyLine.Create(startWall, endWall);

MyWall newWall = new MyWall(
    id: 1,
    locationCurve: wallLine,
    height: 3000,
    wallType: wallType1);

Console.WriteLine("Создан элемент стены:\n" + newWall);


Console.WriteLine("------------------------------");
Console.WriteLine("Всего элементов в проекте:\n");

SomeMethodWithElement(myMaterials.Concat(new IMyElement[2] { wallType1 , newWall }));


void SomeMethodWithElement(IEnumerable<IMyElement> elements)
{
    foreach (var el in elements)
    {
        Console.WriteLine(el.Name);
    }
}
