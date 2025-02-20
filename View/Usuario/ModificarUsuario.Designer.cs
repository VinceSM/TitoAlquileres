﻿namespace TitoAlquiler.View.Usuario
{
    partial class ModificarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            linkVolver = new LinkLabel();
            panel1 = new Panel();
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            btnModificar = new Button();
            checkBoxMembresia = new CheckBox();
            textBoxNombre = new TextBox();
            btnCrearUsuario = new Button();
            textBoxDNI = new TextBox();
            textBoxEmail = new TextBox();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkVolver.Location = new Point(12, 108);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(66, 24);
            linkVolver.TabIndex = 10;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(-5, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 108);
            panel1.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(402, 38);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(284, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Modificar Usuario";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(checkBoxMembresia);
            groupBox1.Controls.Add(textBoxNombre);
            groupBox1.Controls.Add(btnCrearUsuario);
            groupBox1.Controls.Add(textBoxDNI);
            groupBox1.Controls.Add(textBoxEmail);
            groupBox1.Location = new Point(382, 111);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 370);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "MODIFIQUE DATOS";
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Bottom;
            btnModificar.BackColor = Color.White;
            btnModificar.Cursor = Cursors.Hand;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.ForeColor = Color.Blue;
            btnModificar.Location = new Point(111, 311);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(130, 49);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // checkBoxMembresia
            // 
            checkBoxMembresia.Anchor = AnchorStyles.Top;
            checkBoxMembresia.AutoSize = true;
            checkBoxMembresia.Cursor = Cursors.Hand;
            checkBoxMembresia.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxMembresia.Location = new Point(68, 164);
            checkBoxMembresia.Name = "checkBoxMembresia";
            checkBoxMembresia.Size = new Size(113, 25);
            checkBoxMembresia.TabIndex = 12;
            checkBoxMembresia.Text = "Membresia";
            checkBoxMembresia.UseVisualStyleBackColor = true;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Anchor = AnchorStyles.Top;
            textBoxNombre.BorderStyle = BorderStyle.FixedSingle;
            textBoxNombre.Cursor = Cursors.IBeam;
            textBoxNombre.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxNombre.Location = new Point(68, 58);
            textBoxNombre.Margin = new Padding(3, 4, 3, 4);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre";
            textBoxNombre.Size = new Size(231, 28);
            textBoxNombre.TabIndex = 5;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.Anchor = AnchorStyles.Bottom;
            btnCrearUsuario.BackColor = Color.White;
            btnCrearUsuario.Cursor = Cursors.Hand;
            btnCrearUsuario.FlatStyle = FlatStyle.Flat;
            btnCrearUsuario.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearUsuario.ForeColor = Color.Blue;
            btnCrearUsuario.Location = new Point(143, 550);
            btnCrearUsuario.Margin = new Padding(3, 4, 3, 4);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(130, 49);
            btnCrearUsuario.TabIndex = 7;
            btnCrearUsuario.Text = "Crear";
            btnCrearUsuario.UseVisualStyleBackColor = false;
            // 
            // textBoxDNI
            // 
            textBoxDNI.Anchor = AnchorStyles.Top;
            textBoxDNI.BorderStyle = BorderStyle.FixedSingle;
            textBoxDNI.Cursor = Cursors.IBeam;
            textBoxDNI.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDNI.Location = new Point(68, 129);
            textBoxDNI.Margin = new Padding(3, 4, 3, 4);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.PlaceholderText = "DNI";
            textBoxDNI.Size = new Size(231, 28);
            textBoxDNI.TabIndex = 11;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Top;
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Cursor = Cursors.IBeam;
            textBoxEmail.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmail.Location = new Point(68, 93);
            textBoxEmail.Margin = new Padding(3, 4, 3, 4);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Email";
            textBoxEmail.Size = new Size(231, 28);
            textBoxEmail.TabIndex = 6;
            // 
            // FormModificarUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1024, 484);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(linkVolver);
            Name = "FormModificarUsuario";
            Text = "FormModificarUsuario";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkVolver;
        private Panel panel1;
        private Label lblTitle;
        private GroupBox groupBox1;
        private CheckBox checkBoxMembresia;
        private TextBox textBoxNombre;
        private Button btnCrearUsuario;
        private TextBox textBoxDNI;
        private TextBox textBoxEmail;
        private Button btnModificar;
    }
}