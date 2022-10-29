using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        // Permite acceder a la tabla Usuario
        public async Task<bool> LoginAsync(string correo, string clave)
        {
            // Devuelve False, por que el "Codigo y Clave" son incorrectos
            bool valido = false;

            try
            {
                // Si el "Codigo y Claves" son correctos, entonces devolverá 1
                string sql = "SELECT 1 FROM Usuario WHERE Correo=@Correo AND Clave=@Clave;";

                // Clase conexión para acceder a la BD
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    // Abre la conexión de la BD
                    await _conexion.OpenAsync();

                    // Comando que ejecuta la sentencia "sql" y la transmite por medio de "_conexion"
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        // Define el tipo de Comando (texto)
                        comando.CommandType = System.Data.CommandType.Text;

                        // Objeto: comando, pasa parametro a:
                        // "Código" -> Tipo dato: VarChar, Tamaño: 20 caracteres 
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = correo;
                        // "Clave"->Tipo dato: VarChar, Tamaño: 120 caracteres
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 40).Value = clave;

                        // Ejecuta todo el "Objeto: comando" y devuelve un valor numérico (1)
                        // Se covierte a Boolean y devuelve "True" 
                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return valido;
        }
    }
}
