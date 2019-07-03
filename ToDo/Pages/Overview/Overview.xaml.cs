using System;
using ToDo.DataStore;
using ToDo.Pages.Create;
using ToDo.Pages.Overview.ViewModels;
using ToDo.Pages.ToDoView;
using Xamarin.Forms;

namespace ToDo
{
    public partial class Overview : ContentPage
    {
        public OverviewViewModel viewModel = new OverviewViewModel();

        public Overview()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            viewModel.LoadItems();
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
    }
}
