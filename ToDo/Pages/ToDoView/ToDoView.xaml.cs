using System;
using System.Collections.Generic;
using ToDo.DataStore;
using Xamarin.Forms;

namespace ToDo.Pages.ToDoView
{
    public partial class ToDoView : ContentPage
    {
        private ToDoItem item;

        public ToDoView(ToDoItem item)
        {
            this.item = item;
            InitializeComponent();
            BindingContext = this.item;
        }

        public void DeleteButtonTapped(object sender, EventArgs args)
        {
            DataStorage
                .getInstance()
                .RemoveItem(item.Id);
            Navigation.PopAsync();
        }

        public void DoneButtonTapped(object sender, EventArgs args)
        {
            item.IsChecked = true;
            DataStorage
                .getInstance()
                .UpdateItem(item);
            Navigation.PopAsync();
        }
    }
}
