using Microsoft.Extensions.DependencyInjection;

namespace KPNaidis_TARpe24
{
    public partial class App : Application
    {
        public App()
        {

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
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