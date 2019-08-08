using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion.Models;

namespace Promotion.Tests.Models
{
    [TestClass]
    public class ResponseDataTests
    {
        [TestMethod]
        public void ResponseData_Model_Success()
        {
            var id = new Faker("en").Lorem.Word();
            var responseData = new ResponseData
            {
                Id = id
            };

            Assert.AreEqual(id, responseData.Id);
        }

        [TestMethod]
        public void ResponseData_Model_Failure()
        {
            var responseData = new ResponseData();

            Assert.IsNotNull(responseData);
            Assert.IsNull(responseData.Id);
        }
    }
}
