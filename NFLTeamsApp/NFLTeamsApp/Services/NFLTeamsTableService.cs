using NFLTeamsApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFLTeamsApp.Services
{
    public class NFLTeamsTableService : INFLTeamsTableService
    {
        public async Task<List<Team>> GetTeamsAsync()
        {
            var service = new AzureService<Team>();
            var items = await service.GetTable();

            return items.ToList();
        }
    }
}
