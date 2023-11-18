namespace Lesson1.API.Models
{
    public class MyArc : MyCurve
    {
        public MyPoint Center { get; }

        public MyPoint CenterRadius { get; }

        public double Radius { get; }

        private MyArc(MyPoint start, MyPoint end, MyPoint center) 
            : base(start, end)
        {
            Center = center;
            // get other props
        }

        public static MyArc Create(MyPoint start, MyPoint end, MyPoint center)
        {
            return new MyArc(start, end, center);
        }

        private (MyPoint center, double radius) GetCenterRadius()
        {
            throw new NotImplementedException();
        }

        public override MyCurve CreateOffset(MyPoint vector, double distance)
        {
            var newStart = Start + vector * distance;
            var newEnd = End + vector * distance;

            var newCenter = Center + vector * distance;

            var newArc = new MyArc(newStart, newEnd, newCenter);

            return newArc;
        }
    }
}
