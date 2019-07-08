using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class CreateViewHolder
    {
        private string entryText = "";

        public Command AddCommand { private set; get; }
        public string EntryText {
            get => entryText;
            set {
                entryText = value;
                AddCommand.ChangeCanExecute();
            }
        }
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
            }, () => EntryText.Length > 0);
        }
    }
}
