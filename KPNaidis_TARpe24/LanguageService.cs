using KPNaidis_TARpe24.Resources.Localization;
using System.Globalization;
using Microsoft.Maui.Storage;

namespace KPNaidis_TARpe24.Services
{
    public static class LanguageService
    {
        public static event Action? LanguageChanged;

        public static void ChangeLanguage(string languageCode)
        {
            var culture = new CultureInfo(languageCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            AppResources.Culture = culture;
            LanguageChanged?.Invoke();
            Preferences.Set("AppLanguage", languageCode);
        }

        public static void LoadSavedLanguage()
        {
            var languageCode = Preferences.Get("AppLanguage", "en"); // default = English
            ChangeLanguage(languageCode);
        }
    }

}
