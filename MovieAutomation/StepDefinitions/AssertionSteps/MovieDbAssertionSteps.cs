using MovieAutomation.Components;
using MovieAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.StepDefinitions.AssertionSteps
{
    [Binding]
    public sealed class MovieDbAssertionSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HomePage _homePage;
        private readonly MoviePage _moviePage;
        public MovieDbAssertionSteps(HomePage homePage, MoviePage moviePage, ScenarioContext scenarioContext)
        {
            _homePage = homePage;
            _moviePage = moviePage;
            _scenarioContext = scenarioContext;
        }

        [Then("I should be navigated to the {string} page")]
        public void ThenIShouldBeNavigatedToThePage(string expectedPath)
        {
            bool isAtExpectedPath = _homePage.IsAtPath(expectedPath);
            Assert.That(isAtExpectedPath, Is.True,
                "We are not on the expected page");
        }

        [Then("the movies should be sorted by release date ascending")]
        public void ThenTheMoviesShouldBeSortedByReleaseDateAscending()
        {
            var movies = _moviePage.GetMovieCards();
            var releaseDates = movies.Select(m => m.GetReleaseDate()).ToList();
            Assert.That(IsMoviesSortedAscending(releaseDates), Is.True,
                "The movies are not sorted by release date ascending");

        }

        [Then("the movies list should be different from the initial list of movies")]
        public void ThenTheMoviesListShouldBeDifferentFromTheInitialListOfMovies()
        {
            var initialMoviesTitles = (List<string>)_scenarioContext["InitialMovieCardsTitles"];
            var filteredMoviesTitles = (List<string>)_scenarioContext["FilteredMovieCardsTitles"];
            Assert.That(initialMoviesTitles, Is.Not.EquivalentTo(filteredMoviesTitles),
                "The filtered movies list is the same as the initial movies list");
        }

        [Then("the movies list should contains only movies released between {int} and {int}")]
        public void ThenTheMoviesListShouldContainsOnlyMoviesReleasedBetweenAnd(string fromYear, string toYear)
        {
            var filteredMoviesDates = (List<string>)_scenarioContext["FilteredMovieCardsDates"];

            //Extract only the year from the date string
            var moviesYears = filteredMoviesDates.Select(s => s.Substring(s.IndexOf(',') + 2)).ToList();

            //Check that each year is between fromYear and toYear
            //Note: The filter is not working properly on the web app which cause this step to fail
            foreach (var year in moviesYears)
            {
                Assert.That(year, Is.InRange(fromYear, toYear),
                    $"There is a movie with release year {year} which is not between {fromYear} and {toYear}.");
            }
        }

        private bool IsMoviesSortedAscending(List<string> moviesDates)
        {
            var format = "MMM dd, yyyy";
            var provider = CultureInfo.InvariantCulture;

            var dates = moviesDates
                .Select(d => DateTime.ParseExact(d, format, provider))
                .ToList();
            return dates.SequenceEqual(dates.OrderBy(d => d));
        }
    }
}
