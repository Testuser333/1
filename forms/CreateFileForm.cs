using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestTask1.framework;

namespace TestTask1.forms
{
    class CreateFileForm:BaseForm
    {
        private readonly string _locLblExceptionMessage = "//div[@class='container' and contains(.,'already exists')]";
       
        // private readonly Label _lblExceptionMessage = new Label(By.XPath("//div[@class='container' and contains(.,'already exists')]"), "Exception Message");
         [FindsBy(How = How.XPath, Using = "//input[@name='filename']")]
        // private readonly TextBox _txbFileName = new TextBox(By.XPath("//input[@name='filename']"),"File name" );
        private readonly IWebElement _txbFileName;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary js-blob-submit']")]
        private readonly IWebElement _btnCommit;
       // private readonly Button _btnCommit = new Button(By.XPath("//button[@class='btn btn-primary js-blob-submit']"), "Commit new file Button");

        public CreateFileForm() : base(By.XPath("//div[@class='file-header']"), "Create file Page")
        {
            PageFactory.InitElements(Browser.GetDriver(),this);
        }

        public void CreateFile(string filename)
        {
            _txbFileName.SendKeys(filename);
            _btnCommit.Click();
            Log.Info("File with name: "+filename+" is created");
        }

        public void VerifyExceptionIsPresent()
        {
            Assert.IsTrue(Browser.GetDriver().FindElements(By.XPath(_locLblExceptionMessage)).Count>0);
            Log.Info("Exception message is present");
        }
    }
}
