using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
    public class DepositoABMViewModel : BaseViewModel
    {
        #region Properties 
        public INavigation Navigation { get; set; }

        ApiDepositoService depositoService = new ApiDepositoService();

        public DepositoDTO DepositoDTO
        {
            get => GetPropertyValue<DepositoDTO>();
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
        public DepositoABMViewModel()
        {
            DepositoDTO = new DepositoDTO();
            Title = $"Depositos";
        }

        #endregion

        #region Commands
        public Command Agregar
        {
            get
            {
                return new Command(async () => await AgregarDeposito());
            }
        }
        #endregion

        #region Methods

        public async Task AgregarDeposito()
        {
            try
            {
               
                ApiDepositoService apiDepositoService = new ApiDepositoService();
                DepositoDTO.Mensaje = "";
                DepositoDTO.Origen = "";
                DepositoDTO = await apiDepositoService.SendDeposito(DepositoDTO);

                if (DepositoDTO.HuboError)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un error " + DepositoDTO.Mensaje, "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Exito", DepositoDTO.Mensaje, "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un error " + ex.Message, "Ok");
            }
        }
        #endregion
    }

}
