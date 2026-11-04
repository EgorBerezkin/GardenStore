using System;

namespace Librarygardenly.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string UserFullName { get; set; }
    }
}
