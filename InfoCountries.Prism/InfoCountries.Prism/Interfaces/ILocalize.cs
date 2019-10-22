using System.Globalization;

namespace InfoCountries.Prism.Interfaces
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}