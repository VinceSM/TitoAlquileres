using Microsoft.Data.SqlClient;
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
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.View.ViewAlquiler;
using TitoAlquiler.Resources;

namespace TitoAlquiler.View.ViewItem
{
    public partial class CrearItem : Form
    {
        private readonly CategoriaController categoriaController = CategoriaController.Instance;
        private readonly ItemController itemController = ItemController.Instance;

        #region Formulario
        public CrearItem()
        {
            InitializeComponent();
            CargarCategorias();
            comboBoxCategoria.SelectedIndex = -1;
        }

        /// <summary>
        /// Regresa a la pantalla principal de alquiler y oculta la ventana actual.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
            formAlquilar.Show();
            this.Hide();
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
        /// Limpia todos los campos del formulario de creación de ítems.
        /// </summary>
        /// <remarks>
        /// Restablece los valores de los controles del formulario, como los cuadros de texto y el comboBox de categoría, para prepararlos para una nueva entrada.
        /// </remarks>
        private void LimpiarFormulario()
        {
            txtNombreItem.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtTarifa.Clear();
            comboBoxCategoria.SelectedIndex = -1;
        }

        /// <summary>
        /// Limpia los campos de entrada básicos del formulario.
        /// </summary>
        /// <remarks>
        /// Este método restablece los valores de los campos de texto para nombre, marca, modelo y tarifa,
        /// preparándolos para una nueva entrada cuando se cambia de categoría.
        /// </remarks>
        private void LimpiarInputs()
        {
            txtNombreItem.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtTarifa.Clear();
        }
        #endregion

        #region Item
        /// <summary>
        /// Crea un nuevo ítem basado en los datos ingresados en el formulario y lo guarda en el sistema.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Utiliza un patrón de fábrica para crear el ítem adecuado según la categoría seleccionada.
        /// Si algún campo está incompleto o no se puede convertir, muestra un mensaje de error.
        /// </remarks>
        /// 
        private void btnCreaItem_Click(object sender, EventArgs e)
        {
            try
            {
                var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
                string? categoria = categoriaSeleccionada?.nombre?.Trim();

                if (string.IsNullOrEmpty(categoria))
                {
                    MessageShow.MostrarMensajeError("Seleccione una categoría");
                    return;
                }

                IItemFactory factory = itemController.ObtenerFactory(categoria);

                itemController.CrearItem(factory,
                                         txtNombreItem.Text.Trim(),
                                         txtMarca.Text.Trim(),
                                         txtModelo.Text.Trim(),
                                         double.Parse(txtTarifa.Text),
                                         ObtenerParametrosAdicionales(categoria));

                MessageShow.MostrarMensajeExito("Item creado exitosamente");

                LimpiarFormulario();
            }
            catch (SqlException ec)
            {
                MessageShow.MostrarMensajeError($"Error al crear el item: {ec.Message}");
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al crear el item: {ex.Message}");
            }
        }
        #endregion

        #region Categorias
        /// <summary>
        /// Carga todas las categorías en un ComboBox.
        /// </summary>
        private void CargarCategorias()
        {
            try
            {
                comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
                List<Categoria> categorias = categoriaController.ObtenerTodasLasCategorias();
                comboBoxCategoria.DataSource = categorias;
                comboBoxCategoria.DisplayMember = "nombre";
                comboBoxCategoria.ValueMember = "id";
            }
            catch (SqlException ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar las categorías: {ex.Message}");
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de categorías, mostrando
        /// los campos específicos correspondientes a la categoría seleccionada.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método se activa cuando el usuario selecciona una categoría diferente en el ComboBox.
        /// Primero oculta todos los campos específicos, luego obtiene la categoría seleccionada,
        /// limpia los campos de entrada y finalmente muestra solo los campos relevantes para
        /// la categoría seleccionada (Transporte, Electrodoméstico, Electrónica, Inmueble o Indumentaria).
        /// </remarks>
        private void comboBoxCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Ocultar todos los campos específicos de categorías
                OcultarTodosLosCampos();

                // Obtener la categoría seleccionada
                var categoriaSeleccionada = ObtenerCategoriaSeleccionada();
                if (categoriaSeleccionada == null) return;

                // Limpiar los campos de entrada
                LimpiarInputs();

                // Mostrar los campos específicos según la categoría seleccionada
                MostrarCamposEspecificosPorCategoria(categoriaSeleccionada.nombre);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cambiar la categoría: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene la categoría seleccionada en el ComboBox.
        /// </summary>
        /// <returns>La categoría seleccionada o null si no hay selección.</returns>
        private Categoria ObtenerCategoriaSeleccionada()
        {
            return comboBoxCategoria.SelectedItem as Categoria;
        }

        /// <summary>
        /// Muestra los campos específicos según la categoría seleccionada.
        /// </summary>
        /// <param name="nombreCategoria">Nombre de la categoría seleccionada.</param>
        private void MostrarCamposEspecificosPorCategoria(string nombreCategoria)
        {
            // Utilizamos un diccionario de acciones para evitar el switch y hacer el código extensible
            var estrategiasMostrarCampos = new Dictionary<string, Action>
            {
                { "Transporte", mostrarLosCamposTransporte },
                { "Electrodomestico", mostrarLosCamposElectrodomestico },
                { "Electronica", mostrarLosCamposElectronica },
                { "Inmueble", mostrarLosCamposInmuebles },
                { "Indumentaria", mostrarLosCamposIndumentaria }
            };

            // Si la categoría está en el diccionario, ejecutar la acción correspondiente
            if (estrategiasMostrarCampos.ContainsKey(nombreCategoria))
            {
                estrategiasMostrarCampos[nombreCategoria]();
            }
        }

        /// <summary>
        /// Obtiene los parámetros adicionales específicos según la categoría seleccionada.
        /// </summary>
        /// <param name="categoria">Nombre de la categoría.</param>
        /// <returns>Un array de objetos con los parámetros adicionales para la categoría.</returns>
        /// <exception cref="ArgumentException">Se lanza si la categoría no es válida.</exception>
        /// <remarks>
        /// Este método extrae los valores de los campos específicos de cada categoría y los
        /// devuelve como un array de objetos para ser utilizados en la creación del ítem.
        /// </remarks>
        private object[] ObtenerParametrosAdicionales(string categoria)
        {
            return categoria switch
            {
                "Electrodomestico" => new object[] { ObtenerValorNumerico(txtWatss.Text), txtTipoElec.Text.Trim() },
                "Inmueble" => new object[] { ObtenerValorNumerico(txtMetros.Text), txtUbicacion.Text.Trim() },
                "Transporte" => new object[] { ObtenerValorNumerico(txtCapacidad.Text), txtCombustible.Text.Trim() },
                "Electronica" => new object[] { ObtenerValorNumerico(txtAlmacenamiento.Text), txtResolucion.Text.Trim() },
                "Indumentaria" => new object[] { txtTalla.Text.Trim(), txtMaterial.Text.Trim() },
                _ => throw new ArgumentException("Categoría no válida", nameof(categoria))
            };
        }

        /// <summary>
        /// Convierte un texto a un valor numérico entero, con manejo de errores.
        /// </summary>
        /// <param name="texto">El texto a convertir.</param>
        /// <returns>El valor numérico entero.</returns>
        /// <exception cref="FormatException">Se lanza si el texto no puede convertirse a un número.</exception>
        private int ObtenerValorNumerico(string texto)
        {
            if (!int.TryParse(texto, out int valor))
            {
                throw new FormatException($"El valor '{texto}' no es un número válido.");
            }
            return valor;
        }

        #endregion

        #region Mostrar y Ocultar Campos

        /// <summary>
        /// Oculta todos los campos específicos de cada categoría.
        /// </summary>
        private void OcultarTodosLosCampos()
        {
            lblElectrodomesticos.Visible = false;
            txtWatss.Visible = false;
            txtTipoElec.Visible = false;

            lblInmuebles.Visible = false;
            txtUbicacion.Visible = false;
            txtMetros.Visible = false;

            lblTransporte.Visible = false;
            txtCapacidad.Visible = false;
            txtCombustible.Visible = false;

            lblElectronicas.Visible = false;
            txtAlmacenamiento.Visible = false;
            txtResolucion.Visible = false;

            lblIndumentaria.Visible = false;
            txtTalla.Visible = false;
            txtMaterial.Visible = false;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Transporte.
        /// </summary>
        /// <remarks>
        /// Hace visibles los controles relacionados con la capacidad de pasajeros y tipo de combustible.
        /// </remarks>
        private void mostrarLosCamposTransporte()
        {
            lblTransporte.Visible = true;
            txtCapacidad.Visible = true;
            txtCombustible.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Electrodoméstico.
        /// </summary>
        /// <remarks>
        /// Hace visibles los controles relacionados con la potencia en watts y el tipo de electrodoméstico.
        /// </remarks>
        private void mostrarLosCamposElectrodomestico()
        {
            lblElectrodomesticos.Visible = true;
            txtWatss.Visible = true;
            txtTipoElec.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Electrónica.
        /// </summary>
        /// <remarks>
        /// Hace visibles los controles relacionados con el almacenamiento en GB y la resolución de pantalla.
        /// </remarks>
        private void mostrarLosCamposElectronica()
        {
            lblElectronicas.Visible = true;
            txtAlmacenamiento.Visible = true;
            txtResolucion.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Inmueble.
        /// </summary>
        /// <remarks>
        /// Hace visibles los controles relacionados con la ubicación y los metros cuadrados.
        /// </remarks>
        private void mostrarLosCamposInmuebles()
        {
            lblInmuebles.Visible = true;
            txtUbicacion.Visible = true;
            txtMetros.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Indumentaria.
        /// </summary>
        /// <remarks>
        /// Hace visibles los controles relacionados con la talla y el material.
        /// </remarks>
        private void mostrarLosCamposIndumentaria()
        {
            lblIndumentaria.Visible = true;
            txtTalla.Visible = true;
            txtMaterial.Visible = true;
        }

        #endregion
    }
}