using GalaSoft.MvvmLight.Command;
using InfoCountries.Prism.Helpers;
using InfoCountries.Prism.Models;
using InfoCountries.Prism.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace InfoCountries.Prism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CountryItemViewModel> _countries;
        private bool _isRunning;
        private bool _isRefreshing;
        private bool _isEnabled;
        private string _filter;
        private DelegateCommand _searchCommand;
        private List<CountryResponse> _countriesList;
        private static CountriesPageViewModel _getInstance;

        public CountriesPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _getInstance = this;
            IsRunning = true;
            LoadCountries();
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(Search));

        public ICommand RefreshCommand
        {
            get { return new RelayCommand(LoadCountries); }
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
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

        public static CountriesPageViewModel GetInstance()
        {
            return _getInstance;
        }

        private async void LoadCountries()
        {
            IsRunning = true;
            IsRefreshing = true;
            var connection = await _apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ConnectionError,
                    Languages.Accept);
                await App.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await _apiService.GetListAsync<CountryResponse>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }

            _countriesList = (List<CountryResponse>)response.Result;
            Countries = new ObservableCollection<CountryItemViewModel>(
                ToCountryItemViewModel());
            IsRunning = false;
            IsRefreshing = false;
        }

        private IEnumerable<CountryItemViewModel> ToCountryItemViewModel()
        {
            return _countriesList.Select(c => new CountryItemViewModel(_navigationService)
            {
                Alpha2Code = c.Alpha2Code,
                Alpha3Code = c.Alpha3Code,
                AltSpellings = c.AltSpellings,
                Area = c.Area,
                Borders = c.Borders,
                CallingCodes = c.CallingCodes,
                Capital = c.Capital,
                Cioc = c.Cioc,
                Currencies = c.Currencies,
                Demonym = c.Demonym,
                Flag = c.Flag,
                Gini = c.Gini,
                Languages = c.Languages,
                Latlng = c.Latlng,
                Name = c.Name,
                NativeName = c.NativeName,
                NumericCode = c.NumericCode,
                Population = c.Population,
                Region = c.Region,
                RegionalBlocs = c.RegionalBlocs,
                Subregion = c.Subregion,
                Timezones = c.Timezones,
                TopLevelDomain = c.TopLevelDomain,
                Translations = c.Translations,
            });
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                Countries = new ObservableCollection<CountryItemViewModel>(
                    ToCountryItemViewModel());
            }
            else
            {
                Countries = new ObservableCollection<CountryItemViewModel>(
                    ToCountryItemViewModel().Where(
                        c => c.Name.ToLower().Contains(Filter.ToLower()) ||
                            c.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }
    }
}