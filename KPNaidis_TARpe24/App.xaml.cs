using KPNaidis_TARpe24.Resources.Localization;
using KPNaidis_TARpe24.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace KPNaidis_TARpe24
{
    public partial class App : Application
    {
        public App()
        {

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            /*if (AppResources.Culture != null)
            {
                CultureInfo.CurrentUICulture = new CultureInfo("en");
                CultureInfo.CurrentCulture = new CultureInfo("en");
            }
            else
            {
                CultureInfo.CurrentUICulture = new CultureInfo("et");
                CultureInfo.CurrentCulture = new CultureInfo("et");
            }*/
            LanguageService.LoadSavedLanguage();
            var startPage = new StartPage();
            var navPage = new NavigationPage(startPage)
            {
                BarBackgroundColor = Colors.Blue,
                BarTextColor = Colors.White
            };
            return new Window(navPage);
        }
    }
}