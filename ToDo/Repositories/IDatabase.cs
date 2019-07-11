using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.DataStore;

namespace ToDo.Repositories
{
    public interface IDatabase
    {
        Task<List<ToDoItem>> FetchItems();

        Task Insert(ToDoItem item);

        Task Update(ToDoItem item);

        Task Delete(int id);

        Task Close();
    }
}
