using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaPersitencia
{
    public class Conexion
    {

        private static string servidor = "localhost";
        private static string bd = "restaurante";
        private static string usuario = "root";
        private static string password = "";
        private static string puerto = "3306";
        private MySqlConnection connection;
        private string cadenaConexion = $"Server={servidor};Database={bd};Uid={usuario};Pwd={password};Port={puerto};";

        public Conexion()
        {
            this.connection = new MySqlConnection(cadenaConexion);
        }
        public void AbrirConexion()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CerrarConexion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        //devuelve un entero dependiendo del tipo de usuario usa MysqlCommand
        public int ObtenerTipoUsuario(string nombreUsuario, string contrasena)
        {
            int tipo = -1;
            try
            {
                AbrirConexion();
                string query = "SELECT tipo FROM usuarios WHERE nombre = '" + nombreUsuario + "' AND contrasena = '" + contrasena + "'";

                MySqlCommand comando = new MySqlCommand(query, connection);

                MySqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    tipo = Convert.ToInt32(lector["tipo"]);
                }

                lector.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return tipo;
        }





    }
}
