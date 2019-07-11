using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using ToDo.DataStore;

namespace ToDo.Repositories
{
    public class SqliteDatabase: IDatabase
    {
        private string databasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.db");
        private SQLiteAsyncConnection Connection;

        public SqliteDatabase()
        {
            Connection = new SQLiteAsyncConnection(databasePath);
            Connection.CreateTableAsync<ToDoItem>();
        }

        public async Task Close()
        {
            await Connection.CloseAsync();
        }

        public async Task Delete(int id)
        {
            await Connection.DeleteAsync<ToDoItem>(id);
        }

        public async Task<List<ToDoItem>> FetchItems()
        {
            return await Connection.Table<ToDoItem>().ToListAsync();
        }

        public async Task Insert(ToDoItem item)
        {
            await Connection.InsertAsync(item);
        }

        public async Task Update(ToDoItem item)
        {
            await Connection.UpdateAsync(item);
        }
    }
}
