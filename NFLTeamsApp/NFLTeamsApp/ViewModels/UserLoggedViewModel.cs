using NFLTeamsApp.Helpers;

namespace NFLTeamsApp.ViewModels
{
    public class UserLoggedViewModel : BaseViewModel
    {
        public string UserAvatar => Settings.UserAvatar;
        public string UserIdentification => Settings.UserIdentification;
    }
}
