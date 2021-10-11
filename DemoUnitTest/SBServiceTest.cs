using DemoCode.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoUnitTest
{
    [TestClass]
    public class SBServiceTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void ValidateEmail()
        {
            //Assert.Inconclusive();
            SBService sb = new SBService();
            TestContext.WriteLine("Validating A Valid Email");
            bool result = sb.ValidateEmail("abc@xyz.lmn");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidatePhone()
        {
            SBService sb = new SBService();
            TestContext.WriteLine("Validating A Valid Phone");
            bool result = sb.ValidatePhone("8794561230");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InValidateEmail()
        {
            //Assert.Inconclusive();
            SBService sb = new SBService();
            TestContext.WriteLine("Identifying A InValid Email");
            bool result = sb.ValidateEmail("abc@");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void InValidatePhone()
        {
            SBService sb = new SBService();
            TestContext.WriteLine("Identifying A InValid Phone");
            bool result = sb.ValidatePhone("879456130");
            Assert.IsFalse(result);
        }
    }
}
