using System;
using System.Collections.Generic;
using Librarygardenly.Orders;
using Librarygardenly.Receipts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestGardenly
{
    [TestClass]
    public class UnitTestOrders
    {
        // Тест 1. Получение списка продаж
        [TestMethod]
        public void TestGetOrders()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            mock.Setup(r => r.GetOrders())
                .Returns(new List<Order>
                {
                    new Order
                    {
                        Id = 1,
                        UserId = 1,
                        UserFullName = "Берёзкин Егор Витальевич",
                        TotalAmount = 1500
                    }
                });
            OrderService service = new OrderService(mock.Object);
            List<Order> result = service.GetOrders();

            Assert.IsNotNull(result);                     // результат не пустой
            Assert.AreEqual(1, result.Count);             // в списке отображается одна продажа
            Assert.AreEqual(1500, result[0].TotalAmount); // проверка что сумма отображается верно

            mock.Verify(r => r.GetOrders(), Times.Once);  // проверка что метод вызван только один раз
        }

        // Тест 2. Сохранение новой продажи
        [TestMethod]
        public void TestAddOrder()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            OrderService service = new OrderService(mock.Object);

            Order order = new Order
            {
                UserId = 1
            };

            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem
                {
                    ProductId = 1,
                    Quantity = 2,
                    Price = 300
                },
                new OrderItem
                {
                    ProductId = 2,
                    Quantity = 3,
                    Price = 200
                }
            };
            service.AddOrder(order, items); // вызов метода регистрации продажи
            mock.Verify(r => r.AddOrder(order, items), Times.Once);
        }

        // Тест 3. Получение позиций продажи
        [TestMethod]
        public void TestGetOrderItems()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            mock.Setup(r => r.GetOrderItems(1))
                .Returns(new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 1,
                        OrderId = 1,
                        ProductId = 2,
                        ProductName = "Мини-лопатка",
                        Quantity = 5,
                        Price = 300
                    }
                });

            OrderService service = new OrderService(mock.Object); // создание сервиса
            List<OrderItem> result = service.GetOrderItems(1);    // запрос на товары первой продажи

            Assert.AreEqual(1, result.Count);                 // проверка на получение одной товарной позиции
            Assert.AreEqual(5, result[0].Quantity);           // количество товаров равно 5
            Assert.AreEqual(300, result[0].Price);            // цена товара за одну штуку равняется 300 руб.
            mock.Verify(r => r.GetOrderItems(1), Times.Once);
        }

        // Тест 4. Проверка некорректного количества
        [TestMethod]
        public void TestValidateOrderQuantity()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            OrderService service = new OrderService(mock.Object);

            Order order = new Order
            {
                UserId = 1
            };

            int[] quantities = { 0, -5 };  // создание массива с двумя некорректными значениями

            foreach (int quantity in quantities) // перебор значений
            {
                List<OrderItem> items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = 1,
                        Quantity = quantity,
                        Price = 100
                    }
                };
                Assert.ThrowsException<ArgumentException>(() => service.AddOrder(order, items)); // проверка что при попытке регистрации возникает исключение
            }
            mock.Verify(r => r.AddOrder(order, new List<OrderItem>()), Times.Never);
        }

        // Тест 5. Проверка недостаточного остатка
        [TestMethod]
        public void TestInsufficientProductQuantity()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            OrderService service = new OrderService(mock.Object);

            Order order = new Order
            {
                UserId = 1
            };
            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem
                {
                    ProductId = 1,
                    Quantity = 10,
                    Price = 300
                }
            };
            service.AddOrder(order, items);  // вызов регистрации продажи
            mock.Verify(r => r.AddOrder(order, items), Times.Once);
        }

        // Тест 6. Проверка расчёта общей суммы продажи
        [TestMethod]
        public void TestCalculateOrderTotal()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            Order order = new Order
            {
                Id = 1,
                UserId = 1,
                TotalAmount = 1200
            };

            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem
                {
                    ProductId = 1,
                    Quantity = 2,
                    Price = 300
                },
                new OrderItem
                {
                    ProductId = 2,
                    Quantity = 3,
                    Price = 200
                }
            };

            mock.Setup(r => r.GetOrders()).Returns(new List<Order> { order }); // настройка объекта при вызове метода
            OrderService service = new OrderService(mock.Object);              
            List<Order> result = service.GetOrders();                          // получение списка продаж
            double expectedTotal = 2 * 300 + 3 * 200;                          // рассчет ожидаемой суммы
            Assert.AreEqual(expectedTotal, result[0].TotalAmount);             // сравнение ожидаемоц суммы с суммой в полученной продаже
            mock.Verify(r => r.GetOrders(), Times.Once);
        }
    }
}
