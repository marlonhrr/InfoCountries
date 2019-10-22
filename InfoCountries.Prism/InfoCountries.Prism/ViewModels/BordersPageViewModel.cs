using InfoCountries.Prism.Helpers;
using InfoCountries.Prism.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace InfoCountries.Prism.ViewModels
{
    public class BordersPageViewModel : ViewModelBase
    {
        private CountryResponse _country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Country);
        private ObservableCollection<BorderResponse> _borders;

        public BordersPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Borders";
            LoadBorders();
        }

        public ObservableCollection<BorderResponse> Borders
        {
            get => _borders;
            set => SetProperty(ref _borders, value);
        }

        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadBorders()
        {
            Borders = new ObservableCollection<BorderResponse>();
            foreach (var border in _country.Borders)
            {
                var country = CountriesPageViewModel.GetInstance().Countries.Where(c => c.Alpha3Code == border.ToString()).FirstOrDefault();

                if (country != null)
                {
                    Borders.Add(new BorderResponse()
                    {
                        Code = country.Alpha3Code,
                        Name = country.Name
                    });
                }
            }
        }
    }
}