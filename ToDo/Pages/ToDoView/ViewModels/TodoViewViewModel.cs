using System;
using ToDo.DataStore;

namespace ToDo.Pages.ToDoView.ViewModels
{
    public class TodoViewViewModel
    {
        public ToDoItem Item { get; }

        public TodoViewViewModel(ToDoItem item)
        {
            Item = item;
        }
    }
}
