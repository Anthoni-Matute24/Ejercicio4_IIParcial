using Datos;
using System;
using System.Windows.Forms;

namespace InterfacesGraficas
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private async void AccederButton_Click(object sender, EventArgs e)
        {
            if (CorreoTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(CorreoTextBox, "Ingrese un código de usuario");
                CorreoTextBox.Focus();
                return;

            }
            errorProvider1.Clear();

            if (ClaveTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                ClaveTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            // Instanciar un objeto de la clase "UsuarioDatos"
            UsuarioDatos userDatos = new UsuarioDatos();

            // Llamada del método "LoginAsync" para validar el acceso al sistema
            bool valido = await userDatos.LoginAsync(CorreoTextBox.Text, ClaveTextBox.Text);

            if (valido)
            {
                // Muestra el menú principal
                Menu formulario = new Menu();
                Hide(); // Oculta el formulario Login 
                formulario.Show();
            }
            else
            {   // Error en el inicio de sesión
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CerrarButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizarButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
