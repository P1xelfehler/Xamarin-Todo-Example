using System;
using ToDo.DataStore;

namespace ToDo.ViewModels
{
    public class ToDoItemViewModel
    {
        private ToDoItem item;

        public ToDoItem Item { get => item; }

        public string ImageSource => Item.IsChecked ? "check.jpg" : null;

        public ToDoItemViewModel(ToDoItem item)
        {
            this.item = item;
        }

        public void ToggleChecked()
        {
            item.IsChecked = !item.IsChecked;
        }
    }
}
