using Microsoft.WindowsAzure.MobileServices;
using NFLTeamsApp.Droid.Services;
using NFLTeamsApp.Helpers;
using NFLTeamsApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationDroid))]
namespace NFLTeamsApp.Droid.Services
{
    public class AuthenticationDroid : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}