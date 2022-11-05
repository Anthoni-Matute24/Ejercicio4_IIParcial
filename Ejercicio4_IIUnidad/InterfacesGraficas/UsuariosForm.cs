using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace InterfacesGraficas
{
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }

        UsuarioDatos userDatos = new UsuarioDatos();
        string tipoOperacion = string.Empty;
        Usuario user;

        private void UsuariosForm_Load(object sender, System.EventArgs e)
        {
            LlenarDataGrid();
        }
        private async void LlenarDataGrid()
        {
            UsuariosDataGridView.DataSource = await userDatos.DevolverListaAsync();
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            DireccionTextBox.Enabled = true;
            EdadTextBox.Enabled = true;
        }

        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            DireccionTextBox.Enabled = false;
            EdadTextBox.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            CorreoTextBox.Clear();
            ClaveTextBox.Clear();
            NombreTextBox.Clear();
            DireccionTextBox.Clear();
            EdadTextBox.Clear();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            tipoOperacion = "Nuevo";
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            user = new Usuario();

            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CorreoTextBox.Text))
                {
                    errorProvider1.SetError(CorreoTextBox, "Ingrese un correo");
                    CorreoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ClaveTextBox.Text))
                {
                    errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                    ClaveTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DireccionTextBox.Text))
                {
                    errorProvider1.SetError(DireccionTextBox, "Ingrese una dirección");
                    DireccionTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(EdadTextBox.Text))
                {
                    errorProvider1.SetError(EdadTextBox, "Ingrese una edad");
                    EdadTextBox.Focus();
                    return;
                }

                user.Codigo = CodigoTextBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.Clave = ClaveTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Direccion = DireccionTextBox.Text;
                user.Edad = Convert.ToInt32(EdadTextBox.Text);

                bool inserto = await userDatos.InsertarAsync(user);

                if (inserto)
                {
                    LlenarDataGrid();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("Usuario Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El usuario no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tipoOperacion == "Modificar")
            {

                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(CorreoTextBox.Text))
                {
                    errorProvider1.SetError(CorreoTextBox, "Ingrese un correo");
                    CorreoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ClaveTextBox.Text))
                {
                    errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                    ClaveTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DireccionTextBox.Text))
                {
                    errorProvider1.SetError(DireccionTextBox, "Ingrese una dirección");
                    DireccionTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(EdadTextBox.Text))
                {
                    errorProvider1.SetError(EdadTextBox, "Ingrese una edad");
                    EdadTextBox.Focus();
                    return;
                }

                user.Codigo = CodigoTextBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.Clave = ClaveTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Direccion = DireccionTextBox.Text;
                user.Edad = Convert.ToInt32(EdadTextBox.Text);

                bool modifico = await userDatos.ActualizarAsync(user);
                if (modifico)
                {
                    LlenarDataGrid();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("Usuario Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El usuario no se pudo modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ModificarButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                CorreoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                ClaveTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                DireccionTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                EdadTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Edad"].Value.ToString();
                HabilitarControles();
                CodigoTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = await userDatos.EliminarAsync(UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    LlenarDataGrid();
                    MessageBox.Show("Usuario Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DesabilitarControles();
        }
    }
}
