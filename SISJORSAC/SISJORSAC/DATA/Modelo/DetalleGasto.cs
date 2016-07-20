using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class DetalleGasto
    {
        public int COD_DETALLE { get; set; }
        public Gasto GASTO { get; set; }

        public ConceptoGasto ConceptoGasto { get; set; }
        public int ITEM { get; set; }
        public int CANTIDAD { get; set; }
        public int PRECIO { get; set; }

    }
}
