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
    public partial class DepositoPage : ContentPage
    {

        public DepositoViewModel viewModel;
        public DepositoPage()
        {
            InitializeComponent();
            viewModel = new DepositoViewModel();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()

        {
            await viewModel.LoadDepositos();

        }
     

    }
}