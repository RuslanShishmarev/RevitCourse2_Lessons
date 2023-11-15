namespace Lesson1.Models
{
    internal class MyWall : IMy3DElement, IMyElement
    {
        public int Id { get; }

        public string Name { get; }

        public MyCurve LocationCurve { get; }

        public double Height { get; set; }

        public double Thickness => Materials.Sum(m => m.Thickness);

        public List<MyLayMaterial> Materials { get; }

        public MyWall(
            int id,
            string name,
            MyCurve locationCurve,
            double height,
            List<MyLayMaterial> materials)
        {
            Id = id;
            Name = name;
            LocationCurve = locationCurve;
            Height = height;
            Materials = materials;
        }

        public double GetArea()
        {
            var area1 = Height * LocationCurve.Length;
            var area2 = LocationCurve.Length * Thickness;
            var area3 = Height * Thickness;

            return (area1 + area2 + area3) * 2;
        }

        public double GetVolume()
        {
            return Height * Thickness * LocationCurve.Length;
        }
    }
}
