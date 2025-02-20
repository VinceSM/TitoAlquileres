﻿using System;
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

namespace TitoAlquiler.View.Item
{
    public partial class CrearItem : Form
    {
        CategoriaController categoriaController = CategoriaController.getInstance();

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
            catch (Exception ex)
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
       private void btnCreaItem_Click(object sender, EventArgs e)
        {
            
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
