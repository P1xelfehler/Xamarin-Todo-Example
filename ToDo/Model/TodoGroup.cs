using System.Collections.ObjectModel;
using ToDo.ViewModels;

namespace ToDo.Model
{
    public class TodoGroup: ObservableCollection<ToDoItemViewModel>
    {
        public string Title { get; }

        public TodoGroup(string title)
        {
            Title = title;
        }
    }
}
