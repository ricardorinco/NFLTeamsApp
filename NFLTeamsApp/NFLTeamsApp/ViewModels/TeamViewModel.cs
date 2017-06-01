using NFLTeamsApp.Models;
using NFLTeamsApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NFLTeamsApp.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
        private readonly INFLTeamsTableService nflTeamsTableService;
        private readonly Team team;
        public ObservableCollection<Team> Teams { get; }

        public TeamViewModel(INFLTeamsTableService nflTeamsTableService, Team team)
        {
            this.nflTeamsTableService = nflTeamsTableService;
            this.team = team;

            Teams = new ObservableCollection<Team>();
        }

        public async Task Load()
        {
            // var teams = await nflTeamsTableService.GetTeamById(team.Id);
        }
    }
}
