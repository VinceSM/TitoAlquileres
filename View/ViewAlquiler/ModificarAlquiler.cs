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
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.View.ViewAlquiler;
using TitoAlquiler.Resources;

namespace TitoAlquiler.View.ViewAlquiler
{
    public partial class ModificarAlquiler : Form
    {
        private readonly AlquilerController alquilerController;
        private Alquileres alquilerSeleccionado;

        #region Formulario
        public ModificarAlquiler()
        {
            InitializeComponent();
            alquilerController = AlquilerController.Instance;
            CargarAlquileres();
        }
        /// <summary>
        /// Evento que redirige al formulario de visualización de alquileres y oculta el formulario actual.
        /// </summary>
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VerAlquileres formVerAlquileres = new VerAlquileres();
            formVerAlquileres.Show();
            this.Hide();
        }


        /// <summary>
        /// Sobrescribe el comportamiento al cerrar el formulario. Finaliza la aplicación si el usuario cierra.
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
        #endregion

        #region Gestión de Alquileres

        /// <summary>
        /// Carga todos los alquileres activos en el DataGridView.
        /// </summary>
        private void CargarAlquileres()
        {
            try
            {
                var alquileres = alquilerController.ObtenerTodosLosAlquileres();

                if (alquileres == null || !alquileres.Any())
                {
                    MessageShow.MostrarMensajeInformacion("No hay alquileres disponibles para modificar.");
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
                MessageShow.MostrarMensajeError($"Error al cargar alquileres: {ex.Message}");
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el DataGridView de alquileres.
        /// </summary>
        private void DataGridViewAlquileres_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAlquileres.SelectedRows.Count == 0)
            {
                LimpiarDetalleAlquiler();
                return;
            }

            int alquilerId = Convert.ToInt32(dataGridViewAlquileres.SelectedRows[0].Cells["id"].Value);
            CargarDetalleAlquiler(alquilerId);
        }

        /// <summary>
        /// Limpia los detalles del alquiler seleccionado.
        /// </summary>
        private void LimpiarDetalleAlquiler()
        {
            lblDetalleAlquiler.Text = "Seleccione un alquiler para modificar";
            dateTimePickerNuevaFechaInicio.Value = DateTime.Today;
            dateTimePickerNuevaFechaFin.Value = DateTime.Today;
            btnActualizarAlquiler.Enabled = false;
            alquilerSeleccionado = null;
        }

        /// <summary>
        /// Carga los detalles del alquiler seleccionado.
        /// </summary>
        /// <param name="alquilerId">ID del alquiler a cargar.</param>
        private void CargarDetalleAlquiler(int alquilerId)
        {
            try
            {
                alquilerSeleccionado = alquilerController.ObtenerAlquilerPorId(alquilerId);

                if (alquilerSeleccionado == null)
                {
                    MessageShow.MostrarMensajeError("No se encontró el alquiler seleccionado.");
                    LimpiarDetalleAlquiler();
                    return;
                }

                // Verificar si el alquiler ya ha comenzado
                if (alquilerSeleccionado.fechaInicio <= DateTime.Today)
                {
                    MessageShow.MostrarMensajeAdvertencia("No se pueden modificar alquileres que ya han comenzado.");
                    LimpiarDetalleAlquiler();
                    return;
                }

                // Actualizar controles con la información del alquiler
                ActualizarDetalleAlquiler();

                // Habilitar el botón de actualizar
                btnActualizarAlquiler.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar el detalle del alquiler: {ex.Message}");
                LimpiarDetalleAlquiler();
            }
        }

        /// <summary>
        /// Actualiza los controles con la información del alquiler seleccionado.
        /// </summary>
        private void ActualizarDetalleAlquiler()
        {
            // Actualizar etiqueta con detalles del alquiler
            lblDetalleAlquiler.Text = $"Alquiler ID: {alquilerSeleccionado.id}\n" +
                                     $"Item: {alquilerSeleccionado.item?.nombreItem} - {alquilerSeleccionado.item?.marca} {alquilerSeleccionado.item?.modelo}\n" +
                                     $"Usuario: {alquilerSeleccionado.usuario?.nombre}\n" +
                                     $"Fechas actuales: {alquilerSeleccionado.fechaInicio:yyyy-MM-dd} a {alquilerSeleccionado.fechaFin:yyyy-MM-dd}\n" +
                                     $"Días: {alquilerSeleccionado.tiempoDias}\n" +
                                     $"Precio total: ${alquilerSeleccionado.precioTotal}\n" +
                                     $"Estrategia: {alquilerSeleccionado.tipoEstrategia}";

            // Actualizar DateTimePickers con las fechas actuales
            dateTimePickerNuevaFechaInicio.Value = alquilerSeleccionado.fechaInicio;
            dateTimePickerNuevaFechaFin.Value = alquilerSeleccionado.fechaFin;
        }

        /// <summary>
        /// Maneja el evento de cambio de valor en los DateTimePickers.
        /// </summary>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Asegurar que la fecha de fin no sea anterior a la fecha de inicio
            if (dateTimePickerNuevaFechaFin.Value < dateTimePickerNuevaFechaInicio.Value)
            {
                dateTimePickerNuevaFechaFin.Value = dateTimePickerNuevaFechaInicio.Value;
            }

            // Calcular y mostrar una vista previa de los nuevos días y precio
            if (alquilerSeleccionado != null)
            {
                MostrarVistaPreviaActualizacion();
            }
        }

        /// <summary>
        /// Muestra una vista previa de la actualización con los nuevos días y precio estimado.
        /// </summary>
        private void MostrarVistaPreviaActualizacion()
        {
            DateTime nuevaFechaInicio = dateTimePickerNuevaFechaInicio.Value;
            DateTime nuevaFechaFin = dateTimePickerNuevaFechaFin.Value;

            // Calcular nuevos días
            int nuevosDias = (int)(nuevaFechaFin - nuevaFechaInicio).TotalDays + 1;

            // Actualizar etiqueta con vista previa
            lblDetalleAlquiler.Text = $"Alquiler ID: {alquilerSeleccionado.id}\n" +
                                     $"Item: {alquilerSeleccionado.item?.nombreItem} - {alquilerSeleccionado.item?.marca} {alquilerSeleccionado.item?.modelo}\n" +
                                     $"Usuario: {alquilerSeleccionado.usuario?.nombre}\n" +
                                     $"Fechas actuales: {alquilerSeleccionado.fechaInicio:yyyy-MM-dd} a {alquilerSeleccionado.fechaFin:yyyy-MM-dd}\n" +
                                     $"Fechas nuevas: {nuevaFechaInicio:yyyy-MM-dd} a {nuevaFechaFin:yyyy-MM-dd}\n" +
                                     $"Días actuales: {alquilerSeleccionado.tiempoDias} → Nuevos días: {nuevosDias}\n" +
                                     $"Precio actual: ${alquilerSeleccionado.precioTotal}\n" +
                                     $"Estrategia: {alquilerSeleccionado.tipoEstrategia}";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de actualizar alquiler.
        /// </summary>
        private void BtnActualizarAlquiler_Click(object sender, EventArgs e)
        {
            if (alquilerSeleccionado == null)
            {
                MessageShow.MostrarMensajeAdvertencia("No hay un alquiler seleccionado para actualizar.");
                return;
            }

            try
            {
                // Verificar si las fechas han cambiado
                if (dateTimePickerNuevaFechaInicio.Value == alquilerSeleccionado.fechaInicio &&
                    dateTimePickerNuevaFechaFin.Value == alquilerSeleccionado.fechaFin)
                {
                    MessageShow.MostrarMensajeInformacion("No se han realizado cambios en las fechas.");
                    return;
                }

                // Confirmar la actualización
                if (!MessageShow.MostrarMensajeConfirmacion("¿Está seguro de que desea actualizar las fechas del alquiler?"))
                {
                    return;
                }

                // Actualizar fechas del alquiler
                alquilerSeleccionado.fechaInicio = dateTimePickerNuevaFechaInicio.Value;
                alquilerSeleccionado.fechaFin = dateTimePickerNuevaFechaFin.Value;

                // Actualizar el alquiler (el controlador se encargará de recalcular días y precio)
                alquilerController.ActualizarAlquiler(alquilerSeleccionado);

                // Mostrar mensaje de éxito
                MessageShow.MostrarMensajeExito("Alquiler actualizado correctamente.");

                // Recargar alquileres y limpiar selección
                CargarAlquileres();
                LimpiarDetalleAlquiler();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al actualizar el alquiler: {ex.Message}");
            }
        }
        #endregion
    }
}
