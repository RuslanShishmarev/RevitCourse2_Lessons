namespace Lesson1.Models
{
    internal class MyLine : MyCurve
    {
        public MyPoint Vector { get; }

        private MyLine(MyPoint start, MyPoint end) : base(start, end)
        {
            Vector = GetVector();
            Length = GetLength();
        }

        private MyPoint GetVector()
        {
            MyPoint diff = End - Start;
            diff.Normalize();
            return diff;
        }

        private double GetLength()
        {
            double xSqDiff = Math.Pow(End.X - Start.X, 2);
            double ySqDiff = Math.Pow(End.Y - Start.Y, 2);
            double zSqDiff = Math.Pow(End.Z - Start.Z, 2);

            double l = Math.Sqrt(xSqDiff + ySqDiff + zSqDiff);
            return l;
        }

        public static MyLine Create(MyPoint start, MyPoint end)
        {
            return new MyLine(start, end);
        }

        public override MyCurve CreateOffset(MyPoint vector, double distance)
        {
            var newStart = Start + vector * distance;
            var newEnd = End + vector * distance;

            var newLine = new MyLine(newStart, newEnd);
            return newLine;
        }
    }
}
