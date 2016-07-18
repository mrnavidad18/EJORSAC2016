﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class Factura
    {

        public int COD_FAC { get; set; }
        public DateTime FECHA_EMISION { get; set; }
        public string NRO_FACTURA { get; set; }
        public Cliente cliente { get; set; }
        public GuiaRemision guiaRemision { get; set; }
        public string MODALIDAD { get; set; }
        public string OBSERVACION { get; set; }
        public double SUB_TOTAL { get; set; }
        public double IGV { get; set; }
        public double TOTAL { get; set; }

        public string ESTADO { get; set; }

    }
}
