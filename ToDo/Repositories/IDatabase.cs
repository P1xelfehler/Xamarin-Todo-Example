using System;
using System.Collections.Generic;
using ToDo.DataStore;

namespace ToDo.Repositories
{
    public interface IDatabase
    {
        List<ToDoItem> FetchItems();

        void Insert(ToDoItem item);

        void Update(ToDoItem item);

        void Delete(int id);

        void Close();
    }
}
