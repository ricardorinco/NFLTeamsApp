using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using NFLTeamsApp.Helpers;
using NFLTeamsApp.Models;
using NFLTeamsApp.Services.Interfaces;
using NFLTeamsApp.Views;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NFLTeamsApp.Services
{
    public class LoginAzureService
    {
        private List<Identity> identities = null;
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(Constants.ApplicationURL);

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

            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;
            Settings.IsLoggedIn = false;

            if (user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não foi possível efetuar seu login, tente novamente", "Ok");
                });

                return false;
            }
            else
            {
                identities = await Client.InvokeApiAsync<List<Identity>>("/.auth/me");

                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
                Settings.UserToken = identities[0].AccessToken;
                Settings.UserIdentification = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")).Value;
                
                var requestUrl = $"https://graph.facebook.com/v2.9/me/?fields=picture&access_token={Settings.UserToken}";
                var httpClient = new HttpClient();
                var userJson = await httpClient.GetStringAsync(requestUrl);
                var profile = JsonConvert.DeserializeObject<Profile>(userJson);

                Settings.UserAvatar = profile.Picture.Data.Url;
                Settings.IsLoggedIn = true;
            }

            return true;
        }
        public async Task LogoutAsync()
        {
            Initialize();

            if (Client.CurrentUser?.MobileServiceAuthenticationToken == null)
                return;

            Client.CurrentUser = new MobileServiceUser(string.Empty) { MobileServiceAuthenticationToken = string.Empty };
            Settings.UserId = string.Empty;
            Settings.AuthToken = string.Empty;
            Settings.IsLoggedIn = false;

            await Client.LogoutAsync();
        }
    }
}
