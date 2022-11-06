using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        public async Task<bool> LoginAsync(string usuario, string clave)
        {
            // Devuelve False, por que el "Codigo y Clave" son incorrectos
            bool valido = false;

            try
            {
                // Si el "Codigo y Claves" son correctos, entonces devolverá 1
                string sql = "SELECT 1 FROM Usuario WHERE Codigo=@Codigo AND Clave=@Clave;";

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
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 25).Value = usuario;
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

        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM usuario;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public async Task<bool> InsertarAsync(Usuario usuario)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO Usuario VALUES (@Codigo, @Correo, @Clave, @Nombre, @Direccion, @Edad);";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 25).Value = usuario.Codigo;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = usuario.Correo;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 40).Value = usuario.Clave;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 80).Value = usuario.Nombre;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 80).Value = usuario.Direccion;
                        comando.Parameters.Add("@Edad", MySqlDbType.Int32, 3).Value = usuario.Edad;

                        await comando.ExecuteNonQueryAsync();
                        inserto = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public async Task<bool> ActualizarAsync(Usuario usuario)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE usuario SET Correo=@Correo, Clave=@Clave, Nombre=@Nombre, Direccion=@Direccion, Edad=@Edad WHERE Codigo=@Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 25).Value = usuario.Codigo;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = usuario.Correo;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 40).Value = usuario.Clave;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 80).Value = usuario.Nombre;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 80).Value = usuario.Direccion;
                        comando.Parameters.Add("@Edad", MySqlDbType.Int32, 3).Value = usuario.Edad;

                        await comando.ExecuteNonQueryAsync();
                        actualizo = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return actualizo;
        }

        public async Task<bool> EliminarAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM usuario WHERE Codigo = @Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 25).Value = codigo;
                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }

    }
}
