using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestTask1.framework;

namespace TestTask1.forms
{
    class SignInForm:BaseForm
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='login_field' and @type='text']")]
        private readonly IWebElement _txbUserName ;

        [FindsBy(How = How.XPath, Using = "//input[@id='password' and @type='password']")]
        private readonly IWebElement _txbPassword ;

        [FindsBy(How = How.XPath, Using = "//input[@class='btn btn-primary btn-block'and @type='submit']")]
        private readonly IWebElement _btnSubmit ;

        public SignInForm() : base(By.XPath("//h1[contains(text(),'Sign in to GitHub')]"), "Sign In Page")
        {
            PageFactory.InitElements(Browser.GetDriver(),this);
        }

        public void SingIn(string login, string password)
        {
            _txbUserName.SendKeys(login);
            _txbPassword.SendKeys(password);
            _btnSubmit.Click();
            Log.Info("Sing in with User name: "+login+" password: "+password);
        }
    }
}
