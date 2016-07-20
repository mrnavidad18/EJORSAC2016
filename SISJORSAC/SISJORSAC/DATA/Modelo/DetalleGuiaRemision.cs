using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class DetalleGuiaRemision
    {
        public int COD_DETALLE { get; set; }
        public Servicio SERVICIO { get; set; }
        public GuiaRemision GUIA_REMISION { get; set; }
        public int ITEM { get; set; }
        public int CANTIDAD { get; set; }
        public string ESTADO { get; set; }

    }

}
