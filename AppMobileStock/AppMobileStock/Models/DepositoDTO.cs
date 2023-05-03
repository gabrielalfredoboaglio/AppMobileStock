using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileStock.Models
{
    public class DepositoDTO : BaseDTO
    {

        public int Id { get; set; }
        public decimal? Capacidad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
