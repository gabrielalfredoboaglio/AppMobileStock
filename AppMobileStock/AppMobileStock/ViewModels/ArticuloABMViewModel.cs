using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
    public class ArticuloABMViewModel : BaseViewModel
    {
        #region Properties 
        public INavigation Navigation { get; set; }


        ApiArticuloService articuloService = new ApiArticuloService();

        public ArticuloDTO ArticuloDTO
        { get => GetPropertyValue<ArticuloDTO>();
            set => SetPropertyValue(value);
        }

        public string CodeRead
        {


            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public int Numero
        {
            get => GetPropertyValue<int>();
            set => SetPropertyValue(value);
        }

        #endregion

        #region Constructor
       public ArticuloABMViewModel()
        {
            ArticuloDTO = new ArticuloDTO() ;    
            Title = $"Articulos";
          
        }

        #endregion

        #region Commands
        public Command Agregar
        {
            get
            {
                return new Command(async () => await AgregarArticulo());
            }

        }
        #endregion

        #region Methods

        public async Task AgregarArticulo()
        {

            try
            {
                ApiArticuloService apiArticuloService = new ApiArticuloService();
                ArticuloDTO.Mensaje = "";
                ArticuloDTO.Origen = "";
                ArticuloDTO = await apiArticuloService.SendArticulo(ArticuloDTO);

                if (ArticuloDTO.HuboError)

                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + ArticuloDTO.Mensaje, "Ok");

                }
                else
                {

                    await Application.Current.MainPage.DisplayAlert("Exito", ArticuloDTO.Mensaje, "OK");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + ex.Message, "Ok");
            }
        

        }
        #endregion
    }
}
