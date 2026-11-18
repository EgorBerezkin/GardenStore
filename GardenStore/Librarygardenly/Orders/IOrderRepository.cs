using System;
using System.Collections.Generic;

namespace Librarygardenly.Orders
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();

        void AddOrder(Order order, List<OrderItem> items);

        List<OrderItem> GetOrderItems(int orderId);

        List<Order> GetOrdersByFilters(DateTime? date, int? userId);
    }
}