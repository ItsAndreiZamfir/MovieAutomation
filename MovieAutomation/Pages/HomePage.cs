using MovieAutomation.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.Pages
{
    public class HomePage : BasePage
    {
        public MenubarComponent Menubar { get; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            Menubar = new MenubarComponent(driver);
        }

        public void NavigateToMoviesPage()
        {
            WebDriver.Navigate().GoToUrl("https://www.themoviedb.org/movie");
            WaitForPageToLoad();
        }
    }
}
