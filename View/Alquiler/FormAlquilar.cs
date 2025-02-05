using TitoAlquiler.Controller;
using TitoAlquiler.View.Usuario;
using TitoAlquiler.View.Item;
using System;
using System.Windows.Forms;
using TitoAlquiler.Model.Entities;
using System.Linq;

namespace TitoAlquiler.View.Alquiler
{
    public partial class FormAlquilar : Form
    {
        UsuarioController usuarioController = UsuarioController.getInstance();
        AlquilerController alquilerController = AlquilerController.getInstance();
        ItemController itemController = ItemController.getInstance();
        CategoriaController categoriaController = CategoriaController.getInstance();

        public FormAlquilar()
        {
            InitializeComponent();
            this.Activated += FormAlquilar_Activated;
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
            Crear formCreaItem = new Crear();
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
            Modificar formModificarItem = new Modificar();
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
            if (dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un item para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;

            try
            {
                var selectedItem = itemController.ObtenerItemPorId(itemId);
                if (selectedItem == null)
                {
                    MessageBox.Show("No se encontró el item seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el item {selectedItem.nombreItem}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (itemController.EliminarItem(itemId))
                    {
                        MessageBox.Show("Item eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Actualizar la vista
                        if (cmbCategorias.SelectedItem is Categoria categoriaSeleccionada)
                        {
                            CargarItems(categoriaSeleccionada.id);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            FormCrearUsuario formCrearUsuario = new FormCrearUsuario();
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
                    FormModificarUsuario formModificarUsuario = new FormModificarUsuario(usuario);
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
        /// Verifica si hay filas seleccionadas en los DataGridView de usuarios e items.
        /// </summary>
        private void VerificarSeleccionFilaDataGrid()
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0 || dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario y un item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Crea un nuevo alquiler basado en las entradas seleccionadas y muestra el precio total.
        /// </summary>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarSeleccionFilaDataGrid();

                int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
                int usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
                DateTime fechaInicio = dateTimePickerFechaInicio.Value;
                DateTime fechaFin = dateTimePickerFechaFin.Value;
                string tipoEstrategia = "EstrategiaEstacion";

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (fechaInicio < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de inicio debe ser mayor o igual a la fecha de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!alquilerController.VerificarDisponibilidad(itemId, fechaInicio, fechaFin))
                {
                    MessageBox.Show("El item no está disponible para las fechas seleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nuevoAlquiler = alquilerController.CrearNuevoAlquiler(itemId, usuarioId, fechaInicio, fechaFin, tipoEstrategia);

                MessageBox.Show($"Alquiler creado con éxito. Precio total: {nuevoAlquiler.precioTotal:C}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                if (cmbCategorias.SelectedItem is Categoria categoriaSeleccionada)
                {
                    CargarItems(categoriaSeleccionada.id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el formulario de visualización de alquileres y oculta el formulario actual.
        /// </summary>
        private void btnVerAlquileres_Click(object sender, EventArgs e)
        {
            FormAlquileres formAlquileres = new FormAlquileres();
            formAlquileres.Show();
            this.Hide();
        }
        #endregion

    }
}

