using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileStock.Models
{
    public class IngresoStockDTO : BaseDTO
    {

        public int? IdArticulo { get; set; }
        public int? IdDeposito { get; set; }
        public decimal? Cantidad { get; set; }
        public string CodigoArticulo { get; set; }
    }
}
