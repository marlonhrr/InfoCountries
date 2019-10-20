using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {

        public CountriesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Countries";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

        }
    }
}
