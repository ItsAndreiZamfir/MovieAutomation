using MovieAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.StepDefinitions.AssertionSteps
{
    [Binding]
    public sealed class MovieDbAssertionSteps
    {
        private readonly HomePage _homePage;
        public MovieDbAssertionSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        [Then("I should be navigated to the {string} page")]
        public void ThenIShouldBeNavigatedToThePage(string expectedPath)
        {
            bool isAtExpectedPath = _homePage.IsAtPath(expectedPath);
            Assert.That(isAtExpectedPath, Is.True,
                "We are not on the expected page");
        }
    }
}
