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
	public partial class EgresoStockABMPage : ContentPage
	{

		public EgresoABMViewModel viewModel;
        public EgresoStockABMPage ()
		{
			InitializeComponent ();
           
			viewModel = new EgresoABMViewModel();
			
			viewModel.Navigation = Navigation;
			
			BindingContext = viewModel;




        }
	}
}