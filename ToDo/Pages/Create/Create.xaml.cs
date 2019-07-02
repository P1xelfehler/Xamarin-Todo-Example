using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDo.Pages.Create
{
    public partial class Create : ContentPage
    {
        public Create()
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
            DataStorage.getInstance().AddItem(title);
            Navigation.PopModalAsync();
        }
    }
}
