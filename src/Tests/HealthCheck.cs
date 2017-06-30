using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;

namespace Tests
{
    [TestClass]
    public class HealthCheck
    {
        [TestMethod]
        public void HeartBeat()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ConfigRead()
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

            Assert.IsNotNull(config);

            var dbAddress = config["Mongo:Host"];
            Assert.IsNotNull(dbAddress);

            var dbName = config["Mongo:DbName"];
            Assert.IsNotNull(dbName);

            AppConfiguration.DatabaseName = dbName;
            AppConfiguration.DatabaseAddress = dbAddress;
        }
    }
}
