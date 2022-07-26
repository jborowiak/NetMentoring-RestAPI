namespace CatalogServiceAPI.Models
{
    public class CategoryUpdateDto
    {
        public string Name { get; }

        public string Description { get; }

        public CategoryUpdateDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
