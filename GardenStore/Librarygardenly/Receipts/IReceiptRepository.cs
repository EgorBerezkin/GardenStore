using System;
using System.Collections.Generic;

namespace Librarygardenly.Receipts
{
    public interface IReceiptRepository
    {
        List<Receipt> GetReceipts();
        void AddReceipt(Receipt receipt, List<ReceiptItem> items);
        List<ReceiptItem> GetReceiptItems(int receiptId);
        List<Receipt> GetReceiptsByFilters(DateTime? date, int? userId);
        int GetProductQuantity(int productId);
        void UpdateProductQuantity(int productId, int quantity);
    }
}
