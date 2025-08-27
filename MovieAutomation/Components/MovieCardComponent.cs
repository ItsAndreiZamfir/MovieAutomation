using MovieAutomation.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.Components
{
    public class MovieCardComponent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWaitHelper _waitHelper;
        public IWebElement CardElement { get; }
        private IWebElement _title => _waitHelper.WaitForChildElement(CardElement, By.XPath(".//div[@class='content']//h2/a"));
        private IWebElement _releaseDate => _waitHelper.WaitForChildElement(CardElement, By.XPath(".//div[@class='content']/p[last()]"));

        public MovieCardComponent(IWebDriver driver, IWebElement webElement)
        {
            _driver = driver;
            CardElement = webElement;
            _waitHelper = new WebDriverWaitHelper(_driver);
        }

        public string GetTitle() => _title.Text;
        public string GetReleaseDate() => _releaseDate.Text;
    }
}
