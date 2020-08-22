using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstDataBase.Views;
using FirstDataBase.Models;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstDataBase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
       
    }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.DataBase.GetNotesAsync();
        }



        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddContact
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }


    }
}