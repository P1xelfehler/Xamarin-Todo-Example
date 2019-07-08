using SQLite;

namespace ToDo.DataStore
{
    public struct ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; }
        public string Title { get; }
        public bool IsChecked { get; set; }
        public string ImageSource
        {
            get
            {
                return IsChecked ? "check.jpg" : null;
            }
        }

        public ToDoItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsChecked = false;
        }
    }
}
