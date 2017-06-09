﻿using NFLTeamsApp.Models;
using NFLTeamsApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NFLTeamsApp.ViewModels
{
    public class TeamsListViewModel : BaseViewModel
    {
        private readonly INFLTeamsTableService nflTeamsTableService;
        public ObservableCollection<Team> Teams { get; }

        public TeamsListViewModel(INFLTeamsTableService nflTeamsTableService)
        {
            this.nflTeamsTableService = nflTeamsTableService;
            Teams = new ObservableCollection<Team>();

            UserLoggedCommand = new Command(ExecuteUserLoggedCommand);
            AboutCommand = new Command(ExecuteAboutCommand);
            ShowTeamDetailsCommand = new Command<Team>(ExecuteTeamDetailsCommand);
        }

        public Command UserLoggedCommand { get; }
        private async void ExecuteUserLoggedCommand()
        {
            await PushAsync<UserLoggedViewModel>();
        }

        public Command AboutCommand { get; }
        private async void ExecuteAboutCommand()
        {
            await PushAsync<AboutViewModel>();
        }

        public Command<Team> ShowTeamDetailsCommand { get; }
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
