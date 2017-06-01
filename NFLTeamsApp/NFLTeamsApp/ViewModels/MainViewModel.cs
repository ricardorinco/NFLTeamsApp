using NFLTeamsApp.Models;
using NFLTeamsApp.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NFLTeamsApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INFLTeamsTableService nflTeamsTableService;
        public ObservableCollection<Team> Teams { get; }

        public Command AboutCommand { get; }
        public Command<Team> ShowTeamCommand { get; }

        public MainViewModel(INFLTeamsTableService nflTeamsTableService)
        {
            this.nflTeamsTableService = nflTeamsTableService;
            Teams = new ObservableCollection<Team>();

            AboutCommand = new Command(ExecuteAboutCommand);
            ShowTeamCommand = new Command<Team>(ExecuteTeamCommand);
        }

        private async void ExecuteAboutCommand()
        {
            //await PushAsync<AboutViewModel>();
        }

        private async void ExecuteTeamCommand(Team team)
        {
            await PushAsync<TeamViewModel>(team);
        }

        public async Task LoadAsync()
        {
            var teams = await nflTeamsTableService.GetTeamsAsync();

            Teams.Clear();
            foreach (var team in teams)
                Teams.Add(team);
        }
    }
}
