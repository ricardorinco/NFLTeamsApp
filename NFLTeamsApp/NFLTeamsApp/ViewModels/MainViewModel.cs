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
        public Command<Team> ShowTeamDetailsCommand { get; }

        public MainViewModel(INFLTeamsTableService nflTeamsTableService)
        {
            this.nflTeamsTableService = nflTeamsTableService;
            Teams = new ObservableCollection<Team>();

            AboutCommand = new Command(ExecuteAboutCommand);
            ShowTeamDetailsCommand = new Command<Team>(ExecuteTeamDetailsCommand);
        }

        private async void ExecuteAboutCommand()
        {
            await PushAsync<AboutViewModel>();
        }
        private async void ExecuteTeamDetailsCommand(Team team)
        {
            await PushAsync<TeamDetailsViewModel>(team);
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
