using System;
using ToDo.DataStore;
using ToDo.Pages.Create;
using ToDo.Pages.Overview.ViewModels;
using ToDo.Pages.ToDoView;
using Xamarin.Forms;

namespace ToDo
{
    public partial class OverviewPage : ContentPage
    {
        public OverviewViewModel viewModel = new OverviewViewModel();

        public OverviewPage()
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
            var destination = new TodoViewPage(item);
            Navigation.PushAsync(destination);
        }

        public void AddButtonTapped(object sender, EventArgs args)
        {
            var destination = new CreatePage();
            Navigation.PushModalAsync(destination);
        }
    }
}
