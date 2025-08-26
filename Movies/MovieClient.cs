
using Movies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class MovieClient : IMovieClient
    {
        private const string BaseUrl = "https://api.themoviedb.org/3/";
        private HttpClient _httpClient;
        public HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri(BaseUrl);
                    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI0NGIzOTQwOGI1MTUzMjNjNzhmMzk5MjQ0NzQyZjM2NSIsIm5iZiI6MTc1NjE5NTY0NS40NjEsInN1YiI6IjY4YWQ2YjNkZWFmNWM4MmQ3ODQ0OTU1YiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.s37q5076-Hs3wwWB_oSVpQL51ncLhAr6Uln8JdE36WM");
                }

                return _httpClient;
            }
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var response = await HttpClient.GetFromJsonAsync<GetAllMoviesResponse>("discover/movie");
            return response.Results;
        }

        public async Task<List<Movie>> GetMoviesByTitleAsync(string title)
        {
            var response = await HttpClient.GetFromJsonAsync<GetAllMoviesResponse>($"search/movie?query={title}");
            return response.Results;
        }
    }
}
