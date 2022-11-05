using Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;
using System;

namespace Datos
{
    public class EquipoComputoDatos
    {
        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM computo;";

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

        public async Task<bool> InsertarAsync(EquipoComputo equipo)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO Computo VALUES (@Identidad, @NombreCliente, @ModeloEquipo, @Marca, @NombreEquipo, @EspecificacionProblema);";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 20).Value = equipo.Identidad;
                        comando.Parameters.Add("@NombreCliente", MySqlDbType.VarChar, 80).Value = equipo.NombreCliente;
                        comando.Parameters.Add("@ModeloEquipo", MySqlDbType.VarChar, 20).Value = equipo.ModeloEquipo;
                        comando.Parameters.Add("@Marca", MySqlDbType.VarChar, 20).Value = equipo.Marca;
                        comando.Parameters.Add("@NombreEquipo", MySqlDbType.VarChar, 30).Value = equipo.NombreEquipo;
                        comando.Parameters.Add("@EspecificacionProblema", MySqlDbType.VarChar, 200).Value = equipo.EspecificacionProblemaE;

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

        public async Task<bool> ActualizarAsync(EquipoComputo equipo)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE Computo SET NombreCliente=@NombreCliente, ModeloEquipo=@ModeloEquipo, Marca=@Marca, NombreEquipo=@NombreEquipo, EspecificacionProblema=@EspecificacionProblema WHERE Identidad=@Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 20).Value = equipo.Identidad;
                        comando.Parameters.Add("@NombreCliente", MySqlDbType.VarChar, 80).Value = equipo.NombreCliente;
                        comando.Parameters.Add("@ModeloEquipo", MySqlDbType.VarChar, 20).Value = equipo.ModeloEquipo;
                        comando.Parameters.Add("@Marca", MySqlDbType.VarChar, 20).Value = equipo.Marca;
                        comando.Parameters.Add("@NombreEquipo", MySqlDbType.VarChar, 30).Value = equipo.NombreEquipo;
                        comando.Parameters.Add("@EspecificacionProblema", MySqlDbType.VarChar, 200).Value = equipo.EspecificacionProblemaE;

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
