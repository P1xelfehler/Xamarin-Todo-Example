using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ToDo.Constants;
using ToDo.DataStore;
using ToDo.Repositories;
using Xamarin.Forms;

namespace ToDo
{
    public class DataStorage
    {
        private static DataStorage instance;

        private IDatabase Database;

        private DataStorage(IDatabase database) {
            Database = database;
        }

        ~DataStorage() {
            Database.Close();
        }

        public static DataStorage GetInstance(IDatabase database)
        {
            if (instance == null)
            {
                instance = new DataStorage(database);
            }
            return instance;
        }

        public List<ToDoItem> FetchItems() => Database.FetchItems();

        public void AddItem(string title)
        {
            var item = new ToDoItem(0, title);
            Database.Insert(item);
            MessagingCenter.Send(this, MessengerKeys.ItemAdded, item);
        }

        public void RemoveItem(int id)
        {
            Database.Delete(id);
            MessagingCenter.Send(this, MessengerKeys.ItemDeleted, id);
        }

        public void UpdateItem(ToDoItem item)
        {
            Database.Update(item);
            MessagingCenter.Send(this, MessengerKeys.ItemChanged, item);
        }
    }
}
