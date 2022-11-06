using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace InterfacesGraficas
{
    public partial class EquipoTecnologicoForm : Form
    {
        public EquipoTecnologicoForm()
        {
            InitializeComponent();
        }
        Datos.EquipoTecnologicoDatos celDatos = new Datos.EquipoTecnologicoDatos();
        EquipoTecnologico dispositivo;
        string tipoOperacion = string.Empty;

        private void HabilitarControles()
        {
            IdentidadTextBox.Enabled = true;
            NombreClienteTextBox.Enabled = true;
            ModeloTextBox.Enabled = true;
            MarcaTextBox.Enabled = true;
            NombreEquipoTextBox.Enabled = true;
            DescripcionProblemaTextBox.Enabled = true;
            SoporteComboBox.Enabled = true;
        }
        private void DeshabilitarControles()
        {
            IdentidadTextBox.Enabled = false;
            NombreClienteTextBox.Enabled = false;
            ModeloTextBox.Enabled = false;
            MarcaTextBox.Enabled = false;
            NombreEquipoTextBox.Enabled = false;
            DescripcionProblemaTextBox.Enabled = false;
            SoporteComboBox.Enabled = false;
        }
        private void LimpiarControles()
        {
            IdentidadTextBox.Clear();
            NombreClienteTextBox.Clear();
            ModeloTextBox.Clear();
            MarcaTextBox.Clear();
            NombreEquipoTextBox.Clear();
            DescripcionProblemaTextBox.Clear();
            SoporteComboBox.Text = String.Empty;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DeshabilitarControles();
        }

        private void CrearButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            tipoOperacion = "Nuevo";
        }

        private void CelularesForm_Load(object sender, EventArgs e)
        {
            LlenarDataGrid();
        }
        private async void LlenarDataGrid()
        {
            EquipoTecnologicoDataGridView.DataSource = await celDatos.DevolverListaAsync();
        }

        private async void GenerarButton_Click(object sender, EventArgs e)
        {
            dispositivo = new EquipoTecnologico();

            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(IdentidadTextBox.Text))
                {
                    errorProvider1.SetError(IdentidadTextBox, "Ingrese un número de identidad");
                    IdentidadTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreClienteTextBox.Text))
                {
                    errorProvider1.SetError(NombreClienteTextBox, "Ingrese un nombre");
                    NombreClienteTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ModeloTextBox.Text))
                {
                    errorProvider1.SetError(ModeloTextBox, "Ingrese un modelo del dispositivo");
                    ModeloTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(MarcaTextBox.Text))
                {
                    errorProvider1.SetError(MarcaTextBox, "Ingrese una marca");
                    MarcaTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreEquipoTextBox.Text))
                {
                    errorProvider1.SetError(NombreEquipoTextBox, "Ingrese el nombre del dispositivo");
                    NombreEquipoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionProblemaTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionProblemaTextBox, "Ingrese el problema del dispositivo");
                    DescripcionProblemaTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(SoporteComboBox.Text))
                {
                    errorProvider1.SetError(SoporteComboBox, "Seleccione un tipo de soporte");
                    SoporteComboBox.Focus();
                    return;
                }

                dispositivo.Identidad = IdentidadTextBox.Text;
                dispositivo.NombreCliente = NombreClienteTextBox.Text;
                dispositivo.ModeloEquipo = ModeloTextBox.Text;
                dispositivo.Marca = MarcaTextBox.Text;
                dispositivo.NombreEquipo = NombreEquipoTextBox.Text;
                dispositivo.EspecificacionProblema = DescripcionProblemaTextBox.Text;
                dispositivo.Soporte = SoporteComboBox.Text;

                bool inserto = await celDatos.InsertarAsync(dispositivo);

                if (inserto)
                {
                    LlenarDataGrid();
                    LimpiarControles();
                    DeshabilitarControles();
                    MessageBox.Show("Solicitud guardada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se guardó la solicitud", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tipoOperacion == "Modificar")
            {

                if (string.IsNullOrEmpty(IdentidadTextBox.Text))
                {
                    errorProvider1.SetError(IdentidadTextBox, "Ingrese un número de identidad");
                    IdentidadTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreClienteTextBox.Text))
                {
                    errorProvider1.SetError(NombreClienteTextBox, "Ingrese un nombre");
                    NombreClienteTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ModeloTextBox.Text))
                {
                    errorProvider1.SetError(ModeloTextBox, "Ingrese un modelo del dispositivo");
                    ModeloTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(MarcaTextBox.Text))
                {
                    errorProvider1.SetError(MarcaTextBox, "Ingrese una marca");
                    MarcaTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreEquipoTextBox.Text))
                {
                    errorProvider1.SetError(NombreEquipoTextBox, "Ingrese el nombre del dispositivo");
                    NombreEquipoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionProblemaTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionProblemaTextBox, "Ingrese el problema del dispositivo");
                    DescripcionProblemaTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(SoporteComboBox.Text))
                {
                    errorProvider1.SetError(SoporteComboBox, "Seleccione un tipo de soporte");
                    SoporteComboBox.Focus();
                    return;
                }

                dispositivo.Identidad = IdentidadTextBox.Text;
                dispositivo.NombreCliente = NombreClienteTextBox.Text;
                dispositivo.ModeloEquipo = ModeloTextBox.Text;
                dispositivo.Marca = MarcaTextBox.Text;
                dispositivo.NombreEquipo = NombreEquipoTextBox.Text;
                dispositivo.EspecificacionProblema = DescripcionProblemaTextBox.Text;
                dispositivo.Soporte = SoporteComboBox.Text;

                bool modifico = await celDatos.ActualizarAsync(dispositivo);
                if (modifico)
                {
                    LlenarDataGrid();
                    LimpiarControles();
                    DeshabilitarControles();
                    MessageBox.Show("Solicitud modificada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se modificó la solicitud", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ModificarButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (EquipoTecnologicoDataGridView.SelectedRows.Count > 0)
            {
                IdentidadTextBox.Text = EquipoTecnologicoDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                NombreClienteTextBox.Text = EquipoTecnologicoDataGridView.CurrentRow.Cells["NombreCliente"].Value.ToString();
                ModeloTextBox.Text = EquipoTecnologicoDataGridView.CurrentRow.Cells["ModeloEquipo"].Value.ToString();
                MarcaTextBox.Text = EquipoTecnologicoDataGridView.CurrentRow.Cells["Marca"].Value.ToString();
                NombreEquipoTextBox.Text = EquipoTecnologicoDataGridView.CurrentRow.Cells["NombreEquipo"].Value.ToString();
                DescripcionProblemaTextBox.Text = EquipoTecnologicoDataGridView.CurrentRow.Cells["EspecificacionProblema"].Value.ToString();
                SoporteComboBox.Text = EquipoTecnologicoDataGridView.CurrentRow.Cells["Soporte"].Value.ToString();
                HabilitarControles();
                IdentidadTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
