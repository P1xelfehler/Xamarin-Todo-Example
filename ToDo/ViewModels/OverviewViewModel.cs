using System.Collections.Generic;
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
        public ICommand AddCommand { get; }
        public ICommand ItemSelectedCommand { get; }
        public INavigation Navigation { get; }

        public List<TodoGroup> Groups { get; } = new List<TodoGroup> {
            new TodoGroup("Unerledigt"),
            new TodoGroup("Erledigt")
        };

        public OverviewViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AddCommand = new Command(add);
            ItemSelectedCommand = new Command(showTodo);
            loadItems();
            registerReceivers();
        }

        ~OverviewViewModel()
        {
            unregisterReceivers();
        }

        private void add()
        {
            var destination = new CreatePage();
            Navigation.PushModalAsync(destination);
        }

        private void showTodo(object parameters)
        {
            var eventArgs = parameters as ItemTappedEventArgs;
            var item = (ToDoItem)eventArgs.Item;
            var destination = new TodoViewPage(item);
            Navigation.PushAsync(destination);
        }

        private void loadItems()
        {
            var items = DataStorage
                .GetInstance()
                .FetchItems();
            items.ForEach(item => Groups[item.IsChecked ? 1 : 0].Add(item));
        }

        private void registerReceivers()
        {
            // item added
            MessagingCenter.Subscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemAdded, (_, item) =>
            {
                Groups[item.IsChecked ? 1 : 0].Insert(0, item);
            });
            // item changed
            MessagingCenter.Subscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemChanged, (_, item) =>
            {
                for (var groupIndex = 0; groupIndex < Groups.Count; groupIndex++)
                {
                    for (var itemIndex = 0; itemIndex < Groups[groupIndex].Count; itemIndex++)
                    {
                        if (item.Id == Groups[groupIndex][itemIndex].Id)
                        {
                            var targetGroupIndex = item.IsChecked ? 1 : 0;
                            if (groupIndex == targetGroupIndex)
                            {
                                Groups[groupIndex][itemIndex] = item;
                            } else
                            {
                                Groups[groupIndex].RemoveAt(itemIndex);
                                Groups[targetGroupIndex].Insert(0, item);
                            }
                            return;
                        }
                    }
                }
            });
            // item deleted
            MessagingCenter.Subscribe<DataStorage, int>(this, MessengerKeys.ItemDeleted, (_, itemId) =>
            {
                for (var groupIndex = 0; groupIndex < Groups.Count; groupIndex++)
                {
                    for (var itemIndex = 0; itemIndex < Groups[groupIndex].Count; itemIndex++)
                    {
                        if (itemId == Groups[groupIndex][itemIndex].Id)
                        {
                            Groups[groupIndex].RemoveAt(itemIndex);
                            return;
                        }
                    }
                }
            });
        }

        private void unregisterReceivers()
        {
            MessagingCenter.Unsubscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemAdded);
            MessagingCenter.Unsubscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemChanged);
            MessagingCenter.Unsubscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemDeleted);
        }
    }
}
