using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion.Models;

namespace Promotion.Tests.Models
{
    [TestClass]
    public class PostDataTests
    {
        [TestMethod]
        public void PostData_Model_Success()
        {
            var post = new Post();
            var postData = new PostData
            {
                Data = post
            };

            Assert.IsNotNull(postData);
            Assert.AreEqual(post, postData.Data);
        }

        [TestMethod]
        public void PostData_Model_Failure()
        {
            var postData = new PostData();

            Assert.IsNotNull(postData);
            Assert.IsNull(postData.Data.Avatar);
        }
    }
}
