using System;

namespace ClasesBase
{
    public class SectorExtendido : Sector
    {
        //private string estado;
        private int? ultimoTicketReservado;

        public SectorExtendido(int sectorCodigo, string descripcion, string identificador, bool habilitado, int zonaCodigo, string estado, int? ultimoTicketReservado)
            : base(sectorCodigo, descripcion, identificador, habilitado, zonaCodigo, estado)
        {
            //this.estado = estado;
            this.ultimoTicketReservado = ultimoTicketReservado;
        }



        /*public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
            */
        /*
         int? : la variable puede tomar ademas de un valor decimal el valor null
         */
        public int? UltimoTicketReservado
        {
            get { return ultimoTicketReservado; }
            set { ultimoTicketReservado = value; }
        }
    }
}
