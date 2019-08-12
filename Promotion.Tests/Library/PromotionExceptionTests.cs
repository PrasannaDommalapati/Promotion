using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion.Library;
using System;

namespace Promotion.Tests.Library
{
    [TestClass]
    public class PromotionExceptionTests
    {
        [TestMethod]
        public void Ctor()
        {
            var exception = new PromotionException();

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void Ctor_Message()
        {
            var exception = new PromotionException("message");

            Assert.AreEqual("message", exception.Message);
        }

        [TestMethod]
        public void Ctor_Message_InnerException()
        {
            const string message = "message";
            var innerException = new Exception();
            var result = new PromotionException(message, innerException);

            Assert.AreEqual(message, result.Message);
            Assert.AreEqual(innerException, result.InnerException);
        }
    }
}