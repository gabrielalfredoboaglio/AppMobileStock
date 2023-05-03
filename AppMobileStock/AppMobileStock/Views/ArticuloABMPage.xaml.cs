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
    public partial class ArticuloABMPage : ContentPage
    {
        public ArticuloABMPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                ArticuloDTO articuloDTOAAgregar = new ArticuloDTO();
                articuloDTOAAgregar.Nombre = txtNombre.Text;
                articuloDTOAAgregar.Marca = txtMarca.Text;
                articuloDTOAAgregar.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
                articuloDTOAAgregar.Proveedor = txtProveedor.Text;
                articuloDTOAAgregar.Precio = Convert.ToDecimal(txtPrecio.Text);
                articuloDTOAAgregar.Codigo = txtCodigo.Text;
                articuloDTOAAgregar.Mensaje = "Nuevo artículo agregado correctamente";
                articuloDTOAAgregar.Origen = "-";


                if (articuloDTOAAgregar != null)
                {
                    ApiArticuloService apiArticuloService = new ApiArticuloService();

                    articuloDTOAAgregar = await apiArticuloService.SendArticulo(articuloDTOAAgregar);

                    if (articuloDTOAAgregar != null && articuloDTOAAgregar.HuboError)
                    {
                        await DisplayAlert("Error", "Ocurrió un error" + articuloDTOAAgregar.Mensaje, "OK");
                    }
                    else
                    {
                        await DisplayAlert("Mensaje", "Artículo agregado correctamente.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error al agregar el artículo: " + ex.Message, "OK");
            }
        }


    }
}
