using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstDataBase.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstDataBase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContact : ContentPage
    {
        public AddContact()
        {
            InitializeComponent();

        }

        private async void btnadd_Clicked(object sender, EventArgs e)
        {
            Note contact = new Note

            {

                Text = TxtNote.Text,
                Date= DateTime.Now,
                Magazzino = EntMag.Text
               
            };

            await App.DataBase.SaveNoteAsync(contact);
            await DisplayAlert("Add", "Contact Added", "OK");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.DataBase.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}