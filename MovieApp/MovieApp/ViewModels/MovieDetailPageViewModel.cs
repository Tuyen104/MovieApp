using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MovieApp.Entities;
using MovieApp.Entities.Server;
using MovieApp.Services;
using Prism.Navigation;

namespace MovieApp.ViewModels
{
    public class MovieDetailPageViewModel : ViewModelBase
    {
        public Movie movie;
        public Movie Movie {
            get { return movie; }
            set { SetProperty(ref movie, value); }
        }
        public string _genresList;
        public string GenresList
        {
            get { return _genresList; }
            set { SetProperty(ref _genresList, value); }
        }
        public string _companiesList;
        public string CompaniesList
        {
            get { return _companiesList; }
            set { SetProperty(ref _companiesList, value); }
        }

        private MovieService _movieService;

        public MovieDetailPageViewModel(INavigationService navigationService, MovieService movieService, IDialogService dialogService) : base(navigationService, dialogService)
        {
            _movieService = movieService;
        }
        public async override void OnNavigatingTo(INavigationParameters parameters)
        {
            var id = parameters["Id"] as string;
            await PullData(id);
            base.OnNavigatingTo(parameters);

        }
        public async Task PullData(string id)
        {
            ApiResponse<Movie> response;
            using (UserDialogs.Instance.Loading())
            {
                response = await _movieService.GetMovieDetailRequest(id);
            }
            response.Check((result) =>
            {
                Movie = result;
                foreach (var item in Movie.Genres)
                {
                    GenresList = string.Concat(GenresList, " - ", item.Name, "\n");
                }
                foreach (var item in Movie.Companies)
                {
                    CompaniesList = string.Concat(CompaniesList, " - ", item.Name, "\n");
                }
            }, async (statusCode) =>
            {
                await HandleApiError(statusCode, async (errorCode) => await _dialogService.ShowDialogAsync(statusCode));
                await _navigationService.GoBackAsync();
            });
        }
    }
}
