using NFLTeamsApp.Models;

namespace NFLTeamsApp.ViewModels
{
    public class TeamDetailsViewModel : BaseViewModel
    {
        private readonly Team team;

        public TeamDetailsViewModel(Team team)
        {
            this.team = team;
        }

        public string Conference => team.Conference;
        public string Position => team.Position;
        public string City => team.City;
        public string Name => team.Name;
        public string CompleteTeamName => team.CompleteTeamName;
        public string Tag => team.Tag;
        public string Founded => team.Founded;
        public string Stadium => team.Stadium;
        public string Logo => team.Logo;
        public string Helmet => team.Helmet;
        public string BackgroundColor => team.BackgroundColor;

    }
}
