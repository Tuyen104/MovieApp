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
using Xamarin.Forms;
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
                MessagingCenter.Send("", "ScrollToTop");
                if (Keyword.Value.Equals("")) 
                { 
                    PullData();
                    //Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
                    //{
                    //    MovieList.ScrollTo(items.FirstOrDefault(), 0, true);
                    //    return false;
                    //});

                }
                else SearchData(Keyword.Value);
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

        protected void SearchData(string keyword)
        {

            ApiResponse<MovieList> response;
            bool continueLoad = true;
            Task.Run(async () =>
            {
                MovieList = new InfiniteScrollCollection<Movie>
                {
                    OnLoadMore = async () =>
                    {
                        //await Task.Delay(2000);
                        List<Movie> movie = null;
                        var page = MovieList.Count / pageSize + 1;
                        if (MovieList.Count != 0 && MovieList.Count < pageSize) return movie;
                        response = await _movieService.GetSearchMovieRequest(keyword, page);
                        response.Check((result) =>
                        {
                            if(result.TotalResults == 0)
                            {
                                continueLoad = false;
                                _dialogService.DisplayAlertAsync("Warninng", "No result!!!", "OK");
                                return;
                            }
                            else
                            movie = _movieService.GetMovieList(result);

                        });
                        return movie;
                    }
                };
                await MovieList.LoadMoreAsync();
            }).Wait();
        }
    }
}
