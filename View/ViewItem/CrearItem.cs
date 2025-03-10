// CrearItem.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Resources;
using TitoAlquiler.View.ViewAlquiler;
using Microsoft.Data.SqlClient;

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
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
            formAlquilar.Show();
            this.Hide();
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario, cerrando toda la aplicación si el usuario lo cierra.
        /// </summary>
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
        private void LimpiarFormulario()
        {
            txtNombreItem.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtTarifa.Clear();
            comboBoxCategoria.SelectedIndex = -1;
            OcultarTodosLosCampos();
        }

        /// <summary>
        /// Limpia los campos de entrada básicos del formulario.
        /// </summary>
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
        private void btnCreaItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener y validar la categoría
                var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
                if (!ValidacionesItem.ValidarCategoria(categoriaSeleccionada))
                    return;

                string categoria = categoriaSeleccionada.nombre.Trim();

                // Obtener y validar los campos básicos
                string nombre = txtNombreItem.Text.Trim();
                string marca = txtMarca.Text.Trim();
                string modelo = txtModelo.Text.Trim();
                string tarifaText = txtTarifa.Text.Trim();

                if (!ValidacionesItem.ValidarCamposBasicos(nombre, marca, modelo, tarifaText, out double tarifa))
                    return;

                // Obtener y validar los campos específicos
                Dictionary<string, string> camposEspecificos = ObtenerCamposEspecificos(categoria);
                if (!ValidacionesItem.ValidarCamposEspecificos(categoria, camposEspecificos))
                    return;

                // Crear el ítem
                IItemFactory factory = itemController.ObtenerFactory(categoria);
                object[] parametrosAdicionales = ObtenerParametrosAdicionales(categoria, camposEspecificos);

                itemController.CrearItem(factory, nombre, marca, modelo, tarifa, parametrosAdicionales);

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

        /// <summary>
        /// Obtiene los campos específicos según la categoría seleccionada.
        /// </summary>
        private Dictionary<string, string> ObtenerCamposEspecificos(string categoria)
        {
            var campos = new Dictionary<string, string>();

            switch (categoria)
            {
                case "Transporte":
                    campos.Add("capacidad", txtCapacidad.Text.Trim());
                    campos.Add("combustible", txtCombustible.Text.Trim());
                    break;
                case "Electrodomestico":
                    campos.Add("potencia", txtWatss.Text.Trim());
                    campos.Add("tipo", txtTipoElec.Text.Trim());
                    break;
                case "Electronica":
                    campos.Add("almacenamiento", txtAlmacenamiento.Text.Trim());
                    campos.Add("resolucion", txtResolucion.Text.Trim());
                    break;
                case "Inmueble":
                    campos.Add("metros", txtMetros.Text.Trim());
                    campos.Add("ubicacion", txtUbicacion.Text.Trim());
                    break;
                case "Indumentaria":
                    campos.Add("talla", txtTalla.Text.Trim());
                    campos.Add("material", txtMaterial.Text.Trim());
                    break;
            }

            return campos;
        }

        /// <summary>
        /// Obtiene los parámetros adicionales específicos según la categoría seleccionada.
        /// </summary>
        private object[] ObtenerParametrosAdicionales(string categoria, Dictionary<string, string> campos)
        {
            return categoria switch
            {
                "Electrodomestico" => new object[] { int.Parse(campos["potencia"]), campos["tipo"] },
                "Inmueble" => new object[] { int.Parse(campos["metros"]), campos["ubicacion"] },
                "Transporte" => new object[] { int.Parse(campos["capacidad"]), campos["combustible"] },
                "Electronica" => new object[] { int.Parse(campos["almacenamiento"]), campos["resolucion"] },
                "Indumentaria" => new object[] { campos["talla"], campos["material"] },
                _ => throw new ArgumentException("Categoría no válida", nameof(categoria))
            };
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
        /// Maneja el evento de cambio de selección en el ComboBox de categorías.
        /// </summary>
        private void comboBoxCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Ocultar todos los campos específicos de categorías
                OcultarTodosLosCampos();

                // Obtener la categoría seleccionada
                var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
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
        /// Muestra los campos específicos según la categoría seleccionada.
        /// </summary>
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
        private void mostrarLosCamposTransporte()
        {
            lblTransporte.Visible = true;
            txtCapacidad.Visible = true;
            txtCombustible.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Electrodoméstico.
        /// </summary>
        private void mostrarLosCamposElectrodomestico()
        {
            lblElectrodomesticos.Visible = true;
            txtWatss.Visible = true;
            txtTipoElec.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Electrónica.
        /// </summary>
        private void mostrarLosCamposElectronica()
        {
            lblElectronicas.Visible = true;
            txtAlmacenamiento.Visible = true;
            txtResolucion.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Inmueble.
        /// </summary>
        private void mostrarLosCamposInmuebles()
        {
            lblInmuebles.Visible = true;
            txtUbicacion.Visible = true;
            txtMetros.Visible = true;
        }

        /// <summary>
        /// Muestra los campos específicos para la categoría Indumentaria.
        /// </summary>
        private void mostrarLosCamposIndumentaria()
        {
            lblIndumentaria.Visible = true;
            txtTalla.Visible = true;
            txtMaterial.Visible = true;
        }
        #endregion
    }
}