using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestTask1.framework;

namespace TestTask1.forms
{
    class PulseForm:BaseForm
    {
        [FindsBy(How = How.XPath, Using = "//a[@class='bar-section bar-section-negative']")]
        private IWebElement _lblClosedIssuesPercent;

        [FindsBy(How = How.XPath, Using = "//div[@id='issues']//li[1]//a")]
        private IWebElement _lnkIssueForReopening;

        public PulseForm() : base(By.XPath("//div[@class='pulse-sections']"), "Pulse Page")
        {
            PageFactory.InitElements(Browser.GetDriver(),this);
        }

        public void VerifyAllIssuesIsClosed()
        {
            
            Assert.IsTrue(_lblClosedIssuesPercent.GetAttribute("style") == "width: 100%;", 
            $"Closed issues is: {_lblClosedIssuesPercent.GetAttribute("style")} ");
            Log.Info("All issues is closed");
        }

        public void ReopenIssue()
        {
            _lnkIssueForReopening.Click();
        }
    }
}
