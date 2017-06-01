using System.Windows.Input;
using Xamarin.Forms;

namespace NFLTeamsApp.Controls
{
    public class MyListView : ListView
    {
        public MyListView(ListViewCachingStrategy strategy) : base(strategy)
        {
            Initialize();
        }

        public MyListView() : this(ListViewCachingStrategy.RecycleElement)
        {
            Initialize();
        }

        public void Initialize()
        {
            ItemSelected += (sender, e) =>
            {
                if (ItemTappedCommand == null)
                    return;

                if (ItemTappedCommand.CanExecute(e.SelectedItem))
                    ItemTappedCommand.Execute(e.SelectedItem);
            };
        }

        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create(
                "ITemTappedCommand",
                typeof(ICommand),
                typeof(MyListView),
                null
            );

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }
    }
}
