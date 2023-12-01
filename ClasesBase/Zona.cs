﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Zona
    {
        private int zona_ZonaCodigo;
        public int Zona_ZonaCodigo
        {
            get { return zona_ZonaCodigo; }
            set { zona_ZonaCodigo = value; }
        }


        private string zona_Descripcion;

        public string Zona_Descripcion
        {
            get { return zona_Descripcion; }
            set { zona_Descripcion = value; }
        }


        private string zona_Piso;

        public string Zona_Piso
        {
            get { return zona_Piso; }
            set { zona_Piso = value; }
        }
    }
}