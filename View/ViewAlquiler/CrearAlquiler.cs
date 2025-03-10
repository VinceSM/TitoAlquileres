using TitoAlquiler.Controller;
using TitoAlquiler.View.ViewUsuario;
using TitoAlquiler.View.ViewItem;
using System;
using System.Windows.Forms;
using TitoAlquiler.Model.Entities;
using System.Linq;
using TitoAlquiler.Model.Entities.Categorias;
using Microsoft.Data.SqlClient;
using TitoAlquiler.Resources;
using System.Collections.Generic;

namespace TitoAlquiler.View.ViewAlquiler
{
    public partial class CrearAlquiler : Form
    {
        private readonly UsuarioController usuarioController = UsuarioController.Instance;
        private readonly AlquilerController alquilerController = AlquilerController.Instance;
        private readonly ItemController itemController = ItemController.Instance;
        private readonly CategoriaController categoriaController = CategoriaController.Instance;

        #region Formulario
        /// <summary>
        /// Constructor de la clase CrearAlquiler. Inicializa el formulario y carga los datos iniciales.
        /// </summary>
        public CrearAlquiler()
        {
            InitializeComponent();
            this.Activated += FormAlquilar_Activated;
            cmbCategorias.SelectedIndex = -1;
            CargarCategorias();
        }

        /// <summary>
        /// Evento que se dispara cuando el formulario se activa. Recarga los usuarios.
        /// </summary>
        private void FormAlquilar_Activated(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        /// <summary>
        /// Evento que redirige al formulario de inicio y oculta el formulario actual.
        /// </summary>
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Hide();
        }

        /// <summary>
        /// Sobrescribe el comportamiento al cerrar el formulario. Finaliza la aplicación si el usuario cierra.
        /// </summary>
        /// <param name="e">Argumentos del evento de cierre del formulario.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        #endregion

        #region Gestión de Categorías
        /// <summary>
        /// Carga todas las categorías en un ComboBox.
        /// </summary>
        private void CargarCategorias()
        {
            try
            {
                cmbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
                List<Categoria> categorias = categoriaController.ObtenerTodasLasCategorias();
                cmbCategorias.DataSource = categorias;
                cmbCategorias.DisplayMember = "nombre";
                cmbCategorias.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar las categorías: {ex.Message}");
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de categorías y carga los items relacionados.
        /// </summary>
        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategorias.SelectedItem != null)
            {
                Categoria categoriaSeleccionada = (Categoria)cmbCategorias.SelectedItem;
                int categoriaId = categoriaSeleccionada.id;
                CargarItems(categoriaId);
            }
        }
        #endregion

        #region Carga Items, btnCrearItem y btnModificarItem
        /// <summary>
        /// Carga los items de una categoría específica en un DataGridView.
        /// </summary>
        /// <param name="categoriaId">ID de la categoría cuyos items se desean cargar.</param>
        private void CargarItems(int categoriaId)
        {
            try
            {
                var items = itemController.ObtenerItemsPorCategoria(categoriaId);

                if (items == null || !items.Any())
                {
                    dataGridViewItems.Rows.Clear();
                    MessageShow.MostrarMensajeInformacion("No se encontraron items para esta categoría.");
                    return;
                }

                dataGridViewItems.Rows.Clear();
                foreach (var item in items)
                {
                    dataGridViewItems.Rows.Add(
                        item.id,
                        item.nombreItem,
                        item.marca,
                        item.modelo,
                        item.tarifaDia,
                        item.deletedAt == null ? "Activo" : "Inactivo"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar items: {ex.Message}");
            }
        }

        /// <summary>
        /// Muestra el formulario para crear un nuevo ítem y oculta la ventana actual.
        /// </summary>
        private void btnCrearItem_Click(object sender, EventArgs e)
        {
            CrearItem formCreaItem = new CrearItem();
            formCreaItem.Show();
            this.Hide();
        }

        /// <summary>
        /// Muestra el formulario para modificar un ítem seleccionado y oculta la ventana actual.
        /// </summary>
        private void btnModificarItem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarItemsSeleccionados();

                int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;

                // Obtener el ítem y su categoría
                if (!ObtenerItemYCategoria(itemId, out ItemAlquilable item, out object categoria))
                {
                    return;
                }

                // Verificar si el ítem tiene alquileres activos
                bool tieneAlquileresActivos = TieneAlquileresActivos(item);
                if (tieneAlquileresActivos)
                {
                    MessageShow.MostrarMensajeError("No se puede modificar el item porque tiene alquileres activos.");
                    return;
                }

                ModificarItem formModificarItem = new ModificarItem(itemId);
                formModificarItem.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al abrir el formulario de modificación: {ex.Message}");
            }
        }
        #endregion

        #region Gestión de Items - Visualización de Detalles
        /// <summary>
        /// Muestra los detalles completos del ítem seleccionado.
        /// </summary>
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarItemsSeleccionados())
                {
                    int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;

                    if (ObtenerItemYCategoria(itemId, out ItemAlquilable item, out object categoria))
                    {
                        string mensajeDetalle = ConstruirMensajeDetalle(item, categoria);
                        MessageShow.MostrarMensajeInformacion(mensajeDetalle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al mostrar detalles: {ex.Message}");
            }
        }

        /// <summary>
        /// Construye el mensaje de detalle con la información completa del ítem.
        /// </summary>
        private string ConstruirMensajeDetalle(ItemAlquilable item, object categoria)
        {
            string mensajeDetalle = ConstruirInformacionBasicaItem(item);
            mensajeDetalle += ObtenerDetallesCompletosCategoria(categoria);
            return mensajeDetalle;
        }

        /// <summary>
        /// Construye la información básica del ítem.
        /// </summary>
        private string ConstruirInformacionBasicaItem(ItemAlquilable item)
        {
            return $"ID: {item.id}\n" +
                   $"Nombre: {item.nombreItem}\n" +
                   $"Marca: {item.marca}\n" +
                   $"Modelo: {item.modelo}\n" +
                   $"Tarifa por día: ${item.tarifaDia}\n\n";
        }

        /// <summary>
        /// Obtiene los detalles completos específicos de la categoría del ítem.
        /// </summary>
        private string ObtenerDetallesCompletosCategoria(object categoria)
        {
            var estrategiasDetallesCompletos = new Dictionary<Type, Func<object, string>>
            {
                { typeof(Transporte), c => $"Tipo: Transporte\n" +
                                        $"Capacidad de Pasajeros: {((Transporte)c).capacidadPasajeros}\n" +
                                        $"Tipo de Combustible: {((Transporte)c).tipoCombustible}" },

                { typeof(Electrodomestico), c => $"Tipo: Electrodoméstico\n" +
                                                $"Potencia (Watts): {((Electrodomestico)c).potenciaWatts}\n" +
                                                $"Tipo: {((Electrodomestico)c).tipoElectrodomestico}" },

                { typeof(Indumentaria), c => $"Tipo: Indumentaria\n" +
                                            $"Talla: {((Indumentaria)c).talla}\n" +
                                            $"Material: {((Indumentaria)c).material}" },

                { typeof(Inmueble), c => $"Tipo: Inmueble\n" +
                                        $"Metros Cuadrados: {((Inmueble)c).metrosCuadrados}\n" +
                                        $"Ubicación: {((Inmueble)c).ubicacion}" },

                { typeof(Electronica), c => $"Tipo: Electrónica\n" +
                                            $"Resolución: {((Electronica)c).resolucionPantalla}\n" +
                                            $"Almacenamiento: {((Electronica)c).almacenamientoGB}GB" }
            };

            Type tipoCategoria = categoria.GetType();

            if (estrategiasDetallesCompletos.ContainsKey(tipoCategoria))
            {
                return estrategiasDetallesCompletos[tipoCategoria](categoria);
            }

            return "Tipo: Desconocido";
        }

        /// <summary>
        /// Obtiene los detalles básicos de la categoría del ítem.
        /// </summary>
        private string ObtenerDetallesCategoria(object categoria)
        {
            var estrategiasDetalles = new Dictionary<Type, Func<object, string>>
            {
                { typeof(Transporte), c => $"Tipo: Transporte\nCapacidad: {((Transporte)c).capacidadPasajeros} pasajeros" },
                { typeof(Electrodomestico), c => $"Tipo: Electrodoméstico\nPotencia: {((Electrodomestico)c).potenciaWatts}W" },
                { typeof(Indumentaria), c => $"Tipo: Indumentaria\nTalla: {((Indumentaria)c).talla}" },
                { typeof(Inmueble), c => $"Tipo: Inmueble\nUbicación: {((Inmueble)c).ubicacion}" },
                { typeof(Electronica), c => $"Tipo: Electrónica\nAlmacenamiento: {((Electronica)c).almacenamientoGB}GB" }
            };

            Type tipoCategoria = categoria.GetType();

            if (estrategiasDetalles.ContainsKey(tipoCategoria))
            {
                return estrategiasDetalles[tipoCategoria](categoria);
            }

            return "Tipo: Desconocido";
        }
        #endregion

        #region Gestión de Items - Edición de Tarifa
        /// <summary>
        /// Edita la tarifa de un ítem seleccionado.
        /// </summary>
        private void btnEditarTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtenerItemParaEditarTarifa(out int itemId, out string marca, out string modelo, out double tarifaActual))
                {
                    string nuevaTarifaStr = SolicitarNuevaTarifa(marca, modelo, tarifaActual);

                    if (!string.IsNullOrEmpty(nuevaTarifaStr) && ValidarNuevaTarifa(nuevaTarifaStr, out double nuevaTarifa))
                    {
                        ActualizarTarifaItem(itemId, nuevaTarifa);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al editar la tarifa: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene el ítem seleccionado para editar su tarifa.
        /// </summary>
        private bool ObtenerItemParaEditarTarifa(out int itemId, out string marca, out string modelo, out double tarifaActual)
        {
            itemId = 0;
            marca = string.Empty;
            modelo = string.Empty;
            tarifaActual = 0;

            if (!ValidarItemsSeleccionados())
            {
                itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
                marca = dataGridViewItems.SelectedRows[0].Cells["marca"].Value.ToString();
                modelo = dataGridViewItems.SelectedRows[0].Cells["modelo"].Value.ToString();
                tarifaActual = Convert.ToDouble(dataGridViewItems.SelectedRows[0].Cells["tarifaXDia"].Value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Solicita al usuario que ingrese una nueva tarifa para el ítem.
        /// </summary>
        private string SolicitarNuevaTarifa(string marca, string modelo, double tarifaActual)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese la nueva tarifa para {marca} {modelo}:",
                "Editar Tarifa",
                tarifaActual.ToString());
        }

        /// <summary>
        /// Valida que la nueva tarifa ingresada sea un valor numérico válido.
        /// </summary>
        private bool ValidarNuevaTarifa(string nuevaTarifaStr, out double nuevaTarifa)
        {
            if (!double.TryParse(nuevaTarifaStr, out nuevaTarifa))
            {
                MessageShow.MostrarMensajeError("Por favor, ingrese un valor numérico válido para la tarifa.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Actualiza la tarifa de un ítem y refresca la interfaz de usuario.
        /// </summary>
        private void ActualizarTarifaItem(int itemId, double nuevaTarifa)
        {
            if (itemController.ActualizarTarifaItem(itemId, nuevaTarifa))
            {
                MessageShow.MostrarMensajeExito("Tarifa actualizada con éxito.");

                if (cmbCategorias.SelectedItem is Categoria categoriaSeleccionada)
                {
                    CargarItems(categoriaSeleccionada.id);
                }
            }
            else
            {
                MessageShow.MostrarMensajeError("No se pudo actualizar la tarifa del item.");
            }
        }
        #endregion

        #region Gestión de Items - Eliminación
        /// <summary>
        /// Elimina un ítem seleccionado de la lista.
        /// </summary>
        private void btnSoftDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcesarEliminacionItem();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al eliminar el item: {ex.Message}");
            }
        }

        /// <summary>
        /// Procesa la eliminación de un ítem siguiendo un flujo secuencial de validaciones.
        /// </summary>
        private void ProcesarEliminacionItem()
        {
            bool continuarProceso = true;
            int itemId = 0;
            ItemAlquilable? item = null;
            object? categoria = null;

            // Paso 1: Verificar que haya un ítem seleccionado
            if (continuarProceso)
            {
                if (ValidarItemsSeleccionados())
                {
                    continuarProceso = false;
                }
                else
                {
                    itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
                }
            }

            // Paso 2: Obtener el ítem y su categoría
            if (continuarProceso)
            {
                bool itemEncontrado = ObtenerItemYCategoria(itemId, out item, out categoria);
                continuarProceso = itemEncontrado;
            }

            // Paso 3: Verificar si el ítem tiene alquileres activos
            if (continuarProceso)
            {
                bool tieneAlquileresActivos = TieneAlquileresActivos(item);
                if (tieneAlquileresActivos)
                {
                    MessageShow.MostrarMensajeError("No se puede eliminar el item porque tiene alquileres activos.");
                    continuarProceso = false;
                }
            }

            // Paso 4: Solicitar confirmación al usuario
            if (continuarProceso)
            {
                continuarProceso = SolicitarConfirmacionEliminarItem(item, categoria);
            }

            // Paso 5: Eliminar el ítem y actualizar la interfaz
            if (continuarProceso)
            {
                EliminarItem(itemId);
            }
        }

        /// <summary>
        /// Verifica si el ítem tiene alquileres activos.
        /// </summary>
        private bool TieneAlquileresActivos(ItemAlquilable item)
        {
            return itemController.TieneAlquileresActivos(item);
        }

        /// <summary>
        /// Solicita confirmación al usuario para eliminar un ítem.
        /// </summary>
        private bool SolicitarConfirmacionEliminarItem(ItemAlquilable item, object categoria)
        {
            string mensajeConfirmacion = ConstruirMensajeConfirmacion(item, categoria);
            return MessageShow.MostrarMensajeConfirmacion(mensajeConfirmacion);
        }

        /// <summary>
        /// Construye el mensaje de confirmación con los detalles del ítem.
        /// </summary>
        private string ConstruirMensajeConfirmacion(ItemAlquilable item, object categoria)
        {
            string mensajeConfirmacion = $"¿Está seguro que desea eliminar el siguiente item?\n\n" +
                                       $"Nombre: {item.nombreItem}\n" +
                                       $"Marca: {item.marca}\n" +
                                       $"Modelo: {item.modelo}\n";

            mensajeConfirmacion += ObtenerDetallesCategoria(categoria);
            return mensajeConfirmacion;
        }

        /// <summary>
        /// Elimina el ítem y actualiza la interfaz de usuario.
        /// </summary>
        private void EliminarItem(int itemId)
        {
            itemController.EliminarItem(itemId);
            MessageShow.MostrarMensajeExito("Item eliminado exitosamente.");
            cmbCategorias.SelectedIndex = -1;
            CargarCategorias();
        }
        #endregion

        #region Gestión de Usuarios - Carga y Navegación
        /// <summary>
        /// Carga todos los usuarios en un DataGridView con información relevante.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                var usuarios = usuarioController.ObtenerTodosLosUsuarios();

                var usuariosData = usuarios.Select(u => new
                {
                    u.id,
                    u.nombre,
                    u.dni,
                    u.email,
                    membresiaPremium = u.membresiaPremium,
                    CantidadAlquileres = u.Alquileres?.Count ?? 0
                }).ToList();

                dataGridViewUsuarios.DataSource = usuariosData;
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cargar usuarios: {ex.Message}");
            }
        }

        /// <summary>
        /// Abre el formulario para crear un nuevo usuario.
        /// </summary>
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            CrearUsuario formCrearUsuario = new CrearUsuario();
            formCrearUsuario.Show();
            this.Hide();
        }

        /// <summary>
        /// Abre el formulario para modificar los datos de un usuario seleccionado.
        /// </summary>
        private void bntModificarUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtenerUsuarioParaModificar(out int usuarioId) &&
                    CargarDatosCompletosUsuario(usuarioId, out Usuarios usuario))
                {
                    FormModificarUsuario(usuario);
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al abrir el formulario de modificación: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene el ID del usuario seleccionado para modificarlo.
        /// </summary>
        private bool ObtenerUsuarioParaModificar(out int usuarioId)
        {
            usuarioId = 0;

            if (ValidarUsuarioSeleccionado())
            {
                usuarioId = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells[0].Value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Abre el formulario de modificación de usuario.
        /// </summary>
        private void FormModificarUsuario(Usuarios usuario)
        {
            ModificarUsuario formModificarUsuario = new ModificarUsuario(usuario);
            formModificarUsuario.ShowDialog();
        }
        #endregion

        #region Gestión de Usuarios - Eliminación
        /// <summary>
        /// Realiza un borrado lógico del usuario seleccionado.
        /// </summary>
        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtenerUsuarioParaEliminar(out int usuarioId) &&
                    CargarDatosCompletosUsuario(usuarioId, out Usuarios usuario) &&
                    SolicitarConfirmacionEliminarUsuario(usuario))
                {
                    EliminarUsuario(usuario);
                }
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al eliminar el usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene el ID del usuario seleccionado para eliminarlo.
        /// </summary>
        private bool ObtenerUsuarioParaEliminar(out int usuarioId)
        {
            usuarioId = 0;

            if (ValidarUsuarioSeleccionado())
            {
                usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Solicita confirmación al usuario para eliminar un usuario.
        /// </summary>
        private bool SolicitarConfirmacionEliminarUsuario(Usuarios usuario)
        {
            string mensajeConfirmacion = $"¿Está seguro que desea eliminar al usuario {usuario.nombre}?";
            return MessageShow.MostrarMensajeConfirmacion(mensajeConfirmacion);
        }

        /// <summary>
        /// Elimina un usuario y actualiza la interfaz de usuario.
        /// </summary>
        private void EliminarUsuario(Usuarios usuario)
        {
            usuarioController.EliminarUsuario(usuario);
            MessageShow.MostrarMensajeExito("Usuario eliminado exitosamente.");
            CargarUsuarios();
        }
        #endregion

        #region Creación de Alquileres
        /// <summary>
        /// Crea un nuevo alquiler basado en las entradas seleccionadas.
        /// </summary>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario()) return;

                int usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
                DateTime fechaInicio = dateTimePickerFechaInicio.Value;
                DateTime fechaFin = dateTimePickerFechaFin.Value;

                CrearAlquileresParaItemsSeleccionados(usuarioId, fechaInicio, fechaFin);

                CargarUsuarios();
            }
            catch (SqlException ex)
            {
                MessageShow.MostrarMensajeError($"Error al crear alquiler: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea alquileres para todos los ítems seleccionados.
        /// </summary>
        private void CrearAlquileresParaItemsSeleccionados(int usuarioId, DateTime fechaInicio, DateTime fechaFin)
        {
            foreach (DataGridViewRow row in dataGridViewItems.SelectedRows)
            {
                int itemId = ObtenerItemIdDeRow(row);
                CrearAlquilerIndividual(usuarioId, fechaInicio, fechaFin, itemId);
            }
        }

        /// <summary>
        /// Obtiene el ID del ítem de una fila del DataGridView.
        /// </summary>
        private int ObtenerItemIdDeRow(DataGridViewRow row)
        {
            return (int)row.Cells["ID"].Value;
        }

        /// <summary>
        /// Crea un alquiler individual para un ítem específico.
        /// </summary>
        private void CrearAlquilerIndividual(int usuarioId, DateTime fechaInicio, DateTime fechaFin, int itemId)
        {
            Alquileres nuevoAlquiler = CrearObjetoAlquiler(usuarioId, fechaInicio, fechaFin, itemId);
            alquilerController.CrearAlquiler(nuevoAlquiler);
        }

        /// <summary>
        /// Crea un objeto Alquileres con los datos proporcionados.
        /// </summary>
        private Alquileres CrearObjetoAlquiler(int usuarioId, DateTime fechaInicio, DateTime fechaFin, int itemId)
        {
            return new Alquileres
            {
                UsuarioID = usuarioId,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                ItemID = itemId
            };
        }

        /// <summary>
        /// Abre el formulario de visualización de alquileres.
        /// </summary>
        private void btnVerAlquileres_Click(object sender, EventArgs e)
        {
            VerAlquileres formAlquileres = new VerAlquileres();
            formAlquileres.Show();
            this.Hide();
        }
        #endregion

        #region Métodos de Validación
        /// <summary>
        /// Valida que todos los campos del formulario sean correctos.
        /// </summary>
        private bool ValidarFormulario()
        {
            return ValidarUsuarioSeleccionado() &&
                   !ValidarItemsSeleccionados() &&
                   ValidarFechasSeleccionadas();
        }

        /// <summary>
        /// Valida que se haya seleccionado un usuario.
        /// </summary>
        private bool ValidarUsuarioSeleccionado()
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un usuario.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida que se haya seleccionado al menos un ítem.
        /// </summary>
        private bool ValidarItemsSeleccionados()
        {
            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un ítem.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Valida que las fechas seleccionadas sean correctas.
        /// </summary>
        private bool ValidarFechasSeleccionadas()
        {
            if (dateTimePickerFechaFin.Value <= dateTimePickerFechaInicio.Value)
            {
                MessageShow.MostrarMensajeAdvertencia("La fecha de fin debe ser posterior a la fecha de inicio.");
                return false;
            }
            return true;
        }
        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Obtiene el ítem y su categoría específica por su ID.
        /// </summary>
        private bool ObtenerItemYCategoria(int itemId, out ItemAlquilable item, out object categoria)
        {
            var resultado = itemController.ObtenerItemPorId(itemId);
            item = resultado.Item1;
            categoria = resultado.Item2;

            if (item == null)
            {
                MessageShow.MostrarMensajeError("No se encontró el item seleccionado.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Carga los datos completos de un usuario.
        /// </summary>
        private bool CargarDatosCompletosUsuario(int usuarioId, out Usuarios usuario)
        {
            usuario = usuarioController.ObtenerUsuarioPorId(usuarioId);

            if (usuario == null)
            {
                MessageShow.MostrarMensajeError("No se encontró el usuario seleccionado.");
                return false;
            }

            return true;
        }
        #endregion
    }
}