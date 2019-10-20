using InfoCountries.Common.Models;
using InfoCountries.Common.Services;
using Prism.Commands;
using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isSuccess;
        private DelegateCommand _welcomeCommand;

        public HomePageViewModel(
            INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title = "InfoCountries";
            IsEnabled = true;
            _navigationService = navigationService;
            _apiService = apiService;
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

        public bool IsSuccess
        {
            get => _isSuccess;
            set => SetProperty(ref _isSuccess, value);
        }

        private async void Welcome()
        {
            IsRunning = true;
            IsEnabled = false;

            var connection = await _apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }


            await _navigationService.NavigateAsync("CountriesPage");

            IsRunning = false;
            IsEnabled = true;
        }
    }
}
