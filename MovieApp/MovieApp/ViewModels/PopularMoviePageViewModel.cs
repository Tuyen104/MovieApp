using System;
using Acr.UserDialogs;
using MovieApp.Entities;
using MovieApp.Entities.Server;
using MovieApp.Services;
using Prism.Navigation;

namespace MovieApp.ViewModels
{
    public class PopularMoviePageViewModel : PopularMoviePageViewModelBase
    {
        public PopularMoviePageViewModel(INavigationService navigationService, IMovieService movieService, IDialogService dialogService) : base(navigationService, movieService, dialogService)
        {

        }
        protected async override void PullData()
        {
                ApiResponse<MovieList> response;
//                using (UserDialogs.Instance.Loading())
//                {
                    response = await _movieService.GetPopularMovieRequest();
//                }
                response.Check((result) =>
                {
                    MovieList = _movieService.GetMovieList(result);
                }, async (statusCode) =>
                {
                    await HandleApiError(statusCode, async (errorCode) => await _dialogService.ShowDialogAsync(statusCode));
                });
        }
    }
}
