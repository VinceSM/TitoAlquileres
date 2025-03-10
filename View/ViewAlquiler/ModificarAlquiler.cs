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
        private AlquilerController alquilerController = AlquilerController.Instance;
        private Alquileres alquilerSeleccionado;

        #region Formulario
        public ModificarAlquiler()
        {
            InitializeComponent();
            ConfigurarControles();
            CargarAlquileres();
        }

        private void ConfigurarControles()
        {
            // Conectar eventos
            dataGridViewAlquileres.SelectionChanged += dataGridViewAlquileres_SelectionChanged;
            dateTimePickerNuevaFechaInicio.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePickerNuevaFechaFin.ValueChanged += DateTimePicker_ValueChanged;
            btnActualizarAlquiler.Click += btnActualizarAlquiler_Click;

            // Inicializar controles
            lblDetalleAlquiler.Text = "Seleccione un alquiler para modificar";
            btnActualizarAlquiler.Enabled = false;
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

        #region Cargar Alquileres

        /// <summary>
        /// Carga todos los alquileres disponibles en el DataGridView.
        /// Muestra un mensaje informativo si no hay alquileres disponibles.
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

        #endregion

        #region DataGridView Alquileres

        /// <summary>
        /// Maneja el evento de cambio de selección en el DataGridView de alquileres.
        /// Carga los detalles del alquiler seleccionado o limpia los detalles si no hay selección.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento que contienen información sobre el cambio de selección.</param>
        private void dataGridViewAlquileres_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAlquileres.SelectedRows.Count == 0)
            {
                LimpiarDetalleAlquiler();
                return;
            }

            int alquilerId = Convert.ToInt32(dataGridViewAlquileres.SelectedRows[0].Cells["id"].Value);
            CargarDetalleAlquiler(alquilerId);
        }

        #endregion

        #region Detalle Alquiler

        /// <summary>
        /// Limpia los detalles del alquiler seleccionado y restablece los controles a sus valores predeterminados.
        /// </summary>
        private void LimpiarDetalleAlquiler()
        {
            lblDetalleAlquiler.Text = "Seleccione un alquiler para modificar";
            dateTimePickerNuevaFechaInicio.Value = DateTime.Today;
            dateTimePickerNuevaFechaFin.Value = DateTime.Today.AddDays(1);
            btnActualizarAlquiler.Enabled = false;
            alquilerSeleccionado = null;
        }

        /// <summary>
        /// Carga y muestra los detalles del alquiler seleccionado por su ID.
        /// Habilita los controles de edición si el alquiler existe.
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

                dateTimePickerNuevaFechaInicio.Enabled = true;
                dateTimePickerNuevaFechaFin.Enabled = true;
                btnActualizarAlquiler.Enabled = true;

                ActualizarDetalleAlquiler();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar el detalle del alquiler: {ex.Message}");
                LimpiarDetalleAlquiler();
            }
        }

        /// <summary>
        /// Actualiza los controles del formulario con la información del alquiler seleccionado.
        /// </summary>
        private void ActualizarDetalleAlquiler()
        {
            lblDetalleAlquiler.Text = $"Item: {alquilerSeleccionado.item?.nombreItem} - {alquilerSeleccionado.item?.marca} {alquilerSeleccionado.item?.modelo}\n" +
                                      $"Usuario: {alquilerSeleccionado.usuario?.nombre}\n" +
                                      $"Fechas actuales: {alquilerSeleccionado.fechaInicio:yyyy-MM-dd} a {alquilerSeleccionado.fechaFin:yyyy-MM-dd}\n" +
                                      $"Días: {alquilerSeleccionado.tiempoDias}\n" +
                                      $"Precio total: ${alquilerSeleccionado.precioTotal}\n" +
                                      $"Estrategia: {alquilerSeleccionado.tipoEstrategia}";

            dateTimePickerNuevaFechaInicio.Value = alquilerSeleccionado.fechaInicio;
            dateTimePickerNuevaFechaFin.Value = alquilerSeleccionado.fechaFin;
        }

        /// <summary>
        /// Muestra una vista previa de la actualización con los nuevos días calculados
        /// basados en las fechas seleccionadas.
        /// </summary>
        private void DetallePrevioActualizacion()
        {
            DateTime nuevaFechaInicio = dateTimePickerNuevaFechaInicio.Value;
            DateTime nuevaFechaFin = dateTimePickerNuevaFechaFin.Value;
            int nuevosDias = (int)(nuevaFechaFin - nuevaFechaInicio).TotalDays + 1;

            lblDetalleAlquiler.Text = $"Item: {alquilerSeleccionado.item?.nombreItem} - {alquilerSeleccionado.item?.marca} {alquilerSeleccionado.item?.modelo}\n" +
                                      $"Usuario: {alquilerSeleccionado.usuario?.nombre}\n" +
                                      $"Fechas actuales: {alquilerSeleccionado.fechaInicio:yyyy-MM-dd} a {alquilerSeleccionado.fechaFin:yyyy-MM-dd}\n" +
                                      $"Fechas nuevas: {nuevaFechaInicio:yyyy-MM-dd} a {nuevaFechaFin:yyyy-MM-dd}\n" +
                                      $"Días actuales: {alquilerSeleccionado.tiempoDias} → Nuevos días: {nuevosDias}\n" +
                                      $"Precio actual: ${alquilerSeleccionado.precioTotal}\n" +
                                      $"Estrategia: {alquilerSeleccionado.tipoEstrategia}";
        }

        #endregion

        #region Fechas Alquiler

        /// <summary>
        /// Maneja el evento de cambio de valor en los DateTimePickers.
        /// Valida las fechas seleccionadas y muestra una vista previa de la actualización.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento que contienen información sobre el cambio de valor.</param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (alquilerSeleccionado == null) return;

            try
            {
                // Validar fecha de inicio
                ValidarFechaInicio();

                // Validar fecha de fin
                ValidarFechaFin();

                // Calcular días entre las fechas
                int nuevosDias = (int)(dateTimePickerNuevaFechaFin.Value.Date - dateTimePickerNuevaFechaInicio.Value.Date).TotalDays + 1;

                // Verificar que el alquiler dure al menos un día
                if (nuevosDias < 1)
                {
                    MessageShow.MostrarMensajeAdvertencia("Un alquiler debe durar al menos un día.");
                    RestaurarFechasOriginales(alquilerSeleccionado.fechaInicio, alquilerSeleccionado.fechaFin);
                    return;
                }

                // Mostrar vista previa de la actualización
                DetallePrevioActualizacion();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError(ex.Message);

                // Restaurar valores originales en caso de error
                RestaurarFechasOriginales(alquilerSeleccionado.fechaInicio, alquilerSeleccionado.fechaFin);
            }
        }

        /// <summary>
        /// Valida que la fecha de inicio cumpla con las reglas de negocio.
        /// Lanza una excepción si la fecha de inicio es anterior a la fecha actual.
        /// </summary>
        /// <exception cref="Exception">Se lanza cuando la fecha de inicio es anterior a la fecha actual.</exception>
        private void ValidarFechaInicio()
        {
            // Validar que la fecha de inicio no sea anterior a hoy
            if (dateTimePickerNuevaFechaInicio.Value < DateTime.Today)
            {
                throw new Exception("La fecha de inicio debe ser mayor o igual a la fecha de hoy.");
            }
        }

        /// <summary>
        /// Valida que la fecha de fin cumpla con las reglas de negocio.
        /// </summary>
        private void ValidarFechaFin()
        {
            // Comparamos solo las fechas sin la hora para evitar problemas
            DateTime fechaInicio = dateTimePickerNuevaFechaInicio.Value.Date;
            DateTime fechaFin = dateTimePickerNuevaFechaFin.Value.Date;

            // Verificamos que la fecha de fin no sea anterior a la fecha de inicio
            if (fechaFin < fechaInicio)
            {
                throw new Exception("La fecha de fin debe ser igual o posterior a la fecha de inicio.");
            }
        }

        /// <summary>
        /// Verifica si las fechas han cambiado y realiza validaciones finales.
        /// </summary>
        /// <returns>True si la actualización es necesaria y las fechas son válidas, false en caso contrario.</returns>
        /// <exception cref="Exception">Se lanza cuando alguna de las validaciones de fechas falla.</exception>
        private bool EsActualizacionNecesaria()
        {
            return !FechasNoCambiaron();
        }

        /// <summary>
        /// Comprueba si las fechas seleccionadas son idénticas a las originales.
        /// </summary>
        /// <returns>True si las fechas no han cambiado, false si hay cambios.</returns>
        private bool FechasNoCambiaron()
        {
            return dateTimePickerNuevaFechaInicio.Value == alquilerSeleccionado.fechaInicio &&
                   dateTimePickerNuevaFechaFin.Value == alquilerSeleccionado.fechaFin;
        }

        /// <summary>
        /// Aplica las nuevas fechas seleccionadas al alquiler.
        /// </summary>
        private void AplicarNuevasFechas()
        {
            alquilerSeleccionado.fechaInicio = dateTimePickerNuevaFechaInicio.Value;
            alquilerSeleccionado.fechaFin = dateTimePickerNuevaFechaFin.Value;
        }

        /// <summary>
        /// Restaura las fechas originales del alquiler en caso de error.
        /// </summary>
        /// <param name="fechaInicio">La fecha de inicio original a restaurar.</param>
        /// <param name="fechaFin">La fecha de fin original a restaurar.</param>
        private void RestaurarFechasOriginales(DateTime fechaInicio, DateTime fechaFin)
        {
            alquilerSeleccionado.fechaInicio = fechaInicio;
            alquilerSeleccionado.fechaFin = fechaFin;
            dateTimePickerNuevaFechaInicio.Value = fechaInicio;
            dateTimePickerNuevaFechaFin.Value = fechaFin;
        }

        #endregion

        #region Btn Actualizar Alquiler
        /// <summary>
        /// Maneja el evento de clic en el botón de actualizar alquiler.
        /// Valida y procesa la actualización del alquiler seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento que contienen información sobre el clic.</param>
        private void btnActualizarAlquiler_Click(object sender, EventArgs e)
        {
            try
            {
                if (EsActualizacionValida())
                {
                    ActualizarAlquiler();
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError(ex.Message);
            }
        }

        /// <summary>
        /// Verifica si la actualización es necesaria y confirmada por el usuario.
        /// </summary>
        /// <returns>True si la actualización es válida y confirmada, false en caso contrario.</returns>
        private bool EsActualizacionValida()
        {
            if (!EsActualizacionNecesaria()) return false;

            return MessageShow.MostrarMensajeConfirmacion("¿Está seguro de que desea actualizar las fechas del alquiler?");
        }

        /// <summary>
        /// Realiza la actualización del alquiler y maneja posibles errores.
        /// Guarda las fechas originales para restaurarlas en caso de error.
        /// </summary>
        private void ActualizarAlquiler()
        {
            DateTime fechaInicioOriginal = alquilerSeleccionado.fechaInicio;
            DateTime fechaFinOriginal = alquilerSeleccionado.fechaFin;

            try
            {
                AplicarNuevasFechas();

                alquilerController.ActualizarAlquiler(alquilerSeleccionado);

                MessageShow.MostrarMensajeExito("Alquiler actualizado correctamente.");

                RefrescarAlquileres();
            }
            catch (Exception ex)
            {
                RestaurarFechasOriginales(fechaInicioOriginal, fechaFinOriginal);
                MessageShow.MostrarMensajeError($"Error al actualizar el alquiler: {ex.Message}");
            }
        }

        /// <summary>
        /// Recarga la lista de alquileres y mantiene seleccionado el mismo alquiler.
        /// </summary>
        private void RefrescarAlquileres()
        {
            CargarAlquileres();
            SeleccionarAlquilerPorId(alquilerSeleccionado.id);
        }

        /// <summary>
        /// Selecciona un alquiler en el DataGridView por su ID.
        /// </summary>
        /// <param name="alquilerId">ID del alquiler a seleccionar.</param>
        private void SeleccionarAlquilerPorId(int alquilerId)
        {
            foreach (DataGridViewRow row in dataGridViewAlquileres.Rows)
            {
                if (Convert.ToInt32(row.Cells["id"].Value) == alquilerId)
                {
                    dataGridViewAlquileres.ClearSelection();
                    row.Selected = true;
                    dataGridViewAlquileres.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
        #endregion
    }
}