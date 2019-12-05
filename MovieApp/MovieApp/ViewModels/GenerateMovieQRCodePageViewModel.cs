using MovieApp.Services;
using Prism.Navigation;
namespace MovieApp.ViewModels
{
    public class GenerateMovieQRCodePageViewModel : ViewModelBase
    {
        public string _ticketQRCode;
        public string TicketQRCode
        {
            get { return _ticketQRCode; }
            set { SetProperty(ref _ticketQRCode, value); }
        }

        public GenerateMovieQRCodePageViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            string verifier_id = null;
            base.OnNavigatingTo(parameters);
            if (parameters.ContainsKey("VerifierId"))
            {
                verifier_id = (string)parameters["VerifierId"];
            }
            LoadData(verifier_id);
        }

        private void LoadData(string verifier_id)
        {
            TicketQRCode = verifier_id;
            //update TicketQRCode to database to save with this account
        }
    }
}
