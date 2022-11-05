namespace Entidades
{
    public class DetalleTicket
    {
        public int IdDetalleTicket { get; set; }
        public int IdTicket { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}
