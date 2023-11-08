﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Models
{
    internal class MyPoint
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        public MyPoint(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static MyPoint operator +(MyPoint point1, MyPoint point2)
        {
            return new MyPoint(point1.X + point2.X, point1.Y + point2.Y, point1.Z + point2.Z);
        }

        public static MyPoint operator -(MyPoint point1, MyPoint point2)
        {
            return new MyPoint(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);
        }

        public static MyPoint operator *(MyPoint point1, MyPoint point2)
        {
            return new MyPoint(point1.X * point2.X, point1.Y * point2.Y, point1.Z * point2.Z);
        }

        public static MyPoint operator *(MyPoint point1, double num)
        {
            return new MyPoint(point1.X * num, point1.Y * num, point1.Z * num);
        }

        public static MyPoint operator /(MyPoint point1, MyPoint point2)
        {
            return new MyPoint(point1.X / point2.X, point1.Y / point2.Y, point1.Z / point2.Z);
        }

        public static MyPoint operator /(MyPoint point1, double num)
        {
            return new MyPoint(point1.X / num, point1.Y / num, point1.Z / num);
        }

        public static bool operator ==(MyPoint point1, MyPoint point2)
        {
            return point1.Equals(point2);
        }
        public static bool operator !=(MyPoint point1, MyPoint point2)
        {
            return !(point1 == point2);
        }

        public void Normalize()
        {
            double maxXY = Math.Max(Math.Abs(this.X), Math.Abs(this.Y));

            double max = Math.Max(maxXY, Math.Abs(this.Z));

            X /= max; Y /= max; Z /= max;
        }

        public override string ToString()
        {
            string result = $"X={X}; Y={Y}; Z={Z}"; //"X= " + X + "; Y= " + Y + "; Z= " + Z;
            return result;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is MyPoint)
            {
                MyPoint objAsPoint = obj as MyPoint;

                return objAsPoint.GetHashCode() == this.GetHashCode();
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }
    }
}