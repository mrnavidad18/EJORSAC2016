using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class Proveedor
    {

        public int COD_PROV { get; set; }
        public string NOMBRES { get; set; }
        public string AP_PATERNO { get; set; }
        public string AP_MATERNO { get; set; }
        public string DNI { get; set; }
        public string  RUC { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string DIRECCION { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string PROVINCIA { get; set; }
        public string DISTRITO { get; set; }
        public string TELF_FIJO_CASA { get; set; }
        public string TELF_FIJO_OFICINA { get; set; }
        public string CELULAR { get; set; }
        public string EMAIL { get; set; }
        public string OBSERVACIONES { get; set; }
        public string TIPO_PRO { get; set; }
        public string ESTADO { get; set; }
    }
}
