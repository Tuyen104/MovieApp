using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MovieApp.Entities;
using MovieApp.Entities.Server;
using MovieApp.Services;
using MovieApp.Views;
using Prism.Navigation;
using Reactive.Bindings;

namespace MovieApp.ViewModels
{
    public class UpComingMoviePageViewModel : UpComingMoviePageViewModelBase
    {
        public UpComingMoviePageViewModel(INavigationService navigationService, IMovieService movieService, IDialogService dialogService) : base(navigationService, movieService, dialogService)
        {

        }
        protected async override void PullData()
        {
            ApiResponse<MovieList> response;
            using (UserDialogs.Instance.Loading())
            {
                response = await _movieService.GetPopularMovieRequest();
            }
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
