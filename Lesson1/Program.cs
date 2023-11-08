// See https://aka.ms/new-console-template for more information

using Lesson1.Models;

MyPoint point3D = new MyPoint(5, 10, 15);

MyPoint point3DCopy = new MyPoint(50, 100, 0);

MyLine line1 = MyLine.Create(point3D, point3DCopy);

var vectorLine1 = line1.Vector;

Console.WriteLine(vectorLine1);
Console.WriteLine(line1.Length);
