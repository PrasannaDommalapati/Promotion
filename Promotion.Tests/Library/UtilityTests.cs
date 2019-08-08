using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion.Library;
using Promotion.Models;
using System;
using System.Threading.Tasks;
using Errors = Promotion.Dictionary;

namespace Promotion.Tests.Library
{
    [TestClass]
    public class UtilityTests
    {
        private Faker Faker;

        [TestInitialize]
        public void Init()
        {
            Faker = new Faker("en");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Serialize_Null_Data()
        {
            Utility.Serialize<TestModel>(null);
        }

        [TestMethod]
        public void Serialize_Success()
        {
            var result = Utility.Serialize(new TestModel("test"));

            Assert.AreEqual("{\"name\":\"test\"}", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Deserialize_Null_Data()
        {
            Utility.Deserialize<TestModel>(null);
        }

        [TestMethod]
        public void Deserialize_Invalid_Data()
        {
            var data = Faker.Lorem.Word();
            var exception = Assert.ThrowsException<PromotionException>(() => Utility.Deserialize<TestModel>(data));
            var expectedMessage = string.Format(Errors.DeserializationError, data,typeof(TestModel));

            Assert.AreEqual(expectedMessage, exception.Message);
            Assert.AreEqual(typeof(Newtonsoft.Json.JsonReaderException), exception.InnerException.GetType());
        }

        [TestMethod]
        public void DeSerialize_Success()
        {
            var result = Utility.Deserialize<TestModel>("{\"name\":\"test\"}");

            Assert.AreEqual(new TestModel("test").Name, result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeBase64_Null_Data()
        {
            Utility.DecodeBase64(null);
        }

        [TestMethod]
        public void DecodeBase64_Success()
        {
            var result = Utility.DecodeBase64("dGVzdA==");

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeBase64_Null_Data()
        {
            Utility.EncodeBase64(null);
        }

        [TestMethod]
        public void EncodeBase64_Success()
        {
            var result = Utility.EncodeBase64("test");

            Assert.AreEqual("dGVzdA==", result);
        }

        [TestMethod]
        public async Task WaitUntilAsync_Success()
        {
            var result = await Utility.WaitUntilAsync(() =>Task.FromResult(true)).ConfigureAwait(false);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task WaitUntilAsync_Success_timeout()
        {
            var currentTime = DateTime.Now;

            var result = await Utility.WaitUntilAsync(() => Task.FromResult(false), 1).ConfigureAwait(false);

            Assert.AreEqual(false, result);
            Assert.IsTrue(DateTime.Now >= currentTime.AddSeconds(1));
        }
    }
}