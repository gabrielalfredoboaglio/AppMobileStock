using AppMobileStock.Models;
using AppMobileStock.Services;
using AppMobileStock.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
    public class ArticuloViewModel : BaseViewModel
    {

        #region Properties

        public INavigation Navigation { get; set; }

        ApiArticuloService apiArticuloService = new ApiArticuloService();   

        public ObservableCollection<ArticuloDTO> Articulos
        {

            get => GetPropertyValue<ObservableCollection<ArticuloDTO>>();
            set => SetPropertyValue(value);

        }



        #endregion

        #region Constructor

        public ArticuloViewModel() {
            Articulos = new ObservableCollection<ArticuloDTO>();
            Title = $"Listado Articulos"
;         }
        #endregion

        #region Commands

        public Command NuevoArticulo
        {
            get
            {
                return new Command(async () => await GoToABMPage());

            }

        }
        #endregion

        #region Methods
        public async Task LoadArticulos()
        {
            if (IsBusy) return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {

                List<ArticuloDTO> articulosList = await apiArticuloService.GetArticulos();
                Articulos = new ObservableCollection<ArticuloDTO>(articulosList);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", " Ocurrio un error " + ex.Message, "OK");

            }
            finally { IsBusy = false; }     

        }



        public async Task GoToABMPage()
        {
            await Navigation.PushAsync(new ArticuloABMPage());

        }

        #endregion
    }
}
