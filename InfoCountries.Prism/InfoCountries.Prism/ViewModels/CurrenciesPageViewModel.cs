using InfoCountries.Prism.Helpers;
using InfoCountries.Prism.Models;
using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace InfoCountries.Prism.ViewModels
{
    public class CurrenciesPageViewModel : ViewModelBase
    {
        private CountryResponse _country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Country);
        private ObservableCollection<CurrencyResponse> _currencies;
        public CurrenciesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Currencies";
            LoadCurrencies();
        }

        public ObservableCollection<CurrencyResponse> Currencies
        {
            get => _currencies;
            set => SetProperty(ref _currencies, value);
        }

        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadCurrencies()
        {
            Currencies = new ObservableCollection<CurrencyResponse>(Country.Currencies.Select(c => new CurrencyResponse()
            {
                Code = c.Code,
                Name = c.Name,
                Symbol = c.Symbol
            }).ToList());
        }
    }
}
