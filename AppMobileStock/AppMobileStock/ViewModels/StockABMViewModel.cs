using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileStock.ViewModels
{
    public class StockABMViewModel : BaseViewModel
    {

        #region Properties

        public INavigation Navigation { get; set; }

        ApiStockService apiStockService = new ApiStockService();
       public IngresoStockDTO IngresoStockDTO
        {
            get => GetPropertyValue<IngresoStockDTO>();
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

        public StockABMViewModel()
        {   
      

            IngresoStockDTO = new IngresoStockDTO();
            Title = $"Depositos";
            IngresoStockDTO.Mensaje = "";
            IngresoStockDTO.Origen = "";
            LoadDepositos();
            SeleccioneDepositoCommand = new Command<DepositoDTO>(SeleccioneDeposito);
        }

        #endregion

        #region Commands

        public Command Agregar
        {
            get
            {
                return new Command(async () => await AgregarStock());
            }
        }


        public Command<DepositoDTO> SeleccioneDepositoCommand { get; set; }

        #endregion

        #region Methods

        public async Task AgregarStock()
        {
            try
            {
                ApiStockService apiStockService = new ApiStockService();
                IngresoStockDTO = await apiStockService.SendStock(IngresoStockDTO);

                if (IngresoStockDTO.HuboError)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", " Ocurrio un error " + IngresoStockDTO.Mensaje, "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Exito", IngresoStockDTO.Mensaje, "OK");
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
                IngresoStockDTO.IdDeposito = _selectedDeposito.Id;
            }
        }

        private void SeleccioneDeposito(DepositoDTO deposito)
        {
            IngresoStockDTO.IdDeposito = deposito.Id;
        }

        



        #endregion

    }
}

