using Prism.Commands;
using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _welcomeCommand;

        public HomePageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "InfoCountries";
            IsEnabled = true;
            _navigationService = navigationService;
        }

        public DelegateCommand WelcomeCommand => _welcomeCommand ?? (_welcomeCommand = new DelegateCommand(Welcome));

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Welcome()
        {
            IsRunning = true;
            IsEnabled = false;

            //var url = App.Current.Resources["UrlApi"].ToString();           
            await _navigationService.NavigateAsync("CountriesPage");

            IsRunning = false;
            IsEnabled = true;
        }
    }
}
