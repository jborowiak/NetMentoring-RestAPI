namespace CatalogServiceAPI.Models
{
    public class CategoryAdd
    {
        public string Name { get; }

        public string Description { get; }

        public CategoryAdd(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
