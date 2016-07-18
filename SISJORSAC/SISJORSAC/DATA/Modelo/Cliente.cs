using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    class Cliente
    {

                public int COD_CLI { get; set; }
                public int NOMBRES { get; set; }
                public int AP_PATERNO { get; set; }
                public int AP_MATERNO { get; set; }

                public int DNI { get; set; }
                public int RUC { get; set; }
                public int RAZON_SOCIAL { get; set; }
                public int DIRECCION { get; set; }
                public int DEPARTAMENTO { get; set; }
                public int PROVINCIA { get; set; }

                public int DISTRITO { get; set; }        
                public int TEL_FIJO_CASA { get; set;}
                public int TEL_FIJO_OFICINA { get; set; }
                public int CELULAR { get; set; }
                public int EMAIL { get; set; }

                public int OBSERVACIONES { get; set; }
                public int TIPO_CLIE { get; set; }
    
    }
}
