using Version.Plugin;

namespace NFLTeamsApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string Version => CrossVersion.Current.Version;
    }
}
