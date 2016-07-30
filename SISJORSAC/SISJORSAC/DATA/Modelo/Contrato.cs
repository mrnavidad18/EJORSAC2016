using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class Contrato
    {
        public int COD_CONTRATO { get; set; }
        public string NRO_CONTRATO { get; set; }
        public DateTime FECHA_CONTRATO { get; set; }
        public Cliente cliente { get; set; }
        public string DIRECCION_OBRA { get; set; }
        public string TRANSPORTE { get; set; }
        public Usuario usuario { get; set; }
        public int TOTAL_DIAS { get; set; }
        public DateTime FECHA_ENTREGA { get; set; }
        public TimeSpan HORA_ENTREGA { get; set; }
        public DateTime FECHA_DEVOLUCION { get; set; }
        public TimeSpan HORA_DEVOLUCION { get; set; }
        public string MONEDA { get; set; }
        public double GARANTIA { get; set; }
        public string CHEQUE { get; set; }
        public string DOCUMENTO { get; set; }
        public string RECIBO { get; set; }
        public double IGV { get; set; }
        public double SUBTOTAL { get; set; }
        public double TOTAL { get; set; }
        public string ESTADO { get; set; }

        public List<DetalleContrato> DETALLECONTRATO { get; set; }
    }
}
