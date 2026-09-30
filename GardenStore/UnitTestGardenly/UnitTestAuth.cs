using System;
using System.Collections.Generic;
using Librarygardenly;
using Librarygardenly.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestGardenly
{
    [TestClass]
    public class UnitTestAuth
    {
        [TestMethod]
        public void TestMethodPasswordTrue()
        {
            // Создаем имитацию репозитория
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            // Создаем тестового пользователя
            User testUser = new User(1, "Тестовый пользователь", "administrator", "administrator12345", "administrator");
            // Настраиваем имитацию БД
            mock.Setup(repo => repo.GetUsers())
                .Returns(new List<User> { testUser });
            // Создаем UserService с тестовыми данными
            UserService service = new UserService(mock.Object);
            // Выполняем авторизацию
            User result = service.AuthorizeUser(
                "administrator",
                "administrator12345"
            );
            // Проверяем, что пользователь найден
            Assert.IsNotNull(result);
            // Проверяем логин
            Assert.AreEqual("administrator", result.Login);
            // Проверяем пароль
            Assert.AreEqual("administrator12345", result.Password);
            // Проверяем роль
            Assert.AreEqual("administrator", result.Role);
        }
        [TestMethod]
        public void TestMethodPasswordFalse()
        {
            // Создаем имитацию репозитория
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            // Создаем тестового пользователя
            User testUser = new User(1, "Тестовый пользователь", "administrator", "administrator12345", "administrator");
            // Настраиваем имитацию БД
            mock.Setup(repo => repo.GetUsers())
                .Returns(new List<User> { testUser });
            // Создаем UserService с тестовыми данными
            UserService service = new UserService(mock.Object);
            // Передаем неправильный пароль
            User result = service.AuthorizeUser(
                "administrator",
                "administator12"
            );
            // Проверяем, что пользователь не найден
            Assert.IsNull(result);
        }
    }
}
