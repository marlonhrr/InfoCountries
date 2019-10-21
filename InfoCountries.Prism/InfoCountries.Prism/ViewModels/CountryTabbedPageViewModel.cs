using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoCountries.Prism.ViewModels
{
    public class CountryTabbedPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CountryTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Country"
        }
    }
}
