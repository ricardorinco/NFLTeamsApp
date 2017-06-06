using Microsoft.WindowsAzure.MobileServices;

namespace NFLTeamsApp.Models
{
    [DataTable("NFLTeams")]
    public class Team
    {
        public string Id { get; set; }
        public string Conference { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string CompleteTeamName { get { return $"{City} {Name}"; } }
        public string Tag { get; set; }
        public string Founded { get; set; }
        public string Stadium { get; set; }
        public string Logo { get; set; }
        public string Matte { get; set; }
        public string Helmet { get; set; }
        public string BackgroundColor { get; set; }

        [Version]
        public string AzureVersion { get; set; }
    }
}
