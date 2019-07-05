using System.Windows.Input;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class CreateViewHolder
    {
        public ICommand AddCommand { private set; get; }
        public string EntryText { get; set; }
        private INavigation Navigation { set; get; }

        public CreateViewHolder(INavigation navigation)
        {
            Navigation = navigation;
            AddCommand = new Command(() =>
            {
                DataStorage
                    .GetInstance()
                    .AddItem(EntryText);
                Navigation.PopModalAsync();
            });
        }
    }
}
