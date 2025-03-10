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
            // Verificar y cerrar alquileres vencidos primero
            alquilerController.VerificarYCerrarAlquileresVencidos();
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
                // Validar que haya un alquiler seleccionado y obtenerlo
                if (!ValidarYObtenerAlquilerSeleccionado(out Alquileres alquiler))
                {
                    return; // Ya se mostró un mensaje en el método ValidarYObtenerAlquilerSeleccionado
                }

                // Validar que el alquiler esté activo
                if (!ValidarAlquilerActivo(alquiler))
                {
                    return; // Ya se mostró un mensaje en el método ValidarAlquilerActivo
                }

                // Solicitar confirmación al usuario
                if (!SolicitarConfirmacionDevolucionAnticipada(alquiler))
                {
                    return; // El usuario canceló la operación
                }

                // Procesar la devolución anticipada
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
            alquiler = null;

            if (!HayAlquilerSeleccionado())
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un alquiler para realizar una devolución anticipada.");
                return false;
            }

            alquiler = ObtenerAlquilerSeleccionado();
            if (alquiler == null)
            {
                MessageShow.MostrarMensajeError("No se encontró el alquiler seleccionado.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que el alquiler esté activo (no haya finalizado).
        /// </summary>
        /// <param name="alquiler">El alquiler a validar.</param>
        /// <returns>True si el alquiler está activo, false si ya ha finalizado.</returns>
        private bool ValidarAlquilerActivo(Alquileres alquiler)
        {
            // Verificar si el alquiler ya ha finalizado
            if (alquiler.fechaFin < DateTime.Today)
            {
                MessageShow.MostrarMensajeAdvertencia("Este alquiler ya ha finalizado y no puede ser modificado.");
                return false;
            }

            // Verificar si el alquiler aún no ha comenzado
            if (alquiler.fechaInicio > DateTime.Today)
            {
                // Si el alquiler aún no ha comenzado, permitimos cancelarlo pero con un mensaje claro
                bool cancelar = MessageShow.MostrarMensajeConfirmacion(
                    "Este alquiler aún no ha comenzado. ¿Desea cancelarlo completamente?");
        
                if (!cancelar)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Solicita confirmación al usuario para realizar la devolución anticipada.
        /// </summary>
        /// <param name="alquiler">El alquiler para el que se solicita confirmación.</param>
        /// <returns>True si el usuario confirma la devolución, false en caso contrario.</returns>
        private bool SolicitarConfirmacionDevolucionAnticipada(Alquileres alquiler)
        {
            string nombreItem = ObtenerNombreItemSeguro(alquiler);
            string fechaFinOriginal = alquiler.fechaFin.ToString("dd/MM/yyyy");

            string mensajeConfirmacion =
                $"¿Está seguro de que desea realizar la devolución anticipada del ítem '{nombreItem}' hoy?\n\n" +
                $"La fecha original de finalización era {fechaFinOriginal}.";

            return MessageShow.MostrarMensajeConfirmacion(mensajeConfirmacion);
        }

        /// <summary>
        /// Obtiene el nombre del ítem de un alquiler de forma segura, evitando referencias nulas.
        /// </summary>
        /// <param name="alquiler">El alquiler del que se quiere obtener el nombre del ítem.</param>
        /// <returns>El nombre del ítem o un valor por defecto si no está disponible.</returns>
        private string ObtenerNombreItemSeguro(Alquileres alquiler)
        {
            return alquiler.item?.nombreItem ?? "ítem desconocido";
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
                // Verificar si el alquiler ya ha finalizado
                if (alquiler.fechaFin < DateTime.Today)
                {
                    MessageShow.MostrarMensajeAdvertencia("Este alquiler ya ha finalizado.");
                    return;
                }

                // Verificar si el alquiler aún no ha comenzado
                if (alquiler.fechaInicio > DateTime.Today)
                {
                    // Si el alquiler aún no ha comenzado, lo cancelamos directamente
                    try
                    {
                        alquilerController.EliminarAlquiler(alquiler.id);
                        MessageShow.MostrarMensajeExito("Alquiler cancelado correctamente.");
                        LoadAlquileres();
                    }
                    catch (Exception ex)
                    {
                        MessageShow.MostrarMensajeError($"Error al cancelar el alquiler: {ex.Message}");
                    }
                    return;
                }

                // Para alquileres en curso, actualizamos la fecha de fin y recalculamos
                alquiler.fechaFin = DateTime.Today;
                alquiler.tiempoDias = CalcularDiasEntreDosFechas(alquiler.fechaInicio, alquiler.fechaFin);

                // Actualizar el alquiler en la base de datos antes de eliminarlo
                try
                {
                    alquilerController.ActualizarAlquiler(alquiler);
                }
                catch (Exception ex)
                {
                    MessageShow.MostrarMensajeError($"No se pudo actualizar el alquiler: {ex.Message}");
                    return;
                }

                // Cerrar el alquiler (marcarlo como finalizado)
                try
                {
                    alquilerController.EliminarAlquiler(alquiler.id);
                }
                catch (Exception ex)
                {
                    MessageShow.MostrarMensajeError($"No se pudo finalizar el alquiler: {ex.Message}");
                    return;
                }

                // Mostrar mensaje de éxito
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

