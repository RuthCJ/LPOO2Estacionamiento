using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBase;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{

    public class TrabajarCliente
    {
        public static DataTable TraerClientes() //obtencion de todos los clientes cargados en la BD
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "getAllClientes_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    

        public static void ModificarCliente(Cliente alterClient)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "updateCliente_sp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@ClienteDNI", alterClient.Cli_ClienteDNI);
                cmd.Parameters.AddWithValue("@Apellido", alterClient.Cli_Apellido);
                cmd.Parameters.AddWithValue("@Nombre", alterClient.Cli_Nombre);
                cmd.Parameters.AddWithValue("@Telefono", alterClient.Cli_Telefono);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cliente no modificado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void AgregarCliente(Cliente newClient)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "addCliente_sp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@ClienteDNI", newClient.Cli_ClienteDNI);
                cmd.Parameters.AddWithValue("@Apellido", newClient.Cli_Apellido);
                cmd.Parameters.AddWithValue("@Nombre", newClient.Cli_Nombre);
                cmd.Parameters.AddWithValue("@Telefono", newClient.Cli_Telefono);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Cliente no agregado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void EliminarCliente(string clienteDni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "deleteCliente_sp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@ClienteDNI", clienteDni);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cliente no eliminado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static Cliente TraerCliente(string clientDni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            string selectStatement = "SELECT * FROM Cliente WHERE Cli_ClienteDNI = @cli_ClienteDNI";
            cmd.CommandText = selectStatement;
            using (SqlCommand command = new SqlCommand(selectStatement, cnn))
            {
                command.Parameters.AddWithValue("@cli_ClienteDNI", clientDni);
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Cliente cliente = null;
                if (reader.Read())
                {
                    cliente = new Cliente();
                    cliente.Cli_ClienteDNI = reader["Cli_ClienteDNI"].ToString();
                    cliente.Cli_Apellido = reader["Cli_Apellido"].ToString();
                    cliente.Cli_Nombre = reader["Cli_Nombre"].ToString();
                    cliente.Cli_Telefono = reader["Cli_Telefono"].ToString();
                }
                reader.Close();
                cnn.Close();
                return cliente;
            }
        }



    }
}