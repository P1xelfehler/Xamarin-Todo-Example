using System.Collections.Generic;
using ToDo.DataStore;
using ToDo.Model;

namespace ToDo.Pages.Overview.ViewModels
{
    public class OverviewViewModel
    {
        public List<TodoGroup> Groups { get; } = new List<TodoGroup> {
            new TodoGroup("Unerledigt"),
            new TodoGroup("Erledigt")
        };

        public void Clear()
        {
            Groups.ForEach(group => group.Clear());
        }

        public void AddItems(List<ToDoItem> items)
        {
            items.ForEach(item => Groups[item.IsChecked ? 1 : 0].Add(item));
        }
    }
}
