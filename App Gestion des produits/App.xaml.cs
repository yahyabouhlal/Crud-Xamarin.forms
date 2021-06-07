using App_Gestion_des_produits.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Gestion_des_produits
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new ShowProducts());
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
