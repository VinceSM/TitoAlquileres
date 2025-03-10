namespace TitoAlquiler.View.ViewUsuario
{
    partial class CrearUsuario
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
            linkVolver = new LinkLabel();
            lblCrearNombre = new Label();
            lblCrearMail = new Label();
            textBoxCrearNombre = new TextBox();
            textBoxCrearEmail = new TextBox();
            btnCrearUsuario = new Button();
            lblCreado = new Label();
            lblDNI = new Label();
            textBoxCrearDNI = new TextBox();
            checkBoxMembresia = new CheckBox();
            groupBox1 = new GroupBox();
            panelTitle.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(263, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(243, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CREAR USUARIO";
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.Cursor = Cursors.Hand;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkVolver.Location = new Point(10, 108);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(61, 19);
            linkVolver.TabIndex = 1;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.LinkClicked += linkVolverInicioSesion_LinkClicked;
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
            textBoxCrearNombre.Anchor = AnchorStyles.Top;
            textBoxCrearNombre.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearNombre.Cursor = Cursors.IBeam;
            textBoxCrearNombre.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearNombre.Location = new Point(17, 44);
            textBoxCrearNombre.Name = "textBoxCrearNombre";
            textBoxCrearNombre.PlaceholderText = "Nombre";
            textBoxCrearNombre.Size = new Size(202, 24);
            textBoxCrearNombre.TabIndex = 5;
            // 
            // textBoxCrearEmail
            // 
            textBoxCrearEmail.Anchor = AnchorStyles.Top;
            textBoxCrearEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearEmail.Cursor = Cursors.IBeam;
            textBoxCrearEmail.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearEmail.Location = new Point(17, 70);
            textBoxCrearEmail.Name = "textBoxCrearEmail";
            textBoxCrearEmail.PlaceholderText = "Email";
            textBoxCrearEmail.Size = new Size(202, 24);
            textBoxCrearEmail.TabIndex = 6;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.Anchor = AnchorStyles.Bottom;
            btnCrearUsuario.BackColor = Color.White;
            btnCrearUsuario.Cursor = Cursors.Hand;
            btnCrearUsuario.FlatStyle = FlatStyle.Flat;
            btnCrearUsuario.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearUsuario.ForeColor = Color.Blue;
            btnCrearUsuario.Location = new Point(55, 210);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(114, 37);
            btnCrearUsuario.TabIndex = 7;
            btnCrearUsuario.Text = "Crear";
            btnCrearUsuario.UseVisualStyleBackColor = false;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // lblCreado
            // 
            lblCreado.Anchor = AnchorStyles.Top;
            lblCreado.AutoSize = true;
            lblCreado.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCreado.Location = new Point(27, 154);
            lblCreado.Name = "lblCreado";
            lblCreado.Size = new Size(74, 19);
            lblCreado.TabIndex = 8;
            lblCreado.Text = "-------------";
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
            textBoxCrearDNI.Anchor = AnchorStyles.Top;
            textBoxCrearDNI.BorderStyle = BorderStyle.FixedSingle;
            textBoxCrearDNI.Cursor = Cursors.IBeam;
            textBoxCrearDNI.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCrearDNI.Location = new Point(17, 97);
            textBoxCrearDNI.Name = "textBoxCrearDNI";
            textBoxCrearDNI.PlaceholderText = "DNI";
            textBoxCrearDNI.Size = new Size(202, 24);
            textBoxCrearDNI.TabIndex = 11;
            // 
            // checkBoxMembresia
            // 
            checkBoxMembresia.Anchor = AnchorStyles.Top;
            checkBoxMembresia.AutoSize = true;
            checkBoxMembresia.Cursor = Cursors.Hand;
            checkBoxMembresia.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxMembresia.Location = new Point(17, 123);
            checkBoxMembresia.Margin = new Padding(3, 2, 3, 2);
            checkBoxMembresia.Name = "checkBoxMembresia";
            checkBoxMembresia.Size = new Size(91, 21);
            checkBoxMembresia.TabIndex = 12;
            checkBoxMembresia.Text = "Membresia";
            checkBoxMembresia.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(checkBoxMembresia);
            groupBox1.Controls.Add(lblCreado);
            groupBox1.Controls.Add(textBoxCrearNombre);
            groupBox1.Controls.Add(btnCrearUsuario);
            groupBox1.Controls.Add(textBoxCrearDNI);
            groupBox1.Controls.Add(textBoxCrearEmail);
            groupBox1.Location = new Point(260, 136);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(240, 252);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "INGRESE DATOS";
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(700, 422);
            Controls.Add(groupBox1);
            Controls.Add(lblDNI);
            Controls.Add(lblCrearMail);
            Controls.Add(lblCrearNombre);
            Controls.Add(linkVolver);
            Controls.Add(panelTitle);
            Name = "CrearUsuario";
            Text = "Crear Usuario";
            WindowState = FormWindowState.Maximized;
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel linkVolver;
        private System.Windows.Forms.Label lblCrearNombre;
        private System.Windows.Forms.Label lblCrearMail;
        private System.Windows.Forms.TextBox textBoxCrearNombre;
        private System.Windows.Forms.TextBox textBoxCrearEmail;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.Label lblCreado;
        private Label lblDNI;
        private TextBox textBoxCrearDNI;
        private CheckBox checkBoxMembresia;
        private GroupBox groupBox1;
    }
}