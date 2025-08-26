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
        public async Task CheckMovieTitleFilter_ShouldReturnTrue_WhenTitleExists()
        {
            // Arrange
            var movieService = new MovieService();
            var titleToCheck = "War of the Worlds";
            // Act
            var result = await movieService.CheckMovieTitleFilterAsync(titleToCheck);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckMovieTitleFilter_ShouldReturnFalse_WhenTitleNotExists()
        {
            // Arrange
            var movieService = new MovieService();
            var titleToCheck = "Non exists";
            // Act
            var result = await movieService.CheckMovieTitleFilterAsync(titleToCheck);
            // Assert
            Assert.IsFalse(result);
        }
    }
}
