
using InfoCountries.Prism.Helpers;
using InfoCountries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class TranslationsPageViewModel : ViewModelBase
    {
        private CountryResponse _country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Country);
        private TranslationsResponse _translations;
        public TranslationsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _translations = _country.Translations;
            Title = "Translations";
        }

        public TranslationsResponse Translations
        {
            get => _translations;
            set => SetProperty(ref _translations, value);
        }

        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}
