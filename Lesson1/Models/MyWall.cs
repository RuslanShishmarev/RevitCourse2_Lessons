namespace Lesson1.Models
{
    internal class MyWall : IMy3DElement
    {
        public int Id { get; }

        public string Name => WallType.Name;

        public MyCurve LocationCurve { get; }

        public double Height { get; set; }

        public double Length => LocationCurve.Length;

        public MyWallType WallType { get; }

        public double Thickness => WallType.Materials.Sum(m => m.Thickness);

        public MyWall(
            int id,
            MyCurve locationCurve,
            double height,
            MyWallType wallType)
        {
            Id = id;
            LocationCurve = locationCurve;
            Height = height;
            WallType = wallType;
        }

        public double GetArea()
        {
            var area1 = Height * Length;
            var area2 = Length * Thickness;
            var area3 = Height * Thickness;

            return (area1 + area2 + area3) * 2;
        }

        public double GetVolume()
        {
            return Height * Thickness * Length;
        }

        public override string ToString()
        {
            return $"{Name};\nВысота: {Height};\nТолщина: {Thickness};\nДлина: {Length};\nКол-во материалов: {WallType.Materials.Count}";
        }
    }
}
