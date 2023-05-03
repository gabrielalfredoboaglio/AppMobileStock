using AppMobileStock.Models;
using AppMobileStock.Services;
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
    public partial class DepositoAMBPage : ContentPage
    {
        public DepositoAMBPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                DepositoDTO depositoDTOAAgregar = new DepositoDTO();
                depositoDTOAAgregar.Nombre = txtNombre.Text;
                depositoDTOAAgregar.Direccion = txtDireccion.Text;
                depositoDTOAAgregar.Capacidad = Convert.ToInt32(txtCapacidad.Text);
                depositoDTOAAgregar.Mensaje = "-";
                depositoDTOAAgregar.Origen = "-";


                if (depositoDTOAAgregar != null)
                {
                    ApiDepositoService apiDepositoService = new ApiDepositoService();

                    depositoDTOAAgregar = await apiDepositoService.SendDeposito(depositoDTOAAgregar);

                    if (depositoDTOAAgregar != null && depositoDTOAAgregar.HuboError)
                    {
                        await DisplayAlert("Error", "Ocurrió un error" + depositoDTOAAgregar.Mensaje, "OK");
                    }
                    else
                    {
                        await DisplayAlert("Mensaje", "Depósito agregado correctamente.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error al agregar el depósito: " + ex.Message, "OK");
            }
        }
    }
}