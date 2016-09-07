using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestTask1.framework
{
    public static class ExtensionMetod
    {
      public static void WaitForElementPresent(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public static void WaitForElementClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
