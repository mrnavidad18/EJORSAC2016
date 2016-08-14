using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class DetalleFactura
    {

        public int COD_DETALLE { get; set; }
        public int ITEM { get; set; }
        public Servicio SERVICIO { get; set; }
        public Factura FACTURA { get; set; }
        public int CANTIDAD { get; set; }
        public int DIAS { get; set; }
        public double PRECIO { get; set; }
        public double IMPORTE { get; set; }
        public string ESTADO { get; set; }
        
    }
}
