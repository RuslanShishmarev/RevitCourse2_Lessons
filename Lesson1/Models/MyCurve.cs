namespace Lesson1.Models
{
    internal abstract class MyCurve
    {
        public MyPoint Start { get; }

        public MyPoint End { get; }

        public double Length { get; protected set; }

        public MyCurve(MyPoint start, MyPoint end)
        {
            Start = start;
            End = end;
        }

        public MyPoint GetNormal()
        {
            throw new NotImplementedException();
        }

        public abstract MyCurve CreateOffset(MyPoint vector, double distance);
    }
}
