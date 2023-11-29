// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;

var assemly = Assembly.LoadFrom("C:\\Users\\Admin\\Desktop\\Programming\\RevitCourse2\\RevitCourse2_Lessons\\Lesson1.API\\bin\\Debug\\net7.0\\Lesson1.API.dll");

foreach (Type innerType in assemly.GetTypes())
{
    innerType.GetAt
    if (innerType.IsClass && innerType.Name == "MyWall")
    {
        var wallTest = assemly.CreateInstance(
            innerType.FullName,
            true,
            BindingFlags.Default,
            null, new object[] { 0, null, 10, null }, null, null);
    }
    Console.WriteLine(innerType.Name);
}


var allDynamoFiles = Directory.GetFiles("C:\\Program Files\\Autodesk\\Revit 2020\\AddIns\\DynamoForRevit");

var addin = allDynamoFiles.FirstOrDefault(x => x.EndsWith(".addin"));

var addinInfo = File.ReadAllText(addin);

Console.WriteLine(addinInfo);

