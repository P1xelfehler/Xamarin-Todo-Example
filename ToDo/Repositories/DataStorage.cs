using System.Collections.Generic;
using ToDo.Constants;
using ToDo.DataStore;
using Xamarin.Forms;

namespace ToDo
{
    public class DataStorage
    {
        private static DataStorage instance;

        private List<ToDoItem> items = new List<ToDoItem> {
            new ToDoItem(0, "Get"),
            new ToDoItem(1, "Shit"),
            new ToDoItem(2, "Done")
        };

        private DataStorage() { }

        public static DataStorage GetInstance()
        {
            if (instance == null)
            {
                instance = new DataStorage();
            }
            return instance;
        }

        public List<ToDoItem> FetchItems()
        {
            return items;
        }

        public void AddItem(string title)
        {
            var item = new ToDoItem(items.Count, title);
            items.Add(item);
            MessagingCenter.Send(this, MessengerKeys.ItemAdded, item);
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
