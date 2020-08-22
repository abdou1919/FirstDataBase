using FirstDataBase.Models;
using FirstDataBase.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;




namespace FirstDataBase
{
         

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            


            InitializeComponent();
            PushB.Clicked += (sender, e) => { Navigation.PushAsync(new ContactPage()); };
            PushAdd.Clicked += (sender, e) => { Navigation.PushAsync(new AddContact()); };

        }

        private void OpenScanner(object sender, EventArgs e)
        {
            Scanner();
        }

        public async void Scanner()
        {
            
            
            //Note contact = new Note();



            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) => {
                // Interrompi la scansione
                ScannerPage.IsScanning = false;

                // Alert com o código escaneado
                
               
                
                Device.BeginInvokeOnMainThread(async () => {
                    await Navigation.PopAsync();



                    //DisplayAlert("Codice scansionato", result.Text, "OK");


                    Note contact = new Note

                    {
                       Text = result.Text,
                       Date = DateTime.Now
                };

                    await App.DataBase.SaveNoteAsync(contact);
                    ReCodeBare.Text = result.Text;
                    //await DisplayAlert("Codice scansionato", contact.Text, "OK");
                    //await DisplayAlert("Add", "Contact Added", "OK");




                });
            };

            
            
            await Navigation.PushAsync(ScannerPage);
            

        }

        private void AlertCode(object sender, EventArgs e)
        {
            

            if (ReCodeBare.Text == null)
            {
               
                DisplayAlert("Vuoto", "Scanna un articolo", "OK");

            }
            else {

                TestV.IsVisible = true;
                




                //DisplayAlert("Codice scansionato", ReCodeBare.Text, "OK");



            }
        }
    }
}

