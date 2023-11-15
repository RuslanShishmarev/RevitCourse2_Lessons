namespace Lesson1.Models
{
    internal class MyFloor : IMy3DElement
    {
        public int Id { get; }

        public string Name { get; }

        public List<MyCurve> Contour { get; }

        public double Thickness => Materials.Sum(m => m.Thickness);

        public List<MyLayMaterial> Materials { get; }

        public MyFloor(
            int id,
            string name,
            List<MyCurve> contour,
            List<MyLayMaterial> materials)
        {
            Id = id;
            Name = name;
            Contour = contour;
            Materials = materials;
        }

        public double GetArea()
        {
            var sideArea = Contour.Sum(c => c.Length * Thickness);
            return sideArea + GetContourArea() * 2;
        }

        public double GetVolume()
        {
            return GetContourArea() * Thickness;
        }

        public double GetContourArea()
        {
            throw new NotImplementedException();
        }
    }
}
