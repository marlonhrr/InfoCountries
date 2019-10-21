using InfoCountries.Common.Models;
using InfoCountries.Common.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InfoCountries.Prism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CountriesResponse> _countries;
        private bool _isRefreshing;
        private bool _isEnabled;
        private string _filter;
        private DelegateCommand _searchCommand;
        private List<CountriesResponse> countriesList;

        public CountriesPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Countries";
            LoadCountries();
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(Search));

        public ObservableCollection<CountriesResponse> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public string Filter
        {
            get => _filter;
            set 
            {
                SetProperty(ref _filter, value);
                Search();
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        private async void LoadCountries()
        {
            IsRefreshing = true;
            var connection = await _apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsEnabled = true;
                IsRefreshing = false;
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

            if (!response.IsSuccess)
            {
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            countriesList = (List<CountriesResponse>)response.Result;
            Countries = new ObservableCollection<CountriesResponse>(countriesList);
            IsRefreshing = false;
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                Countries = new ObservableCollection<CountriesResponse>(countriesList);
            }
            else
            {
                Countries = new ObservableCollection<CountriesResponse>(
                    countriesList.Where(
                        c => c.Name.ToLower().Contains(Filter.ToLower()) ||
                            c.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }
    }
}