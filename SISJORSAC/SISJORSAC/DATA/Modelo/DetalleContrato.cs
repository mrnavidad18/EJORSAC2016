﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class DetalleContrato
    {

        public int COD_DETALLE { get; set; }
        public int COD_CONTRATO { get; set; }
        public int COD_SERV { get; set; }
        public int ITEM { get; set; }
        public int CANTIDAD { get; set; }
        public double PRECIO { get; set; }
        public double IMPORTE { get; set; }
        public string ESTADO { get; set; }

    }
}
