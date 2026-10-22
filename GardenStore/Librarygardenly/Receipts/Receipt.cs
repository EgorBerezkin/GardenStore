using System;

namespace Librarygardenly.Receipts
{
    public class Receipt
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string UserFullName { get; set; }

        public int ItemsCount { get; set; }
        public double TotalAmount { get; set; }
    }
}
