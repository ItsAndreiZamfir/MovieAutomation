using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.Helpers
{
    public class WebDriverWaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly int _defaultTimeoutSeconds;

        public WebDriverWaitHelper(IWebDriver driver, int defaultTimeoutSeconds = 10)
        {
            _driver = driver;
            _defaultTimeoutSeconds = defaultTimeoutSeconds;
        }

        public IWebElement WaitForElement(By by, int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds ?? _defaultTimeoutSeconds));
            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public IWebElement WaitForElement(IWebElement webElement, int? timeoutSeconds=null)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds ?? _defaultTimeoutSeconds));
            return wait.Until(drv =>
            {
                try
                {
                    // Attempt to access a property to ensure the element is still valid
                    var displayed = webElement.Displayed;
                    return webElement;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        public List<IWebElement> WaitForElements(By by, int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds ?? _defaultTimeoutSeconds));
            return wait.Until(drv =>
            {
                var elements = drv.FindElements(by);
                return elements.Count > 0 ? elements.ToList() : null;
            });
        }

        public IWebElement WaitForChildElement(IWebElement parentElement, By by, int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds ?? _defaultTimeoutSeconds));
            return wait.Until(drv =>
            {
                try
                {
                    var childElement = parentElement.FindElement(by);
                    return childElement.Displayed ? childElement : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }
    }
}
