using System;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.View.Alquiler;

namespace TitoAlquiler.View.Usuario
{
    public partial class ModificarUsuario : Form
    {
        private readonly UsuarioController usuarioController = UsuarioController.getInstance();
        private Usuarios usuarioActual; // Almacena el usuario actual

        // Constructor que recibe el usuario a modificar
        public ModificarUsuario(Usuarios usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarDatosUsuario(); 
        }

        // Llena los campos con los datos del usuario actual
        private void CargarDatosUsuario()
        {
            textBoxNombre.Text = usuarioActual.nombre;
            textBoxEmail.Text = usuarioActual.email;
            textBoxDNI.Text = usuarioActual.dni.ToString();
            checkBoxMembresia.Checked = usuarioActual.membresiaPremium;
        }
 

        // Método para validar los inputs
        private bool ValidateInputs(out string nombre, out string email, out int dni)
        {
            nombre = textBoxNombre.Text.Trim();
            email = textBoxEmail.Text.Trim();
            string dniText = textBoxDNI.Text.Trim();

            if (!int.TryParse(dniText, out dni) || dniText.Length != 8)
            {
                MessageBox.Show("El DNI debe ser un número válido de 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("El email ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Método para validar el formato del email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains("@");
            }
            catch
            {
                return false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out string nombre, out string email, out int dni))
            {
                MessageBox.Show("Por favor, completa los campos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            usuarioActual.nombre = nombre;
            usuarioActual.email = email;
            usuarioActual.dni = dni;
            usuarioActual.membresiaPremium = checkBoxMembresia.Checked;

            try
            {
                usuarioController.ActualizarUsuario(usuarioActual);
                MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
            formAlquilar.Show();
            this.Hide();
        }
    }
}
