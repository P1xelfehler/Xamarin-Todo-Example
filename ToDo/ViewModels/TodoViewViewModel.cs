using System.Windows.Input;
using ToDo.DataStore;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class TodoViewViewModel
    {
        private INavigation Navigation;

        public ToDoItem Item { private set; get; }

        public string ChangeStateButtonTitle => Item.IsChecked ? "Doch nicht erledigt" : "Erledigt";

        public ICommand DeleteCommand { private set; get; }

        public ICommand ChangeStateCommand { private set; get; }

        public TodoViewViewModel(ToDoItem item, INavigation navigation)
        {
            Item = item;
            Navigation = navigation;
            DeleteCommand = new Command((parameters) =>
            {
                DataStorage
                    .GetInstance()
                    .RemoveItem(Item.Id);
                Navigation.PopAsync();
            });
            ChangeStateCommand = new Command(() =>
            {
                var todoItem = Item;
                item.IsChecked = !todoItem.IsChecked;
                DataStorage
                    .GetInstance()
                    .UpdateItem(item);
                Navigation.PopAsync();
            });
        }
    }
}
