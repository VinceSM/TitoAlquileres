// ModificarItem.cs - Versión simplificada
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Resources;
using TitoAlquiler.View.ViewAlquiler;

namespace TitoAlquiler.View.ViewItem
{
    public partial class ModificarItem : Form
    {
        private readonly CategoriaController categoriaController = CategoriaController.Instance;
        private readonly ItemController itemController = ItemController.Instance;

        private ItemAlquilable itemSeleccionado;
        private object categoriaEspecifica;
        private int itemId = -1;

        // Variables para almacenar los valores originales y detectar cambios
        private string nombreOriginal;
        private string marcaOriginal;
        private string modeloOriginal;
        private double tarifaOriginal;
        private Dictionary<string, string> camposEspecificosOriginales;

        #region Formulario
        /// <summary>
        /// Constructor que recibe el ID del ítem a modificar.
        /// </summary>
        /// <param name="id">ID del ítem a modificar</param>
        public ModificarItem(int id)
        {
            InitializeComponent();

            // Cargar categorías pero ocultar el ComboBox y su etiqueta
            CargarCategorias();
            lblCategoria.Visible = false;
            comboBoxCategoria.Visible = false;

            // Inicialmente ocultar todos los campos específicos
            OcultarTodosLosCampos();

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

                // Guardar valores originales para detectar cambios
                nombreOriginal = item.nombreItem;
                marcaOriginal = item.marca;
                modeloOriginal = item.modelo;
                tarifaOriginal = item.tarifaDia;

                // Cargar datos básicos
                txtNombreItem.Text = item.nombreItem;
                txtMarca.Text = item.marca;
                txtModelo.Text = item.modelo;
                txtTarifa.Text = item.tarifaDia.ToString();

                // Seleccionar la categoría en el ComboBox (aunque esté oculto)
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

                // Guardar los campos específicos originales
                camposEspecificosOriginales = ObtenerCamposEspecificos(((Categoria)comboBoxCategoria.SelectedItem).nombre);
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

                // Obtener y validar los campos básicos
                string nombre = txtNombreItem.Text.Trim();
                string marca = txtMarca.Text.Trim();
                string modelo = txtModelo.Text.Trim();
                string tarifaText = txtTarifa.Text.Trim();

                if (!ValidacionesItem.ValidarCamposBasicos(nombre, marca, modelo, tarifaText, out double tarifa))
                    return;

                // Obtener y validar la categoría
                var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
                if (!ValidacionesItem.ValidarCategoria(categoriaSeleccionada))
                    return;

                // Obtener y validar los campos específicos según la categoría
                Dictionary<string, string> camposEspecificos = ObtenerCamposEspecificos(categoriaSeleccionada.nombre);
                if (!ValidacionesItem.ValidarCamposEspecificos(categoriaSeleccionada.nombre, camposEspecificos))
                    return;

                // Verificar si hubo cambios
                if (!HayCambios(nombre, marca, modelo, tarifa, camposEspecificos))
                {
                    MessageShow.MostrarMensajeInformacion("No se detectaron cambios en el ítem.");
                    return;
                }

                // Actualizar datos básicos del ítem
                itemSeleccionado.nombreItem = nombre;
                itemSeleccionado.marca = marca;
                itemSeleccionado.modelo = modelo;
                itemSeleccionado.tarifaDia = tarifa;

                // Actualizar datos específicos según la categoría
                object categoriaActualizada = ActualizarCategoriaEspecifica(camposEspecificos);

                if (categoriaActualizada == null)
                {
                    MessageShow.MostrarMensajeError("Error al actualizar los datos específicos de la categoría.");
                    return;
                }

                // Guardar cambios
                itemController.ActualizarItem(itemSeleccionado, categoriaActualizada);

                MessageShow.MostrarMensajeExito("Ítem actualizado correctamente.");

                // Actualizar los valores originales
                nombreOriginal = nombre;
                marcaOriginal = marca;
                modeloOriginal = modelo;
                tarifaOriginal = tarifa;
                camposEspecificosOriginales = new Dictionary<string, string>(camposEspecificos);

                // Recargar los datos
                CargarItem(itemId);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al modificar el ítem: {ex.Message}");
            }
        }

        /// <summary>
        /// Verifica si se han realizado cambios en el ítem
        /// </summary>
        /// <returns>True si hay cambios, False si no hay cambios</returns>
        private bool HayCambios(string nombre, string marca, string modelo, double tarifa, Dictionary<string, string> camposEspecificos)
        {
            // Verificar cambios en los campos básicos
            if (nombre != nombreOriginal ||
                marca != marcaOriginal ||
                modelo != modeloOriginal ||
                Math.Abs(tarifa - tarifaOriginal) > 0.001)
            {
                return true;
            }

            // Verificar cambios en los campos específicos
            if (camposEspecificosOriginales != null)
            {
                foreach (var campo in camposEspecificos)
                {
                    if (camposEspecificosOriginales.ContainsKey(campo.Key))
                    {
                        if (camposEspecificosOriginales[campo.Key] != campo.Value)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true; // Campo nuevo
                    }
                }
            }

            return false;
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
                    campos.Add("capacidad", txtCantidad.Text.Trim());
                    campos.Add("combustible", txtCombustible.Text.Trim());
                    break;
                case "Electrodomestico":
                    campos.Add("potencia", txtWatss.Text.Trim());
                    campos.Add("tipo", txtTipo.Text.Trim());
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
        /// Actualiza el objeto de categoría específica con los datos del formulario
        /// </summary>
        private object ActualizarCategoriaEspecifica(Dictionary<string, string> campos)
        {
            var categoriaSeleccionada = comboBoxCategoria.SelectedItem as Categoria;
            if (categoriaSeleccionada == null) return null;

            switch (categoriaSeleccionada.nombre)
            {
                case "Transporte":
                    if (categoriaEspecifica is Transporte transporte)
                    {
                        if (int.TryParse(campos["capacidad"], out int capacidad))
                        {
                            transporte.capacidadPasajeros = capacidad;
                        }
                        transporte.tipoCombustible = campos["combustible"];
                        return transporte;
                    }
                    else
                    {
                        return new Transporte
                        {
                            itemId = itemId,
                            capacidadPasajeros = int.TryParse(campos["capacidad"], out int cap) ? cap : 0,
                            tipoCombustible = campos["combustible"]
                        };
                    }

                case "Electrodomestico":
                    if (categoriaEspecifica is Electrodomestico electrodomestico)
                    {
                        if (int.TryParse(campos["potencia"], out int potencia))
                        {
                            electrodomestico.potenciaWatts = potencia;
                        }
                        electrodomestico.tipoElectrodomestico = campos["tipo"];
                        return electrodomestico;
                    }
                    else
                    {
                        return new Electrodomestico
                        {
                            itemId = itemId,
                            potenciaWatts = int.TryParse(campos["potencia"], out int pot) ? pot : 0,
                            tipoElectrodomestico = campos["tipo"]
                        };
                    }

                case "Electronica":
                    if (categoriaEspecifica is Electronica electronica)
                    {
                        if (int.TryParse(campos["almacenamiento"], out int almacenamiento))
                        {
                            electronica.almacenamientoGB = almacenamiento;
                        }
                        electronica.resolucionPantalla = campos["resolucion"];
                        return electronica;
                    }
                    else
                    {
                        return new Electronica
                        {
                            itemId = itemId,
                            almacenamientoGB = int.TryParse(campos["almacenamiento"], out int alm) ? alm : 0,
                            resolucionPantalla = campos["resolucion"]
                        };
                    }

                case "Inmueble":
                    if (categoriaEspecifica is Inmueble inmueble)
                    {
                        if (int.TryParse(campos["metros"], out int metros))
                        {
                            inmueble.metrosCuadrados = metros;
                        }
                        inmueble.ubicacion = campos["ubicacion"];
                        return inmueble;
                    }
                    else
                    {
                        return new Inmueble
                        {
                            itemId = itemId,
                            metrosCuadrados = int.TryParse(campos["metros"], out int met) ? met : 0,
                            ubicacion = campos["ubicacion"]
                        };
                    }

                case "Indumentaria":
                    if (categoriaEspecifica is Indumentaria indumentaria)
                    {
                        indumentaria.talla = campos["talla"];
                        indumentaria.material = campos["material"];
                        return indumentaria;
                    }
                    else
                    {
                        return new Indumentaria
                        {
                            itemId = itemId,
                            talla = campos["talla"],
                            material = campos["material"]
                        };
                    }

                default:
                    return null;
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
        #endregion
    }
}