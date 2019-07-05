using System;
using ToDo.Constants;
using ToDo.DataStore;
using ToDo.Pages.Create;
using ToDo.Pages.ToDoView;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Pages.Overview
{
    public partial class OverviewPage : ContentPage
    {
        public OverviewPage()
        {
            InitializeComponent();
            BindingContext = new OverviewViewModel(Navigation);
        }
    }
}
