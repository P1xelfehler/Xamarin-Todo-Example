using System;
using ToDo.DataStore;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Pages.ToDoView
{
    public partial class TodoViewPage : ContentPage
    {
        private TodoViewViewModel viewModel;

        public TodoViewPage(ToDoItem item)
        {
            InitializeComponent();
            viewModel = new TodoViewViewModel(item, Navigation);
            BindingContext = viewModel;
        }
    }
}
