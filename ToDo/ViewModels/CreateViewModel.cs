using System;
using ToDo.Repositories;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class CreateViewModel
    {
        private string entryText = "";

        private Lazy<DataStorage> dataStorage = new Lazy<DataStorage>(() => DataStorage.GetInstance(new SqliteDatabase()));

        private DataStorage DataStorage => dataStorage.Value;

        public Command AddCommand { private set; get; }
        public string EntryText {
            get => entryText;
            set {
                entryText = value;
                AddCommand.ChangeCanExecute();
            }
        }
        private INavigation Navigation { set; get; }

        public CreateViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AddCommand = new Command(() =>
            {
                DataStorage.AddItem(EntryText);
                Navigation.PopModalAsync();
            }, () => EntryText.Length > 0);
        }
    }
}
