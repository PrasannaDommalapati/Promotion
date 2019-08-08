using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Promotion.Tests.Models
{
    [TestClass]
    public class RequestDataTests
    {
        private Faker Faker;

        [TestInitialize]
        public void Init()
        {
            Faker = new Faker("en");
        }

        [TestMethod]
        public void RequestData_Model_Success()
        {
            var businessApplication = Faker.Company.CompanyName();
            var businessUnit =  Faker.Company.CompanyName();
            var data = Faker.Lorem.Sentence();
            var metadata = new Dictionary<string, string>();
            var requesterId = Faker.Lorem.Slug();
            var template = Faker.Lorem.Word();

            var requestData = new RequestData
            {
                BusinessApplication = businessApplication,
                BusinessUnit = businessUnit,
                Data = data,
                Metadata = metadata,
                RequesterId = requesterId,
                Templates = new string[] { template }
            };

            Assert.AreEqual(businessApplication, requestData.BusinessApplication);
            Assert.AreEqual(businessUnit, requestData.BusinessUnit);
            Assert.AreEqual(data, requestData.Data);
            Assert.AreEqual(metadata, requestData.Metadata);
            Assert.AreEqual(requesterId, requestData.RequesterId);
            Assert.IsTrue(requestData.Templates.Contains(template));
        }

        [TestMethod]
        public void RequestData_Model_Failure()
        {
            var requestData = new RequestData();

            Assert.IsNotNull(requestData);
            Assert.IsNull(requestData.RequesterId);
        }
    }
}
