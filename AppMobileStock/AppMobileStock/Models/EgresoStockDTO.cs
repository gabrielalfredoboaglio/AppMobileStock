using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileStock.Models
{
    public class EgresoStockDTO : BaseDTO

    {
        public int? IdDeposito { get; set; }
        public decimal? Cantidad { get; set; }
        public string CodigoArticulo { get; set; }


    }
}
