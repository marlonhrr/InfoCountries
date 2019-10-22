using InfoCountries.Prism.Helpers;
using InfoCountries.Prism.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class CountryItemViewModel : CountryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountryCommand;

        public CountryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCountryCommand => _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountry));

        private async void SelectCountry()
        {
            Settings.Country = JsonConvert.SerializeObject(this);
            var parameters = new NavigationParameters
            {
                { "country", this}
            };
            await _navigationService.NavigateAsync("CountryTabbedPage", parameters);
        }
    }
}
