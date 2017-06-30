using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace Tests.Services
{
    [TestClass]
    public class ServicesTest
    {
        [TestMethod]
        public void MongoConnection()
        {
            var ServiceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
            Assert.IsNotNull(ServiceManager);

            var responses = ServiceManager.UserService.ListAll();
            Assert.IsNotNull(responses);
        }
    }
}
