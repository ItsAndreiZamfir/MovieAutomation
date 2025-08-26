using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts
{
    public interface IMovieClient
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<List<Movie>> GetMoviesByTitleAsync(string title);
    }
}
