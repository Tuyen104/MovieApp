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
using Xamarin.Forms.Extended;

namespace MovieApp.ViewModels
{
    public abstract class PopularMoviePageViewModelBase : ViewModelBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public InfiniteScrollCollection<Movie> MovieList { get; set; }
        protected const int pageSize = 20;

        protected readonly IMovieService _movieService;

        public ReactiveProperty<string> Keyword { get; set; }

        public AsyncReactiveCommand<Movie> _selectedItemCommand;

        public AsyncReactiveCommand<Movie> SelectedItemCommand { get; }

        public AsyncReactiveCommand SearchMovieCommand { get; }

        public AsyncReactiveCommand ClearSearchCommand { get; }

        public ReactiveProperty<bool> IsExistText => new ReactiveProperty<bool>(MovieList == null || !MovieList.Any());
        public ReactiveProperty<bool> IsExistList => new ReactiveProperty<bool>(MovieList != null && MovieList.Any());

        public PopularMoviePageViewModelBase(INavigationService navigationService, IMovieService movieService, IDialogService dialogService) : base(navigationService, dialogService)
        {
            _movieService = movieService;
            Keyword = new ReactiveProperty<string>();

            IsExistText.Value = false;

            PullData();
            SearchMovieCommand = new AsyncReactiveCommand();
            SearchMovieCommand.Subscribe(async () =>
            {
                SearchData(Keyword.Value);
            });
            SelectedItemCommand = new AsyncReactiveCommand<Movie>();
            SelectedItemCommand.Subscribe(async movie =>
            {
                var param = new NavigationParameters
                {
                    {"Id", movie.Id}
                };
                await _navigationService.NavigateAsync(nameof(MovieDetailPage), param);
            });
            ClearSearchCommand = new AsyncReactiveCommand();
            ClearSearchCommand.Subscribe(async () =>
            {
                //MovieList = new List<Movie>();
                //Keyword.Value = null;
            });
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            //PullData();
            base.OnNavigatingTo(parameters);
        }
        protected abstract void PullData();
        //protected abstract void SearchData(string keyword);
        protected async void SearchData(string keyword)
        {
            ApiResponse<MovieList> response;
            // using (UserDialogs.Instance.Loading())
            //{
            response = await _movieService.GetUpComingMovieRequest();
            //}
            response.Check((result) =>
            {
                MovieList = _movieService.GetMovieSearchData(result, keyword);
            }, async (statusCode) =>
            {
                await HandleApiError(statusCode, async (errorCode) => await _dialogService.ShowDialogAsync(statusCode));
            });
        }
    }
}
