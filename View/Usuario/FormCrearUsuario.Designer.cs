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
            panelTitle.Location = new Point(-4, -2);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(710, 96);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(263, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Crear Usuario";
            // 
            // linkVolverInicioSesion
            // 
            linkVolverInicioSesion.AutoSize = true;
            linkVolverInicioSesion.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkVolverInicioSesion.Location = new Point(10, 108);
            linkVolverInicioSesion.Name = "linkVolverInicioSesion";
            linkVolverInicioSesion.Size = new Size(61, 19);
            linkVolverInicioSesion.TabIndex = 1;
            linkVolverInicioSesion.TabStop = true;
            linkVolverInicioSesion.Text = "Volver";
            linkVolverInicioSesion.LinkClicked += linkVolverInicioSesion_LinkClicked;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubTitle.Location = new Point(293, 136);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(110, 21);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "Ingrese datos";
            // 
            // lblCrearNombre
            // 
            lblCrearNombre.AutoSize = true;
            lblCrearNombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCrearNombre.Location = new Point(201, 179);
            lblCrearNombre.Name = "lblCrearNombre";
            lblCrearNombre.Size = new Size(0, 19);
            lblCrearNombre.TabIndex = 3;
            // 
            // lblCrearMail
            // 
            lblCrearMail.AutoSize = true;
            lblCrearMail.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCrearMail.Location = new Point(216, 206);
            lblCrearMail.Name = "lblCrearMail";
            lblCrearMail.Size = new Size(0, 19);
            lblCrearMail.TabIndex = 4;
            // 
            // textBoxCrearNombre
            // 
            textBoxCrearNombre.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearNombre.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearNombre.Location = new Point(251, 178);
            textBoxCrearNombre.Name = "textBoxCrearNombre";
            textBoxCrearNombre.PlaceholderText = "Nombre";
            textBoxCrearNombre.Size = new Size(202, 24);
            textBoxCrearNombre.TabIndex = 5;
            // 
            // textBoxCrearEmail
            // 
            textBoxCrearEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearEmail.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearEmail.Location = new Point(251, 206);
            textBoxCrearEmail.Name = "textBoxCrearEmail";
            textBoxCrearEmail.PlaceholderText = "Email";
            textBoxCrearEmail.Size = new Size(202, 24);
            textBoxCrearEmail.TabIndex = 6;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.BackColor = Color.White;
            btnCrearUsuario.FlatStyle = FlatStyle.Flat;
            btnCrearUsuario.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearUsuario.ForeColor = Color.Blue;
            btnCrearUsuario.Location = new Point(293, 306);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(114, 37);
            btnCrearUsuario.TabIndex = 7;
            btnCrearUsuario.Text = "Crear";
            btnCrearUsuario.UseVisualStyleBackColor = false;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // lblCreado
            // 
            lblCreado.AutoSize = true;
            lblCreado.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCreado.Location = new Point(216, 355);
            lblCreado.Name = "lblCreado";
            lblCreado.Size = new Size(74, 19);
            lblCreado.TabIndex = 8;
            lblCreado.Text = "-------------";
            // 
            // comboBoxTipoMembresia
            // 
            comboBoxTipoMembresia.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTipoMembresia.FormattingEnabled = true;
            comboBoxTipoMembresia.Items.AddRange(new object[] { "Estandar", "Premium" });
            comboBoxTipoMembresia.Location = new Point(251, 259);
            comboBoxTipoMembresia.Margin = new Padding(3, 2, 3, 2);
            comboBoxTipoMembresia.Name = "comboBoxTipoMembresia";
            comboBoxTipoMembresia.Size = new Size(202, 22);
            comboBoxTipoMembresia.TabIndex = 9;
            comboBoxTipoMembresia.Text = "Seleccione tipo de membresía";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDNI.Location = new Point(228, 234);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(0, 19);
            lblDNI.TabIndex = 10;
            // 
            // textBoxCrearDNI
            // 
            textBoxCrearDNI.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearDNI.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearDNI.Location = new Point(251, 232);
            textBoxCrearDNI.Name = "textBoxCrearDNI";
            textBoxCrearDNI.PlaceholderText = "DNI";
            textBoxCrearDNI.Size = new Size(202, 24);
            textBoxCrearDNI.TabIndex = 11;
            // 
            // FormCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(700, 422);
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