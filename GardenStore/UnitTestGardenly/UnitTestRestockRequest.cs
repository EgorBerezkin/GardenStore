using System;
using System.Collections.Generic;
using Librarygardenly.Orders;
using Librarygardenly.Receipts;
using Librarygardenly.Restock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestGardenly
{
    [TestClass]
    public class UnitTestRestockRequest
    {
        // Тест 1. Получение списка заявок
        [TestMethod]
        public void TestGetRequests()
        {
            Mock<IRestockRequestRepository> mock = new Mock<IRestockRequestRepository>();

            mock.Setup(r => r.GetRequests())
                .Returns(new List<RestockRequest>
                {
                    new RestockRequest
                    {
                        Id = 1,
                        UserId = 1,
                        UserFullName = "Берёзкин Егор Витальевич",
                        Status = "Ожидает рассмотрения"
                    }
                });

            RestockRequestService service = new RestockRequestService(mock.Object);
            List<RestockRequest> result = service.GetRequests();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual("Ожидает рассмотрения", result[0].Status);

            mock.Verify(r => r.GetRequests(), Times.Once);
        }

        // Тест 2. Получение заявок определённого сотрудника
        [TestMethod]
        public void TestGetRequestsByUser()
        {
            Mock<IRestockRequestRepository> mock = new Mock<IRestockRequestRepository>();

            mock.Setup(r => r.GetRequestsByUser(2))
                .Returns(new List<RestockRequest>
                {
                    new RestockRequest
                    {
                        Id = 1,
                        UserId = 2,
                        UserFullName = "Иванова Анна Сергеевна",
                        Status = "Ожидает рассмотрения"
                    },
                    new RestockRequest
                    {
                        Id = 2,
                        UserId = 2,
                        UserFullName = "Иванова Анна Сергеевна",
                        Status = "Одобрена"
                    }
                });

            RestockRequestService service = new RestockRequestService(mock.Object);
            List<RestockRequest> result = service.GetRequestsByUser(2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            foreach (RestockRequest request in result)
            {
                Assert.AreEqual(2, request.UserId);
            }
            mock.Verify(r => r.GetRequestsByUser(2), Times.Once);
        }

        // Тест 3. Сохранение новой заявки с несколькими товарами
        [TestMethod]
        public void TestAddRequest()
        {
            Mock<IRestockRequestRepository> mock = new Mock<IRestockRequestRepository>();

            RestockRequestService service = new RestockRequestService(mock.Object);
            RestockRequest request = new RestockRequest
            {
                UserId = 1,
                Status = "Ожидает рассмотрения"
            };

            List<RestockRequestItem> items =
                new List<RestockRequestItem>
                {
                    new RestockRequestItem
                    {
                        ProductId = 1,
                        ProductName = "Мини-лопатка",
                        Quantity = 5
                    },
                    new RestockRequestItem
                    {
                        ProductId = 2,
                        ProductName = "Семена томатов",
                        Quantity = 10
                    }
                };
            service.AddRequest(request, items);
            mock.Verify(r => r.AddRequest(request, items), Times.Once);
        }

        // Тест 4. Проверка некорректного количества товара
        [TestMethod]
        public void TestValidateRequestQuantity()
        {
            Mock<IRestockRequestRepository> mock = new Mock<IRestockRequestRepository>();

            RestockRequestService service = new RestockRequestService(mock.Object);
            RestockRequest request = new RestockRequest
            {
                UserId = 1
            };

            int[] quantities = { 0, -5 };

            foreach (int quantity in quantities)
            {
                List<RestockRequestItem> items =
                    new List<RestockRequestItem>
                    {
                        new RestockRequestItem
                        {
                            ProductId = 1,
                            Quantity = quantity
                        }
                    };
                Assert.ThrowsException<ArgumentException>(() => service.AddRequest(request, items));
            }

            mock.Verify(r => r.AddRequest(request, new List<RestockRequestItem>
            {
                new RestockRequestItem
                {
                    ProductId = 1,
                    Quantity = 0
                }
            }), Times.Never);
        }
        // Тест 5. Проверка изменения статуса заявки
        [TestMethod]
        public void TestUpdateRequestStatus()
        {
            Mock<IRestockRequestRepository> mock = new Mock<IRestockRequestRepository>();

            RestockRequestService service = new RestockRequestService(mock.Object);

            int requestId = 1;
            string status = "Одобрена";

            service.UpdateRequestStatus(requestId, status);
            mock.Verify(r => r.UpdateRequestStatus(requestId, status), Times.Once);
        }

        // Тест 6. Получение товарных позиций заявки
        [TestMethod]
        public void TestGetRequestItems()
        {
            Mock<IRestockRequestRepository> mock = new Mock<IRestockRequestRepository>();

            mock.Setup(r => r.GetRequestItems(1))
                .Returns(new List<RestockRequestItem>
                {
                    new RestockRequestItem
                    {
                        Id = 1,
                        RequestId = 1,
                        ProductId = 2,
                        ProductName = "Мини-лопатка",
                        Quantity = 5
                    },
                    new RestockRequestItem
                    {
                        Id = 2,
                        RequestId = 1,
                        ProductId = 3,
                        ProductName = "Семена томатов",
                        Quantity = 10
                    }
                });

            RestockRequestService service = new RestockRequestService(mock.Object);
            List<RestockRequestItem> result = service.GetRequestItems(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result[0].ProductId);
            Assert.AreEqual(5, result[0].Quantity);
            Assert.AreEqual(3, result[1].ProductId);
            Assert.AreEqual(10, result[1].Quantity);

            mock.Verify(r => r.GetRequestItems(1), Times.Once);
        }
    }
}
