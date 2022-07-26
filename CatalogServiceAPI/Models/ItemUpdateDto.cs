namespace CatalogServiceAPI.Models
{
    public class ItemUpdateDto
    {
        public string Name { get; }

        public int CategoryId { get; }

        public ItemUpdateDto(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
