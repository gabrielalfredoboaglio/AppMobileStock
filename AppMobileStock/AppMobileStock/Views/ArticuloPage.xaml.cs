using AppMobileStock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileStock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticuloPage : ContentPage
    {
        public ArticuloViewModel viewModel; 

        public ArticuloPage()
        {
            InitializeComponent();
            viewModel = new ArticuloViewModel();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel; 
        }

       
        protected override async void OnAppearing()

        {
            await viewModel.LoadArticulos();

        }
        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new ArticuloABMPage());
        //}
    }
}