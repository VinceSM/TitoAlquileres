using TitoAlquiler.Controller;
using TitoAlquiler.View.ViewUsuario;
using TitoAlquiler.View.ViewItem;
using System;
using System.Windows.Forms;
using TitoAlquiler.Model.Entities;
using System.Linq;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.View.ViewAlquiler
{
    public partial class CrearAlquiler : Form
    {
        UsuarioController usuarioController = UsuarioController.Instance;
        AlquilerController alquilerController = AlquilerController.Instance;
        ItemController itemController = ItemController.Instance;
        CategoriaController categoriaController = CategoriaController.Instance;

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
                    MessageBox.Show("No se encontraron items para esta categoría.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Error al cargar items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ModificarItem formModificarItem = new ModificarItem();
            formModificarItem.Show();
            this.Hide();
        }

        /// <summary>
        /// Elimina un ítem seleccionado de la lista. Solicita confirmación antes de proceder.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Si no hay un ítem seleccionado, se mostrará un mensaje de advertencia.
        /// También se manejarán posibles errores durante el proceso de eliminación.
        /// </remarks>
        private void btnSoftDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar selección
                if (dataGridViewItems.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un item para eliminar.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;

                // Obtener el item y su categoría
                var (item, categoria) = itemController.ObtenerItemPorId(itemId);

                if (item == null)
                {
                    MessageBox.Show("No se encontró el item seleccionado.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar si el item tiene alquileres activos
                if (item.Alquileres?.Any(a => a.deletedAt == null &&
                    a.fechaFin > DateTime.Now) == true)
                {
                    MessageBox.Show("No se puede eliminar el item porque tiene alquileres activos.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construir mensaje de confirmación con detalles
                string mensajeConfirmacion = $"¿Está seguro que desea eliminar el siguiente item?\n\n" +
                                           $"Nombre: {item.nombreItem}\n" +
                                           $"Marca: {item.marca}\n" +
                                           $"Modelo: {item.modelo}\n";

                // Agregar detalles específicos según la categoría
                switch (categoria)
                {
                    case Transporte t:
                        mensajeConfirmacion += $"Tipo: Transporte\n" +
                                             $"Capacidad: {t.capacidadPasajeros} pasajeros";
                        break;
                    case Electrodomestico ele:
                        mensajeConfirmacion += $"Tipo: Electrodoméstico\n" +
                                             $"Potencia: {ele.potenciaWatts}W";
                        break;
                    case Indumentaria i:
                        mensajeConfirmacion += $"Tipo: Indumentaria\n" +
                                             $"Talla: {i.talla}";
                        break;
                    case Inmueble inm:
                        mensajeConfirmacion += $"Tipo: Inmueble\n" +
                                             $"Ubicación: {inm.ubicacion}";
                        break;
                    case Electronica el:
                        mensajeConfirmacion += $"Tipo: Electrónica\n" +
                                             $"Almacenamiento: {el.almacenamientoGB}GB";
                        break;
                }

                DialogResult result = MessageBox.Show(mensajeConfirmacion,
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Intentar eliminar el item
                    itemController.EliminarItem(itemId);

                    MessageBox.Show("Item eliminado exitosamente.",
                                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmbCategorias.SelectedIndex = -1;
                    CargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el item: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void btnEditarTarifa_Click(object sender, EventArgs e)
        {
            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un item para editar su tarifa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
            string marca = dataGridViewItems.SelectedRows[0].Cells["marca"].Value.ToString();
            string modelo = dataGridViewItems.SelectedRows[0].Cells["modelo"].Value.ToString();
            double tarifaActual = Convert.ToDouble(dataGridViewItems.SelectedRows[0].Cells["tarifaXDia"].Value);

            string input = Microsoft.VisualBasic.Interaction.InputBox($"Ingrese la nueva tarifa para {marca} {modelo}:", "Editar Tarifa", tarifaActual.ToString());

            if (string.IsNullOrEmpty(input))
                return;

            if (double.TryParse(input, out double nuevaTarifa))
            {
                if (itemController.ActualizarTarifaItem(itemId, nuevaTarifa))
                {
                    MessageBox.Show("Tarifa actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (cmbCategorias.SelectedItem is Categoria categoriaSeleccionada)
                    {
                        CargarItems(categoriaSeleccionada.id);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la tarifa del item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la tarifa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;

            try
            {
                var selectedUsuario = usuarioController.ObtenerUsuarioPorId(usuarioId);
                if (selectedUsuario == null)
                {
                    MessageBox.Show("No se encontró el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar al usuario {selectedUsuario.nombre}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    usuarioController.EliminarUsuario(selectedUsuario);
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntModificarUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells[0].Value);
                var usuario = usuarioController.ObtenerUsuarioPorId(idUsuario);

                if (usuario != null)
                {
                    ModificarUsuario formModificarUsuario = new ModificarUsuario(usuario);
                    formModificarUsuario.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cmbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
                List<Categoria> categorias = categoriaController.ObtenerTodasLasCategorias();
                cmbCategorias.DataSource = categorias;
                cmbCategorias.DisplayMember = "nombre";
                cmbCategorias.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region FormAlquilar

        /// <summary>
        /// Crea un nuevo alquiler basado en las entradas seleccionadas y muestra el precio total.
        /// </summary>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya un usuario seleccionado
                if (dataGridViewUsuarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener ID del usuario seleccionado
                int usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;

                // Verificar que haya al menos un ítem seleccionado
                if (dataGridViewItems.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione al menos un ítem para alquilar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Establecer la fecha de inicio y fin del alquiler
                DateTime fechaInicio = dateTimePickerFechaInicio.Value;
                DateTime fechaFin = dateTimePickerFechaFin.Value;

                if (fechaFin <= fechaInicio)
                {
                    MessageBox.Show("La fecha de fin debe ser posterior a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear y guardar un alquiler por cada ítem seleccionado
                foreach (DataGridViewRow row in dataGridViewItems.SelectedRows)
                {
                    int itemId = (int)row.Cells["ID"].Value;

                    // Crear objeto Alquiler
                    Alquileres nuevoAlquiler = new Alquileres
                    {
                        UsuarioID = usuarioId,
                        fechaInicio = fechaInicio,
                        fechaFin = fechaFin,
                        ItemID = itemId
                    };

                    // Llamar al método sin intentar asignar su retorno si devuelve void
                    alquilerController.CrearAlquiler(nuevoAlquiler);
                }

                MessageBox.Show("Alquiler creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewItems.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un ítem para ver su detalle.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int itemId = Convert.ToInt32(dataGridViewItems.SelectedRows[0].Cells["ID"].Value);
                var (item, categoria) = itemController.ObtenerItemPorId(itemId);

                if (item == null)
                {
                    MessageBox.Show("No se encontraron detalles para el ítem seleccionado.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string mensajeDetalle = $"ID: {item.id}\n" +
                                      $"Nombre: {item.nombreItem}\n" +
                                      $"Marca: {item.marca}\n" +
                                      $"Modelo: {item.modelo}\n" +
                                      $"Tarifa por día: ${item.tarifaDia}\n\n";

                // Agregar detalles específicos según la categoría
                switch (categoria)
                {
                    case Transporte t:
                        mensajeDetalle += $"Tipo: Transporte\n" +
                                        $"Capacidad de Pasajeros: {t.capacidadPasajeros}\n" +
                                        $"Tipo de Combustible: {t.tipoCombustible}";
                        break;
                    case Electrodomestico ele:
                        mensajeDetalle += $"Tipo: Electrodoméstico\n" +
                                        $"Potencia (Watts): {ele.potenciaWatts}\n" +
                                        $"Tipo: {ele.tipoElectrodomestico}";
                        break;
                    case Indumentaria i:
                        mensajeDetalle += $"Tipo: Indumentaria\n" +
                                        $"Talla: {i.talla}\n" +
                                        $"Material: {i.material}";
                        break;
                    case Inmueble inm:
                        mensajeDetalle += $"Tipo: Inmueble\n" +
                                        $"Metros Cuadrados: {inm.metrosCuadrados}\n" +
                                        $"Ubicación: {inm.ubicacion}";
                        break;
                    case Electronica el:
                        mensajeDetalle += $"Tipo: Electrónica\n" +
                                        $"Resolución: {el.resolucionPantalla}\n" +
                                        $"Almacenamiento: {el.almacenamientoGB}GB";
                        break;
                }

                MessageBox.Show(mensajeDetalle, "Detalle del Ítem",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar detalles: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para calcular y mostrar el precio estimado
        private void MostrarPrecioEstimado()
        {
            try
            {
                if (dataGridViewItems.SelectedRows.Count == 0 || dataGridViewUsuarios.SelectedRows.Count == 0)
                    return;

                int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
                int usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;

                DateTime fechaInicio = dateTimePickerFechaInicio.Value;
                DateTime fechaFin = dateTimePickerFechaFin.Value;
                int dias = (int)(fechaFin - fechaInicio).TotalDays + 1;

                double precioEstimado = alquilerController.CalcularPrecioEstimado(itemId, usuarioId, dias);

                lblPrecioPorDia.Text = $"Precio Estimado: ${precioEstimado:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular precio estimado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Agregar este manejador de eventos para los DateTimePicker
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            MostrarPrecioEstimado();
        }

        // Agregar este manejador para la selección de items o usuarios
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            MostrarPrecioEstimado();
        }
    }
}

