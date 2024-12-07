﻿using SistemaAlquileres.Controllers;
using SistemaAlquileres.View.Usuario;
using System;
using System.Windows.Forms;
using TitoAlquiler.Controllers;
using TitoAlquiler.Model.Entities;

namespace SistemaAlquileres.View.Alquiler
{
    public partial class FormAlquilar : Form
    {
        UsuarioController usuarioController = UsuarioController.getInstance();
        AlquilerController alquilerController = AlquilerController.getInstance();
        ItemController itemController = ItemController.getInstance();

        public FormAlquilar()
        {
            InitializeComponent();
            CargarItems();
            CargarUsuarios();
        }

        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Hide();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void CargarItems()
        {
            try
            {
                // Obtener los datos desde el controlador
                var items = itemController.ObtenerTodosLosItems();

                // Crear una lista de objetos anónimos para el DataGridView
                var itemsData = items.Select(item => new
                {
                    item.id,
                    item.nombreItem,
                    item.marca,
                    item.modelo,
                    item.tarifaDia,
                    Categoria = item.categoria?.nombre ?? "Sin categoría",
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                // Obtener los datos desde el controlador
                var usuarios = usuarioController.ObtenerTodosLosUsuarios();

                // Crear una lista de objetos anónimos para el DataGridView
                var usuariosData = usuarios.Select(u => new
                {
                    u.id,
                    u.nombre,
                    u.dni,
                    u.email,
                    u.membresiaPremium,
                    u.deletedAt.HasValue,
                    CantidadAlquileres = u.Alquileres?.Count ?? 0
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            FormCrearUsuario formCrearUsuario = new FormCrearUsuario();
            formCrearUsuario.Show();
            this.Hide();
        }
    }
}

