using MovieApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService _navigationService { get; private set; }
        protected IDialogService _dialogService { get; private set; }

        public ViewModelBase(INavigationService navigationService, IDialogService dialogService)
        {
           _navigationService = navigationService;
            _dialogService = dialogService;
        }
        public async Task HandleCommonApiCommonError(int statusCode)
        {
            _dialogService.CloseLoadingDialog();

            switch (statusCode)
            {
                case ApiService.NO_NETWORK_ERROR_CODE:
                    await _dialogService.DisplayAlertAsync("ERROR","No network!!!", "OK");
                    break;
            }
        }
        public async Task HandleApiError(int statusCode, Action<int> onApiError)
        {
            if (ApiService.HasCommonError(statusCode))
            {
                await HandleCommonApiCommonError(statusCode);
                return;
            }
            onApiError?.Invoke(statusCode);
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
