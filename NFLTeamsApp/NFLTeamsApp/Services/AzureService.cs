using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFLTeamsApp.Services
{
    public class AzureService<T>
    {
        IMobileServiceClient Client;
        IMobileServiceTable<T> Table;

        public AzureService()
        {
            string urlNFLTeamApp = "http://nflteamsapp.azurewebsites.net";
            Client = new MobileServiceClient(urlNFLTeamApp);
            Table = Client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }
    }
}
