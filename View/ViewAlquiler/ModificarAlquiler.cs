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
            dateTimePickerNuevaFechaInicio.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePickerNuevaFechaFin.ValueChanged += DateTimePicker_ValueChanged;

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
        /// Maneja el evento de cambio de valor en los DateTimePickers, validando las fechas
        /// y actualizando la vista previa del alquiler.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar las fechas seleccionadas
                ValidarFechasSeleccionadas();

                // Mostrar vista previa de la actualización si hay un alquiler seleccionado
                if (alquilerSeleccionado != null)
                {
                    MostrarVistaPreviaActualizacion();
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al procesar el cambio de fecha: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida las fechas seleccionadas en los DateTimePickers según las reglas de negocio.
        /// </summary>
        private void ValidarFechasSeleccionadas()
        {
            DateTime hoy = DateTime.Today;

            // Aplicar reglas de validación según el estado del alquiler
            if (EsAlquilerFuturo(hoy))
            {
                ValidarFechasParaAlquilerFuturo(hoy);
            }
            else if (EsAlquilerEnCurso(hoy))
            {
                RestringirFechaInicioParaAlquilerEnCurso();
            }

            // Asegurar que la fecha de fin no sea anterior a la fecha de inicio
            ValidarCoherenciaEntreFechas();
        }

        /// <summary>
        /// Determina si el alquiler seleccionado es un alquiler futuro (aún no ha comenzado).
        /// </summary>
        /// <param name="fechaActual">La fecha actual para comparar.</param>
        /// <returns>True si el alquiler es futuro, false en caso contrario.</returns>
        private bool EsAlquilerFuturo(DateTime fechaActual)
        {
            return alquilerSeleccionado != null && alquilerSeleccionado.fechaInicio > fechaActual;
        }

        /// <summary>
        /// Determina si el alquiler seleccionado está en curso (ya ha comenzado).
        /// </summary>
        /// <param name="fechaActual">La fecha actual para comparar.</param>
        /// <returns>True si el alquiler está en curso, false en caso contrario.</returns>
        private bool EsAlquilerEnCurso(DateTime fechaActual)
        {
            return alquilerSeleccionado != null && alquilerSeleccionado.fechaInicio <= fechaActual;
        }

        /// <summary>
        /// Valida las fechas para un alquiler futuro, asegurando que no sean anteriores a hoy.
        /// </summary>
        /// <param name="fechaActual">La fecha actual para comparar.</param>
        private void ValidarFechasParaAlquilerFuturo(DateTime fechaActual)
        {
            if (dateTimePickerNuevaFechaInicio.Value < fechaActual && dateTimePickerNuevaFechaFin.Value < fechaActual)
            {
                dateTimePickerNuevaFechaInicio.Value = fechaActual;
                dateTimePickerNuevaFechaFin.Value = fechaActual;
                MessageShow.MostrarMensajeAdvertencia("La fecha de inicio no puede ser anterior a hoy.");
            }
        }

        /// <summary>
        /// Restringe la modificación de la fecha de inicio para alquileres en curso.
        /// </summary>
        private void RestringirFechaInicioParaAlquilerEnCurso()
        {
            dateTimePickerNuevaFechaInicio.Value = alquilerSeleccionado.fechaInicio;
            dateTimePickerNuevaFechaInicio.Enabled = false;
        }

        /// <summary>
        /// Valida que la fecha de fin no sea anterior a la fecha de inicio.
        /// </summary>
        private void ValidarCoherenciaEntreFechas()
        {
            if (dateTimePickerNuevaFechaFin.Value < dateTimePickerNuevaFechaInicio.Value)
            {
                dateTimePickerNuevaFechaFin.Value = dateTimePickerNuevaFechaInicio.Value;
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
        /// Maneja el evento de clic en el botón de actualizar alquiler, validando y aplicando
        /// los cambios a las fechas del alquiler seleccionado.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActualizarAlquiler_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya un alquiler seleccionado
                if (!ValidarAlquilerSeleccionado())
                {
                    return;
                }

                // Verificar si las fechas han cambiado
                if (!HanCambiadoLasFechas())
                {
                    MessageShow.MostrarMensajeInformacion("No se han realizado cambios en las fechas.");
                    return;
                }

                // Solicitar confirmación según el estado del alquiler
                if (!SolicitarConfirmacionActualizacion())
                {
                    return;
                }

                // Actualizar el alquiler
                ActualizarAlquiler();

                // Recargar datos y limpiar selección
                FinalizarActualizacion();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al actualizar el alquiler: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida que haya un alquiler seleccionado para actualizar.
        /// </summary>
        /// <returns>True si hay un alquiler seleccionado, false en caso contrario.</returns>
        private bool ValidarAlquilerSeleccionado()
        {
            if (alquilerSeleccionado == null)
            {
                MessageShow.MostrarMensajeAdvertencia("No hay un alquiler seleccionado para actualizar.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica si las fechas seleccionadas son diferentes a las fechas actuales del alquiler.
        /// </summary>
        /// <returns>True si las fechas han cambiado, false en caso contrario.</returns>
        private bool HanCambiadoLasFechas()
        {
            return dateTimePickerNuevaFechaInicio.Value != alquilerSeleccionado.fechaInicio ||
                   dateTimePickerNuevaFechaFin.Value != alquilerSeleccionado.fechaFin;
        }

        /// <summary>
        /// Solicita confirmación al usuario para actualizar el alquiler, con un mensaje
        /// específico según si el alquiler ya ha comenzado o no.
        /// </summary>
        /// <returns>True si el usuario confirma la actualización, false en caso contrario.</returns>
        private bool SolicitarConfirmacionActualizacion()
        {
            if (EsAlquilerEnCurso(DateTime.Today))
            {
                return SolicitarConfirmacionAlquilerEnCurso();
            }
            else
            {
                return SolicitarConfirmacionAlquilerFuturo();
            }
        }

        /// <summary>
        /// Solicita confirmación específica para actualizar un alquiler en curso.
        /// </summary>
        /// <returns>True si el usuario confirma, false en caso contrario.</returns>
        private bool SolicitarConfirmacionAlquilerEnCurso()
        {
            return MessageShow.MostrarMensajeConfirmacion(
                "Este alquiler ya ha comenzado. Modificar las fechas podría afectar la facturación y disponibilidad. ¿Desea continuar?");
        }

        /// <summary>
        /// Solicita confirmación para actualizar un alquiler futuro.
        /// </summary>
        /// <returns>True si el usuario confirma, false en caso contrario.</returns>
        private bool SolicitarConfirmacionAlquilerFuturo()
        {
            return MessageShow.MostrarMensajeConfirmacion("¿Está seguro de que desea actualizar las fechas del alquiler?");
        }

        /// <summary>
        /// Actualiza las fechas del alquiler y guarda los cambios.
        /// </summary>
        private void ActualizarAlquiler()
        {
            // Actualizar fechas del alquiler
            alquilerSeleccionado.fechaInicio = dateTimePickerNuevaFechaInicio.Value;
            alquilerSeleccionado.fechaFin = dateTimePickerNuevaFechaFin.Value;

            // Guardar cambios (el controlador recalculará días y precio)
            alquilerController.ActualizarAlquiler(alquilerSeleccionado);
        }

        /// <summary>
        /// Finaliza el proceso de actualización mostrando un mensaje de éxito,
        /// recargando los alquileres y limpiando la selección.
        /// </summary>
        private void FinalizarActualizacion()
        {
            // Mostrar mensaje de éxito
            MessageShow.MostrarMensajeExito("Alquiler actualizado correctamente.");

            // Recargar alquileres y limpiar selección
            CargarAlquileres();
            LimpiarDetalleAlquiler();
        }
        #endregion
    }
}