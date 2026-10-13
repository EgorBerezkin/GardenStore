using System;
using Librarygardenly.Categories;
using Librarygardenly.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGardenly
{
    [TestClass]
    public class UnitTestProducts
    {
        private ProductService productService;
        private CategoryService categoryService;

        // Тест на проверку добавления нового товара в бд
        [TestMethod]
        public void TestMethodAddProduct()
        {
            productService = new ProductService();
            categoryService = new CategoryService();

            // Получение списка категорий из бд
            var categories = categoryService.GetCategories();
            Assert.AreNotEqual(0, categories.Count);

            int categoryId = categories[0].Id; // первая категория из списка
            string productName = "Садовый светильник - Сова";
            Product product = new Product(0, productName, categoryId, categories[0].Name, 350, 5, "Декоративный светильник для сада");
            productService.AddProduct(product); // добавление товара в бд

            var products = productService.GetProducts(); // обновленный список товаров
            bool found = false;
            int productId = 0;

            // Поиск товара по названию, для убеждения что товар точно есть
            foreach (Product item in products)
            {
                if (item.Name == productName)
                {
                    found = true;
                    productId = item.Id;
                }
            }
            Assert.AreEqual(true, found, "Товар должен быть добавлен в базу данных.");
            productService.DeleteProduct(productId);
        }

        // Тест на проверку поиска товара по названию
        [TestMethod]
        public void TestSearchProduct()
        {
            productService = new ProductService();
            categoryService = new CategoryService();

            var categories = categoryService.GetCategories();
            Assert.AreNotEqual(0, categories.Count);

            string productName = "Семена подсолнечника - Солнечный";
            Product product = new Product(0, productName, categories[0].Id, categories[0].Name, 120, 10, "Семена для выращивания подсолнечника");
            productService.AddProduct(product); // добавление товара, для последующего поиска

            var products = productService.GetProducts();
            bool found = false;
            int productId = 0;

            // Поиск товара в полученном списке
            foreach (Product item in products)
            {
                if (item.Name == productName)
                {
                    found = true;
                    productId = item.Id;
                }
            }

            Assert.AreEqual(true, found, "Поиск должен находить товар по названию.");
            productService.DeleteProduct(productId);
        }

        // Тест на проверку отображения товара в выбранной категории
        [TestMethod]
        public void TestFilterProductsByCategory()
        {
            productService = new ProductService();
            categoryService = new CategoryService();

            var categories = categoryService.GetCategories();
            Assert.AreNotEqual(0, categories.Count);

            int categoryId = categories[0].Id;
            string productName = "Лопатка садовая, стальная";
            Product product = new Product(0, productName, categoryId, categories[0].Name, 250, 7, "Ручной инструмент для работы в саду");

            productService.AddProduct(product);

            var products = productService.GetProducts();
            bool found = false;
            int productId = 0;
            bool correctCategory = true;

            // Проверка категории каждого товара
            foreach (Product item in products)
            {
                if (item.CategoryId == categoryId)
                {
                    // проверка, есть ли нужный товар в категории
                    if (item.Name == productName)
                    {
                        found = true;
                        productId = item.Id;
                    }
                }
                else if (item.Name == productName)
                {
                    correctCategory = false;
                }
            }
            Assert.AreEqual(true, found, "Товар должен отображаться в выбранной категории.");
            Assert.AreEqual(true, correctCategory, "Товар должен относиться к выбранной категории.");
            productService.DeleteProduct(productId);
        }

        // Тест на проверку существования категории
        [TestMethod]
        public void TestCategoryExists()
        {
            categoryService = new CategoryService();

            var categories = categoryService.GetCategories();
            Assert.AreNotEqual(0, categories.Count);

            // Берём название существующей категории из бд
            string categoryName = categories[0].Name;
            // Поиск категории по обучному названию
            Assert.AreEqual(true, categoryService.CategoryExists(categoryName), "Существующая категория должна определяться.");
            // Поиск категории в нижнем регистре
            Assert.AreEqual(true, categoryService.CategoryExists(categoryName.ToLower()), "Проверка категории должна учитывать название без учёта регистра.");
        }

        // Тест на проверку написания корректной цены
        [TestMethod]
        public void TestNegativeProductPrice()
        {
            productService = new ProductService();
            categoryService = new CategoryService();

            var categories = categoryService.GetCategories();
            Assert.AreNotEqual(0, categories.Count);

            Product product = new Product(0, "Удобрение универсальное", categories[0].Id, categories[0].Name, -100, 5, "Удобрение для садовых растений");
            // Возникновение ошибки, так как цена не может быть отрицательной
            Assert.ThrowsException<ArgumentException>(() => productService.AddProduct(product), "Товар с отрицательной ценой не должен сохраняться.");
        }
    }
}
