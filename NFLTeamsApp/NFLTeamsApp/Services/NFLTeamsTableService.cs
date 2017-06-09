using NFLTeamsApp.Models;
using NFLTeamsApp.Services;
using NFLTeamsApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(NFLTeamsTableService))]
namespace NFLTeamsApp.Services
{
    public class NFLTeamsTableService : INFLTeamsTableService
    {
        public async Task<List<Team>> GetTeamsAsync()
        {
            var easyTableAzureService = new EasyTableAzureService<Team>();
            var items = await easyTableAzureService.GetTable();

            return items.ToList();
        }
    }
}
