using Microsoft.WindowsAzure.MobileServices;
using NFLTeamsApp.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFLTeamsApp.Services
{
    public class EasyTableAzureService<T>
    {
        public MobileServiceClient Client { get; set; } = null;
        public IMobileServiceTable<T> Table;

        public EasyTableAzureService()
        {
            Client = new MobileServiceClient(Constants.ApplicationURL);
            Table = Client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }
    }
}
