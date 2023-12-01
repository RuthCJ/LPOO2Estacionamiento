using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Sector
    {
        
        private bool sec_Habilitado;

        public bool Sec_Habilitado
        {
            get { return sec_Habilitado; }
            set { sec_Habilitado = value; }
        }


        private string sec_Identificador;

        public string Sec_Identificador
        {
            get { return sec_Identificador; }
            set { sec_Identificador = value; }
        }


        private string sec_Descripcion;

        public string Sec_Descripcion
        {
            get { return sec_Descripcion; }
            set { sec_Descripcion = value; }
        }


        private int sec_SectorCodigo;

        public int Sec_SectorCodigo
        {
            get { return sec_SectorCodigo; }
            set { sec_SectorCodigo = value; }
        }


        private int sec_ZonaCodigo;

        public int Sec_ZonaCodigo
        {
            get { return sec_ZonaCodigo; }
            set { sec_ZonaCodigo = value; }
        }

        public override string ToString()
        {
            return "SectorCodigo: " + Sec_SectorCodigo + ",\nDescripcion: " + Sec_Descripcion + ",\nIdentificador: " + Sec_Identificador + ",\nHabilitado: " + Sec_Habilitado + ",\nZonaCodigo: " + Sec_ZonaCodigo + ",\nEstado:" + Sec_Estado;
        }

        //Contructores
        public Sector() { }

        public Sector(int sectorCodigo, string descripcion, string identificador, bool habilitado, int zonaCodigo, string estado)
        {
            Sec_SectorCodigo = sectorCodigo;
            Sec_Descripcion = descripcion;
            Sec_Identificador = identificador;
            Sec_Habilitado = habilitado;
            Sec_ZonaCodigo = zonaCodigo;
            Sec_Estado = estado;
        }

        private string sec_Estado;

        public string Sec_Estado
        {
            get { return sec_Estado; }
            set { sec_Estado = value; }
        }
    }
}