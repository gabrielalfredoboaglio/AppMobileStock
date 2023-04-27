using AppMobileStock.ViewModels;
using AppMobileStock.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppMobileStock
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ArticuloPage), typeof(ArticuloPage));
            Routing.RegisterRoute(nameof(DepositoPage), typeof(DepositoPage));
            Routing.RegisterRoute(nameof(StockPage), typeof(StockPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
