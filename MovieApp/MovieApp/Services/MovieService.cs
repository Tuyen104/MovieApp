using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Entities;
using MovieApp.Entities.Server;
using Newtonsoft.Json;

namespace MovieApp.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovieList(MovieList movieList);
        Task<ApiResponse<MovieList>> GetPopularMovieRequest();
        Task<ApiResponse<MovieList>> GetUpComingMovieRequest();
        Task<ApiResponse<MovieList>> GetSearchMovieRequest(string keyword);
        Task<ApiResponse<Movie>> GetMovieDetailRequest(string id);

    }

    public class MovieService : IMovieService
    {
        readonly IApiService _apiService;

        public MovieService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ApiResponse<MovieList>> GetSearchMovieRequest(string keyword)
        {
            var response = await _apiService.GetMovieListResult(keyword);
            if (!response.HasError())
            {
                return new ApiResponse<MovieList>(JsonConvert.DeserializeObject<MovieList>(response.GetResult()), response.GetStatusCode(), response.GetErrorMessage());
            }
            return new ApiResponse<MovieList>(new MovieList(), response.GetStatusCode(), response.GetErrorMessage());
        }

        public List<Movie> GetMovieList(MovieList movieList)
        {
            return movieList.Movies.ToList();
        }

        public async Task<ApiResponse<Movie>> GetMovieDetailRequest(string id)
        {
            var response = await _apiService.GetMovieDetail(id);
            if (!response.HasError())
            {
                return new ApiResponse<Movie>(JsonConvert.DeserializeObject<Movie>(response.GetResult()), response.GetStatusCode(), response.GetErrorMessage());
            }
            return new ApiResponse<Movie>(new Movie(), response.GetStatusCode(), response.GetErrorMessage());
        }

        public async Task<ApiResponse<MovieList>> GetPopularMovieRequest()
        {
            var response = await _apiService.GetPopularMovieResult();
            if (!response.HasError())
            {
                return new ApiResponse<MovieList>(JsonConvert.DeserializeObject<MovieList>(response.GetResult()), response.GetStatusCode(), response.GetErrorMessage());
            }
            return new ApiResponse<MovieList>(new MovieList(), response.GetStatusCode(), response.GetErrorMessage());
        }

        public async Task<ApiResponse<MovieList>> GetUpComingMovieRequest()
        {
            var response = await _apiService.GetUpComingMovieResult();
            if (!response.HasError())
            {
                return new ApiResponse<MovieList>(JsonConvert.DeserializeObject<MovieList>(response.GetResult()), response.GetStatusCode(), response.GetErrorMessage());
            }
            return new ApiResponse<MovieList>(new MovieList(), response.GetStatusCode(), response.GetErrorMessage());
        }
    }
}
