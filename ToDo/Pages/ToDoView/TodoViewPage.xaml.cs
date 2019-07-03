using System;
using System.Collections.Generic;
using ToDo.DataStore;
using ToDo.Pages.ToDoView.ViewModels;
using Xamarin.Forms;

namespace ToDo.Pages.ToDoView
{
    public partial class TodoViewPage : ContentPage
    {
        private TodoViewViewModel viewModel;

        public TodoViewPage(ToDoItem item)
        {
            InitializeComponent();
            viewModel = new TodoViewViewModel(item);
            BindingContext = viewModel;
        }

        public void DeleteButtonTapped(object sender, EventArgs args)
        {
            DataStorage
                .getInstance()
                .RemoveItem(viewModel.Item.Id);
            Navigation.PopAsync();
        }

        public void DoneButtonTapped(object sender, EventArgs args)
        {
            var item = viewModel.Item;
            item.IsChecked = !item.IsChecked;
            DataStorage
                .getInstance()
                .UpdateItem(item);
            Navigation.PopAsync();
        }
    }
}
