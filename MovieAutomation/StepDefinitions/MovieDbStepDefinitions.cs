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
        private readonly MoviePage _moviePage;
        private readonly ScenarioContext _scenarioContext;

        public MovieDbStepDefinitions( HomePage homePage, MoviePage moviePage, ScenarioContext scenarioContext)
        {
            _homePage = homePage;
            _moviePage = moviePage;
            _scenarioContext = scenarioContext;
        }

        [Given("I navigate to the movies page")]
        public void GivenINavigateToTheHomePage()
        {
            _homePage.NavigateToMoviesPage();
        }

        [When("I filter movies by {string}")]
        public void WhenIFilterMoviesByReleaseDateAscending(string optionToSort)
        {
            _moviePage.OpenSortTab();
            _moviePage.SelectSortBy(optionToSort);
        }

        [When("I select genres filters: {string}")]
        public void WhenISelectGenresFilters(string genres)
        {
            var genresList = genres.Split(',').Select(g => g.Trim()).ToList();
            _moviePage.SelectGenres(genresList);
        }

        [When("I press search button")]
        public void WhenIPressSearchButton()
        {
            _moviePage.ClickSearchButton();
            Thread.Sleep(2000); // Temporary wait to allow results to load
            _scenarioContext["FilteredMovieCardsTitles"] = _moviePage.GetMovieCards().Select(movie => movie.GetTitle()).ToList();
            _scenarioContext["FilteredMovieCardsDates"] = _moviePage.GetMovieCards().Select(movie => movie.GetReleaseDate()).ToList();
        }

        [When("I save the initial list of movies")]
        public void WhenISaveTheInitialListOfMovies()
        {
            _scenarioContext["InitialMovieCardsTitles"] = _moviePage.GetMovieCards().Select(movie => movie.GetTitle()).ToList();
            _scenarioContext["InitialMovieCardsDates"] = _moviePage.GetMovieCards().Select(movie => movie.GetReleaseDate()).ToList();
        }

        [When("I select release dates from {string} to {string}")]
        public void WhenISelectReleaseDatesFromTo(string releaseFrom, string releaseTo)
        {
            string formattedReleaseFrom = FormatYearInDate(releaseFrom);
            string formattedReleaseTo = FormatYearInDate(releaseTo);
            _moviePage.SetReleaseDateFrom(formattedReleaseFrom);
            _moviePage.SetReleaseDateTo(formattedReleaseTo);
        }

        private string FormatYearInDate(string year)
        {
            int yearInt = int.Parse(year);
            DateTime today = DateTime.Today;
            DateTime result = new DateTime(yearInt, today.Month, today.Day);
            string formattedDate = result.ToString("M/d/yyyy");
            return formattedDate;
        }
    }
}
