using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace Promotion.Tests.Extensions
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void ValidateNotNull_Throws_Null()
        {
            XElement testElement = null;

            var exception = Assert.ThrowsException<ArgumentNullException>(() => testElement.ValidateForNotNull(nameof(testElement)));

            Assert.IsNotNull(exception);

            Assert.IsTrue(exception.Message.Contains(nameof(testElement)));
        }

        [TestMethod]
        public void ValidateNotNull_Throws_Defaults_To_Type_Name()
        {
            XElement testElement = null;

            var exception = Assert.ThrowsException<ArgumentNullException>(() => testElement.ValidateForNotNull());

            Assert.IsNotNull(exception);

            Assert.IsTrue(exception.Message.Contains(typeof(XElement).Name));
        }

        [TestMethod]
        public void ValidateNotNull_Success()
        {
            var value = new object();
            Assert.AreEqual(value, value.ValidateForNotNull());
        }
    }
}
