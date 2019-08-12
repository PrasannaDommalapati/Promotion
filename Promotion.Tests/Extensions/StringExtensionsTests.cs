using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Validate_Not_Empty_Success()
        {
            var word = new Faker().Lorem.Word();
            Assert.AreEqual(word, word.ValidateNotEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_Throws_Null()
        {
            (default(string)).ValidateNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]

        public void Validate_Throws_Whitespace()
        {
            const string whiteSpace = " ";
            whiteSpace.ValidateNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]

        public void Validate_Throws_Empty()
        {
            string.Empty.ValidateNotEmpty();
        }

        [TestMethod]
        public void Validate_Using_Parametername()
        {
            var faker = new Faker();
            var word = faker.Lorem.Word();
            var otherWord = faker.Lorem.Word();

            Assert.AreEqual(word, word.ValidateNotEmpty(otherWord));
        }

        [TestMethod]
        public void Validate_Throws_Parametername()
        {
            var word = new Faker().Lorem.Word();

            var exception = Assert.ThrowsException<ArgumentNullException>(() => string
                .Empty
                .ValidateNotEmpty(word));

            Assert.IsTrue(exception.Message.Contains(word));
        }
    }
}
