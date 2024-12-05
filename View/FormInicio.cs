﻿using SistemaAlquileres.View.Alquiler;
using SistemaAlquileres.View.Usuario;
using System;
using System.Windows.Forms;

namespace SistemaAlquileres
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FormAlquilar form = new FormAlquilar();
            form.Show();
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
    }
}