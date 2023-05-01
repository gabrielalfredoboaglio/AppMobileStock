using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobileStock.Models
{
    public class BaseDTO
    {
        public string Mensaje { get; set; }

        public bool HuboError { get; set; }

        public string Origen { get; set; }

        public BaseDTO()
        {
            this.Mensaje = string.Empty;
        }
    }
}

