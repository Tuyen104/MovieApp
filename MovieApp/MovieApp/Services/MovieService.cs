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
        Task<ApiResponse<MovieList>> GetPopularMovieRequest(int page);
        Task<ApiResponse<MovieList>> GetUpComingMovieRequest(int page);
        Task<ApiResponse<MovieList>> GetSearchMovieRequest(string keyword, int page);
        Task<ApiResponse<Movie>> GetMovieDetailRequest(string id);
        List<Movie> GetMovieSearchData(MovieList movieList, string keyword);

    }

    public class MovieService : IMovieService
    {
        readonly IApiService _apiService;

        public MovieService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ApiResponse<MovieList>> GetSearchMovieRequest(string keyword, int page)
        {
            var response = await _apiService.GetMovieListResult(keyword, page);
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

        public List<Movie> GetMovieSearchData(MovieList movieList, string keyword)
        {
            return movieList.Movies.Where(x => x.Title.ToLower().Contains(keyword.ToLower()) || x.Overview.ToLower().Contains(keyword.ToLower())).ToList();
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

        public async Task<ApiResponse<MovieList>> GetPopularMovieRequest(int page)
        {
            var response = await _apiService.GetPopularMovieResult(page);
            if (!response.HasError())
            {
                return new ApiResponse<MovieList>(JsonConvert.DeserializeObject<MovieList>(response.GetResult()), response.GetStatusCode(), response.GetErrorMessage());
            }
            return new ApiResponse<MovieList>(new MovieList(), response.GetStatusCode(), response.GetErrorMessage());
        }

        public async Task<ApiResponse<MovieList>> GetUpComingMovieRequest(int page)
        {
            var response = await _apiService.GetUpComingMovieResult(page);
            if (!response.HasError())
            {
                return new ApiResponse<MovieList>(JsonConvert.DeserializeObject<MovieList>(response.GetResult()), response.GetStatusCode(), response.GetErrorMessage());
            }
            return new ApiResponse<MovieList>(new MovieList(), response.GetStatusCode(), response.GetErrorMessage());
        }
    }
}
