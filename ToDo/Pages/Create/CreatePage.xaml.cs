using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDo.Pages.Create
{
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
        }

        public void AddButtonTapped(object sender, EventArgs args)
        {
            var title = entry.Text;
            if (title == "")
            {
                return;
            }
            DataStorage.GetInstance().AddItem(title);
            Navigation.PopModalAsync();
        }
    }
}
