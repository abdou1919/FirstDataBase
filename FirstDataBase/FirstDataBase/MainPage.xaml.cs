namespace FirstDataBase
{
    using FirstDataBase.Models;
    using FirstDataBase.Views;
    using System;
    using System.ComponentModel;
    using Xamarin.Forms;
    using ZXing.Net.Mobile.Forms;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        internal string ScanResult;


        public MainPage()
        {  
            InitializeComponent();
            //PushB.Clicked += (sender, e) => { Navigation.PushAsync(new ContactPage()); };
            //PushAdd.Clicked += (sender, e) => { Navigation.PushAsync(new AddContact()); };
        }

        private void OpenScanner(object sender, EventArgs e)
        {
            Scanner();
        }

        public async void Scanner()
        {


            //Note contact = new Note();



            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) =>
            {
                // Interrompi la scansione
                ScannerPage.IsScanning = false;

                // Alert com o código escaneado



                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();


                    ScanResult = result.Text;



                    //DisplayAlert("Codice scansionato", result.Text, "OK");


                    //Note contact = new Note

                    //{
                    //    Text = result.Text,
                    //    Date = DateTime.Now,

                    //    Magazzino = MyPicke.SelectedItem.ToString()

                    //};

                    ReCodeBare.Text = ScanResult;

                    //await App.DataBase.SaveNoteAsync(contact);
                    //MyPicke.IsVisible = true;

                    //await DisplayAlert("Codice scansionato", contact.Text, "OK");
                    //await DisplayAlert("Add", "Contact Added", "OK");






                    //if (contact.Magazzino == null)


                    //{


                    //    await DisplayAlert("Add", "Contact Added", "OK");


                    //}


                    //else 
                    //{

                    //    await App.DataBase.SaveNoteAsync(contact);
                    //}






                });
            };

            await Navigation.PushAsync(ScannerPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {


            if (ScanResult == null || MyPicke.SelectedIndex == -1)
            {

                await DisplayAlert("Errore", "Devi scansionare un prodotto e scegliere un magazzino", "OK");
            }

            else
            {
                string PickerResult = MyPicke.SelectedItem.ToString();

                Note contact = new Note

                {
                    Text = ScanResult,
                    Date = DateTime.Now,
                    Magazzino = PickerResult

                };

                await App.DataBase.SaveNoteAsync(contact);
                await DisplayAlert("", "Elemento aggiunto con successo", "OK");
                ScanResult = null;
                ReCodeBare.Text = null;
                MyPicke.SelectedIndex = -1;
            }
        }
    }
}
