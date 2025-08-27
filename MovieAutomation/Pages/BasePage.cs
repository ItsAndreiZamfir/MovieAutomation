using MovieAutomation.HelperMethods;
using MovieAutomation.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.Pages
{
    public class BasePage
    {
        private IWebDriver _driver;
        protected ElementMethods _elementMethods;
        protected WebDriverWaitHelper _waitHelper;
        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
            _elementMethods = new ElementMethods(driver);
            _waitHelper = new WebDriverWaitHelper(driver);
        }

        public IWebDriver WebDriver
        {
            get { return _driver; }
            set { _driver = value; }
        }

        protected void WaitForPageToLoad(int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void WaitUntilDriverFindElement(By by, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => drv.FindElement(by).Displayed);
        }

        public bool IsAtPath(string pathEndsWith) =>
            _driver.Url.EndsWith(pathEndsWith, System.StringComparison.OrdinalIgnoreCase);
    }
}
