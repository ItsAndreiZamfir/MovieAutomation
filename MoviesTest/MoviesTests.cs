using Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTest
{
    public class MoviesTests
    {

        [Test]
        public void CheckMovieTitleFilter_ShouldReturnTrue_WhenTitleExists()
        {
            // Arrange
            var movieService = new MovieService();
            var titleToCheck = "War of the Worlds";
            // Act
            var result = movieService.CheckMovieTitleFilter(titleToCheck).Result;
            // Assert
            Assert.IsTrue(result);
        }
    }
}
