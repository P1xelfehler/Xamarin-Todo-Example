using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using ToDo.DataStore;

namespace ToDo.Repositories
{
    public class SqliteDatabase: IDatabase
    {
        private string databasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.db");
        private SQLiteConnection Connection;

        public SqliteDatabase()
        {
            Connection = new SQLiteConnection(databasePath);
            Connection.CreateTable<ToDoItem>();
        }

        public void Close()
        {
            Connection.Close();
        }

        public void Delete(int id)
        {
            Connection.Delete<ToDoItem>(id);
        }

        public List<ToDoItem> FetchItems()
        {
            return Connection.Table<ToDoItem>().ToList();
        }

        public void Insert(ToDoItem item)
        {
            Connection.Insert(item);
        }

        public void Update(ToDoItem item)
        {
            Connection.Update(item);
        }
    }
}
