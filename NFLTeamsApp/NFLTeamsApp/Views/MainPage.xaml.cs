using NFLTeamsApp.Services;
using NFLTeamsApp.ViewModels;
using Xamarin.Forms;

namespace NFLTeamsApp.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();

            var nflTeamsTableService = DependencyService.Get<INFLTeamsTableService>();
            BindingContext = new MainViewModel(nflTeamsTableService);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
                await ViewModel.LoadAsync();
        }
    }
}
