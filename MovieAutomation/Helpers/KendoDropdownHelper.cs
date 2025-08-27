using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MovieAutomation.Helpers
{
    internal class KendoDropdownHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public KendoDropdownHelper(IWebDriver driver, int timeoutSeconds = 10)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        }

        /// <summary>
        /// Select an option by visible text (e.g., "Release Date Descending")
        /// </summary>
        public void SelectByText(By comboLocator, string optionText)
        {
            var combo = _wait.Until(ExpectedConditions.ElementIsVisible(comboLocator));

            string listBoxId = combo.GetAttribute("aria-controls");
            if (string.IsNullOrEmpty(listBoxId))
                throw new InvalidOperationException("Combobox does not have aria-controls set");
            var toggleBtn = combo.FindElements(By.CssSelector("button[role='button']")).Count > 0
                ? combo.FindElement(By.CssSelector("button[role='button']"))
                : combo;
            toggleBtn.Click();

            var listUl = _wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(By.Id(listBoxId));
                    return el.Displayed ? el : null;
                }
                catch { return null; }
            });

            var option = _wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath($"//ul[@id='{listBoxId}']//li[normalize-space()='{optionText}']|//ul[@id='{listBoxId}']//li//*[normalize-space()='{optionText}']")));

            option.Click();
            _wait.Until(d =>
            {
                try
                {
                    var textEl = combo.FindElement(By.CssSelector(".k-input-value-text"));
                    return string.Equals(textEl.Text.Trim(), optionText, StringComparison.OrdinalIgnoreCase);
                }
                catch { return false; }
            });
        }
    }
}
