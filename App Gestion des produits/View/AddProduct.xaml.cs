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
    public partial class AddProduct : ContentPage
    {
        ProductService _services;
        bool _isUpdate;
        int productID;
        public AddProduct()
        {
            InitializeComponent();
            _services = new ProductService();
            _isUpdate = false;
        }

        public AddProduct(Products obj)
        {
            InitializeComponent();
            _services = new ProductService();
            if (obj != null)
            {
                //obj.Id = productID;
                //obj.Name = txtName.Text;
                //obj.Prix = Int16.Parse(txtPrix.Text);
                //obj.stock = Int16.Parse(txtStock.Text);
                productID = obj.Id;
                txtName.Text = obj.Name;
                txtPrix.Text = obj.Prix.ToString();
                txtStock.Text = obj.stock.ToString();
                //txtAddress.Text = obj.Address;
                _isUpdate = true;
            }
        }

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Products prd = new Products();
            prd.Name = txtName.Text;
            prd.Prix = Int16.Parse(txtPrix.Text);
            prd.stock = Int16.Parse(txtStock.Text);
            if (_isUpdate)
            {
                prd.Id = productID;
                await _services.UpdateProduct(prd);
            }
            else
            {
                _services.InsertProduct(prd);
            }
            await this.Navigation.PopAsync();
        }
    }
}