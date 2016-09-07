using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestTask1.framework;

namespace TestTask1.forms
{
    class MergePullRequestForm:BaseForm
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary js-details-target' and contains(.,'Merge')]")]
        private IWebElement _btnMergePullRequest;

        private string _locBranchIsMerged = "//div[@class='state state-merged' and contains(.,'Merged')]";
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary js-merge-commit-button' and contains(.,'Confirm  merge')]")]
        private IWebElement _btnConfirmMergePullRequest;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn float-right' and contains(.,'Delete')]")]
        private IWebElement _btnDeleteBranch;
        
        public MergePullRequestForm():base (By.XPath("//div[@class='tabnav tabnav-pr']"), "Pull request for merging Page")
        { PageFactory.InitElements(Browser.GetDriver(),this);}

        public void MergePullRequest()
        {
            ExtensionMetod.WaitForElementPresent(By.XPath("//button[@class='btn btn-primary js-details-target' and contains(.,'Merge')]"));
            _btnMergePullRequest.Click();
            ExtensionMetod.WaitForElementPresent(By.XPath("//button[@class='btn btn-primary js-merge-commit-button' and contains(.,'Confirm  merge')]"));
            _btnConfirmMergePullRequest.Click();
            ExtensionMetod.WaitForElementPresent(By.XPath("//button[@class='btn float-right' and contains(.,'Delete')]"));
            _btnDeleteBranch.Click();
            Log.Info("Pull request is merged");
        }

        public void VerifyBranchIsMerged()
        {
            ExtensionMetod.WaitForElementPresent(By.XPath("//div[@class='state state-merged' and contains(.,'Merged')]"));
            Assert.IsTrue(Browser.GetDriver().FindElements(By.XPath("//div[@class='state state-merged' and contains(.,'Merged')]")).Count>0);
            Log.Info("Branch is successfully merged");
        }
    }
}
