using NFLTeamsApp.ViewModels;
using Xamarin.Forms;

namespace NFLTeamsApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = new MainViewModel(this.Navigation);
        }
    }
}