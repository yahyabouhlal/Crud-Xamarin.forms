using App_Gestion_des_produits.Model;
using App_Gestion_des_produits.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Gestion_des_produits.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProducts : ContentPage
    {
        ProductService services;
        public ShowProducts()
        {
            InitializeComponent();
            services = new ProductService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showProduct();
        }

        private void showProduct()
        {
            var res = services.GetProducts().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddProduct());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Products obj = (Products)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddProduct(obj));
                        break;
                    case "Delete":
                        services.DeleteEmployee(obj);
                        showProduct();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}