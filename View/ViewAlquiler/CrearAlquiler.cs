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

namespace TitoAlquiler.View.ViewAlquiler
{
    public partial class CrearAlquiler : Form
    {
        UsuarioController usuarioController = UsuarioController.Instance;
        AlquilerController alquilerController = AlquilerController.Instance;
        ItemController itemController = ItemController.Instance;
        CategoriaController categoriaController = CategoriaController.Instance;

        #region FormAlquiler
        public CrearAlquiler()
        {
            InitializeComponent();
            this.Activated += FormAlquilar_Activated;
            cmbCategorias.SelectedIndex = -1;
            CargarCategorias();
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

        #region Items
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
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCrearItem_Click(object sender, EventArgs e)
        {
            CrearItem formCreaItem = new CrearItem();
            formCreaItem.Show();
            this.Hide();
        }

        /// <summary>
        /// Muestra el formulario para modificar un ítem seleccionado y oculta la ventana actual.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnModificarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewItems.SelectedRows.Count == 0)
                {
                    MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un ítem para modificar.");
                    return;
                }

                int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;

                // Crear y mostrar el formulario de modificación con el ID del ítem seleccionado
                ModificarItem formModificarItem = new ModificarItem(itemId);
                formModificarItem.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al abrir el formulario de modificación: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina un ítem seleccionado de la lista. Solicita confirmación antes de proceder.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método implementa la eliminación lógica (soft delete) de un ítem, verificando primero
        /// que esté seleccionado, que exista y que no tenga alquileres activos. Luego solicita
        /// confirmación al usuario mostrando los detalles del ítem antes de proceder con la eliminación.
        /// </remarks>
        private void btnSoftDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya un ítem seleccionado
                if (!VerificarItemSeleccionado())
                {
                    return; // Ya se mostró un mensaje en el método VerificarItemSeleccionado
                }

                // Obtener el ítem y su categoría
                int itemId = ObtenerIdItemSeleccionado();
                if (!ObtenerItemYCategoria(itemId, out ItemAlquilable item, out object categoria))
                {
                    return; // Ya se mostró un mensaje en el método ObtenerItemYCategoria
                }

                // Verificar si el ítem tiene alquileres activos
                if (TieneAlquileresActivos(item))
                {
                    MessageShow.MostrarMensajeError("No se puede eliminar el item porque tiene alquileres activos.");
                    return;
                }

                // Solicitar confirmación al usuario
                if (!SolicitarConfirmacionEliminarItem(item, categoria))
                {
                    return; // El usuario canceló la operación
                }

                // Eliminar el ítem y actualizar la interfaz
                EliminarItemYActualizarInterfaz(itemId);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al eliminar el item: {ex.Message}");
            }
        }

        /// <summary>
        /// Verifica que haya un ítem seleccionado en el DataGridView.
        /// </summary>
        /// <returns>True si hay un ítem seleccionado, false en caso contrario.</returns>
        private bool VerificarItemSeleccionado()
        {
            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un item para eliminar.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene el ID del ítem seleccionado en el DataGridView.
        /// </summary>
        /// <returns>El ID del ítem seleccionado.</returns>
        private int ObtenerIdItemSeleccionado()
        {
            return (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
        }

        /// <summary>
        /// Obtiene el ítem y su categoría específica por su ID.
        /// </summary>
        /// <param name="itemId">ID del ítem a obtener.</param>
        /// <param name="item">El ítem obtenido (salida).</param>
        /// <param name="categoria">La categoría específica del ítem (salida).</param>
        /// <returns>True si se obtuvo el ítem y su categoría, false en caso contrario.</returns>
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
        /// Verifica si el ítem tiene alquileres activos.
        /// </summary>
        /// <param name="item">El ítem a verificar.</param>
        /// <returns>True si el ítem tiene alquileres activos, false en caso contrario.</returns>
        private bool TieneAlquileresActivos(ItemAlquilable item)
        {
            return item.Alquileres?.Any(a => a.deletedAt == null && a.fechaFin > DateTime.Now) == true;
        }

        /// <summary>
        /// Solicita confirmación al usuario para eliminar un ítem, mostrando sus detalles.
        /// </summary>
        /// <param name="item">El ítem a eliminar.</param>
        /// <param name="categoria">La categoría específica del ítem.</param>
        /// <returns>True si el usuario confirma la eliminación, false en caso contrario.</returns>
        private bool SolicitarConfirmacionEliminarItem(ItemAlquilable item, object categoria)
        {
            string mensajeConfirmacion = ConstruirMensajeConfirmacion(item, categoria);

            DialogResult result = MessageBox.Show(mensajeConfirmacion,
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Construye el mensaje de confirmación con los detalles del ítem.
        /// </summary>
        /// <param name="item">El ítem cuyos detalles se mostrarán.</param>
        /// <param name="categoria">La categoría específica del ítem.</param>
        /// <returns>El mensaje de confirmación con los detalles del ítem.</returns>
        private string ConstruirMensajeConfirmacion(ItemAlquilable item, object categoria)
        {
            string mensajeConfirmacion = $"¿Está seguro que desea eliminar el siguiente item?\n\n" +
                                       $"Nombre: {item.nombreItem}\n" +
                                       $"Marca: {item.marca}\n" +
                                       $"Modelo: {item.modelo}\n";

            // Agregar detalles específicos según la categoría
            mensajeConfirmacion += ObtenerDetallesCategoria(categoria);

            return mensajeConfirmacion;
        }

        /// <summary>
        /// Obtiene los detalles específicos de la categoría del ítem.
        /// </summary>
        /// <param name="categoria">La categoría específica del ítem.</param>
        /// <returns>Una cadena con los detalles específicos de la categoría.</returns>
        private string ObtenerDetallesCategoria(object categoria)
        {
            // Usar un diccionario de funciones para obtener los detalles según el tipo de categoría
            var estrategiasDetalles = new Dictionary<Type, Func<object, string>>
    {
        { typeof(Transporte), c => $"Tipo: Transporte\nCapacidad: {((Transporte)c).capacidadPasajeros} pasajeros" },
        { typeof(Electrodomestico), c => $"Tipo: Electrodoméstico\nPotencia: {((Electrodomestico)c).potenciaWatts}W" },
        { typeof(Indumentaria), c => $"Tipo: Indumentaria\nTalla: {((Indumentaria)c).talla}" },
        { typeof(Inmueble), c => $"Tipo: Inmueble\nUbicación: {((Inmueble)c).ubicacion}" },
        { typeof(Electronica), c => $"Tipo: Electrónica\nAlmacenamiento: {((Electronica)c).almacenamientoGB}GB" }
    };

            // Obtener el tipo de la categoría
            Type tipoCategoria = categoria.GetType();

            // Si existe una estrategia para este tipo, ejecutarla
            if (estrategiasDetalles.ContainsKey(tipoCategoria))
            {
                return estrategiasDetalles[tipoCategoria](categoria);
            }

            return "Tipo: Desconocido";
        }

        /// <summary>
        /// Elimina el ítem y actualiza la interfaz de usuario.
        /// </summary>
        /// <param name="itemId">ID del ítem a eliminar.</param>
        private void EliminarItemYActualizarInterfaz(int itemId)
        {
            // Intentar eliminar el item
            itemController.EliminarItem(itemId);

            MessageShow.MostrarMensajeExito("Item eliminado exitosamente.");

            // Actualizar la interfaz
            ActualizarInterfazDespuesDeEliminar();
        }

        /// <summary>
        /// Actualiza la interfaz de usuario después de eliminar un ítem.
        /// </summary>
        private void ActualizarInterfazDespuesDeEliminar()
        {
            cmbCategorias.SelectedIndex = -1;
            CargarCategorias();
        }

        /// <summary>
        /// Edita la tarifa de un ítem seleccionado. Solicita al usuario que ingrese un nuevo valor.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Si no hay un ítem seleccionado, se mostrará un mensaje de advertencia.
        /// Se valida que el nuevo valor ingresado sea un número válido.
        /// </remarks>
        /// <summary>
        /// Maneja el evento de clic para editar la tarifa de un ítem seleccionado.
        /// </summary>
        private void btnEditarTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ítem seleccionado
                if (!ObtenerItemParaEditarTarifa(out int itemId, out string marca, out string modelo, out double tarifaActual))
                {
                    return; // Ya se mostró un mensaje en el método ObtenerItemParaEditarTarifa
                }

                // Solicitar la nueva tarifa al usuario
                string nuevaTarifaStr = SolicitarNuevaTarifa(marca, modelo, tarifaActual);

                if (string.IsNullOrEmpty(nuevaTarifaStr))
                    return; // El usuario canceló la operación

                // Validar y convertir la nueva tarifa
                if (!ValidarNuevaTarifa(nuevaTarifaStr, out double nuevaTarifa))
                {
                    return; // Ya se mostró un mensaje en el método ValidarNuevaTarifa
                }

                // Actualizar la tarifa y refrescar la interfaz
                ActualizarTarifaItem(itemId, nuevaTarifa);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al editar la tarifa: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene el ítem seleccionado para editar su tarifa.
        /// </summary>
        /// <param name="itemId">ID del ítem seleccionado (salida).</param>
        /// <param name="marca">Marca del ítem (salida).</param>
        /// <param name="modelo">Modelo del ítem (salida).</param>
        /// <param name="tarifaActual">Tarifa actual del ítem (salida).</param>
        /// <returns>True si se obtuvo un ítem válido, false en caso contrario.</returns>
        private bool ObtenerItemParaEditarTarifa(out int itemId, out string marca, out string modelo, out double tarifaActual)
        {
            // Inicializar valores de salida
            itemId = 0;
            marca = string.Empty;
            modelo = string.Empty;
            tarifaActual = 0;

            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un item para editar su tarifa.");
                return false;
            }

            // Obtener datos del ítem seleccionado
            itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
            marca = dataGridViewItems.SelectedRows[0].Cells["marca"].Value.ToString();
            modelo = dataGridViewItems.SelectedRows[0].Cells["modelo"].Value.ToString();
            tarifaActual = Convert.ToDouble(dataGridViewItems.SelectedRows[0].Cells["tarifaXDia"].Value);

            return true;
        }

        /// <summary>
        /// Solicita al usuario que ingrese una nueva tarifa para el ítem.
        /// </summary>
        /// <param name="marca">Marca del ítem.</param>
        /// <param name="modelo">Modelo del ítem.</param>
        /// <param name="tarifaActual">Tarifa actual del ítem.</param>
        /// <returns>La nueva tarifa ingresada por el usuario o una cadena vacía si canceló.</returns>
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
        /// <param name="nuevaTarifaStr">Cadena con la nueva tarifa ingresada.</param>
        /// <param name="nuevaTarifa">Valor numérico de la nueva tarifa (salida).</param>
        /// <returns>True si la tarifa es válida, false en caso contrario.</returns>
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
        /// <param name="itemId">ID del ítem a actualizar.</param>
        /// <param name="nuevaTarifa">Nueva tarifa a aplicar.</param>
        private void ActualizarTarifaItem(int itemId, double nuevaTarifa)
        {
            if (itemController.ActualizarTarifaItem(itemId, nuevaTarifa))
            {
                MessageShow.MostrarMensajeExito("Tarifa actualizada con éxito.");

                // Refrescar la lista de ítems
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

        /// <summary>
        /// Muestra los detalles completos del ítem seleccionado, incluyendo sus propiedades específicas según su categoría.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método obtiene el ítem seleccionado del DataGridView, recupera sus datos completos
        /// incluyendo las propiedades específicas de su categoría (Transporte, Electrodoméstico, etc.)
        /// y muestra toda esta información en un mensaje informativo para el usuario.
        /// Si no hay un ítem seleccionado o no se puede obtener la información, muestra un mensaje de error.
        /// </remarks>
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya un ítem seleccionado
                if (!VerificarItemSeleccionadoParaDetalle())
                {
                    return; // Ya se mostró un mensaje en el método VerificarItemSeleccionadoParaDetalle
                }

                // Obtener el ítem y su categoría
                int itemId = ObtenerIdItemSeleccionado();
                if (!ObtenerItemYCategoria(itemId, out ItemAlquilable item, out object categoria))
                {
                    return; // Ya se mostró un mensaje en el método ObtenerItemYCategoria
                }

                // Construir y mostrar el mensaje de detalle
                string mensajeDetalle = ConstruirMensajeDetalle(item, categoria);
                MessageShow.MostrarMensajeInformacion(mensajeDetalle);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al mostrar detalles: {ex.Message}");
            }
        }

        /// <summary>
        /// Verifica que haya un ítem seleccionado para mostrar sus detalles.
        /// </summary>
        /// <returns>True si hay un ítem seleccionado, false en caso contrario.</returns>
        private bool VerificarItemSeleccionadoParaDetalle()
        {
            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un ítem para ver su detalle.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Construye el mensaje de detalle con la información completa del ítem.
        /// </summary>
        /// <param name="item">El ítem cuyos detalles se mostrarán.</param>
        /// <param name="categoria">La categoría específica del ítem.</param>
        /// <returns>El mensaje de detalle con la información completa del ítem.</returns>
        private string ConstruirMensajeDetalle(ItemAlquilable item, object categoria)
        {
            // Construir la información básica del ítem
            string mensajeDetalle = ConstruirInformacionBasicaItem(item);

            // Agregar detalles específicos según la categoría
            mensajeDetalle += ObtenerDetallesCompletosCategoria(categoria);

            return mensajeDetalle;
        }

        /// <summary>
        /// Construye la información básica del ítem (propiedades comunes a todos los ítems).
        /// </summary>
        /// <param name="item">El ítem cuya información básica se construirá.</param>
        /// <returns>Una cadena con la información básica del ítem.</returns>
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
        /// <param name="categoria">La categoría específica del ítem.</param>
        /// <returns>Una cadena con los detalles completos específicos de la categoría.</returns>
        private string ObtenerDetallesCompletosCategoria(object categoria)
        {
            // Usar un diccionario de funciones para obtener los detalles según el tipo de categoría
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

            // Obtener el tipo de la categoría
            Type tipoCategoria = categoria.GetType();

            // Si existe una estrategia para este tipo, ejecutarla
            if (estrategiasDetallesCompletos.ContainsKey(tipoCategoria))
            {
                return estrategiasDetallesCompletos[tipoCategoria](categoria);
            }

            return "Tipo: Desconocido";
        }

        #endregion

        #region Usuarios
        private void FormAlquilar_Activated(object sender, EventArgs e)
        {
            CargarUsuarios(); // Recarga la tabla cada vez que el formulario se activa
        }

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
        /// Abre el formulario para crear un nuevo usuario y oculta el formulario actual.
        /// </summary>
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            CrearUsuario formCrearUsuario = new CrearUsuario();
            formCrearUsuario.Show();
            this.Hide();
        }

        /// <summary>
        /// Realiza un borrado lógico del usuario seleccionado en el DataGridView.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el usuario seleccionado
                if (!ObtenerUsuarioParaEliminar(out int usuarioId))
                {
                    return; // Ya se mostró un mensaje en el método ObtenerUsuarioParaEliminar
                }

                // Cargar los datos completos del usuario
                if (!CargarDatosCompletosUsuario(usuarioId, out Usuarios usuario))
                {
                    return; // Ya se mostró un mensaje en el método CargarDatosCompletosUsuario
                }

                // Solicitar confirmación al usuario
                if (SolicitarConfirmacionEliminarUsuario(usuario))
                {
                    // Eliminar el usuario y actualizar la interfaz
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
        /// <param name="usuarioId">ID del usuario seleccionado (salida).</param>
        /// <returns>True si se seleccionó un usuario válido, false en caso contrario.</returns>
        private bool ObtenerUsuarioParaEliminar(out int usuarioId)
        {
            usuarioId = 0;

            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione un usuario para eliminar.");
                return false;
            }

            usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
            return true;
        }

        /// <summary>
        /// Carga los datos completos de un usuario.
        /// </summary>
        /// <param name="usuarioId">ID del usuario a cargar.</param>
        /// <param name="usuario">Objeto Usuario cargado (salida).</param>
        /// <returns>True si se cargaron los datos correctamente, false en caso contrario.</returns>
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

        /// <summary>
        /// Solicita confirmación al usuario para eliminar un usuario.
        /// </summary>
        /// <param name="usuario">Usuario a eliminar.</param>
        /// <returns>True si el usuario confirma la eliminación, false en caso contrario.</returns>
        private bool SolicitarConfirmacionEliminarUsuario(Usuarios usuario)
        {
            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea eliminar al usuario {usuario.nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Elimina un usuario y actualiza la interfaz de usuario.
        /// </summary>
        /// <param name="usuario">Usuario a eliminar.</param>
        private void EliminarUsuario(Usuarios usuario)
        {
            usuarioController.EliminarUsuario(usuario);
            MessageShow.MostrarMensajeExito("Usuario eliminado exitosamente.");
            CargarUsuarios();
        }

        /// <summary>
        /// Abre el formulario para modificar los datos de un usuario seleccionado.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método verifica si hay un usuario seleccionado en el DataGridView, obtiene sus datos
        /// completos y abre el formulario de modificación de usuario con esos datos precargados.
        /// Si no hay un usuario seleccionado o no se puede encontrar el usuario en la base de datos,
        /// se muestra un mensaje de error apropiado.
        /// </remarks>
        private void bntModificarUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el usuario seleccionado
                if (!ObtenerUsuarioParaModificar(out int usuarioId))
                {
                    return; // Ya se mostró un mensaje en el método ObtenerUsuarioParaModificar
                }

                // Cargar los datos completos del usuario
                if (!CargarDatosCompletosUsuario(usuarioId, out Usuarios usuario))
                {
                    return; // Ya se mostró un mensaje en el método CargarDatosCompletosUsuario
                }

                // Abrir el formulario de modificación
                AbrirFormularioModificarUsuario(usuario);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al abrir el formulario de modificación: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene el ID del usuario seleccionado para modificarlo.
        /// </summary>
        /// <param name="usuarioId">ID del usuario seleccionado (salida).</param>
        /// <returns>True si se seleccionó un usuario válido, false en caso contrario.</returns>
        private bool ObtenerUsuarioParaModificar(out int usuarioId)
        {
            usuarioId = 0;

            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageShow.MostrarMensajeAdvertencia("Seleccione un usuario para modificar.");
                return false;
            }

            usuarioId = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells[0].Value);
            return true;
        }

        /// <summary>
        /// Abre el formulario de modificación de usuario con los datos del usuario seleccionado.
        /// </summary>
        /// <param name="usuario">Usuario a modificar.</param>
        private void AbrirFormularioModificarUsuario(Usuarios usuario)
        {
            ModificarUsuario formModificarUsuario = new ModificarUsuario(usuario);
            formModificarUsuario.ShowDialog();
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

        #region Alquiler

        /// <summary>
        /// Crea un nuevo alquiler basado en las entradas seleccionadas y muestra el precio total.
        /// </summary>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario()) return;

                int usuarioId = ObtenerUsuarioSeleccionado();
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
        /// Abre el formulario de visualización de alquileres y oculta el formulario actual.
        /// </summary>
        private void btnVerAlquileres_Click(object sender, EventArgs e)
        {
            VerAlquileres formAlquileres = new VerAlquileres();
            formAlquileres.Show();
            this.Hide();
        }
        #endregion

        #region Métodos de validación

        /// <summary>
        /// Valida que todos los campos del formulario sean correctos.
        /// </summary>
        private bool ValidarFormulario()
        {
            return ValidarUsuarioSeleccionado() &&
                   ValidarItemsSeleccionados() &&
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
                MessageShow.MostrarMensajeAdvertencia("Por favor, seleccione al menos un ítem para alquilar.");
                return false;
            }
            return true;
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

        #region Métodos de creación de alquileres

        /// <summary>
        /// Obtiene el ID del usuario seleccionado en el DataGridView.
        /// </summary>
        private int ObtenerUsuarioSeleccionado()
        {
            return (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
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

        #endregion 
    }
}