using MovieAutomation.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.Components
{
    public class MenubarComponent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Actions _actions;

        // Root locator for the menu bar
        private readonly By _root = By.XPath("//ul[@data-role='menu']");

        public MenubarComponent(IWebDriver driver, int timeoutSeconds = 10)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            _actions = new Actions(driver);
        }

        // Returns the root menu element
        private IWebElement Root() =>
            _wait.Until(ExpectedConditions.ElementIsVisible(_root));

        // Returns the locator for a top-level menu item by its aria-label
        private By TopMenuItem(string ariaLabel) =>
            By.XPath($".//li[@role='menuitem' and .//a[@aria-label='{ariaLabel}']]");

        // Returns the locator for a sub-item link in a popup menu
        private By SubItemLinkInPopup(string popupUlId, string subItemAriaLabel) =>
            By.XPath($"//ul[@id='{popupUlId}']//a[@aria-label='{subItemAriaLabel}']");

        // Opens a top-level menu by hovering over it
        public void OpenMenu(string topAriaLabel)
        {
            var root = Root();
            var topLi = root.FindElement(TopMenuItem(topAriaLabel));
            var link = topLi.FindElement(By.CssSelector("a[aria-label]"));

            // Hover to open the menu
            _actions.MoveToElement(link).Perform();

            // Wait for the popup to be visible
            string popupId = topLi.GetAttribute("aria-controls");
            if (string.IsNullOrEmpty(popupId))
                throw new InvalidOperationException($"Menu item '{topAriaLabel}' does not have aria-controls set.");

            _wait.Until(driver =>
            {
                try
                {
                    var popupUl = driver.FindElement(By.Id(popupId));
                    return popupUl.Displayed;
                }
                catch
                {
                    return false;
                }
            });
        }

        // Select a sub-item from the menu, searching globally for the sub-item
        public void SelectSubItemFromMenu(string topAriaLabel, string subItemAriaLabel)
        {
            OpenMenu(topAriaLabel);

            // Wait for any visible submenu link with the given aria-label
            var subItem = _wait.Until(driver =>
            {
                var elements = driver.FindElements(By.XPath($"//a[@aria-label='{subItemAriaLabel}']"));
                foreach (var el in elements)
                {
                    if (el.Displayed && el.Enabled)
                        return el;
                }
                return null;
            });

            // Scroll into view and click
            ((IJavaScriptExecutor)_driver).ExecuteScript(
                "arguments[0].scrollIntoView({behavior: 'instant', block: 'center'});", subItem);

            subItem.Click();
        }
    }
 }
