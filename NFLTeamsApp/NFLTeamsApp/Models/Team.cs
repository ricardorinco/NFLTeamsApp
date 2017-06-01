using Microsoft.WindowsAzure.MobileServices;

namespace NFLTeamsApp.Models
{
    [DataTable("NFLTeams")]
    public class Team
    {
        public string Conference { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Founded { get; set; }
        public string Stadium { get; set; }
        public string Tag { get; set; }
        public string Logo { get; set; }
        public string Gloss { get; set; }

        [Version]
        public string AzureVersion { get; set; }
    }
}
