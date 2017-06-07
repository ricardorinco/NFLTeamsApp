using NFLTeamsApp.Services.Interfaces;
using NFLTeamsApp.ViewModels;
using Xamarin.Forms;

namespace NFLTeamsApp.Views
{
    public partial class TeamsListPage : ContentPage
    {
        private TeamsListViewModel teamsListViewModel => BindingContext as TeamsListViewModel;

        public TeamsListPage()
        {
            InitializeComponent();

            var nflTeamsTableService = DependencyService.Get<INFLTeamsTableService>();
            BindingContext = new TeamsListViewModel(nflTeamsTableService);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (teamsListViewModel != null)
                await teamsListViewModel.LoadAsync();
        }
    }
}