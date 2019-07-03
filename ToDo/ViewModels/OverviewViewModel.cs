using System.Collections.Generic;
using ToDo.Model;

namespace ToDo.Pages.Overview.ViewModels
{
    public class OverviewViewModel
    {
        public List<TodoGroup> Groups { get; } = new List<TodoGroup> {
            new TodoGroup("Unerledigt"),
            new TodoGroup("Erledigt")
        };

        public void LoadItems()
        {
            var items = DataStorage
                .GetInstance()
                .FetchItems();
            Groups.ForEach(group => group.Clear());
            items.ForEach(item => Groups[item.IsChecked ? 1 : 0].Add(item));
        }
    }
}
