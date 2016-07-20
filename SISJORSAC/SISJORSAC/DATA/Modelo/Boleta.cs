using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
   public class Boleta
    {

        public int NRO_CP { get; set; }
        public DateTime FECHA_EMISION { get; set; }
        public string NRO_BOLETA { get; set; }

        public Cliente cliente { get; set; }
        public string MODALIDAD { get; set; }
        public string OBSERVACION { get; set; }
        public double TOTAL { get; set; }

        public string ESTADO { get; set; }

        public List<DetalleBoleta> DETALLEBOLETA { get; set; }
    }
}
