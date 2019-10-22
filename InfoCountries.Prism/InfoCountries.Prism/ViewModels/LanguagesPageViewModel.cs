using InfoCountries.Prism.Helpers;
using InfoCountries.Prism.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InfoCountries.Prism.ViewModels
{
    public class LanguagesPageViewModel : ViewModelBase
    {
        private CountryResponse _country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Country);
        private ObservableCollection<LanguageResponse> _languages;
        public LanguagesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Languages";
            LoadLanguages();
        }

        public ObservableCollection<LanguageResponse> Languages
        {
            get => _languages;
            set => SetProperty(ref _languages, value);
        }

        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadLanguages()
        {
            Languages = new ObservableCollection<LanguageResponse>(Country.Languages.Select(l => new LanguageResponse()
            {
                Iso6391 = l.Iso6391,
                Iso6392 = l.Iso6392,
                Name = l.Name,
                NativeName = l.Name
            }).ToList());
        }
    }
}
