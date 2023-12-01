using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket
    {
        
        public decimal tkt_Total;

        public decimal Tkt_Total
        {
            get { return tkt_Total; }
            set { tkt_Total = value; }
        }


        public decimal tv_Tarifa;
        public decimal Tv_Tarifa
        {
            get { return tv_Tarifa; }
            set { tv_Tarifa = value; }
        }

        private double tkt_Duracion;
        public double Tkt_Duracion
        {
            get { return tkt_Duracion; }
            set { tkt_Duracion = value; }
        }


        private int sec_SectorCodigo;
        public int Sec_SectorCodigo
        {
            get { return sec_SectorCodigo; }
            set { sec_SectorCodigo = value; }
        }


        private string tkt_Patente;
        public string Tkt_Patente
        {
            get { return tkt_Patente; }
            set { tkt_Patente = value; }
        }



        private int tv_TVCodigo;
        
        public int Tv_TVCodigo
        {
            get { return tv_TVCodigo; }
            set { tv_TVCodigo = value; }
        }


        private int cli_ClienteDNI;
        public int Cli_ClienteDNI
        {
            get { return cli_ClienteDNI; }
            set { cli_ClienteDNI = value; }
        }


        private DateTime tkt_FechaHoraSal;
        public DateTime Tkt_FechaHoraSal
        {
            get { return tkt_FechaHoraSal; }
            set { tkt_FechaHoraSal = value; }
        }


        private DateTime tkt_FechaHoraEnt;
        public DateTime Tkt_FechaHoraEnt
        {
            get { return tkt_FechaHoraEnt; }
            set { tkt_FechaHoraEnt = value; }
        }

        private int tkt_TicketNro;
        public int Tkt_TicketNro
        {
            get { return tkt_TicketNro; }
            set { tkt_TicketNro = value; }
        }
    }
}
