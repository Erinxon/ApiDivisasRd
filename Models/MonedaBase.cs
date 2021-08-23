using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDivisas.Models
{
    public class MonedaBase
    {
        public string Compra { get; set; }
        public string Venta { get; set; }
        public string UltimaActualizacion { get; set; }
    }
}
