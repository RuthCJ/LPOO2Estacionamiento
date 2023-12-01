using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace ClasesBase
{
    public class TrabajarUsuario
    {
        public static DataTable list_usuarios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static Boolean deleteUser(int userId)
        {
            bool userFound = false;
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            string deleteStatement = "DELETE FROM Usuario WHERE usr_Id = @id";
            cmd.CommandText = deleteStatement;
            using (SqlCommand command = new SqlCommand(deleteStatement, cnn))
            {
                command.Parameters.AddWithValue("@id", userId);
                cnn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Usuario eliminado con id: ", userId);
                    userFound = true;
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado con id: ", userId);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cnn.Close();
            }
            return userFound;
        }


        public static void saveUser(Usuario newUser)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "saveUser_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@usrApellido", newUser.Usr_Apellido);
            cmd.Parameters.AddWithValue("@usrNombre", newUser.Usr_Nombre);
            cmd.Parameters.AddWithValue("@usrUserName", newUser.Usr_UserName);
            cmd.Parameters.AddWithValue("@usrPassword", newUser.Usr_Password);
            cmd.Parameters.AddWithValue("@usr_Rol", newUser.Usr_Rol);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Usuario findUserByCredentials(string username, string password)
        {
            Usuario usuario = null;
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            string sqlQuery = "SELECT * FROM Usuario WHERE BINARY_CHECKSUM(Usr_UserName) = BINARY_CHECKSUM(@username) AND BINARY_CHECKSUM(Usr_Password) = BINARY_CHECKSUM(@password)";
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Usr_Id = Convert.ToInt32(reader["Usr_Id"]),
                        Usr_Rol = reader["Usr_Rol"].ToString(),
                        Usr_Nombre = reader["Usr_Nombre"].ToString(),
                        Usr_Apellido = reader["Usr_Apellido"].ToString(),
                        Usr_Password = reader["Usr_Password"].ToString(),
                        Usr_UserName = reader["Usr_UserName"].ToString()
                    };
                }
                else
                {
                    Console.WriteLine("No se encontró el usuario: " + username);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Usuario no encontrado: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
            return usuario;
        }


        public static ObservableCollection<Usuario> traerUsuarios()
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            string sqlQuery = "SELECT * FROM Usuario";
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Usr_Id = Convert.ToInt32(reader["Usr_Id"]),
                        Usr_Rol = reader["Usr_Rol"].ToString(),
                        Usr_Nombre = reader["Usr_Nombre"].ToString(),
                        Usr_Apellido = reader["Usr_Apellido"].ToString(),
                        Usr_Password = reader["Usr_Password"].ToString(),
                        Usr_UserName = reader["Usr_UserName"].ToString()
                    };
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer usuarios de la BD: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
            return usuarios;
        }


    }


}
