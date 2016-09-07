using System;
using OpenQA.Selenium;
using TestTask1.framework.elements;

namespace TestTask1.framework
{
    public class BaseForm : BaseEntity
    {
        private readonly String _name;
        private readonly By _locator;
        protected BaseForm(By locator, String name)
        {
            _locator = locator;
            _name = name;
            AssertIsPresent();
        }

        protected void AssertIsPresent()
        {
            BaseElement.WaitForElementPresent(_locator);
            Log.Info(String.Format("Form '{0}' has appeared", _name));
        }

       }
}
