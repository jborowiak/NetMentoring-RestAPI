namespace CatalogServiceAPI.Models
{
    public class ItemUpdate
    {
        public int Id { get; }

        public string Name { get; }

        public int CategoryId { get; }

        public ItemUpdate(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }
    }
}
