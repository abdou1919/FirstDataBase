using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FirstDataBase.Models;
using FirstDataBase.Views;
using System.IO;
namespace FirstDataBase
{
    public partial class App : Application
    {

        static NoteDatabase dataBase;
        public static NoteDatabase DataBase
        {
            get {

                if (dataBase == null)
                { 
                    
                 dataBase = new NoteDatabase
                        (Path.Combine
                        (Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData),"Contact.db3"));
                
                 }
                return dataBase;
                        }
        }



        public App()
        {
            InitializeComponent();




            //MainPage = new NavigationPage( MainPage = new TabbedPage
            //{


            //                            Children =
            //                            {
            //                                new MainPage(),
            //                                new ContactPage()

            //                            }
            //                        }) ;


            //MainPage = new NavigationPage(new FirstDataBase.MainPage());

            MainPage = new NavigationPage(new FirstDataBase.MyTabbedPage());




            //MainPage = new TabbedPage
            //{


            //    Children =
            //    {
            //        new MainPage(),
            //        new ContactPage()

            //    }
            //};


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
