using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class DetalleContrato
    {

        public int COD_DETALLE { get; set; }
        public Contrato CONTRATO { get; set; }
        public Servicio SERVICIO { get; set; }
        public int ITEM { get; set; }
        public int CANTIDAD { get; set; }
        public double PRECIO { get; set; }
        public double IMPORTE { get; set; }
        public string ESTADO { get; set; }
        public int DIAS { get; set; }

    }
}
