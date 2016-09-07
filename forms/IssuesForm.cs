using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestTask1.framework;

namespace TestTask1.forms
{
    class IssuesForm:BaseForm
    {
        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-primary float-right' and contains(.,'New issue')]")]
        private IWebElement _btnCreateNewIssue;

        [FindsBy(How = How.XPath, Using = "//input[@id='issue_title']")]
        private IWebElement _txbIssueName;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary' and contains(.,'Submit new issue')]")]
        private IWebElement _btnSubmitIssue;

        [FindsBy(How = How.XPath, Using = "//span[@class=' js-issue-title']")]
        private IWebElement _lblIsueName;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn js-comment-and-button' and contains(.,'Close')]")]
        private IWebElement _btnCloseIssue;

        [FindsBy(How = How.XPath, Using = "//button[@class='discussion-sidebar-heading discussion-sidebar-toggle js-menu-target' and contains(.,'Labels')]")]
        private IWebElement _btnLabels;

        private readonly string  _locIssueLabel= "//div[@data-name='{0}']";

        [FindsBy(How = How.XPath, Using = "//button[@class='btn js-comment-and-button' and contains(.,'Reopen')]")]
        private IWebElement _btnReopenIssue;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'select-menu-modal-holder')][.//span[contains(.,'Apply')]]/div/div[1]//*[local-name() = 'svg']")]
        private IWebElement _btnCloseLabelMenu;
        

       private readonly string  _locReopenedIssueLabel= "//span[@class='labels']/a[contains(.,'{0}')]";

        public IssuesForm() : base(By.XPath("//div[@class='issues-listing']"), "Issues Page")
        {
            PageFactory.InitElements(Browser.GetDriver(),this);
        }

        public void CreateNewIssue(string issueName)
        {
            _btnCreateNewIssue.Click();
            ExtensionMetod.WaitForElementPresent(By.XPath("//input[@id='issue_title']"));
            _txbIssueName.SendKeys(issueName);
            _btnSubmitIssue.Click();
            Log.Info("Create new issue with name: "+issueName);
        }

        public void ReopenIssue(string issueLabel)
        {
            _btnLabels.Click();
            ExtensionMetod.WaitForElementPresent(By.XPath(string.Format(_locIssueLabel,issueLabel)));
            Browser.GetDriver().FindElement(By.XPath(string.Format(_locIssueLabel, issueLabel))).Click();
            _btnCloseLabelMenu.Click();
            ExtensionMetod.WaitForElementClickable(By.XPath("//button[@class='btn js-comment-and-button' and contains(.,'Reopen')]"));
            _btnReopenIssue.Click();
            Log.Info("Issue with label: "+issueLabel+" is opened");
        }

        public void VerifyIssueIsReopened(string issueLabel)
        {
            ExtensionMetod.WaitForElementPresent(By.XPath(string.Format(_locReopenedIssueLabel, issueLabel)));
            Assert.IsTrue(Browser.GetDriver().FindElements(By.XPath(string.Format(_locReopenedIssueLabel, issueLabel))).Count>0);
            Log.Info("Issue with label: " + issueLabel + " is reopened and appeared in Issues folder");
        }

        public void VerifyIssueIsCreated(string issueName)
        {
            Assert.IsTrue(_lblIsueName.Text == issueName);
            Log.Info("Issue with name: "+issueName+" is created");
        }

        public void CloseIssue()
        {
            _btnCloseIssue.Click();
            Log.Info("Close Issue");
        }
    }
}
