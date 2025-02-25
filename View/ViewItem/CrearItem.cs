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
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Factory;
using TitoAlquiler.View.ViewAlquiler;

namespace TitoAlquiler.View.ViewItem
{
    public partial class CrearItem : Form
    {
        CategoriaController categoriaController = CategoriaController.getInstance();
        ItemController itemController = ItemController.getInstance();

        public CrearItem()
        {
            InitializeComponent();
            CargarCategorias();
            comboBoxCategoria.SelectedIndex = -1;
        }


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
            //txtDescripcion.Clear();
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
                // Validar campos comunes
                if (string.IsNullOrEmpty(txtNombreItem.Text) ||
                    string.IsNullOrEmpty(txtMarca.Text) ||
                    string.IsNullOrEmpty(txtModelo.Text) ||
                    string.IsNullOrEmpty(txtTarifa.Text) ||
                    comboBoxCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Todos los campos son obligatorios", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que la tarifa sea un número válido
                if (!double.TryParse(txtTarifa.Text, out double tarifaDia))
                {
                    MessageBox.Show("La tarifa debe ser un valor numérico válido", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear el item según la categoría seleccionada
                Item nuevoItem = null;
                switch (comboBoxCategoria.SelectedItem?.ToString())
                {
                    case "Electrodomestico":
                        nuevoItem = new ElectrodomesticoFactory().CrearAlquilable(
                            txtNombreItem.Text.Trim(),
                            txtMarca.Text.Trim(),
                            txtModelo.Text.Trim(),
                            tarifaDia,
                            int.Parse(txtWatss.Text),
                            txtTipoElec.Text).item;
                        break;

                    case "Inmueble":
                        nuevoItem = new InmuebleFactory().CrearAlquilable(
                            txtNombreItem.Text.Trim(),
                            txtMarca.Text.Trim(),
                            txtModelo.Text.Trim(),
                            tarifaDia,
                            txtMetros,
                            txtUbicacion.Text).item;
                        break;

                    case "Transporte":
                        nuevoItem = new TransporteFactory().CrearAlquilable(
                            txtNombreItem.Text.Trim(),
                            txtMarca.Text.Trim(),
                            txtModelo.Text.Trim(),
                            tarifaDia,
                            txtCapacidad,
                            txtCombustible.Text).item;
                        break;

                    case "Electronica":
                        nuevoItem = new ElectronicaFactory().CrearAlquilable(
                            txtNombreItem.Text.Trim(),
                            txtMarca.Text.Trim(),
                            txtModelo.Text.Trim(),
                            tarifaDia,
                            txtResolucion.Text,
                            txtAlmacenamiento).item;
                        break;

                    case "Indumentaria":
                        nuevoItem = new IndumentariaFactory().CrearAlquilable(
                            txtNombreItem.Text.Trim(),
                            txtMarca.Text.Trim(),
                            txtModelo.Text.Trim(),
                            tarifaDia,
                            txtTalla.Text,
                            txtMaterial.Text).item;
                        break;
                }

                // Asignar propiedades comunes
                if (nuevoItem != null)
                {
                    nuevoItem.nombreItem = txtNombreItem.Text.Trim();
                    nuevoItem.marca = txtMarca.Text.Trim();
                    nuevoItem.modelo = txtModelo.Text.Trim();
                    nuevoItem.tarifaDia = tarifaDia;
                    nuevoItem.categoriaId = comboBoxCategoria.SelectedIndex + 1;

                    itemController.CrearItem(
                    itemController.ObtenerFactory(comboBoxCategoria.SelectedItem.ToString()),
                    nuevoItem.nombreItem,
                    nuevoItem.marca,
                    nuevoItem.modelo,
                    nuevoItem.tarifaDia
                    );

                    MessageBox.Show("Item creado exitosamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el item: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCategoria.SelectedItem?.ToString())
            {
                case "Electrodomestico":
                    lblElectrodomesticos.Visible = true;
                    txtWatss.Visible = true;
                    txtTipoElec.Visible = true;
                    break;
                case "Inmueble":
                    lblInmuebles.Visible = true;
                    txtUbicacion.Visible = true;
                    txtMetros.Visible = true;
                    break;
                case "Transporte":
                    lblTransporte.Visible = true;
                    txtCapacidad.Visible = true;
                    txtCombustible.Visible = true;
                    break;
                case "Electronica":
                    lblElectronicas.Visible = true;
                    txtAlmacenamiento.Visible = true;
                    txtResolucion.Visible = true;
                    break;
                case "Indumentaria":
                    lblIndumentaria.Visible = true;
                    txtTalla.Visible = true;
                    txtMaterial.Visible = true;
                    break;
            }
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
    }
}
