using Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;
using System;

namespace Datos
{
    public class TicketDatos
    {
        public async Task<bool> InsertarAsync(Ticket boleto)
         {
             bool inserto = false;
             try
             {
                 string sql = "INSERT INTO Ticket (Ticket, CodigoUsuario, IdCliente, Fecha, TipoSoporte, DescripcionSolicitud, RespuestaSolicitud, Precio, ISV, Descuento, Total) VALUES (@Ticket, @CodigoUsuario, @IdCliente, @Fecha, @TipoSoporte, @DescripcionSolicitud, @RespuestaSolicitud @Precio, @ISV, @Descuento, @Total);";
                 //string sql = "INSERT INTO Ticket VALUES (@Ticket, @CodigoUsuario, @IdCliente, @Fecha, @TipoSoporte, @DescripcionSolicitud, @RespuestaSolicitud @Precio, @ISV, @Descuento, @Total);";
                 using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                 {
                     await _conexion.OpenAsync();
                     using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                     {
                         comando.CommandType = CommandType.Text;
                         comando.Parameters.Add("@Ticket", MySqlDbType.VarChar, 10).Value = boleto.Id;
                         comando.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 25).Value = boleto.CodigoUsuario;
                         comando.Parameters.Add("@IdCliente", MySqlDbType.VarChar, 20).Value = boleto.IdCliente;
                         comando.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = boleto.Fecha;
                         comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 20).Value = boleto.TipoSoporte;
                         comando.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 200).Value = boleto.DescripcionSolicitud;
                         comando.Parameters.Add("@RespuestaSolicitud", MySqlDbType.VarChar, 200).Value = boleto.RespuestaSolicitud;
                         comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = boleto.Precio;
                         comando.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = boleto.ISV;
                         comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = boleto.Descuento;
                         comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = boleto.Total;

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
    }
}
