namespace Lesson1.API.Models
{
    public class MyWallType : IMyElement
    {
        public int Id { get; }

        public string Name { get; }

        public List<MyLayMaterial> Materials { get; }

        public MyWallType(
            int id,
            string name,
            List<MyLayMaterial> materials)
        {
            Id = id;
            Name = name;
            Materials = materials;
        }
    }
}
