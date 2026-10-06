namespace Librarygardenly.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Product(int id, string name, int categoryId, string categoryName, double price, int quantity, string description)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            CategoryName = categoryName;
            Price = price;
            Quantity = quantity;
            Description = description;
        }
    }
}
