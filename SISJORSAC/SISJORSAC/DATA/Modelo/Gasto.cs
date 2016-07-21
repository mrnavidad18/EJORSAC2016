using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class Gasto
    {
        public int COD_GASTO { get; set; }
        public string NRO_GASTO { get; set; }
        public Proveedor PROVEEDOR { get; set; }
        public DateTime FECHA_EGRE { get; set; }
        public string DOC_REF { get; set; }
        public string NRO_DOC_REF { get; set; }
        public string MONEDA { get; set; }
        public string ESTADO { get; set; }
        public List<DetalleGasto> DetalleGASTO { get; set; }

    }
}
