using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFLTeamsApp.Services
{
    public class AzureService<T>
    {
        static readonly string AppUrl = "http://nflteamsapp.azurewebsites.net";
        public MobileServiceClient Client { get; set; } = null;
        public IMobileServiceTable<T> Table;

        public AzureService()
        {
            Client = new MobileServiceClient(AppUrl);
            Table = Client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }
    }
}
