using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Models;
using MongoDB.Bson;

namespace Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private ObjectId ScopedUserId { get; set; }

        [TestMethod]
        public void CreateUser()
        {
            var ServiceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
            Assert.IsNotNull(ServiceManager);

            var model = new User {
                Name = "Test" + new Random().ToString(),
                Email = "Test" + new Random().ToString() + "@test.com",
                Password = "1234"
            };

            var response = ServiceManager.UserService.Create(model);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Id);

            UserServiceTestContext.Id = ObjectId.Parse(response.Id);
        }

        [TestMethod]
        public void FetchUser()
        {
            var ServiceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
            Assert.IsNotNull(ServiceManager);
            
            var response = ServiceManager.UserService.Find(UserServiceTestContext.Id);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Id);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var ServiceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
            Assert.IsNotNull(ServiceManager);

            var response = ServiceManager.UserService.Find(UserServiceTestContext.Id);
            Assert.IsNotNull(response);

            response.Name = "Updated user" + new Random().ToString();
            var updatedResponse = ServiceManager.UserService.Update(ObjectId.Parse(response.Id), response);

            Assert.IsNotNull(updatedResponse);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var ServiceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
            Assert.IsNotNull(ServiceManager);

            var response = ServiceManager.UserService.Delete(UserServiceTestContext.Id);
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response);
        }
    }

    public static class UserServiceTestContext
    {
        public static ObjectId Id { get; set; }
    }
}
