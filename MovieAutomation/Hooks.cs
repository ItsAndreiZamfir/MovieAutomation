using MovieAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = CreateDriver(headless: false);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _objectContainer.RegisterTypeAs<HomePage, HomePage>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }

        private IWebDriver CreateDriver(bool headless = false)
        {
            var options = new ChromeOptions();

            if (headless)
            {
                options.AddArgument("--headless=new");
            }

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-extensions");

            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return _driver;
        }
    }
}
