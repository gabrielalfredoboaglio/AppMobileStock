using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileStock.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArticuloPage());
        }

        private void Deposito_Clicked(object sender, EventArgs e)
        {
            // Aquí es donde puedes agregar la lógica para navegar a la página de depósitos
            Navigation.PushAsync(new DepositoPage());
        }
        private void Stock_Clicked(object sender, EventArgs e)
        {
            // Aquí es donde puedes agregar la lógica para navegar a la página de depósitos
            Navigation.PushAsync(new StockPage());
        }
    }
}