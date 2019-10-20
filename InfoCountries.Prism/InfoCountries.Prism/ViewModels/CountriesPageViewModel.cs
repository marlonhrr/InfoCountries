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
        private ObservableCollection<CountriesPageViewModel> _countries;
        private bool _isRunning;

        public CountriesPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Countries";
            LoadCountries();
        }

        public ObservableCollection<CountriesPageViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public bool IsRunning
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
            //var connection = await _apiService.CheckConnection(url);
            //if (!connection)
            //{
            //    IsEnabled = true;
            //    IsRunning = false;
            //    await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
            //    return;
            //}

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

            var list = (List<CountriesPageViewModel>)response.Result;
            Countries = new ObservableCollection<CountriesPageViewModel>(list);
        }
    }
}
