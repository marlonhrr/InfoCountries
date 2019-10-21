using InfoCountries.Common.Models;
using InfoCountries.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCountries.Prism.ViewModels
{
    public class CountryItemViewModel : CountriesResponse
    {
        private DelegateCommand _selectCountryCommand;
        //Comandos
        public DelegateCommand SelectCountryCommand => _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountry));

        private async void SelectCountry()
        {
            //CountryPageViewModel.
            await App.Current.MainPage.Navigation.PushAsync(new CountryPage());
        }
    }
}
