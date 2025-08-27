using MovieAutomation.Components;
using MovieAutomation.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAutomation.Pages
{
    public class MoviePage : BasePage
    {
        public MoviePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _releaseDateFrom => _waitHelper.WaitForElement(By.XPath("//input[@id='release_date_gte']"));
        private IWebElement _releaseDateTo => _waitHelper.WaitForElement(By.XPath("//input[@id='release_date_lte']"));

        private IWebElement Genres(string selectedGenre) => _waitHelper.WaitForElement(By.XPath($"//ul[@id='with_genres']//a[normalize-space()='{selectedGenre}']"));

        private IWebElement SortTab => _waitHelper.WaitForElement(By.XPath("//div[@class='name']//h2[normalize-space()='Sort']"));

        private IWebElement _searchButton => _waitHelper.WaitForElement(By.XPath("(//p[@class='load_more']//a[normalize-space()='Search'])[1]"));

        private By _sortResultsBy => (By.CssSelector("span.k-dropdownlist[role='combobox'][aria-controls='sort_by_listbox']"));

        private KendoDropdownHelper _kendoDropdownHelper => new KendoDropdownHelper(WebDriver);

        public void OpenSortTab() => _elementMethods.ClickElement(SortTab);

        private List<MovieCardComponent> _movieCards =>
            _waitHelper.WaitForElements(By.XPath("//div[@class='card style_1']")).Select(e => new MovieCardComponent(WebDriver, e)).ToList();

        public void SelectGenres(List<string> genres)
        {
            foreach (var genre in genres)
            {
                var genreElement = Genres(genre);
                _elementMethods.ClickElement(genreElement);
            }
        }

        public void SetReleaseDateFrom(string date)
        {
            _elementMethods.FillElement(_releaseDateFrom, date);
        }

        public void SetReleaseDateTo(string date)
        {
            _elementMethods.FillElement(_releaseDateTo, date);
        }

        public void SelectSortBy(string optionText) =>
            _kendoDropdownHelper.SelectByText(_sortResultsBy, optionText);

        public void ClickSearchButton() => _elementMethods.ClickElement(_searchButton);

        public List<MovieCardComponent> GetMovieCards() => _movieCards;
    }
}
