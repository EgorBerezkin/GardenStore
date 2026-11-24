using System;

namespace Librarygardenly.Restock
{
    public class RestockRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public string UserFullName { get; set; }
        public string Status { get; set; }
        public int CountItems { get; set; }
    }
}
