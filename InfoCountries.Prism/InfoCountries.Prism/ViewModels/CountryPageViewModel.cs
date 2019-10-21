using InfoCountries.Common.Models;
using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class CountryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private CountriesResponse _country;

        public CountryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public CountriesResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<CountriesResponse>("country");
                Title = Country.Name;
            }
        }
    }
}
