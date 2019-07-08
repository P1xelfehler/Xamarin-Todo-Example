using System;
using ToDo.Repositories;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class CreateViewHolder
    {
        private string entryText = "";

        private Lazy<IDatabase> database = new Lazy<IDatabase>(() => new SqliteDatabase());

        private IDatabase Database => database.Value;

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
                    .GetInstance(Database)
                    .AddItem(EntryText);
                Navigation.PopModalAsync();
            }, () => EntryText.Length > 0);
        }
    }
}
