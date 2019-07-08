using ToDo.DataStore;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Pages.ToDoView
{
    public partial class TodoViewPage : ContentPage
    {
        private TodoViewViewModel viewModel;

        public TodoViewPage(ToDoItemViewModel itemViewModel)
        {
            InitializeComponent();
            viewModel = new TodoViewViewModel(itemViewModel, Navigation);
            BindingContext = viewModel;
        }
    }
}
