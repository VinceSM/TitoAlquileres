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
using TitoAlquiler.Model.Factory;
using TitoAlquiler.View.ViewAlquiler;

namespace TitoAlquiler.View.ViewItem
{
    public partial class CrearItem : Form
    {
        private readonly CategoriaController categoriaController = CategoriaController.Instance;
        private readonly ItemController itemController = ItemController.Instance;

        public CrearItem()
        {
            InitializeComponent();
            CargarCategorias();
            comboBoxCategoria.SelectedIndex = -1;
        }

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
                    MessageBox.Show("Seleccione una categoría", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IItemFactory factory = itemController.ObtenerFactory(categoria);

                itemController.CrearItem(factory,
                                         txtNombreItem.Text.Trim(),
                                         txtMarca.Text.Trim(),
                                         txtModelo.Text.Trim(),
                                         double.Parse(txtTarifa.Text),
                                         ObtenerParametrosAdicionales(categoria));

                MessageBox.Show("Item creado exitosamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el item: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private object[] ObtenerParametrosAdicionales(string categoria)
        {
            return categoria switch
            {
                "Electrodomestico" => new object[] { int.Parse(txtWatss.Text), txtTipoElec.Text },
                "Inmueble" => new object[] { int.Parse(txtMetros.Text), txtUbicacion.Text },
                "Transporte" => new object[] { int.Parse(txtCapacidad.Text), txtCombustible.Text },
                "Electronica" => new object[] { txtResolucion.Text, int.Parse(txtAlmacenamiento.Text) },
                "Indumentaria" => new object[] { txtTalla.Text, txtMaterial.Text },
                _ => throw new ArgumentException("Categoría no válida", nameof(categoria))
            };
        }

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
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            OcultarTodosLosCampos();

            var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
            if (categoriaSeleccionada == null) return;

            switch (categoriaSeleccionada.nombre)
            {
                case "Transporte":
                    LimpiarInputs();
                    mostrarLosCamposTransporte();
                    break;
                case "Electrodomestico":
                    LimpiarInputs();
                    mostrarLosCamposElectrodomestico();
                    break;
                case "Electronica":
                    LimpiarInputs();
                    mostrarLosCamposElectronica();
                    break;
                case "Inmueble":
                    LimpiarInputs();
                    mostrarLosCamposInmuebles();
                    break;
                case "Indumentaria":
                    LimpiarInputs();
                    mostrarLosCamposIndumentaria();
                    break;
            }
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
        private void mostrarLosCamposTransporte()
        {
            lblTransporte.Visible = true;
            txtCapacidad.Visible = true;
            txtCombustible.Visible = true;
        }
        private void mostrarLosCamposElectrodomestico()
        {
            lblElectrodomesticos.Visible = true;
            txtWatss.Visible = true;
            txtTipoElec.Visible = true;
        }
        private void mostrarLosCamposElectronica()
        {
            lblElectronicas.Visible = true;
            txtAlmacenamiento.Visible = true;
            txtResolucion.Visible = true;
        }
        private void mostrarLosCamposInmuebles()
        {
            lblInmuebles.Visible = true;
            txtUbicacion.Visible = true;
            txtMetros.Visible = true;
        }
        private void mostrarLosCamposIndumentaria()
        {
            lblIndumentaria.Visible = true;
            txtTalla.Visible = true;
            txtMaterial.Visible = true;
        }

        #endregion

        #region Form

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

        private void LimpiarInputs()
        {
            txtNombreItem.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtTarifa.Clear();
        }

        #endregion

    }
}
