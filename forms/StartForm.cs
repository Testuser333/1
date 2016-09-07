using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestTask1.framework;

namespace TestTask1.forms
{
    class StartForm:BaseForm
    {
        [FindsBy(How = How.XPath,Using = "//a[@class='btn site-header-actions-btn mr-2']")]
        private IWebElement _btnOpenSignInPage;

        public StartForm() : base(By.XPath("//div[@class='homepage-hero-intro column']"), "Start GitHub Page")
        {
            PageFactory.InitElements(Browser.GetDriver(),this);
        }

        public void OpenSignInPage()
        {
            _btnOpenSignInPage.Click();
            Log.Info("Open page for signing in");
        }
    }
}
