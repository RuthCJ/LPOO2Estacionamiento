﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarSector
    {
        public static DataTable TraerSectoresPorZona(int zonaCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "getSectorByZona_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@ZonaCodigo", zonaCodigo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable TraerSectores()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void AgregarSector(Sector newSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "addSector_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@Descripcion", newSector.Sec_Descripcion);
            cmd.Parameters.AddWithValue("@Habilitado", newSector.Sec_Habilitado);
            cmd.Parameters.AddWithValue("@Identificador", newSector.Sec_Identificador);
            cmd.Parameters.AddWithValue("@ZonaCodigo", newSector.Sec_ZonaCodigo);
            cmd.Parameters.AddWithValue("@SectorCodigo", newSector.Sec_SectorCodigo);
            cmd.Parameters.AddWithValue("@Estado", newSector.Sec_Estado);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sector no agregado: "+ex);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
        }


        public static Sector TraerSectorPorZonaYIdentificador(int zonaCodigo, string zonaIdentificador)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "getSectorByIdentificador_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@ZonaCodigo", zonaCodigo);
            cmd.Parameters.AddWithValue("@Identificador", zonaIdentificador);

            try
            {
                cnn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Sector sector = new Sector
                        {
                            Sec_SectorCodigo = Convert.ToInt32(reader["sec_SectorCodigo"]),
                            Sec_Descripcion = Convert.ToString(reader["sec_Descripcion"]),
                            Sec_Identificador = Convert.ToString(reader["sec_Identificador"]),
                            Sec_Habilitado = Convert.ToBoolean(reader["sec_Habilitado"]),
                            Sec_ZonaCodigo = Convert.ToInt32(reader["sec_ZonaCodigo"]),
                            Sec_Estado = Convert.ToString(reader["sec_Estado"])
                        };

                        return sector;
                    }
                    else return null;
                }
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }

        }


        public static void ModificarSector(Sector alterSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "updateSector_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@Descripcion", alterSector.Sec_Descripcion);
            cmd.Parameters.AddWithValue("@Habilitado", alterSector.Sec_Habilitado);
            cmd.Parameters.AddWithValue("@ZonaCodigo", alterSector.Sec_ZonaCodigo);
            cmd.Parameters.AddWithValue("@Identificador", alterSector.Sec_Identificador);
            cmd.Parameters.AddWithValue("@SectorCodigo", alterSector.Sec_SectorCodigo);
            //cmd.Parameters.AddWithValue("@Estado", alterSector.Sec_Estado);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)  cnn.Close();
            }
        }

        public static void EliminarSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "deleteSector_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@SectorCodigo", sectorCodigo);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
        }

        public static Sector BuscarSectorPorCodigo(int codigoSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "searchSectorByCodigo_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@CodigoSector", codigoSector);

            try
            {
                cnn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Sector sector = new Sector
                        {
                            Sec_SectorCodigo = Convert.ToInt32(reader["sec_SectorCodigo"]),
                            Sec_Descripcion = Convert.ToString(reader["sec_Descripcion"]),
                            Sec_Identificador = Convert.ToString(reader["sec_Identificador"]),
                            Sec_Habilitado = Convert.ToBoolean(reader["sec_Habilitado"]),
                            Sec_ZonaCodigo = Convert.ToInt32(reader["sec_ZonaCodigo"]),
                            Sec_Estado = Convert.ToString(reader["sec_Estado"])
                        };
                        return sector;
                    }
                    else return null;
                }
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
        }

        public static DataTable TraerSectoresOcupados()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "getSectorOcupado_sp";
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("TiempoTranscurrido", typeof(string));
            da.Fill(dt);
            return dt;
        }


        public static void ModificarEstadoSector(int codigo, string estado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "updateEstadoSector_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@SectorCodigo", codigo);
            cmd.Parameters.AddWithValue("@Estado", estado);


            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
        }


    }

}