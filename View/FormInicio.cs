using TitoAlquiler.View.ViewAlquiler;
using TitoAlquiler.View.ViewUsuario;
using System;
using System.Windows.Forms;

namespace TitoAlquiler
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navega a la ventana principal de alquiler y oculta la ventana actual.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método se activa al hacer clic en el botón "Entrar", y oculta la ventana actual para mostrar la ventana principal del sistema de alquiler.
        /// </remarks>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            CrearAlquiler form = new CrearAlquiler();
            form.Show();
            this.Hide();
        }

        /// <summary>
        /// Controla el evento de cierre del formulario.
        /// </summary>
        /// <param name="e">Los datos del evento de cierre del formulario.</param>
        /// <remarks>
        /// Este método asegura que, al cerrar la ventana mediante la acción del usuario, se cierre toda la aplicación.
        /// </remarks>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}