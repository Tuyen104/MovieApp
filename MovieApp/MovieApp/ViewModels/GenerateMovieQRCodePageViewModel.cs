using System;
using MovieApp.Services;
using Prism.Navigation;

namespace MovieApp.ViewModels
{
    public class GenerateMovieQRCodePageViewModel : ViewModelBase
    {
        public GenerateMovieQRCodePageViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {

        }
    }
}
