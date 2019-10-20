using Prism;
using Prism.Ioc;
using InfoCountries.Prism.ViewModels;
using InfoCountries.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InfoCountries.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InfoCountries.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();
        }
    }
}
