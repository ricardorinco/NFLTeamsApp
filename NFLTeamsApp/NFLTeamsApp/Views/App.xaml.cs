using NFLTeamsApp.Helpers;
using Xamarin.Forms;

namespace NFLTeamsApp.Views
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            if (Settings.IsLoggedIn)
                MainPage = new NavigationPage(new TeamsListPage());
            else
                MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
