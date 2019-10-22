using InfoCountries.Prism.Helpers;
using InfoCountries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace InfoCountries.Prism.ViewModels
{
    public class CountryTabbedPageViewModel : ViewModelBase
    {
        public CountryTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
