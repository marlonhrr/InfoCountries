using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCountries.Prism.Helpers
{
    public class Settings
    {
        private const string _country = "Country";
        private static readonly string _stringDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Country
        {
            get => AppSettings.GetValueOrDefault(_country, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_country, value);
        }
    }
}
