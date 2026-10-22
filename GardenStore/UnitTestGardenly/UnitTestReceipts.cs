using System;
using System.Collections.Generic;
using Librarygardenly.Receipts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestGardenly
{
    [TestClass]
    public class UnitTestReceipts
    {
        // Тест 1. Получение списка поступлений
        [TestMethod]
        public void TestGetReceipts()
        {
            Mock<IReceiptRepository> mock = new Mock<IReceiptRepository>();

            mock.Setup(r => r.GetReceipts())
                .Returns(new List<Receipt>
                {
                    new Receipt
                    {
                        Id = 1,
                        UserId = 1,
                        UserFullName = "Баранов Александр Сергеевич",
                        ItemsCount = 5,
                        TotalAmount = 1500
                    }
                });

            ReceiptService service = new ReceiptService(mock.Object);
            List<Receipt> result = service.GetReceipts();

            Assert.AreEqual(1, result.Count);

            mock.Verify(r => r.GetReceipts(), Times.Once);
        }

        // Тест 2. Сохранение нового поступления
        [TestMethod]
        public void TestAddReceipt()
        {
            Mock<IReceiptRepository> mock = new Mock<IReceiptRepository>();
            
            ReceiptService service = new ReceiptService(mock.Object);
            Receipt receipt = new Receipt{ UserId = 1 };

            List<ReceiptItem> items = new List<ReceiptItem>
            {
                new ReceiptItem
                {
                    ProductId = 1,
                    Quantity = 5,
                    Price = 300
                }
            };

            service.AddReceipt(receipt, items);
            mock.Verify(r => r.AddReceipt(receipt, items), Times.Once);
        }

        // Тест 3. Получение позиций поступления
        [TestMethod]
        public void TestGetReceiptItems()
        {
            Mock<IReceiptRepository> mock = new Mock<IReceiptRepository>();

            mock.Setup(r => r.GetReceiptItems(1))
                .Returns(new List<ReceiptItem>
                {
                    new ReceiptItem
                    {
                        Id = 1,
                        ReceiptId = 1,
                        ProductId = 2,
                        ProductName = "Мини-лопатка",
                        Quantity = 5,
                        Price = 300
                    }
                });

            ReceiptService service = new ReceiptService(mock.Object);
            List<ReceiptItem> result = service.GetReceiptItems(1);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(5, result[0].Quantity);
            Assert.AreEqual(300, result[0].Price);

            mock.Verify(r => r.GetReceiptItems(1), Times.Once);
        }

        // Тест 4. Проверка корректности введённых данных
        [TestMethod]
        public void TestValidateReceiptData()
        {
            Mock<IReceiptRepository> mock = new Mock<IReceiptRepository>();
            ReceiptService service = new ReceiptService(mock.Object);

            Receipt receipt = new Receipt { UserId = 1 };

            int[] quantities = { 0, -5, 5 };
            double[] prices = { 100, 100, -100 };

            for (int i = 0; i < quantities.Length; i++)
            {
                List<ReceiptItem> items = new List<ReceiptItem>
                {
                    new ReceiptItem
                    {
                        ProductId = 1,
                        Quantity = quantities[i],
                        Price = prices[i]
                    }
                };
                Assert.ThrowsException<ArgumentException>(() => service.AddReceipt(receipt, items));
            }
            mock.Verify(r => r.AddReceipt(receipt, new List<ReceiptItem>()), Times.Never);
        }

        // Тест 5. Проверка увеличения количества товара
        [TestMethod]
        public void TestUpdateProductQuantity()
        {
            Mock<IReceiptRepository> mock = new Mock<IReceiptRepository>();

            ReceiptService service = new ReceiptService(mock.Object);
            Receipt receipt = new Receipt { UserId = 1 };

            List<ReceiptItem> items = new List<ReceiptItem>
            {
                new ReceiptItem
                {
                    ProductId = 1,
                    Quantity = 5,
                    Price = 300
                }
            };

            service.AddReceipt(receipt, items);
            mock.Verify(r => r.AddReceipt(receipt, items), Times.Once);
        }
    }
}
