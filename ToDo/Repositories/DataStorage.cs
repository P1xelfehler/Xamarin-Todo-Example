using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SQLite;
using ToDo.Constants;
using ToDo.DataStore;
using Xamarin.Forms;

namespace ToDo
{
    public class DataStorage
    {
        private static DataStorage instance;

        private string databasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.db");

        private SQLiteConnection database;

        private SQLiteConnection Database => database ?? (database = new SQLiteConnection(databasePath));

        private DataStorage() {
            Database.CreateTable<ToDoItem>();
            Debug.WriteLine(databasePath);
        }

        ~DataStorage() {
            Database.Close();
        }

        public static DataStorage GetInstance()
        {
            if (instance == null)
            {
                instance = new DataStorage();
            }
            return instance;
        }

        public List<ToDoItem> FetchItems() => Database.Table<ToDoItem>().ToList();

        public void AddItem(string title)
        {
            var item = new ToDoItem(0, title);
            Database.Insert(item);
            MessagingCenter.Send(this, MessengerKeys.ItemAdded, item);
        }

        public void RemoveItem(int id)
        {
            Database.Delete<ToDoItem>(id);
            MessagingCenter.Send(this, MessengerKeys.ItemDeleted, id);
        }

        public void UpdateItem(ToDoItem item)
        {
            Database.Update(item);
            MessagingCenter.Send(this, MessengerKeys.ItemChanged, item);
        }
    }
}
