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
using TitoAlquiler.Model.Factory;
using TitoAlquiler.View.Alquiler;

namespace TitoAlquiler.View.CrearItem
{
    public partial class creaItem : Form
    {
        ItemController itemController = ItemController.getInstance();
        CategoriaController categoriaController = CategoriaController.getInstance();

        public creaItem()
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarFormulario()
        {
            txtNombreItem.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtTarifa.Clear();
            //txtDescripcion.Clear();
            comboBoxCategoria.SelectedIndex = -1;
        }

        private void btnCreaItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la categoría seleccionada
                if (!(comboBoxCategoria.SelectedItem is Categoria categoriaSeleccionada))
                {
                    MessageBox.Show("Por favor seleccione una categoría");
                    return;
                }

                // Crear la fábrica apropiada según la categoría
                FabricaItems fabrica = itemController.ObtenerFabricaSegunCategoria(categoriaSeleccionada.id);

                // Crear el item usando el factory
                var item = fabrica.BuildItem(
                    txtNombreItem.Text,
                    categoriaSeleccionada.id,
                    txtMarca.Text,
                    txtModelo.Text,
                    double.Parse(txtTarifa.Text)
                );

                // Establecer la descripción según el tipo de item
                /*switch (item)
                {
                    case ItemTransporte transporte:
                        transporte.descripcion = txtDescripcion.Text;
                        break;
                    case ItemElectrodomesticos electrodomestico:
                        electrodomestico.descripcion = txtDescripcion.Text;
                        break;
                    case ItemElectronica electronica:
                        electronica.descripcion = txtDescripcion.Text;
                        break;
                    case ItemInmuebles inmueble:
                        inmueble.descripcion = txtDescripcion.Text;
                        break;
                }*/

                // Guardar el item usando el controller
                itemController.CrearItem(item);

                MessageBox.Show("Item creado exitosamente!");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el item: {ex.Message}");
            }
        }

        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAlquilar formAlquilar = new FormAlquilar();
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
