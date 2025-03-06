using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.View.ViewAlquiler
{
    public partial class VerAlquileres : Form
    {
        private AlquilerController alquilerController;
        private ItemController itemController;

        #region Form
        public VerAlquileres()
        {
            InitializeComponent();
            alquilerController = AlquilerController.Instance;
            LoadAlquileres();
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario para finalizar la aplicación si el usuario cierra la ventana.
        /// </summary>
        /// <param name="e">Argumentos del evento de cierre del formulario.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Navega de vuelta al formulario principal para gestionar alquileres.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento del enlace.</param>
        private void linkLabelVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
            formAlquilar.Show();
            this.Hide();
        }
#endregion

        #region VerAlquileres

        /// <summary>
        /// Carga todos los alquileres disponibles desde el controlador y los muestra en el DataGridView.
        /// </summary>
        private void LoadAlquileres()
        {
            try
            {
                var alquileres = alquilerController.ObtenerTodosLosAlquileres();

                if (alquileres == null || !alquileres.Any())
                {
                    dataGridViewAlquileres.Rows.Clear();
                    MessageBox.Show("No se encontraron alquileres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridViewAlquileres.Rows.Clear();

                foreach (var alquiler in alquileres)
                {
                    dataGridViewAlquileres.Rows.Add(
                        alquiler.id,
                        alquiler.item?.marca ?? "Sin marca",
                        alquiler.item?.modelo ?? "Sin modelo",
                        alquiler.item?.nombreItem ?? "Sin nombre",
                        alquiler.usuario?.nombre ?? "Sin usuario", 
                        alquiler.tiempoDias,
                        alquiler.fechaInicio.ToString("yyyy-MM-dd"),
                        alquiler.fechaFin.ToString("yyyy-MM-dd"),
                        alquiler.precioTotal,
                        alquiler.tipoEstrategia
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alquileres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Cierra el alquiler seleccionado en el DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento del botón.</param>
        private void btnCerrarAlquiler_Click(object sender, EventArgs e)
        {
            if (dataGridViewAlquileres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un alquiler para cerrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = Convert.ToInt32(dataGridViewAlquileres.SelectedRows[0].Cells["id"].Value);
            var alquiler = alquilerController.ObtenerAlquilerPorId(selectedId);

            if (alquiler == null)
            {
                MessageBox.Show("No se encontró el alquiler seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                "¿Está seguro de que desea cerrar este alquiler?",
                "Confirmar cierre de alquiler",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (alquilerController.EliminarAlquiler(alquiler.id))
                {
                    MessageBox.Show("El alquiler se ha cerrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAlquileres();
                }
            }
        }
        #endregion
    }
}
