using InfoCountries.Prism.Models;
using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class CountryPageViewModel : ViewModelBase
    {
        private CountryResponse _country;

        public CountryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<CountryResponse>("country");
                //Title = "Information";
            }
        }
    }
}
