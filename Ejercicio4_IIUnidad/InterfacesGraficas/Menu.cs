using System.Windows.Forms;

namespace InterfacesGraficas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        UsuariosForm _usuariosForm = null;
        CelularesForm _celularesForm = null; 
        EquipoComputoForm _equipoComputoForm = null;
        TicketsForm _ticketsForm = null;

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            if (_usuariosForm == null)
            {
                _usuariosForm = new UsuariosForm();
                _usuariosForm.MdiParent = this;
                _usuariosForm.FormClosed += _usuariosForm_FormClosed;
                _usuariosForm.Show();
            }
            else
            {
                _usuariosForm.Activate();
            }
        }
        private void _usuariosForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _usuariosForm = null;
        }

        private void CelularToolStripButton_Click(object sender, System.EventArgs e)
        {
            if (_celularesForm == null)
            {
                _celularesForm = new CelularesForm();
                _celularesForm.MdiParent = this;
                _celularesForm.FormClosed += _celularesForm_FormClosed;
                _celularesForm.Show();
            }
            else
            {
                _celularesForm.Activate();
            }
        }

        private void _celularesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _celularesForm = null;
        }

        private void ComputoToolStripButton_Click(object sender, System.EventArgs e)
        {
            if (_equipoComputoForm == null)
            {
                _equipoComputoForm = new EquipoComputoForm();
                _equipoComputoForm.MdiParent = this;
                _equipoComputoForm.FormClosed += _equipoComputoForm_FormClosed;
                _equipoComputoForm.Show();
            }
            else
            {
                _equipoComputoForm.Activate();
            }
        }
        private void _equipoComputoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _equipoComputoForm = null;
        }

        private void TicketToolStripButton_Click(object sender, System.EventArgs e)
        {
            if (_ticketsForm == null)
            {
                _ticketsForm = new TicketsForm();
                _ticketsForm.MdiParent = this;
                _ticketsForm.FormClosed += _ticketsForm_FormClosed;
                _ticketsForm.Show();
            }
            else
            {
                _ticketsForm.Activate();
            }
        }
        private void _ticketsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ticketsForm = null;
        }
    }
}
