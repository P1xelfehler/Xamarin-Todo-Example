using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDo.DataStore;
using ToDo.Model;
using ToDo.Pages.Create;
using ToDo.Pages.ToDoView;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ToDo
{
    public partial class Overview : ContentPage
    {
        //public ObservableCollection<ToDoItem> Items { get; set; } = new ObservableCollection<ToDoItem>();
        public List<TodoGroup> Groups { get; } = new List<TodoGroup> {
            new TodoGroup("Unerledigt"),
            new TodoGroup("Erledigt")
        };

        public Overview()
        {
            InitializeComponent();

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            Groups.ForEach(group => group.Clear());
            DataStorage
                .getInstance()
                .fetchItems()
                .ForEach(item => Groups[item.IsChecked ? 1 : 0].Add(item));
        }

        public void OnItemTapped(ListView _, ItemTappedEventArgs args)
        {
            var item = (ToDoItem) args.Item;
            var destination = new ToDoView(item);
            Navigation.PushAsync(destination);
        }

        public void AddButtonTapped(object sender, EventArgs args)
        {
            var destination = new Create();
            Navigation.PushModalAsync(destination);
        }

        private int indexOf(ToDoItem item, Collection<ToDoItem> collection)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                if (collection[i].Id == item.Id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
