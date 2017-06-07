using NFLTeamsApp.Helpers;

namespace NFLTeamsApp.ViewModels
{
    public class UserLoggedViewModel : BaseViewModel
    {
        public UserLoggedViewModel()
        { }

        public string UserId => Settings.UserId;
        public string Token => Settings.AuthToken;
    }
}
