using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class GuiaRemision
    {
        public int COD_GUIA { get; set; }
        public string NRO_GUIA { get; set; }
        public Chofer CHOFER { get; set; }
        public DateTime FECHA_EMISION { get; set; }
        public string PTO_PARTIDA { get; set; }
        public string PTO_LLEGADA { get; set; }
        public Cliente cliente { get; set; }
        public string VEHICULO_MARCA { get; set; }
        public string NRO_CERTIFICADO { get; set; }
        public string NONBRE_CONDUCTOR { get; set; }
        public string NRO_BREVETE { get; set; }
        public string NOMB_TRANSPORTE { get; set; }
        public string RUC_TRANSPORTE { get; set; }
        public string TIPO_COMPROB { get; set; }
        public string TIPO_TRASLADO { get; set; }
        public string MTO_TRASLADO { get; set; }
        public string PROVINCIA { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string DISTRITO { get; set; }
        public string SITUACION { get; set; }
        public string ESTADO { get; set; }
        public string CLIENTEJURIDICONATURAL { get;set;}

        public List<DetalleGuiaRemision> DETALLEGUIAREMISION { get; set; }
      
    }
}
