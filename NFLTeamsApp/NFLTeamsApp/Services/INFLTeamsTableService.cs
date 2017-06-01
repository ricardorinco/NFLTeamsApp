using NFLTeamsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFLTeamsApp.Services
{
    public interface INFLTeamsTableService
    {
        Task<List<Team>> GetTeamsAsync();
    }
}
