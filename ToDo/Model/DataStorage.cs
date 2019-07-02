using System.Collections.ObjectModel;
using ToDo.DataStore;

namespace ToDo
{
    public class DataStorage
    {
        private static DataStorage instance;

        private ObservableCollection<ToDoItem> items = new ObservableCollection<ToDoItem> {
            new ToDoItem(0, "Get"),
            new ToDoItem(1, "Shit"),
            new ToDoItem(2, "Done")
        };

        private DataStorage() { }

        public static DataStorage getInstance()
        {
            if (instance == null)
            {
                instance = new DataStorage();
            }
            return instance;
        }

        public ObservableCollection<ToDoItem> fetchItems()
        {
            return items;
        }

        public void AddItem(string title)
        {
            var item = new ToDoItem(items.Count, title);
            items.Add(item);
        }

        public void RemoveItem(int id)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
        }

        public void UpdateItem(ToDoItem item)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Id == item.Id)
                {
                    items[i] = item;
                    break;
                }
            }
        }
    }
}
