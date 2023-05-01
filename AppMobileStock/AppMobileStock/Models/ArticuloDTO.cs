using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileStock.Models
{
    public class ArticuloDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Nombre { set; get; }

        public string Marca { get; set; }

        public decimal MinimoStock { get; set; }
        public string Proveedor { get; set; }

        public decimal Precio { get; set; }

        public string Codigo { get; set; }

        
    }
}

