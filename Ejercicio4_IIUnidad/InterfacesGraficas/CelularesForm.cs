using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace InterfacesGraficas
{
    public partial class CelularesForm : Form
    {
        public CelularesForm()
        {
            InitializeComponent();
        }
        CelularesDatos celDatos = new CelularesDatos();
        Celulares dispositivo;
        string tipoOperacion = string.Empty;
        string Soporte = "Celulares";

        private void HabilitarControles()
        {
            IdentidadTextBox.Enabled = true;
            NombreClienteTextBox.Enabled = true;
            ModeloTextBox.Enabled = true;
            MarcaTextBox.Enabled = true;
            AlmacenamientoTextBox.Enabled = true;
            RAMTextBox.Enabled = true;
            DescripcionProblemaTextBox.Enabled = true;
        }
        private void DeshabilitarControles()
        {
            IdentidadTextBox.Enabled = false;
            NombreClienteTextBox.Enabled = false;
            ModeloTextBox.Enabled = false;
            MarcaTextBox.Enabled = false;
            AlmacenamientoTextBox.Enabled = false;
            RAMTextBox.Enabled = false;
            DescripcionProblemaTextBox.Enabled = false;
        }
        private void LimpiarControles()
        {
            IdentidadTextBox.Clear();
            NombreClienteTextBox.Clear();
            ModeloTextBox.Clear();
            MarcaTextBox.Clear();
            AlmacenamientoTextBox.Clear();
            RAMTextBox.Clear();
            DescripcionProblemaTextBox.Clear();
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
            CelularesDataGridView.DataSource = await celDatos.DevolverListaAsync();
        }

        private async void GenerarButton_Click(object sender, EventArgs e)
        {
            dispositivo = new Celulares();

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
                    errorProvider1.SetError(ModeloTextBox, "Ingrese un modelo de celular");
                    ModeloTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(MarcaTextBox.Text))
                {
                    errorProvider1.SetError(MarcaTextBox, "Ingrese una marca");
                    MarcaTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(AlmacenamientoTextBox.Text))
                {
                    errorProvider1.SetError(AlmacenamientoTextBox, "Ingrese una cantidad de almacenamiento");
                    AlmacenamientoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(RAMTextBox.Text))
                {
                    errorProvider1.SetError(RAMTextBox, "Ingrese la memoria RAM del dispositivo");
                    RAMTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionProblemaTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionProblemaTextBox, "Ingrese el problema del dispositivo");
                    DescripcionProblemaTextBox.Focus();
                    return;
                }

                dispositivo.Identidad = IdentidadTextBox.Text;
                dispositivo.NombreCliente = NombreClienteTextBox.Text;
                dispositivo.Modelo = ModeloTextBox.Text;
                dispositivo.Marca = MarcaTextBox.Text;
                dispositivo.Almacenamiento = AlmacenamientoTextBox.Text;
                dispositivo.RAM = RAMTextBox.Text;
                dispositivo.EspecificacionProblema = DescripcionProblemaTextBox.Text;

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
                    errorProvider1.SetError(ModeloTextBox, "Ingrese un modelo de celular");
                    ModeloTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(MarcaTextBox.Text))
                {
                    errorProvider1.SetError(MarcaTextBox, "Ingrese una marca");
                    MarcaTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(AlmacenamientoTextBox.Text))
                {
                    errorProvider1.SetError(AlmacenamientoTextBox, "Ingrese una cantidad de almacenamiento");
                    AlmacenamientoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(RAMTextBox.Text))
                {
                    errorProvider1.SetError(RAMTextBox, "Ingrese la memoria RAM del dispositivo");
                    RAMTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionProblemaTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionProblemaTextBox, "Ingrese el problema del dispositivo");
                    DescripcionProblemaTextBox.Focus();
                    return;
                }

                dispositivo.Identidad = IdentidadTextBox.Text;
                dispositivo.NombreCliente = NombreClienteTextBox.Text;
                dispositivo.Modelo = ModeloTextBox.Text;
                dispositivo.Marca = MarcaTextBox.Text;
                dispositivo.Almacenamiento = AlmacenamientoTextBox.Text;
                dispositivo.RAM = RAMTextBox.Text;
                dispositivo.EspecificacionProblema = DescripcionProblemaTextBox.Text;

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
            if (CelularesDataGridView.SelectedRows.Count > 0)
            {
                IdentidadTextBox.Text = CelularesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                NombreClienteTextBox.Text = CelularesDataGridView.CurrentRow.Cells["NombreCliente"].Value.ToString();
                ModeloTextBox.Text = CelularesDataGridView.CurrentRow.Cells["Modelo"].Value.ToString();
                MarcaTextBox.Text = CelularesDataGridView.CurrentRow.Cells["Marca"].Value.ToString();
                AlmacenamientoTextBox.Text = CelularesDataGridView.CurrentRow.Cells["Almacenamiento"].Value.ToString();
                RAMTextBox.Text = CelularesDataGridView.CurrentRow.Cells["RAM"].Value.ToString();
                DescripcionProblemaTextBox.Text = CelularesDataGridView.CurrentRow.Cells["EspecificacionProblema"].Value.ToString();
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
