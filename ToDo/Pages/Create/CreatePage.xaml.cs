using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Pages.Create
{
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
            BindingContext = new CreateViewHolder(Navigation);
        }
    }
}
