using InfoCountries.Common.Models;
using InfoCountries.Common.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InfoCountries.Prism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CountriesResponse> _countries;
        private bool _isRunning;
        private bool _isEnabled;

        public CountriesPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Countries";
            LoadCountries();
        }

        public ObservableCollection<CountriesResponse> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        private async void LoadCountries()
        {
            IsRunning = true;
            
            var connection = await _apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Check the internet connection.", 
                    "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;

            }

            var response = await _apiService.GetListAsync<CountriesResponse>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");

            if(!response.IsSuccess)
            {
                _isRunning = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    response.Message, 
                    "Accept");
                return;
            }

            IsRunning = false;

            var list = (List<CountriesResponse>)response.Result;
            this.Countries = new ObservableCollection<CountriesResponse>(list);
        }
    }
}
