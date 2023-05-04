using AppMobileStock.Models;
using AppMobileStock.Services;
using AppMobileStock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileStock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticuloABMPage : ContentPage
    {

        public ArticuloABMViewModel viewModel;
        public ArticuloABMPage()
        {
            InitializeComponent();
           
            viewModel = new ArticuloABMViewModel();
            
            viewModel.Navigation = Navigation;
            
            BindingContext = viewModel;

        }

    }
}
