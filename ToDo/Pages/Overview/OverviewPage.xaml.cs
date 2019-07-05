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
