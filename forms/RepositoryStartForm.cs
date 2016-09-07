using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestTask1.framework;

namespace TestTask1.forms
{
    class RepositoryStartForm:BaseForm
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-sm' and contains(.,'Create new file')]")]
        private readonly IWebElement _btnCreateFile;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-sm select-menu-button js-menu-target css-truncate']")]
        private  IWebElement _btnSelectBranch;

        [FindsBy(How = How.XPath, Using = "//form[contains(@class,'create-branch')]")]
        private  IWebElement _btnCreateBranch;

        [FindsBy(How = How.XPath, Using = "//input[@class='form-control js-filterable-field js-navigation-enable']")]
        private  IWebElement _txbBranchName;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-sm new-pull-request-btn']")]
        private IWebElement _btnNewPullRequest;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'reponav-item')][./span[text()='Issues']]")]
        private IWebElement _btnIssues;

        [FindsBy(How = How.XPath, Using = "//a[@class='js-selected-navigation-item reponav-item'][contains(.,'Pulse')]")]
        private IWebElement _btnPulse;

        private readonly string _locFile =
           "//table[@class='files js-navigation-container js-active-navigation-container']//tr[{0}]//a[@class='js-navigation-open']";

        [FindsBy(How = How.XPath, Using = "//table[@class='files js-navigation-container js-active-navigation-container']//tr")]
        private readonly IList<IWebElement> _lnkFiles ;

        public RepositoryStartForm() : base(By.XPath("//div[@class='btn-group float-right']"), "Repository Start Page")
        {
            PageFactory.InitElements(Browser.GetDriver(),this);
        }

        public void OpenCreateFilePage()
        {
            _btnCreateFile.Click();
            Log.Info("Open Create File page");
        }

        public void OpenPulsePage()
        {
            _btnPulse.Click();
            Log.Info("Open Pulse page");
        }

        public void OpenIssuesPage()
        {
            _btnIssues.Click();
            Log.Info("Open issues page ");
        }

        public void OpenPullRequestForm()
        {
            _btnNewPullRequest.Click();
            Log.Info("Open new pull request page");

        }

        public void CreateBranch(string branchName)
        {
            _btnSelectBranch.Click();
            _txbBranchName.SendKeys(branchName);
            ExtensionMetod.WaitForElementPresent(By.XPath("//form[contains(@class,'create-branch')]"));
           _btnCreateBranch.Click();
            Log.Info("Create branch :"+branchName);

        }

        public void VerifyFileIsCreated(string filename)
        {
            bool isFileCreated = false;
            for (int i = 2; i <= _lnkFiles.Count; i++)
                if (Browser.GetDriver().FindElement(By.XPath(string.Format(_locFile,i))).Text == filename)
                    isFileCreated = true;
            Assert.IsTrue(isFileCreated, "File is not created");
            Log.Info("File is successfully created");
        }
    }
}
