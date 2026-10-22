using Librarygardenly.Products;

namespace Librarygardenly.Receipts
{
    public class ReceiptItem
    {
        public int Id {  get; set; }
        public int ReceiptId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        // Информация о товаре, если его ещё нет в базе
        public Product NewProduct { get; set; }
        public string ProductName { get; set; }
    }
}
