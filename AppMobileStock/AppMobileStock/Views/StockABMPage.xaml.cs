using AppMobileStock.Models;
using AppMobileStock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace AppMobileStock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockABMPage : ContentPage
    {
        public StockABMPage()
        {
            InitializeComponent();
        }

        private  async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                IngresoStockDTO stockAAgregar = new IngresoStockDTO();
               
            
                stockAAgregar.IdDeposito = Convert.ToInt32(txtIdDeposito.Text);
                stockAAgregar.Mensaje = "-";
                stockAAgregar.CodigoArticulo = txtCodigo.Text;
                stockAAgregar.Cantidad = Convert.ToInt32(txtCantidad.Text);
                stockAAgregar.Origen= "-";



                if (stockAAgregar != null)
                {
                    ApiStockService apiStockService = new ApiStockService();    

                    stockAAgregar = await apiStockService.SendStock(stockAAgregar);

                    if (stockAAgregar != null && stockAAgregar.HuboError)
                    {
                        await DisplayAlert("Error", "Ocurrió un error" + stockAAgregar.Mensaje, "OK");
                    }
                    else
                    {
                        await DisplayAlert("Mensaje", "Stock agregado correctamente.", "OK");
                    }
                }
            }

            catch (Exception ex)
            {

                DisplayAlert("Error", "Ocurrio un error " + ex.Message, "Ok");
            }
            }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {

                EgresoStockDTO stockExistente = new EgresoStockDTO();


                stockExistente.IdDeposito = Convert.ToInt32(txtIdDeposito.Text);
                stockExistente.Mensaje = "-";
                stockExistente.CodigoArticulo = txtCodigo.Text;
                stockExistente.Cantidad = Convert.ToInt32(txtCantidad.Text);
                stockExistente.Origen = "-";

                if (stockExistente != null)
                {
                    ApiStockService apiStockService = new ApiStockService();

                    stockExistente = await apiStockService.SendEgresoStock(stockExistente);

                    if (stockExistente != null && stockExistente.HuboError)
                    {
                        await DisplayAlert("Error", "Ocurrió un error" + stockExistente.Mensaje, "OK");
                    }
                    else
                    {
                        await DisplayAlert("Mensaje", "Stock agregado correctamente.", "OK");
                    }
                }
            }

            catch (Exception ex)
            {

                DisplayAlert("Error", "Ocurrio un error " + ex.Message, "Ok");
            }
        }
    }
            
        }
  