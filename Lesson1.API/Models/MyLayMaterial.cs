namespace Lesson1.API.Models
{
    public class MyLayMaterial : IMyElement
    {
        public int Id { get; }

        public string Name { get; }

        public double Thickness { get; }

        public double GetVolume(double height)
        {
            return Thickness * height;
        }

        public MyLayMaterial(
            int id,
            string name,
            double thickness)
        {
            Id = id;
            Name = name;
            Thickness = thickness;
        }
    }
}
