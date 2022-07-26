namespace CatalogServiceAPI.Models
{
    public class CategoryUpdate
    {
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public CategoryUpdate(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
