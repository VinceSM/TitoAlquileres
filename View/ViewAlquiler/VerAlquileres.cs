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
using TitoAlquiler.Resources;

namespace TitoAlquiler.View.ViewAlquiler
{
    public partial class VerAlquileres : Form
    {
        private AlquilerController alquilerController;
        private ItemController itemController;

        #region Formulario

        public VerAlquileres()
        {
            InitializeComponent();
            InicializarControladores();
            CargarDatosIniciales();
        }

        /// <summary>
        /// Inicializa los controladores necesarios para la operación del formulario.
        /// </summary>
        private void InicializarControladores()
        {
            alquilerController = AlquilerController.Instance;
        }

        /// <summary>
        /// Carga los datos iniciales necesarios para el formulario.
        /// </summary>
        private void CargarDatosIniciales()
        {
            LoadAlquileres();
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario, cerrando toda la aplicación si el usuario lo cierra.
        /// </summary>
        /// <param name="e">Datos del evento de cierre del formulario.</param>
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

        private void btnModificarAlquiler_Click(object sender, EventArgs e)
        {
            ModificarAlquiler modificarAlquiler = new ModificarAlquiler();
            modificarAlquiler.Show();
            this.Hide();
        }

        #endregion

        #region Gestion Alquileres

        /// <summary>
        /// Carga todos los alquileres disponibles desde el controlador y los muestra en el DataGridView.
        /// </summary>
        private void LoadAlquileres()
        {
            try
            {
                var alquileres = ObtenerAlquileresDesdeControlador();

                if (NoHayAlquileres(alquileres))
                {
                    LimpiarTablaAlquileres();
                    MessageShow.MostrarMensajeInformacion("No se encontraron alquileres.");
                    return;
                }

                MostrarAlquileresEnTabla(alquileres);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar alquileres: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene la lista de alquileres desde el controlador.
        /// </summary>
        private List<Alquileres> ObtenerAlquileresDesdeControlador()
        {
            return alquilerController.ObtenerTodosLosAlquileres();
        }

        /// <summary>
        /// Verifica si no hay alquileres disponibles.
        /// </summary>
        private bool NoHayAlquileres(List<Alquileres> alquileres)
        {
            return alquileres == null || !alquileres.Any();
        }

        /// <summary>
        /// Limpia la tabla de alquileres.
        /// </summary>
        private void LimpiarTablaAlquileres()
        {
            dataGridViewAlquileres.Rows.Clear();
        }

        /// <summary>
        /// Muestra los alquileres en la tabla.
        /// </summary>
        private void MostrarAlquileresEnTabla(List<Alquileres> alquileres)
        {
            LimpiarTablaAlquileres();

            foreach (var alquiler in alquileres)
            {
                AgregarFilaAlquiler(alquiler);
            }
        }

        /// <summary>
        /// Agrega una fila con los datos del alquiler a la tabla.
        /// </summary>
        private void AgregarFilaAlquiler(Alquileres alquiler)
        {
            dataGridViewAlquileres.Rows.Add(
                alquiler.id,
                ObtenerMarcaItem(alquiler),
                ObtenerModeloItem(alquiler),
                ObtenerNombreItem(alquiler),
                ObtenerNombreUsuario(alquiler),
                alquiler.tiempoDias,
                FormatearFecha(alquiler.fechaInicio),
                FormatearFecha(alquiler.fechaFin),
                alquiler.precioTotal,
                alquiler.tipoEstrategia
            );
        }

        /// <summary>
        /// Obtiene la marca del ítem del alquiler o un valor por defecto.
        /// </summary>
        private string ObtenerMarcaItem(Alquileres alquiler)
        {
            return alquiler.item?.marca ?? "Sin marca";
        }

        /// <summary>
        /// Obtiene el modelo del ítem del alquiler o un valor por defecto.
        /// </summary>
        private string ObtenerModeloItem(Alquileres alquiler)
        {
            return alquiler.item?.modelo ?? "Sin modelo";
        }

        /// <summary>
        /// Obtiene el nombre del ítem del alquiler o un valor por defecto.
        /// </summary>
        private string ObtenerNombreItem(Alquileres alquiler)
        {
            return alquiler.item?.nombreItem ?? "Sin nombre";
        }

        /// <summary>
        /// Obtiene el nombre del usuario del alquiler o un valor por defecto.
        /// </summary>
        private string ObtenerNombreUsuario(Alquileres alquiler)
        {
            return alquiler.usuario?.nombre ?? "Sin usuario";
        }

        /// <summary>
        /// Formatea una fecha para mostrarla en la tabla.
        /// </summary>
        private string FormatearFecha(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Cierra el alquiler seleccionado en el DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento del botón.</param>
        private void btnCerrarAlquiler_Click(object sender, EventArgs e)
        {
            if (!HayAlquilerSeleccionado())
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un alquiler para cerrar.");
                return;
            }

            var alquiler = ObtenerAlquilerSeleccionado();

            if (alquiler == null)
            {
                MessageShow.MostrarMensajeError("No se encontró el alquiler seleccionado.");
                return;
            }

            if (ConfirmarCierreAlquiler())
            {
                CerrarAlquiler(alquiler);
            }
        }

        /// <summary>
        /// Verifica si hay un alquiler seleccionado en la tabla.
        /// </summary>
        private bool HayAlquilerSeleccionado()
        {
            return dataGridViewAlquileres.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Obtiene el alquiler seleccionado en la tabla.
        /// </summary>
        private Alquileres ObtenerAlquilerSeleccionado()
        {
            int selectedId = ObtenerIdAlquilerSeleccionado();
            return alquilerController.ObtenerAlquilerPorId(selectedId);
        }

        /// <summary>
        /// Obtiene el ID del alquiler seleccionado en la tabla.
        /// </summary>
        private int ObtenerIdAlquilerSeleccionado()
        {
            return Convert.ToInt32(dataGridViewAlquileres.SelectedRows[0].Cells["id"].Value);
        }

        /// <summary>
        /// Muestra un diálogo de confirmación para cerrar el alquiler.
        /// </summary>
        private bool ConfirmarCierreAlquiler()
        {
            var confirmResult = MessageBox.Show(
                "¿Está seguro de que desea cerrar este alquiler?",
                "Confirmar cierre de alquiler",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return confirmResult == DialogResult.Yes;
        }

        /// <summary>
        /// Cierra el alquiler y actualiza la interfaz.
        /// </summary>
        private void CerrarAlquiler(Alquileres alquiler)
        {
            if (alquilerController.EliminarAlquiler(alquiler.id))
            {
                MessageShow.MostrarMensajeExito("El alquiler se ha cerrado correctamente.");
                LoadAlquileres();
            }
        }

        #endregion
    }
}

