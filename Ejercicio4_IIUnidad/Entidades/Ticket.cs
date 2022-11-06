using System;

namespace Entidades
{
    public class Ticket
    {
        public string Id { get; set; }
        public string CodigoUsuario { get; set; }
        public string IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string RespuestaSolicitud { get; set; }
        public decimal Precio { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}
