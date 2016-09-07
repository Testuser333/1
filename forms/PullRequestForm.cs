using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestTask1.framework;

namespace TestTask1.forms
{
    class PullRequestForm:BaseForm
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        private IWebElement _btnCreatePullRequest;
        
        public PullRequestForm():base(By.XPath("//h1[@class='gh-header-title' and contains(.,'Open a pull request')]"),"Pull Request Page" )
        {
            PageFactory.InitElements(Browser.GetDriver(), this);
        }

        public void CreatePullRequest()
        {
            WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//button[@class='btn btn-primary']")));
            _btnCreatePullRequest.Click();
            Log.Info("Create pull request");
        }
    }
}
