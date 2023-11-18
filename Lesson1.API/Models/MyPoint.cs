namespace Lesson1.API.Models
{
    public class MyPoint
    {
        public double X { get; }

        public double Y { get; }

        public double Z { get; }

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

        public MyPoint Normalize()
        {
            double maxXY = Math.Max(Math.Abs(this.X), Math.Abs(this.Y));

            double max = Math.Max(maxXY, Math.Abs(this.Z));

            return this / max;
        }

        public override string ToString()
        {
            string result = $"X={X}; Y={Y}; Z={Z}"; //"X= " + X + "; Y= " + Y + "; Z= " + Z;
            return result;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is MyPoint objAsPoint)
            {
                return objAsPoint.GetHashCode() == this.GetHashCode();
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public static MyPoint Zero => new MyPoint(0, 0, 0);
    }
}
