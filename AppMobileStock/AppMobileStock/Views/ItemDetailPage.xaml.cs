using AppMobileStock.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppMobileStock.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}