using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
          public class EgresoABMViewModel: BaseViewModel
    {

        #region Properties


        public INavigation Navigation { get; set; }

        ApiStockService apiStockService = new ApiStockService();
        public EgresoStockDTO EgresoStockDTO
        {
            get => GetPropertyValue<EgresoStockDTO>();
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

        public EgresoABMViewModel()
        {


            EgresoStockDTO = new EgresoStockDTO();
            Title = $"Depositos";
            EgresoStockDTO.Mensaje = "";
            EgresoStockDTO.Origen = "";
            LoadDepositos();
            SeleccioneDepositoCommand = new Command<DepositoDTO>(SeleccioneDeposito);
        }

        #endregion

        #region Commands

        public Command Egreso
        {
            get
            {
                return new Command(async () => await Egresotock());
            }
        }


        public Command<DepositoDTO> SeleccioneDepositoCommand { get; set; }

        #endregion

        #region Methods

        public async Task Egresotock()
        {
            try
            {
                ApiStockService apiStockService = new ApiStockService();
                EgresoStockDTO = await apiStockService.SendEgresoStock(EgresoStockDTO);

                if (EgresoStockDTO.HuboError)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", " Ocurrio un error " + EgresoStockDTO.Mensaje, "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Exito", EgresoStockDTO.Mensaje, "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + ex.Message, "OK");
            }
        }




        private async Task LoadDepositos()
        {
            try
            {
                var apiDepositoService = new ApiDepositoService();
                var depositos = await apiDepositoService.GetDepositos();
                ListaDepositos = depositos;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudieron obtener los depósitos: {ex.Message}", "OK");
            }
        }

        private List<DepositoDTO> _listaDepositos;

        public List<DepositoDTO> ListaDepositos
        {
            get => _listaDepositos;
            set => SetProperty(ref _listaDepositos, value);
        }

        private DepositoDTO _selectedDeposito;

        public DepositoDTO SelectedDeposito
        {
            get { return _selectedDeposito; }
            set
            {
                SetProperty(ref _selectedDeposito, value);
                EgresoStockDTO.IdDeposito = _selectedDeposito.Id;
            }
        }

        private void SeleccioneDeposito(DepositoDTO deposito)
        {
            EgresoStockDTO.IdDeposito = deposito.Id;
        }




        #endregion

    }
}


