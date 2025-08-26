using MovieAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.StepDefinitions
{
    [Binding]
    public sealed class MovieDbStepDefinitions
    {
        private readonly HomePage _homePage;

        public MovieDbStepDefinitions( HomePage homePage)
        {
            _homePage = homePage;
        }

        [Given("I navigate to the movies page")]
        public void GivenINavigateToTheHomePage()
        {
            _homePage.NavigateToMoviesPage();
        }

        [When("I click on the {string} option from {string} menu from the navigation menu")]
        public void WhenIClickOnTheOptionFromMenuFromTheNavigationMenu(string subItemName, string menuName)
        {
            _homePage.Menubar.SelectSubItemFromMenu(subItemName, menuName);
        }
    }
}
