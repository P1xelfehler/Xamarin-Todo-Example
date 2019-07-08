using System;
using System.Windows.Input;
using ToDo.DataStore;
using ToDo.Repositories;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class TodoViewViewModel
    {
        private INavigation Navigation;

        private Lazy<IDatabase> database = new Lazy<IDatabase> (() => new SqliteDatabase());

        private IDatabase Database => database.Value;

        public ToDoItemViewModel Item { private set; get; }

        public string ChangeStateButtonTitle => Item.Item.IsChecked ? "Doch nicht erledigt" : "Erledigt";

        public ICommand DeleteCommand { private set; get; }

        public ICommand ChangeStateCommand { private set; get; }

        public TodoViewViewModel(ToDoItemViewModel itemViewModel, INavigation navigation)
        {
            Item = itemViewModel;
            Navigation = navigation;
            DeleteCommand = new Command((parameters) =>
            {
                DataStorage
                    .GetInstance(Database)
                    .RemoveItem(itemViewModel.Item.Id);
                Navigation.PopAsync();
            });
            ChangeStateCommand = new Command(() =>
            {
                Item.ToggleChecked();
                DataStorage
                    .GetInstance(Database)
                    .UpdateItem(Item.Item);
                Navigation.PopAsync();
            });
        }
    }
}
