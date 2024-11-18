namespace SistemaAlquileres.View.Usuario
{
    partial class FormCrearUsuario
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
            panelTitle = new Panel();
            lblTitle = new Label();
            linkVolverInicioSesion = new LinkLabel();
            lblSubTitle = new Label();
            lblCrearNombre = new Label();
            lblCrearMail = new Label();
            textBoxCrearNombre = new TextBox();
            textBoxCrearEmail = new TextBox();
            btnCrearUsuario = new Button();
            lblCreado = new Label();
            comboBoxTipoMembresia = new ComboBox();
            lblDNI = new Label();
            textBoxCrearDNI = new TextBox();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.SteelBlue;
            panelTitle.BorderStyle = BorderStyle.FixedSingle;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Location = new Point(-5, -2);
            panelTitle.Margin = new Padding(3, 4, 3, 4);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(811, 128);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(301, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Crear Usuario";
            // 
            // linkVolverInicioSesion
            // 
            linkVolverInicioSesion.AutoSize = true;
            linkVolverInicioSesion.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkVolverInicioSesion.Location = new Point(11, 144);
            linkVolverInicioSesion.Name = "linkVolverInicioSesion";
            linkVolverInicioSesion.Size = new Size(75, 24);
            linkVolverInicioSesion.TabIndex = 1;
            linkVolverInicioSesion.TabStop = true;
            linkVolverInicioSesion.Text = "Volver";
            linkVolverInicioSesion.LinkClicked += linkVolverInicioSesion_LinkClicked;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubTitle.Location = new Point(335, 181);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(135, 26);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "Ingrese datos";
            // 
            // lblCrearNombre
            // 
            lblCrearNombre.AutoSize = true;
            lblCrearNombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCrearNombre.Location = new Point(230, 239);
            lblCrearNombre.Name = "lblCrearNombre";
            lblCrearNombre.Size = new Size(0, 22);
            lblCrearNombre.TabIndex = 3;
            // 
            // lblCrearMail
            // 
            lblCrearMail.AutoSize = true;
            lblCrearMail.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCrearMail.Location = new Point(247, 274);
            lblCrearMail.Name = "lblCrearMail";
            lblCrearMail.Size = new Size(0, 22);
            lblCrearMail.TabIndex = 4;
            // 
            // textBoxCrearNombre
            // 
            textBoxCrearNombre.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearNombre.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearNombre.Location = new Point(287, 237);
            textBoxCrearNombre.Margin = new Padding(3, 4, 3, 4);
            textBoxCrearNombre.Name = "textBoxCrearNombre";
            textBoxCrearNombre.PlaceholderText = "Nombre";
            textBoxCrearNombre.Size = new Size(230, 28);
            textBoxCrearNombre.TabIndex = 5;
            // 
            // textBoxCrearEmail
            // 
            textBoxCrearEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearEmail.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearEmail.Location = new Point(287, 275);
            textBoxCrearEmail.Margin = new Padding(3, 4, 3, 4);
            textBoxCrearEmail.Name = "textBoxCrearEmail";
            textBoxCrearEmail.PlaceholderText = "Email";
            textBoxCrearEmail.Size = new Size(230, 28);
            textBoxCrearEmail.TabIndex = 6;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.BackColor = Color.White;
            btnCrearUsuario.FlatStyle = FlatStyle.Flat;
            btnCrearUsuario.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearUsuario.ForeColor = Color.Blue;
            btnCrearUsuario.Location = new Point(335, 408);
            btnCrearUsuario.Margin = new Padding(3, 4, 3, 4);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(130, 49);
            btnCrearUsuario.TabIndex = 7;
            btnCrearUsuario.Text = "Crear";
            btnCrearUsuario.UseVisualStyleBackColor = false;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // lblCreado
            // 
            lblCreado.AutoSize = true;
            lblCreado.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCreado.Location = new Point(247, 473);
            lblCreado.Name = "lblCreado";
            lblCreado.Size = new Size(101, 22);
            lblCreado.TabIndex = 8;
            lblCreado.Text = "-------------";
            // 
            // comboBoxTipoMembresia
            // 
            comboBoxTipoMembresia.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTipoMembresia.FormattingEnabled = true;
            comboBoxTipoMembresia.Items.AddRange(new object[] { "Estandar", "Premium", "Vip" });
            comboBoxTipoMembresia.Location = new Point(287, 345);
            comboBoxTipoMembresia.Name = "comboBoxTipoMembresia";
            comboBoxTipoMembresia.Size = new Size(230, 26);
            comboBoxTipoMembresia.TabIndex = 9;
            comboBoxTipoMembresia.Text = "Seleccione tipo de membresía";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDNI.Location = new Point(260, 312);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(0, 22);
            lblDNI.TabIndex = 10;
            // 
            // textBoxCrearDNI
            // 
            textBoxCrearDNI.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearDNI.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearDNI.Location = new Point(287, 310);
            textBoxCrearDNI.Margin = new Padding(3, 4, 3, 4);
            textBoxCrearDNI.Name = "textBoxCrearDNI";
            textBoxCrearDNI.PlaceholderText = "DNI";
            textBoxCrearDNI.Size = new Size(230, 28);
            textBoxCrearDNI.TabIndex = 11;
            // 
            // FormCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 562);
            Controls.Add(textBoxCrearDNI);
            Controls.Add(lblDNI);
            Controls.Add(comboBoxTipoMembresia);
            Controls.Add(lblCreado);
            Controls.Add(btnCrearUsuario);
            Controls.Add(textBoxCrearEmail);
            Controls.Add(textBoxCrearNombre);
            Controls.Add(lblCrearMail);
            Controls.Add(lblCrearNombre);
            Controls.Add(lblSubTitle);
            Controls.Add(linkVolverInicioSesion);
            Controls.Add(panelTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCrearUsuario";
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel linkVolverInicioSesion;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblCrearNombre;
        private System.Windows.Forms.Label lblCrearMail;
        private System.Windows.Forms.TextBox textBoxCrearNombre;
        private System.Windows.Forms.TextBox textBoxCrearEmail;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.Label lblCreado;
        private ComboBox comboBoxTipoMembresia;
        private Label lblDNI;
        private TextBox textBoxCrearDNI;
    }
}