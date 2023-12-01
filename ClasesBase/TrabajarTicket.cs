using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
   public class TrabajarTicket
    {
      

       public static void saveTicket(Ticket ticket)
       {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT MAX(tkt_TicketNro) FROM Ticket"; 
            cmd.Connection = cnn;

            cnn.Open();
            object maxTicketNumber = cmd.ExecuteScalar();
            cnn.Close();

            int nextTicketNumber = 1; 
            if (maxTicketNumber != DBNull.Value)
            {
                nextTicketNumber = Convert.ToInt32(maxTicketNumber) + 1;
            }

            ticket.Tkt_TicketNro = nextTicketNumber;

            cmd.CommandText = "addTicket_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            Console.WriteLine("entro");
            cmd.Parameters.AddWithValue("@cliClienteDNI", ticket.Cli_ClienteDNI);
            cmd.Parameters.AddWithValue("@secSectorCodigo", ticket.Sec_SectorCodigo);
            cmd.Parameters.AddWithValue("@tktDuracion", ticket.Tkt_Duracion);
            cmd.Parameters.AddWithValue("@tktFechaHoraEnt", ticket.Tkt_FechaHoraEnt);
            cmd.Parameters.AddWithValue("@tktFechaHoraSal", ticket.Tkt_FechaHoraSal);
            cmd.Parameters.AddWithValue("@tktPatente", ticket.Tkt_Patente);
            cmd.Parameters.AddWithValue("@tktTicketNro", ticket.Tkt_TicketNro);
            cmd.Parameters.AddWithValue("@tktTotal", ticket.Tkt_Total);
            cmd.Parameters.AddWithValue("@tvTarifa", ticket.Tv_Tarifa);
            cmd.Parameters.AddWithValue("@tvTVCodigo", ticket.Tv_TVCodigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable TraerTicketsPorSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket WHERE sec_SectorCodigo = @SectorCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@SectorCodigo", sectorCodigo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static DataTable TraerUltimoTicketPorSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT TOP 1 * FROM Ticket WHERE sec_SectorCodigo = @SectorCodigo ORDER BY tkt_FechaHoraEnt DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@SectorCodigo", sectorCodigo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable TraerTicketPorNumero(int? numeroTicket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket WHERE tkt_TicketNro = @NumeroTicket";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@NumeroTicket", numeroTicket);  
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static void saveTicketEntrada(Ticket ticket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT MAX(tkt_TicketNro) FROM Ticket";
            cmd.Connection = cnn;

            cnn.Open();
            object maxTicketNumber = cmd.ExecuteScalar();
            cnn.Close();

            int nextTicketNumber = 1;
            if (maxTicketNumber != DBNull.Value)
            {
                nextTicketNumber = Convert.ToInt32(maxTicketNumber) + 1;
            }

            ticket.Tkt_TicketNro = nextTicketNumber;
            cmd.CommandText = "saveTicketEnter_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            Console.WriteLine("entro");
            cmd.Parameters.AddWithValue("@cliClienteDNI", ticket.Cli_ClienteDNI);
            cmd.Parameters.AddWithValue("@secSectorCodigo", ticket.Sec_SectorCodigo);
            cmd.Parameters.AddWithValue("@tktFechaHoraEnt", ticket.Tkt_FechaHoraEnt);
            cmd.Parameters.AddWithValue("@tktPatente", ticket.Tkt_Patente);
            cmd.Parameters.AddWithValue("@tktTicketNro", ticket.Tkt_TicketNro);
            cmd.Parameters.AddWithValue("@tvTarifa", ticket.Tv_Tarifa);
            cmd.Parameters.AddWithValue("@tvTVCodigo", ticket.Tv_TVCodigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable TraerTickets()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void ModificarTicket(DataTable ticketModificado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();

                foreach (DataRow row in ticketModificado.Rows)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE Ticket SET tkt_Duracion = @Duracion, tkt_Total = @Total, tkt_FechaHoraSal = @HoraSalida WHERE tkt_TicketNro = @TNumero";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;

                    cmd.Parameters.AddWithValue("@TNumero", row["tkt_TicketNro"]); 
                    cmd.Parameters.AddWithValue("@Total", row["tkt_Total"]); 
                    cmd.Parameters.AddWithValue("@HoraSalida", row["tkt_FechaHoraSal"]); 
                    cmd.Parameters.AddWithValue("@Duracion", row["tkt_Duracion"]); 

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tiket no modificado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static DataTable TraerTicketsVendidos()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "getTicketSold_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable TraerTicketsVendidosPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "getTicketSaleByFecha_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
