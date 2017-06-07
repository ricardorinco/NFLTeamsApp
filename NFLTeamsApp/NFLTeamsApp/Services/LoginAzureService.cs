using Microsoft.WindowsAzure.MobileServices;
using NFLTeamsApp.Helpers;
using NFLTeamsApp.Services.Interfaces;
using NFLTeamsApp.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NFLTeamsApp.Services
{
    public class LoginAzureService
    {
        static readonly string AppUrl = "http://nflteamsapp.azurewebsites.net";
        public MobileServiceClient Client { get; set; } = null;
        public static bool UserAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var authenticate = DependencyService.Get<IAuthentication>();
            var user = await authenticate.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não foi possível efetuar seu login, tente novamente", "Ok");
                });

                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }

            return true;
        }
    }
}
