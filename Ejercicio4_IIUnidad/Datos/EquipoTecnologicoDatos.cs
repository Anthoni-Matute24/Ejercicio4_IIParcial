using Entidades;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Datos
{
    public class EquipoTecnologicoDatos
    {
        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM EquipoTecnologico;";

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

        public async Task<bool> InsertarAsync(EquipoTecnologico equipo)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO EquipoTecnologico VALUES (@Identidad, @NombreCliente, @ModeloEquipo, @Marca, @NombreEquipo, @EspecificacionProblema, @Soporte);";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 20).Value = equipo.Identidad;
                        comando.Parameters.Add("@NombreCliente", MySqlDbType.VarChar, 80).Value = equipo.NombreCliente;
                        comando.Parameters.Add("@ModeloEquipo", MySqlDbType.VarChar, 20).Value = equipo.ModeloEquipo;
                        comando.Parameters.Add("@Marca", MySqlDbType.VarChar, 30).Value = equipo.Marca;
                        comando.Parameters.Add("@NombreEquipo", MySqlDbType.VarChar, 30).Value = equipo.NombreEquipo;
                        comando.Parameters.Add("@EspecificacionProblema", MySqlDbType.VarChar, 200).Value = equipo.EspecificacionProblema;
                        comando.Parameters.Add("@Soporte", MySqlDbType.VarChar, 20).Value = equipo.Soporte;

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

        public async Task<bool> ActualizarAsync(EquipoTecnologico equipo)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE EquipoTecnologico SET NombreCliente=@NombreCliente, ModeloEquipo=@ModeloEquipo, Marca=@Marca, NombreEquipo=@NombreEquipo, EspecificacionProblema=@EspecificacionProblema, Soporte=@Soporte WHERE Identidad=@Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 20).Value = equipo.Identidad;
                        comando.Parameters.Add("@NombreCliente", MySqlDbType.VarChar, 80).Value = equipo.NombreCliente;
                        comando.Parameters.Add("@ModeloEquipo", MySqlDbType.VarChar, 20).Value = equipo.ModeloEquipo;
                        comando.Parameters.Add("@Marca", MySqlDbType.VarChar, 30).Value = equipo.Marca;
                        comando.Parameters.Add("@NombreEquipo", MySqlDbType.VarChar, 30).Value = equipo.NombreEquipo;
                        comando.Parameters.Add("@EspecificacionProblema", MySqlDbType.VarChar, 200).Value = equipo.EspecificacionProblema;
                        comando.Parameters.Add("@Soporte", MySqlDbType.VarChar, 20).Value = equipo.Soporte;

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

        public async Task<EquipoTecnologico> DatosCliente(string identidad)
        {
            EquipoTecnologico cliente = new EquipoTecnologico();
            try
            {
                string sql = "SELECT * FROM EquipoTecnologico WHERE Identidad = @Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 20).Value = identidad;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                            cliente.Identidad = dr["Identidad"].ToString();
                            cliente.NombreCliente = dr["NombreCliente"].ToString();
                            cliente.EspecificacionProblema = dr["EspecificacionProblema"].ToString();
                            cliente.Soporte = dr["Soporte"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return cliente;
        }
    }
}
