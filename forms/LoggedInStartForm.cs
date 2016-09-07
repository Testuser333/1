using OpenQA.Selenium;
using TestTask1.framework;

namespace TestTask1.forms
{
    class LoggedInStartForm:BaseForm
    {

        private readonly string _locRepository="//span[@class='repo'and contains(.,{0})]";

        public LoggedInStartForm() : base(By.XPath("//div[@class='newsfeed-placeholder']"), "Logged In Start Page")
        {
        }

        public void OpenRepository(string repositoryname)
        {
            Browser.GetDriver().FindElement(By.XPath(string.Format(_locRepository, repositoryname))).Click();  // (By.XPath(string.Format(_locRepository, repositoryname)), string.Format("Repository {0}",repositoryname)).ClickAndWait();
            Log.Info("Open repository:"+repositoryname);
        }

       
    }
}
