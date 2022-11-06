using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace InterfacesGraficas
{
    public partial class TicketsForm : Form
    {
        public TicketsForm()
        {
            InitializeComponent();
        }

        Random aleatorio = new Random();
        TicketDatos ticketDatos = new TicketDatos();
        Ticket ticket;   
        EquipoTecnologico Cliente;
        
        
        decimal precio = 0;
        decimal isv = 0.15M;

        private void TicketsForm_Load(object sender, System.EventArgs e)
        {
            UsuarioTextBox.Text = VariableGlobal.UsuarioLogin;
            DescuentoTextBox.Text = "0.00";
            ISVTextBox.Text = "0.00";
            TotalTextBox.Text = "0.00";
            FechaDateTimePicker.Value = DateTime.Now;
        }

        private async void IdentidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EquipoTecnologicoDatos clienteDatos = new EquipoTecnologicoDatos();
                Cliente = new EquipoTecnologico();
                Cliente = await clienteDatos.DatosCliente(IdentidadTextBox.Text);

                if (Cliente.Identidad != null)
                {
                    int ticket = aleatorio.Next(99999);
                    TicketTextBox.Text = ticket.ToString();
                    NombreClienteTextBox.Text = Cliente.NombreCliente;
                    SolicitudTextBox.Text = Cliente.EspecificacionProblema;
                    SoporteTextBox.Text = Cliente.Soporte;
                    errorProvider1.Clear();
                    RespuestaTextBox.ReadOnly = false;
                    RespuestaTextBox.Focus();
                }
                else 
                {
                    errorProvider1.SetError(NombreClienteTextBox, "No existe la solicitud del cliente");
                }
            }
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PrecioTextBox.Focus();
                precio = Convert.ToDecimal(PrecioTextBox.Text);
                ISVTextBox.Text = (precio * isv).ToString("N");
                TotalTextBox.Text = (Convert.ToDecimal(ISVTextBox.Text) + precio - Convert.ToDecimal(DescuentoTextBox.Text)).ToString("N");
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Cliente == null)
            {
                errorProvider1.SetError(IdentidadTextBox, "Consulte un cliente");
                IdentidadTextBox.Focus();
                return;
            }

            ticket = new Ticket();

            ticket.Id = TicketTextBox.Text;
            ticket.CodigoUsuario = UsuarioTextBox.Text;
            ticket.IdCliente = IdentidadTextBox.Text;
            ticket.Fecha = FechaDateTimePicker.Value;
            ticket.TipoSoporte = SoporteTextBox.Text;
            ticket.DescripcionSolicitud = SolicitudTextBox.Text;
            ticket.RespuestaSolicitud = RespuestaTextBox.Text;
            ticket.Precio = Convert.ToDecimal(PrecioTextBox.Text); 
            ticket.ISV = Convert.ToDecimal(ISVTextBox.Text);
            ticket.Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            ticket.Total = Convert.ToDecimal(TotalTextBox.Text);

            bool inserto = await ticketDatos.InsertarAsync(ticket);

            if (inserto)
            {
                MessageBox.Show("Ticket guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se guardó el ticket", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
