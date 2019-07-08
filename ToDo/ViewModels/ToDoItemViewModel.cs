using System;
using ToDo.DataStore;

namespace ToDo.ViewModels
{
    public class ToDoItemViewModel
    {
        public ToDoItem Item { get; }

        public string ImageSource => Item.IsChecked ? "check.jpg" : null;

        public ToDoItemViewModel(ToDoItem item)
        {
            Item = item;
        }
    }
}
