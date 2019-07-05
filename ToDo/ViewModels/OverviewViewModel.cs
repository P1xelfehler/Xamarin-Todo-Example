using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using ToDo.Constants;
using ToDo.DataStore;
using ToDo.Model;
using ToDo.Pages.Create;
using ToDo.Pages.ToDoView;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class OverviewViewModel
    {
        public ICommand AddCommand { private set; get; }
        public ICommand ItemSelectedCommand { private set; get; }
        public INavigation Navigation { set; get; }

        public List<TodoGroup> Groups { get; } = new List<TodoGroup> {
            new TodoGroup("Unerledigt"),
            new TodoGroup("Erledigt")
        };

        public OverviewViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AddCommand = new Command(() =>
            {
                var destination = new CreatePage();
                Navigation.PushModalAsync(destination);
            });
            ItemSelectedCommand = new Command((parameters) =>
            {
                var eventArgs = parameters as ItemTappedEventArgs;
                var item = (ToDoItem)eventArgs.Item;
                var destination = new TodoViewPage(item);
                Navigation.PushAsync(destination);
            });
            loadItems();
            registerItemAddedReceiver();
        }

        ~OverviewViewModel()
        {
            unregisterReceivers();
        }

        private void loadItems()
        {
            var items = DataStorage
                .GetInstance()
                .FetchItems();
            items.ForEach(item => Groups[item.IsChecked ? 1 : 0].Add(item));
        }

        private void registerItemAddedReceiver()
        {
            MessagingCenter.Subscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemAdded, (_, item) =>
            {
                Groups[item.IsChecked ? 1 : 0].Insert(0, item);
            });
        }

        private void unregisterReceivers()
        {
            MessagingCenter.Unsubscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemAdded);
        }
    }
}
