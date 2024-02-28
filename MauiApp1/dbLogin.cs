using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class dbLogin
    {
        String cadenaConexion = $"server=192.168.1.109;port=3306;database=loginDB;uid=appmovil;password=Olivas27-;SSL Mode=None";
        public string errorMessage = "";
        public bool InsertarUsuario(string nombre, string telefono, string email, char genero, DateTime fechaNacimiento, string contraseña)
        {
            bool success = false;
            errorMessage = "";

            using (var connection = new MySqlConnection(cadenaConexion))
            {
                string query = @"INSERT INTO users (nombre, telefono, email, genero, fechaNacimiento, contraseña) 
                                 VALUES (@Nombre, @Telefono, @Email, @Genero, @FechaNacimiento, @Contraseña)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Genero", genero);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                    catch (MySqlException ex)
                    {

                        errorMessage = ex.Message;
                        // Manejo de excepciones específicas de MySQL
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de otras excepciones
                    }
                }
            }

            return success;
        }

        public bool ConsultarUsuario(string nombre, string contraseña)
        {
            bool success = false;
            errorMessage = "";

            using (var connection = new MySqlConnection(cadenaConexion))
            {
                string query = @"SELECT COUNT(*) FROM users WHERE nombre = @Nombre AND contraseña = @Contraseña;";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        success = count > 0;
                    }
                    catch (MySqlException ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de excepciones específicas de MySQL
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de otras excepciones
                    }
                }
            }

            return success;
        }

        public bool ActualizarContraseña(string nombre, string email, string contraseña)
        {
            bool success = false;
            errorMessage = "";

            using (var connection = new MySqlConnection(cadenaConexion))
            {
                string query = @"UPDATE users SET contraseña = @Contraseña WHERE nombre = @Nombre and email = @Email";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                    catch (MySqlException ex)
                    {

                        errorMessage = ex.Message;
                        // Manejo de excepciones específicas de MySQL
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        // Manejo de otras excepciones
                    }
                }
            }

            return success;
        }

    }
}
