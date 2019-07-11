using System;
using System.Windows.Input;
using ToDo.DataStore;
using ToDo.Repositories;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class ToDoItemViewModel
    {
        private Lazy<DataStorage> dataStorage = new Lazy<DataStorage>(() => DataStorage.GetInstance(new SqliteDatabase()));

        private DataStorage DataStorage => dataStorage.Value;

        private ToDoItem item;

        public ToDoItem Item { get => item; }

        public string ImageSource => Item.IsChecked ? "check.jpg" : null;

        public ICommand DeleteCommand { get; }

        public ToDoItemViewModel(ToDoItem item)
        {
            this.item = item;
            DeleteCommand = new Command(parameters =>
            {
                DataStorage.RemoveItem(item.Id);
            });
        }

        public void ToggleChecked()
        {
            item.IsChecked = !item.IsChecked;
        }
    }
}
