using System;
namespace ToDo.DataStore
{
    public struct ToDoItem
    {
        public int Id { get; }
        public string Title { get; }
        public bool IsChecked { get; set; }

        public ToDoItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsChecked = false;
        }
    }
}
