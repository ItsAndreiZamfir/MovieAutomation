using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class MovieService
    {
        private MovieRepository _movieRepository;
        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }

        public async Task<bool> CheckMovieTitleFilter(string title)
        {
            var allMovies = await _movieRepository.GetAllMoviesAsync();
            var movies = await _movieRepository.GetMoviesByTitleAsync(title);

            var allMovieTitles = new HashSet<string>(allMovies.Select(m => m.Title), StringComparer.OrdinalIgnoreCase);
            return movies.Any(m => allMovieTitles.Contains(m.Title));
        }
    }
}
