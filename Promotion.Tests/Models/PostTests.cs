using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion.Models;

namespace Promotion.Tests.Models
{
    [TestClass]
    public class PostTests
    {
        private Faker Faker;

        [TestInitialize]
        public void Init()
        {
            Faker = new Faker("en_GB");
        }

        [TestMethod]
        public void Post_Model_Success()
        {
            var id = Faker.Random.Number(0,20);
            var avatar = Faker.Internet.Avatar();
            var email = Faker.Internet.Email();
            var firstName = Faker.Name.FirstName();
            var lastName = Faker.Name.LastName();

            var post = new Post
            {
                Id = id,
                Avatar =avatar,
                Email = email,
                First_Name =firstName,
                Last_Name = lastName
            };

            Assert.AreEqual(id, post.Id);
            Assert.AreEqual(avatar, post.Avatar);
            Assert.AreEqual(email, post.Email);
            Assert.AreEqual(firstName, post.First_Name);
            Assert.AreEqual(lastName, post.Last_Name);
        }

        [TestMethod]
        public void Post_Model_Failure()
        {
            var expected = Faker.Name.FullName();
            var id = Faker.Random.Number(5);

            var post = new Post();

            Assert.IsNotNull(post);
            Assert.AreNotEqual(id, post.Id);
            Assert.AreNotEqual(expected, post.Avatar);
            Assert.AreNotEqual(expected, post.Email);
            Assert.AreNotEqual(expected, post.First_Name);
            Assert.AreNotEqual(expected, post.Last_Name);
        }

        [TestMethod]
        public void Post_Model_Should_Not_Throws_Long_Email()
        {
            var email = Faker.Random.String(200);

            var post = new Post
            {
                Email = email
            };
            Assert.AreEqual(email, post.Email);
        }
    }
}
