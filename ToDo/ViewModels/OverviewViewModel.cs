using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Constants;
using ToDo.DataStore;
using ToDo.Model;
using ToDo.Pages.Create;
using ToDo.Pages.ToDoView;
using ToDo.Repositories;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class OverviewViewModel
    {
        public ICommand AddCommand { get; }
        public ICommand ItemSelectedCommand { get; }
        public ICommand DeleteCommand { get; }
        public INavigation Navigation { get; }

        private Lazy<IDatabase> database = new Lazy<IDatabase>(() => new SqliteDatabase());

        private IDatabase Database => database.Value;

        public List<TodoGroup> Groups { get; } = new List<TodoGroup> {
            new TodoGroup("Unerledigt"),
            new TodoGroup("Erledigt")
        };

        public OverviewViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AddCommand = new Command(add);
            ItemSelectedCommand = new Command(showTodo);
            DeleteCommand = new Command(parameters =>
            {
                Debug.WriteLine("Delete item");
                Debug.WriteLine(parameters);
            });
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
            var item = (ToDoItemViewModel)eventArgs.Item;
            var destination = new TodoViewPage(item);
            Navigation.PushAsync(destination);
        }

        private void loadItems()
        {
            var task = DataStorage
                .GetInstance(Database)
                .FetchItems();

            Task.Run(async () =>
            {
                var items = await DataStorage.GetInstance(Database).FetchItems();

                Device.BeginInvokeOnMainThread(() =>
                {
                    items.ForEach(item => Groups[item.IsChecked ? 1 : 0].Add(new ToDoItemViewModel(item)));
                });
            });
            
        }

        private void registerReceivers()
        {
            // item added
            MessagingCenter.Subscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemAdded, (_, item) =>
            {
                Groups[item.IsChecked ? 1 : 0].Insert(0, new ToDoItemViewModel(item));
            });
            // item changed
            MessagingCenter.Subscribe<DataStorage, ToDoItem>(this, MessengerKeys.ItemChanged, (_, item) =>
            {
                for (var groupIndex = 0; groupIndex < Groups.Count; groupIndex++)
                {
                    for (var itemIndex = 0; itemIndex < Groups[groupIndex].Count; itemIndex++)
                    {
                        if (item.Id == Groups[groupIndex][itemIndex].Item.Id)
                        {
                            var targetGroupIndex = item.IsChecked ? 1 : 0;
                            if (groupIndex == targetGroupIndex)
                            {
                                Groups[groupIndex][itemIndex] = new ToDoItemViewModel(item);
                            } else
                            {
                                Groups[groupIndex].RemoveAt(itemIndex);
                                Groups[targetGroupIndex].Insert(0, new ToDoItemViewModel(item));
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
                        if (itemId == Groups[groupIndex][itemIndex].Item.Id)
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
