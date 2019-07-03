using System;
using System.Collections.ObjectModel;
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
            var items = DataStorage
                .getInstance()
                .fetchItems();
            viewModel.Clear();
            viewModel.AddItems(items);
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
