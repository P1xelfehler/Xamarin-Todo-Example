using System.Collections.ObjectModel;
using ToDo.DataStore;

namespace ToDo.Model
{
    public class TodoGroup: ObservableCollection<ToDoItem>
    {
        public string Title { get; }

        public TodoGroup(string title)
        {
            Title = title;
        }
    }
}
