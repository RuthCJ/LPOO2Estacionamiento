using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarTiposVehiculo
    {

        public static DataTable TraerTiposVehiculo() 
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT *";
            cmd.CommandText += " FROM TipoVehiculo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static void EliminarTipoVehiculo(int tvCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TipoVehiculo WHERE tv_TVCodigo = @TVCodigo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@TVCodigo", tvCodigo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("TipoVehiculo no eliminado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
        }

        public static void AgregarTipoVehiculo(TipoVehiculo newVehiculo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "addTypeVehiculo_sp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@TVCodigo", newVehiculo.Tv_TVCodigo);
                cmd.Parameters.AddWithValue("@Descripcion", newVehiculo.Tv_Descripcion);
                cmd.Parameters.AddWithValue("@Tarifa", newVehiculo.Tv_Tarifa);
                cmd.Parameters.AddWithValue("@Imagen", newVehiculo.Tv_Imagen);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("TipoVehiculo no agregado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
        }

        public static void ModificarTipoVehiculo(TipoVehiculo vehiculoModificado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TipoVehiculo SET tv_Descripcion = @Descripcion, tv_Tarifa = @Tarifa, tv_Imagen = @Imagen WHERE tv_TVCodigo = @TVCodigo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cmd.Parameters.AddWithValue("@TVCodigo", vehiculoModificado.Tv_TVCodigo);
                cmd.Parameters.AddWithValue("@Descripcion", vehiculoModificado.Tv_Descripcion);
                cmd.Parameters.AddWithValue("@Tarifa", vehiculoModificado.Tv_Tarifa);
                cmd.Parameters.AddWithValue("@Imagen", vehiculoModificado.Tv_Imagen);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error modifying TipoVehiculo: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
        }

      

        public static TipoVehiculo BuscarTipoVehiculo(int codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM TipoVehiculo WHERE tv_TVCodigo = @TVCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@TVCodigo", codigo);
            TipoVehiculo vehiculoEncontrado = null;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    vehiculoEncontrado = new TipoVehiculo
                    {
                        Tv_TVCodigo = Convert.ToInt32(reader["tv_TVCodigo"]),
                        Tv_Descripcion = reader["tv_Descripcion"].ToString(),
                        Tv_Tarifa = Convert.ToDecimal(reader["tv_Tarifa"]),
                        Tv_Imagen = reader["tv_Imagen"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("TipoVehiculo no encontrado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)  cnn.Close();
            }

            return vehiculoEncontrado;
        }



    }
}
