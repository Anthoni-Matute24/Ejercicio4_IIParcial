using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace InterfacesGraficas
{
    public partial class EquipoComputoForm : Form
    {
        public EquipoComputoForm()
        {
            InitializeComponent();
        }

        EquipoComputoDatos E_ComputoDatos = new EquipoComputoDatos();
        EquipoComputo E_Computo;
        string tipoOperacion = string.Empty;
        string Soporte = "Equipo de Cómputo";

        private void EquipoComputoForm_Load(object sender, EventArgs e)
        {
            LlenarDataGrid();
        }

        private async void LlenarDataGrid()
        {
            EquipoComputoDataGridView.DataSource = await E_ComputoDatos.DevolverListaAsync();
        }

        private void HabilitarControles()
        {
            IdentidadTextBox.Enabled = true;
            NombreClienteTextBox.Enabled = true;
            ModeloEquipoTextBox.Enabled = true;
            MarcaTextBox.Enabled = true;
            NombreEquipoTextBox.Enabled = true;
            DescripcionProblemaTextBox.Enabled = true;
        }
        private void DeshabilitarControles()
        {
            IdentidadTextBox.Enabled = false;
            NombreClienteTextBox.Enabled = false;
            ModeloEquipoTextBox.Enabled = false;
            MarcaTextBox.Enabled = false;
            NombreEquipoTextBox.Enabled = false;
            DescripcionProblemaTextBox.Enabled = false;
        }
        private void LimpiarControles()
        {
            IdentidadTextBox.Clear();
            NombreClienteTextBox.Clear();
            ModeloEquipoTextBox.Clear();
            MarcaTextBox.Clear();
            NombreEquipoTextBox.Clear();
            DescripcionProblemaTextBox.Clear();
        }
        private void CrearButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            tipoOperacion = "Nuevo";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DeshabilitarControles();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (EquipoComputoDataGridView.SelectedRows.Count > 0)
            {
                IdentidadTextBox.Text = EquipoComputoDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                NombreClienteTextBox.Text = EquipoComputoDataGridView.CurrentRow.Cells["NombreCliente"].Value.ToString();
                ModeloEquipoTextBox.Text = EquipoComputoDataGridView.CurrentRow.Cells["ModeloEquipo"].Value.ToString();
                MarcaTextBox.Text = EquipoComputoDataGridView.CurrentRow.Cells["Marca"].Value.ToString();
                NombreEquipoTextBox.Text = EquipoComputoDataGridView.CurrentRow.Cells["NombreEquipo"].Value.ToString();
                DescripcionProblemaTextBox.Text = EquipoComputoDataGridView.CurrentRow.Cells["EspecificacionProblema"].Value.ToString();
                HabilitarControles();
                IdentidadTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void GenerarButton_Click(object sender, EventArgs e)
        {
            E_Computo = new EquipoComputo();

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
                if (string.IsNullOrEmpty(ModeloEquipoTextBox.Text))
                {
                    errorProvider1.SetError(ModeloEquipoTextBox, "Ingrese un modelo de celular");
                    ModeloEquipoTextBox.Focus();
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
                    errorProvider1.SetError(NombreEquipoTextBox, "Ingrese el nombre del equipo");
                    NombreEquipoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionProblemaTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionProblemaTextBox, "Ingrese el problema del dispositivo");
                    DescripcionProblemaTextBox.Focus();
                    return;
                }

                E_Computo.Identidad = IdentidadTextBox.Text;
                E_Computo.NombreCliente = NombreClienteTextBox.Text;
                E_Computo.ModeloEquipo = ModeloEquipoTextBox.Text;
                E_Computo.Marca = MarcaTextBox.Text;
                E_Computo.NombreEquipo = NombreEquipoTextBox.Text;
                E_Computo.EspecificacionProblemaE = DescripcionProblemaTextBox.Text;

                //bool inserto = await E_ComputoDatos.InsertarAsync(E_Computo);
                var inserto = await E_ComputoDatos.InsertarAsync(E_Computo);

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
                if (string.IsNullOrEmpty(ModeloEquipoTextBox.Text))
                {
                    errorProvider1.SetError(ModeloEquipoTextBox, "Ingrese un modelo de celular");
                    ModeloEquipoTextBox.Focus();
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
                    errorProvider1.SetError(NombreEquipoTextBox, "Ingrese el nombre del equipo");
                    NombreEquipoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionProblemaTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionProblemaTextBox, "Ingrese el problema del dispositivo");
                    DescripcionProblemaTextBox.Focus();
                    return;
                }

                E_Computo.Identidad = IdentidadTextBox.Text;
                E_Computo.NombreCliente = NombreClienteTextBox.Text;
                E_Computo.ModeloEquipo = ModeloEquipoTextBox.Text;
                E_Computo.Marca = MarcaTextBox.Text;
                E_Computo.NombreEquipo = NombreEquipoTextBox.Text;
                E_Computo.EspecificacionProblemaE = DescripcionProblemaTextBox.Text;

                bool modifico = await E_ComputoDatos.ActualizarAsync(E_Computo);
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
    }
}
