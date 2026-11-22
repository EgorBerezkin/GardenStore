using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarygardenly.Restock
{
    public class RestockRequestItem
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double TotalPrice
        {
            get { return Quantity * Price; }
        }
    }
}
