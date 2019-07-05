using System;
using ToDo.DataStore;
using ToDo.Pages.Create;
using ToDo.Pages.ToDoView;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Pages.Overview
{
    public partial class OverviewPage : ContentPage
    {
        public OverviewViewModel viewModel { private set; get; }

        public OverviewPage()
        {
            InitializeComponent();
            viewModel = new OverviewViewModel(Navigation);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            viewModel.LoadItems();
        }
    }
}
