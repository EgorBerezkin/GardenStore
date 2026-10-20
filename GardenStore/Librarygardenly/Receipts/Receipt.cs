using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarygardenly.Receipts
{
    public class Receipt
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ReceiptDate { get; set; }

       // добавить список товаров
    }
}
