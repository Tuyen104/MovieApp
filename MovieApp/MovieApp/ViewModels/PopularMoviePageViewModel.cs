using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MovieApp.Entities;
using MovieApp.Entities.Server;
using MovieApp.Services;
using Prism.Navigation;
using Xamarin.Forms.Extended;

namespace MovieApp.ViewModels
{
    public class PopularMoviePageViewModel : PopularMoviePageViewModelBase
    {
        public PopularMoviePageViewModel(INavigationService navigationService, IMovieService movieService, IDialogService dialogService) : base(navigationService, movieService, dialogService)
        {

        }

        protected override void PullData()
        {
            ApiResponse<MovieList> response;

            Task.Run(async () =>
            {
                MovieList = new InfiniteScrollCollection<Movie>
                {
                    OnLoadMore = async () =>
                    {
                       await Task.Delay(2000);
                        List<Movie> movie = null;
                        var page = MovieList.Count / pageSize + 1;
                        response = await _movieService.GetPopularMovieRequest(page);
                        response.Check((result) =>
                        {
                            movie = _movieService.GetMovieList(result);
                        });

                        return movie;
                    }
                };
                await MovieList.LoadMoreAsync();
            }).Wait();
        }
        //protected override async void PullData()
        //{
        //        ApiResponse<MovieList> response;
        //       // using (UserDialogs.Instance.Loading())
        //        //{
        //            response = await _movieService.GetPopularMovieRequest();
        //        //}
        //        response.Check((result) =>
        //        {
        //            MovieList = _movieService.GetMovieList(result);
        //        }, async (statusCode) =>
        //        {
        //            await HandleApiError(statusCode, async (errorCode) => await _dialogService.ShowDialogAsync(statusCode));
        //        });
        //}

        //protected override async void SearchData(string keyword)
        //{
        //    ApiResponse<MovieList> response;
        //    // using (UserDialogs.Instance.Loading())
        //    //{
        //    response = await _movieService.GetPopularMovieRequest();
        //    //}
        //    response.Check((result) =>
        //    {
        //        MovieList = _movieService.GetMovieSearchData(result, keyword);
        //    }, async (statusCode) =>
        //    {
        //        await HandleApiError(statusCode, async (errorCode) => await _dialogService.ShowDialogAsync(statusCode));
        //    });
        //}
    }
}
