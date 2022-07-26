namespace CatalogServiceAPI.Models
{
    public class ItemAdd
    {
        public string Name { get; }

        public int CategoryId { get; }

        public ItemAdd( string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
