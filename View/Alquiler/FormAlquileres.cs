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

namespace TitoAlquiler.View.Alquiler
{
    public partial class FormAlquileres : Form
    {
        private AlquilerController alquilerController;

        public FormAlquileres()
        {
            InitializeComponent();
            alquilerController = AlquilerController.getInstance();
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
            FormAlquilar formAlquilar = new FormAlquilar();
            formAlquilar.Show();
            this.Hide();
        }


        #region FormAlquileres

        /// <summary>
        /// Carga todos los alquileres disponibles desde el controlador y los muestra en el DataGridView.
        /// </summary>
        private void LoadAlquileres()
        {
            var alquileres = alquilerController.ObtenerTodosLosAlquileres();
            dataGridViewAlquileres.DataSource = alquileres;
        }

        /// <summary>
        /// Cierra el alquiler seleccionado en el DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento del botón.</param>
        private void btnCerrarAlquiler_Click(object sender, EventArgs e)
        {
            if (dataGridViewAlquileres.SelectedRows.Count > 0)
            {
                var selectedAlquiler = (Alquileres)dataGridViewAlquileres.SelectedRows[0].DataBoundItem;
                DialogResult result = MessageBox.Show($"¿Está seguro que desea cerrar el alquiler de {selectedAlquiler.item.nombreItem}?",
                    "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        alquilerController.EliminarAlquiler(selectedAlquiler);
                        MessageBox.Show("Alquiler cerrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAlquileres(); // Cargar la lista de alquileres
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cerrar el alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un alquiler para cerrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
