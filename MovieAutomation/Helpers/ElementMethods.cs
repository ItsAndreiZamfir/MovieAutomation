using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.HelperMethods
{
    public class ElementMethods
    {
        IWebDriver driver;
        WebDriverWait wait;

        public ElementMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitElementToBeVisible(IWebElement webElement)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_ =>
            {
                try
                {
                    return webElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitElementToBeClickable(IWebElement webElement)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_ =>
            {
                try
                {
                    return webElement.Enabled && webElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }


        public void ClickElement(IWebElement webElement)
        {
            WaitElementToBeVisible(webElement);
            ScrollToElement(webElement);
            WaitElementToBeClickable(webElement);
            webElement.Click();
        }

        public void FillElement(IWebElement webElement, string keyToSend)
        {
            WaitElementToBeVisible(webElement);
            ScrollToElement(webElement);
            webElement.Clear();
            webElement.SendKeys(keyToSend);
        }

        public void SelectDropdownByText(IWebElement webElement, string textToSelect)
        {
            WaitElementToBeVisible(webElement);
            ScrollToElement(webElement);
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(textToSelect);
        }

        public void SelectDropdownByValue(IWebElement webElement, string valueToSelect)
        {
            WaitElementToBeVisible(webElement);
            ScrollToElement(webElement);
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(valueToSelect);
        }

        public void SelectDropdownByIndex(IWebElement webElement, int index)
        {
            WaitElementToBeVisible(webElement);
            ScrollToElement(webElement);
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByIndex(index);
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
        }
    }
}
