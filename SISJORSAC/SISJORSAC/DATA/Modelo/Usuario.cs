﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.Modelo
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string clave { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string ESTADO { get; set; }

        public string NOMBRE_COMPLETO { get; set; }
    }
}
