using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using ToDo.DataStore;
using ToDo.Pages.Create;
using ToDo.Pages.ToDoView;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ToDo
{
    public partial class Overview : ContentPage
    {
        public ObservableCollection<ToDoItem> Items { get; set; } = new ObservableCollection<ToDoItem>();

        public Overview()
        {
            InitializeComponent();

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            Items.Clear();
            DataStorage
                .getInstance()
                .fetchItems()
                .ForEach(x =>
                {
                    if (!Items.Any(item => item.Id == x.Id))
                    {
                        Items.Add(x);
                    }
                });
        }

        public void OnItemTapped(ListView listView, ItemTappedEventArgs args)
        {
            var item = Items[args.ItemIndex];
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
