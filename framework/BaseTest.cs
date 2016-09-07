using NUnit.Framework;

namespace TestTask1.framework
{
    [TestFixture]
    public class BaseTest : BaseEntity
    {
        [SetUp]
        public void SetUp()
        {
            Browser = Browser.GetInstance();
            Browser.GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
           Browser.GetDriver().Quit();
           Browser.SetDriverToNull();
        }

        
        
    }
}
