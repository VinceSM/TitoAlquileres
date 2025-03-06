// ModificarItem.cs
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

namespace TitoAlquiler.View.ViewItem
{
    public partial class ModificarItem : Form
    {
        private readonly CategoriaController categoriaController = CategoriaController.Instance;
        private readonly ItemController itemController = ItemController.Instance;

        private ItemAlquilable itemSeleccionado;
        private object categoriaEspecifica;
        private int itemId = -1;

        #region Formulario
        public ModificarItem()
        {
            InitializeComponent();
            CargarCategorias();
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;

            // Inicialmente ocultar todos los campos específicos
            OcultarTodosLosCampos();

            // Configurar el botón de modificar
            btnModificaItem.Click += btnModificaItem_Click;

            // Cargar el DataGrid con todos los ítems
            CargarItems();
        }

        // Constructor sobrecargado para recibir un ID de ítem directamente
        public ModificarItem(int id)
        {
            InitializeComponent();
            CargarCategorias();
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;

            // Inicialmente ocultar todos los campos específicos
            OcultarTodosLosCampos();

            // Configurar el botón de modificar
            btnModificaItem.Click += btnModificaItem_Click;

            // Cargar el ítem específico
            CargarItem(id);
        }

        /// <summary>
        /// Maneja el evento de clic en el enlace de volver
        /// </summary>
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
            formAlquilar.Show();
            this.Hide();
        }

        /// <summary>
        /// Sobrescribe el comportamiento al cerrar el formulario
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        #endregion

        #region Carga de Datos

        /// <summary>
        /// Carga todas las categorías en el ComboBox
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
                MessageShow.MostrarMensajeError($"Error al cargar las categorías: {ex.Message}");
            }
        }

        /// <summary>
        /// Carga todos los ítems en un DataGridView
        /// </summary>
        private void CargarItems()
        {
            try
            {
                // Crear un DataGridView dinámicamente si no existe
                DataGridView dataGridViewItems = new DataGridView();
                dataGridViewItems.Name = "dataGridViewItems";
                dataGridViewItems.Location = new Point(50, 400);
                dataGridViewItems.Size = new Size(800, 200);
                dataGridViewItems.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                dataGridViewItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewItems.ReadOnly = true;
                dataGridViewItems.AllowUserToAddRows = false;
                dataGridViewItems.AllowUserToDeleteRows = false;
                dataGridViewItems.BackgroundColor = Color.LightBlue;
                dataGridViewItems.RowHeadersVisible = false;

                // Agregar columnas
                dataGridViewItems.Columns.Add("ID", "ID");
                dataGridViewItems.Columns.Add("Nombre", "Nombre");
                dataGridViewItems.Columns.Add("Marca", "Marca");
                dataGridViewItems.Columns.Add("Modelo", "Modelo");
                dataGridViewItems.Columns.Add("Tarifa", "Tarifa");
                dataGridViewItems.Columns.Add("Categoria", "Categoría");

                // Agregar evento de selección
                dataGridViewItems.SelectionChanged += DataGridViewItems_SelectionChanged;

                // Agregar al formulario
                this.Controls.Add(dataGridViewItems);

                // Cargar datos
                var items = itemController.ObtenerTodosLosItems();

                foreach (var item in items)
                {
                    dataGridViewItems.Rows.Add(
                        item.item.id,
                        item.item.nombreItem,
                        item.item.marca,
                        item.item.modelo,
                        item.item.tarifaDia,
                        item.item.categoria?.nombre
                    );
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar los ítems: {ex.Message}");
            }
        }

        /// <summary>
        /// Carga un ítem específico por su ID
        /// </summary>
        private void CargarItem(int id)
        {
            try
            {
                var (item, categoria) = itemController.ObtenerItemPorId(id);

                if (item == null)
                {
                    MessageShow.MostrarMensajeError("No se encontró el ítem especificado.");
                    return;
                }

                // Guardar referencias
                itemSeleccionado = item;
                categoriaEspecifica = categoria;
                itemId = id;

                // Cargar datos básicos
                txtNombreItem.Text = item.nombreItem;
                txtMarca.Text = item.marca;
                txtModelo.Text = item.modelo;
                txtTarifa.Text = item.tarifaDia.ToString();

                // Seleccionar la categoría en el ComboBox
                for (int i = 0; i < comboBoxCategoria.Items.Count; i++)
                {
                    var cat = comboBoxCategoria.Items[i] as Categoria;
                    if (cat != null && cat.id == item.categoriaId)
                    {
                        comboBoxCategoria.SelectedIndex = i;
                        break;
                    }
                }

                // Cargar datos específicos según la categoría
                CargarDatosEspecificos(categoria);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar el ítem: {ex.Message}");
            }
        }

        /// <summary>
        /// Carga los datos específicos según la categoría del ítem
        /// </summary>
        private void CargarDatosEspecificos(object categoria)
        {
            // Primero ocultar todos los campos
            OcultarTodosLosCampos();

            // Luego mostrar y cargar los campos según la categoría
            switch (categoria)
            {
                case Transporte transporte:
                    MostrarCamposTransporte();
                    txtCombustible.Text = transporte.tipoCombustible;
                    txtCantidad.Text = transporte.capacidadPasajeros.ToString();
                    break;

                case Electrodomestico electrodomestico:
                    MostrarCamposElectrodomestico();
                    txtWatss.Text = electrodomestico.potenciaWatts.ToString();
                    txtTipo.Text = electrodomestico.tipoElectrodomestico;
                    break;

                case Electronica electronica:
                    MostrarCamposElectronica();
                    txtResolucion.Text = electronica.resolucionPantalla;
                    txtAlmacenamiento.Text = electronica.almacenamientoGB.ToString();
                    break;

                case Inmueble inmueble:
                    MostrarCamposInmueble();
                    txtMetros.Text = inmueble.metrosCuadrados.ToString();
                    txtUbicacion.Text = inmueble.ubicacion;
                    break;

                case Indumentaria indumentaria:
                    MostrarCamposIndumentaria();
                    txtTalla.Text = indumentaria.talla;
                    txtMaterial.Text = indumentaria.material;
                    break;
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Maneja el evento de selección en el DataGridView
        /// </summary>
        private void DataGridViewItems_SelectionChanged(object sender, EventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ID"].Value);
                CargarItem(id);
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de categorías
        /// </summary>
        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoria.SelectedItem == null) return;

            var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
            if (categoriaSeleccionada == null) return;

            // Ocultar todos los campos específicos
            OcultarTodosLosCampos();

            // Mostrar los campos según la categoría seleccionada
            switch (categoriaSeleccionada.nombre)
            {
                case "Transporte":
                    MostrarCamposTransporte();
                    break;
                case "Electrodomestico":
                    MostrarCamposElectrodomestico();
                    break;
                case "Electronica":
                    MostrarCamposElectronica();
                    break;
                case "Inmueble":
                    MostrarCamposInmueble();
                    break;
                case "Indumentaria":
                    MostrarCamposIndumentaria();
                    break;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de modificar
        /// </summary>
        private void btnModificaItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemSeleccionado == null || itemId == -1)
                {
                    MessageShow.MostrarMensajeError("No hay un ítem seleccionado para modificar.");
                    return;
                }

                // Actualizar datos básicos del ítem
                itemSeleccionado.nombreItem = txtNombreItem.Text.Trim();
                itemSeleccionado.marca = txtMarca.Text.Trim();
                itemSeleccionado.modelo = txtModelo.Text.Trim();

                if (double.TryParse(txtTarifa.Text, out double tarifa))
                {
                    itemSeleccionado.tarifaDia = tarifa;
                }
                else
                {
                    MessageShow.MostrarMensajeError("La tarifa debe ser un valor numérico válido.");
                    return;
                }

                // Actualizar datos específicos según la categoría
                object categoriaActualizada = ActualizarCategoriaEspecifica();

                if (categoriaActualizada == null)
                {
                    MessageShow.MostrarMensajeError("Error al actualizar los datos específicos de la categoría.");
                    return;
                }

                // Guardar cambios
                itemController.ActualizarItem(itemSeleccionado, categoriaActualizada);

                MessageShow.MostrarMensajeExito("Ítem actualizado correctamente.");

                // Recargar los datos
                CargarItem(itemId);
                CargarItems();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al modificar el ítem: {ex.Message}");
            }
        }
        #endregion

        #region Métodos de Ayuda

        /// <summary>
        /// Oculta todos los campos específicos de categorías
        /// </summary>
        private void OcultarTodosLosCampos()
        {
            // Electrodoméstico
            lblElectrodomestico.Visible = false;
            txtWatss.Visible = false;
            txtTipo.Visible = false;

            // Electrónica
            lblElectronica.Visible = false;
            txtResolucion.Visible = false;
            txtAlmacenamiento.Visible = false;

            // Indumentaria
            lblIndumentaria.Visible = false;
            txtTalla.Visible = false;
            txtMaterial.Visible = false;

            // Inmueble
            lblInmueble.Visible = false;
            txtMetros.Visible = false;
            txtUbicacion.Visible = false;

            // Transporte
            lblTransporte.Visible = false;
            txtCantidad.Visible = false;
            txtCombustible.Visible = false;
        }

        /// <summary>
        /// Muestra los campos específicos para Transporte
        /// </summary>
        private void MostrarCamposTransporte()
        {
            lblTransporte.Visible = true;
            txtCantidad.Visible = true;
            txtCombustible.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para Electrodoméstico
        /// </summary>
        private void MostrarCamposElectrodomestico()
        {
            lblElectrodomestico.Visible = true;
            txtWatss.Visible = true;
            txtTipo.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para Electrónica
        /// </summary>
        private void MostrarCamposElectronica()
        {
            lblElectronica.Visible = true;
            txtResolucion.Visible = true;
            txtAlmacenamiento.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para Inmueble
        /// </summary>
        private void MostrarCamposInmueble()
        {
            lblInmueble.Visible = true;
            txtMetros.Visible = true;
            txtUbicacion.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para Indumentaria
        /// </summary>
        private void MostrarCamposIndumentaria()
        {
            lblIndumentaria.Visible = true;
            txtTalla.Visible = true;
            txtMaterial.Visible = true;
        }

        /// <summary>
        /// Actualiza el objeto de categoría específica con los datos del formulario
        /// </summary>
        private object ActualizarCategoriaEspecifica()
        {
            var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
            if (categoriaSeleccionada == null) return null;

            switch (categoriaSeleccionada.nombre)
            {
                case "Transporte":
                    if (categoriaEspecifica is Transporte transporte)
                    {
                        if (int.TryParse(txtCantidad.Text, out int capacidad))
                        {
                            transporte.capacidadPasajeros = capacidad;
                        }
                        transporte.tipoCombustible = txtCombustible.Text;
                        return transporte;
                    }
                    else
                    {
                        return new Transporte
                        {
                            itemId = itemId,
                            capacidadPasajeros = int.TryParse(txtCantidad.Text, out int cap) ? cap : 0,
                            tipoCombustible = txtCombustible.Text
                        };
                    }

                case "Electrodomestico":
                    if (categoriaEspecifica is Electrodomestico electrodomestico)
                    {
                        if (int.TryParse(txtWatss.Text, out int potencia))
                        {
                            electrodomestico.potenciaWatts = potencia;
                        }
                        electrodomestico.tipoElectrodomestico = txtTipo.Text;
                        return electrodomestico;
                    }
                    else
                    {
                        return new Electrodomestico
                        {
                            itemId = itemId,
                            potenciaWatts = int.TryParse(txtWatss.Text, out int pot) ? pot : 0,
                            tipoElectrodomestico = txtTipo.Text
                        };
                    }

                case "Electronica":
                    if (categoriaEspecifica is Electronica electronica)
                    {
                        if (int.TryParse(txtAlmacenamiento.Text, out int almacenamiento))
                        {
                            electronica.almacenamientoGB = almacenamiento;
                        }
                        electronica.resolucionPantalla = txtResolucion.Text;
                        return electronica;
                    }
                    else
                    {
                        return new Electronica
                        {
                            itemId = itemId,
                            almacenamientoGB = int.TryParse(txtAlmacenamiento.Text, out int alm) ? alm : 0,
                            resolucionPantalla = txtResolucion.Text
                        };
                    }

                case "Inmueble":
                    if (categoriaEspecifica is Inmueble inmueble)
                    {
                        if (int.TryParse(txtMetros.Text, out int metros))
                        {
                            inmueble.metrosCuadrados = metros;
                        }
                        inmueble.ubicacion = txtUbicacion.Text;
                        return inmueble;
                    }
                    else
                    {
                        return new Inmueble
                        {
                            itemId = itemId,
                            metrosCuadrados = int.TryParse(txtMetros.Text, out int met) ? met : 0,
                            ubicacion = txtUbicacion.Text
                        };
                    }

                case "Indumentaria":
                    if (categoriaEspecifica is Indumentaria indumentaria)
                    {
                        indumentaria.talla = txtTalla.Text;
                        indumentaria.material = txtMaterial.Text;
                        return indumentaria;
                    }
                    else
                    {
                        return new Indumentaria
                        {
                            itemId = itemId,
                            talla = txtTalla.Text,
                            material = txtMaterial.Text
                        };
                    }

                default:
                    return null;
            }
        }

        #endregion
    }
}