using System;
using System.Diagnostics;
using System.Windows.Input;
using ToDo.DataStore;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class ToDoItemViewModel
    {
        private ToDoItem item;

        public ToDoItem Item { get => item; }

        public string ImageSource => Item.IsChecked ? "check.jpg" : null;

        public ICommand DeleteCommand { get; }

        public ToDoItemViewModel(ToDoItem item)
        {
            this.item = item;
            DeleteCommand = new Command(parameters =>
            {
                Debug.WriteLine("Delete item");
                Debug.WriteLine(parameters);
            });
        }

        public void ToggleChecked()
        {
            item.IsChecked = !item.IsChecked;
        }
    }
}
