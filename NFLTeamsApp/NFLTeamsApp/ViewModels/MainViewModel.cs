using NFLTeamsApp.Helpers;
using NFLTeamsApp.Services;
using NFLTeamsApp.Views;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(LoginAzureService))]
namespace NFLTeamsApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private LoginAzureService loginAzureService;
        INavigation navigation;

        ICommand loginCommand;
        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async async => await ExecuteLoginCommandAsync()));

        public MainViewModel(INavigation navigation)
        {
            loginAzureService = DependencyService.Get<LoginAzureService>();
            this.navigation = navigation;
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (!await LoginAsync())
                return;
            else
            {
                var teamsListPage = new TeamsListPage();
                await navigation.PushAsync(teamsListPage);

                RemovePageFromStack();
            }
        }

        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(MainPage))
                    navigation.RemovePage(page);
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return loginAzureService.LoginAsync();
        }
    }
}
