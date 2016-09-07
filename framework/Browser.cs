using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestTask1.framework
{
    public class Browser: BaseEntity
    {
        
        private static IWebDriver _driver;
       
        public static Browser GetInstance()
        {
            GetDriver();
            return new Browser();
        }

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                }
            return _driver;
        }

        public void SetDriverToNull()
        {
            _driver = null;
        }
        public void GoToUrl(string _BaseUrl)
        {
           GetDriver().Navigate().GoToUrl(_BaseUrl);
        }

        public static void WaitForPageToLoad()
        {
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until<Boolean>(waiting =>
                {
                    try
                    {
                        var result = ((IJavaScriptExecutor)Browser.GetDriver()).ExecuteScript("return document['readyState'] ? 'complete' == document.readyState : true");
                        return result != null && result is Boolean && (Boolean)result;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch (Exception e)
            {

             }
        }

    }
    
}
