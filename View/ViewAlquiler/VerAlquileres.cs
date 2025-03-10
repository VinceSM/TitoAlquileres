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

        #region Formulario

        public VerAlquileres()
        {
            InitializeComponent();
            alquilerController = AlquilerController.Instance;
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
            // Verificar y cerrar alquileres vencidos primero
            alquilerController.VerificarYCerrarAlquileresVencidos();
            try
            {
                var alquileres = alquilerController.ObtenerTodosLosAlquileres(); 

                if (alquileres == null || !alquileres.Any())
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
                dataGridViewAlquileres.Rows.Add(
                alquiler.id,
                alquiler.item?.marca ?? "Sin marca",
                alquiler.item?.modelo ?? "Sin modelo",
                alquiler.item?.nombreItem ?? "Sin nombre",
                alquiler.usuario?.nombre ?? "Sin usuario",
                alquiler.tiempoDias,
                FormatearFecha(alquiler.fechaInicio),
                FormatearFecha(alquiler.fechaFin),
                alquiler.precioTotal,
                alquiler.tipoEstrategia
                );
            }
        }

        /// <summary>
        /// Formatea una fecha para mostrarla en la tabla.
        /// </summary>
        private string FormatearFecha(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Obtiene el alquiler seleccionado en la tabla.
        /// </summary>
        private Alquileres ObtenerAlquilerSeleccionado()
        {
            int selectedId = Convert.ToInt32(dataGridViewAlquileres.SelectedRows[0].Cells["id"].Value);

            return alquilerController.ObtenerAlquilerPorId(selectedId);
        }

        #endregion

        /// <summary>
        /// Maneja el evento de clic en el botón de devolución anticipada, permitiendo finalizar
        /// un alquiler antes de la fecha prevista.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método permite al usuario realizar la devolución anticipada de un ítem alquilado,
        /// actualizando la fecha de finalización al día actual, recalculando los días de alquiler
        /// y el precio correspondiente, y marcando el alquiler como finalizado.
        /// </remarks>
        private void btnDevolucionAnticipada_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarYObtenerAlquilerSeleccionado(out Alquileres alquiler);

                if (!CancelarAlquilerActivo(alquiler))
                {
                    return;
                }

                if (!SolicitarConfirmacionDevolucionAnticipada(alquiler))
                {
                    return;
                }

                ProcesarDevolucionAnticipada(alquiler);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al procesar la devolución anticipada: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida que haya un alquiler seleccionado y lo obtiene.
        /// </summary>
        /// <param name="alquiler">El alquiler seleccionado (salida).</param>
        /// <returns>True si se seleccionó y obtuvo un alquiler válido, false en caso contrario.</returns>
        private bool ValidarYObtenerAlquilerSeleccionado(out Alquileres alquiler)
        {
            bool isValid = true;

            alquiler = ObtenerAlquilerSeleccionado();

            if (alquiler == null)
            {
                MessageShow.MostrarMensajeError("No se encontró el alquiler seleccionado.");
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Cancela el alquiler activo.
        /// </summary>
        /// <param name="alquiler">El alquiler a validar.</param>
        /// <returns>True si el alquiler está activo, false si ya ha finalizado.</returns>
        private bool CancelarAlquilerActivo(Alquileres alquiler)
        {
            bool isValid = true;

            if (alquiler.fechaInicio > DateTime.Today)
            {
                bool cancelar = MessageShow.MostrarMensajeConfirmacion(
                    "Este alquiler aún no ha finalizado. ¿Desea cancelarlo completamente?");
        
                if (!cancelar)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Solicita confirmación al usuario para realizar la devolución anticipada.
        /// </summary>
        /// <param name="alquiler">El alquiler para el que se solicita confirmación.</param>
        /// <returns>True si el usuario confirma la devolución, false en caso contrario.</returns>
        private bool SolicitarConfirmacionDevolucionAnticipada(Alquileres alquiler)
        {
            string nombreItem = alquiler.item?.nombreItem ?? "ítem desconocido";
            string fechaFinOriginal = alquiler.fechaFin.ToString("dd/MM/yyyy");

            string mensajeConfirmacion =
                $"¿Está seguro de que desea realizar la devolución anticipada del ítem '{nombreItem}' hoy?\n\n" +
                $"La fecha original de finalización era {fechaFinOriginal}.";

            return MessageShow.MostrarMensajeConfirmacion(mensajeConfirmacion);
        }

        /// <summary>
        /// Procesa la devolución anticipada, actualizando las fechas, recalculando los días
        /// y finalizando el alquiler.
        /// </summary>
        /// <param name="alquiler">El alquiler a procesar.</param>
        private void ProcesarDevolucionAnticipada(Alquileres alquiler)
        {
            try
            {
                if (alquiler.fechaInicio > DateTime.Today)
                {
                    alquilerController.EliminarAlquiler(alquiler.id);
                    MessageShow.MostrarMensajeExito("Alquiler cancelado correctamente.");
                    LoadAlquileres();
                    return;
                }

                alquiler.fechaFin = DateTime.Today;
                alquiler.tiempoDias = CalcularDiasEntreDosFechas(alquiler.fechaInicio, alquiler.fechaFin);

                alquilerController.ActualizarAlquiler(alquiler);

                alquilerController.EliminarAlquiler(alquiler.id);

                MessageShow.MostrarMensajeExito("Devolución anticipada realizada con éxito. El ítem está disponible para nuevos alquileres.");
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al procesar la devolución anticipada: {ex.Message}");
            }
        }

        /// <summary>
        /// Calcula el número de días entre dos fechas, incluyendo ambos días.
        /// </summary>
        /// <param name="fechaInicio">La fecha de inicio.</param>
        /// <param name="fechaFin">La fecha de fin.</param>
        /// <returns>El número de días entre las dos fechas, incluyendo ambos días.</returns>
        private int CalcularDiasEntreDosFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return (int)(fechaFin - fechaInicio).TotalDays +1;
        }
    }
}

