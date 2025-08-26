using Movies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class MovieRepository : IMovieRepository
    {
        private MovieClient _movieClient;

        public MovieRepository()
        {
            _movieClient = new MovieClient();
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieClient.GetAllMoviesAsync();
        }

        public async Task<List<Movie>> GetMoviesByTitleAsync(string title)
        {
            return await _movieClient.GetMoviesByTitleAsync(title);
        }
    }
}
