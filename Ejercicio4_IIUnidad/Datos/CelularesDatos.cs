using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Datos
{
    public class CelularesDatos
    {
        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM celulares;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
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

        public async Task<bool> InsertarAsync(Celulares celular)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO Celulares VALUES (@Identidad, @NombreCliente, @Modelo, @Marca, @Almacenamiento, @RAM, @EspecificacionProblema);";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 20).Value = celular.Identidad;
                        comando.Parameters.Add("@NombreCliente", MySqlDbType.VarChar, 80).Value = celular.NombreCliente;
                        comando.Parameters.Add("@Modelo", MySqlDbType.VarChar, 20).Value = celular.Modelo;
                        comando.Parameters.Add("@Marca", MySqlDbType.VarChar, 20).Value = celular.Marca;
                        comando.Parameters.Add("@Almacenamiento", MySqlDbType.VarChar, 10).Value = celular.Almacenamiento;
                        comando.Parameters.Add("@RAM", MySqlDbType.VarChar, 10).Value = celular.RAM;
                        comando.Parameters.Add("@EspecificacionProblema", MySqlDbType.VarChar, 200).Value = celular.EspecificacionProblema;

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

        public async Task<bool> ActualizarAsync(Celulares celular)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE celulares SET NombreCliente=@NombreCliente, Modelo=@Modelo, Marca=@Marca, Almacenamiento=@Almacenamiento, RAM=@RAM, EspecificacionProblema=@EspecificacionProblema WHERE Identidad=@Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 20).Value = celular.Identidad;
                        comando.Parameters.Add("@NombreCliente", MySqlDbType.VarChar, 80).Value = celular.NombreCliente;
                        comando.Parameters.Add("@Modelo", MySqlDbType.VarChar, 20).Value = celular.Modelo;
                        comando.Parameters.Add("@Marca", MySqlDbType.VarChar, 20).Value = celular.Marca;
                        comando.Parameters.Add("@Almacenamiento", MySqlDbType.VarChar, 10).Value = celular.Almacenamiento;
                        comando.Parameters.Add("@RAM", MySqlDbType.VarChar, 10).Value = celular.RAM;
                        comando.Parameters.Add("@EspecificacionProblema", MySqlDbType.VarChar, 200).Value = celular.EspecificacionProblema;

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
    }
}
