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

        /// <summary>
        /// Constructor que inicializa el formulario de visualización de alquileres.
        /// Configura los componentes, obtiene la instancia del controlador de alquileres y carga los alquileres activos.
        /// </summary>
        public VerAlquileres()
        {
            InitializeComponent();
            alquilerController = AlquilerController.Instance;
            LoadAlquileres();
        }

        /// <summary>
        /// Sobrescribe el comportamiento predeterminado al cerrar el formulario.
        /// Si el usuario cierra el formulario directamente, finaliza toda la aplicación.
        /// </summary>
        /// <param name="e">Argumentos del evento que contienen información sobre el cierre del formulario.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el enlace para volver al formulario anterior.
        /// Muestra el formulario de creación de alquileres y oculta el formulario actual.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento que contienen información sobre el clic en el enlace.</param>
        private void linkLabelVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
            formAlquilar.Show();
            this.Hide();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón para modificar un alquiler.
        /// Abre el formulario de modificación de alquileres y oculta el formulario actual.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento que contienen información sobre el clic en el botón.</param>
        private void btnModificarAlquiler_Click(object sender, EventArgs e)
        {
            ModificarAlquiler modificarAlquiler = new ModificarAlquiler();
            modificarAlquiler.Show();
            this.Hide();
        }

        #endregion

        #region Gestion Alquileres

        /// <summary>
        /// Carga todos los alquileres activos desde el controlador y los muestra en el DataGridView.
        /// Verifica y cierra automáticamente los alquileres vencidos antes de cargar la lista.
        /// </summary>
        /// <exception cref="Exception">Se lanza cuando ocurre un error al cargar los alquileres.</exception>
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
        /// Limpia todas las filas del DataGridView de alquileres.
        /// Prepara la tabla para cargar nuevos datos.
        /// </summary>
        private void LimpiarTablaAlquileres()
        {
            dataGridViewAlquileres.Rows.Clear();
        }

        /// <summary>
        /// Muestra la lista de alquileres en el DataGridView.
        /// Agrega una fila por cada alquiler con sus datos principales.
        /// </summary>
        /// <param name="alquileres">Lista de objetos Alquileres que se mostrarán en la tabla.</param>
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
        /// Formatea una fecha para mostrarla en un formato consistente en la interfaz de usuario.
        /// </summary>
        /// <param name="fecha">Fecha a formatear.</param>
        /// <returns>Cadena de texto con la fecha formateada en el formato "yyyy-MM-dd".</returns>
        private string FormatearFecha(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Obtiene el alquiler seleccionado actualmente en el DataGridView.
        /// </summary>
        /// <returns>Objeto Alquileres que representa el alquiler seleccionado.</returns>
        /// <exception cref="Exception">Se lanza cuando no hay un alquiler seleccionado o cuando ocurre un error al obtener el alquiler.</exception>
        private Alquileres ObtenerAlquilerSeleccionado()
        {
            int selectedId = Convert.ToInt32(dataGridViewAlquileres.SelectedRows[0].Cells["id"].Value);

            return alquilerController.ObtenerAlquilerPorId(selectedId);
        }

        #endregion

        /// <summary>
        /// Maneja el evento de clic en el botón de devolución anticipada.
        /// Permite finalizar un alquiler antes de la fecha prevista, actualizando la fecha de fin,
        /// recalculando los días y el precio, y marcando el alquiler como finalizado.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento que contienen información sobre el clic en el botón.</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante el proceso de devolución anticipada.</exception>
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
        /// Valida que haya un alquiler seleccionado en el DataGridView y lo obtiene.
        /// </summary>
        /// <param name="alquiler">Variable de salida que contendrá el alquiler seleccionado si la validación es exitosa.</param>
        /// <returns>True si se seleccionó y obtuvo un alquiler válido, False en caso contrario.</returns>
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
        /// Verifica si un alquiler puede ser cancelado y solicita confirmación al usuario si es necesario.
        /// </summary>
        /// <param name="alquiler">Alquiler a validar para cancelación.</param>
        /// <returns>True si el alquiler puede ser cancelado, False si no puede o si el usuario rechaza la cancelación.</returns>
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
        /// Solicita confirmación al usuario para realizar la devolución anticipada de un alquiler.
        /// Muestra un mensaje con los detalles del ítem y la fecha original de finalización.
        /// </summary>
        /// <param name="alquiler">Alquiler para el que se solicita confirmación de devolución anticipada.</param>
        /// <returns>True si el usuario confirma la devolución, False si la cancela.</returns>
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
        /// Procesa la devolución anticipada de un alquiler.
        /// Si el alquiler aún no ha comenzado, lo cancela completamente.
        /// Si el alquiler está en curso, actualiza la fecha de fin al día actual, recalcula los días y el precio,
        /// y marca el alquiler como finalizado.
        /// </summary>
        /// <param name="alquiler">Alquiler a procesar para devolución anticipada.</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante el procesamiento de la devolución.</exception>
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
        /// Calcula el número de días entre dos fechas, incluyendo ambos días en el cálculo.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del período.</param>
        /// <param name="fechaFin">Fecha de fin del período.</param>
        /// <returns>Número entero que representa la cantidad de días entre las fechas, incluyendo ambos extremos.</returns>
        private int CalcularDiasEntreDosFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return (int)(fechaFin - fechaInicio).TotalDays +1;
        }
    }
}

