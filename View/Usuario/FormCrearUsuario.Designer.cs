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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.linkVolverInicioSesion = new System.Windows.Forms.LinkLabel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblCrearNombre = new System.Windows.Forms.Label();
            this.lblCrearMail = new System.Windows.Forms.Label();
            this.textBoxCrearNombre = new System.Windows.Forms.TextBox();
            this.textBoxCrearEmail = new System.Windows.Forms.TextBox();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.lblCreado = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Location = new System.Drawing.Point(-5, -2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(811, 103);
            this.panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(301, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Crear Usuario";
            // 
            // linkVolverInicioSesion
            // 
            this.linkVolverInicioSesion.AutoSize = true;
            this.linkVolverInicioSesion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkVolverInicioSesion.Location = new System.Drawing.Point(11, 115);
            this.linkVolverInicioSesion.Name = "linkVolverInicioSesion";
            this.linkVolverInicioSesion.Size = new System.Drawing.Size(75, 24);
            this.linkVolverInicioSesion.TabIndex = 1;
            this.linkVolverInicioSesion.TabStop = true;
            this.linkVolverInicioSesion.Text = "Volver";
            this.linkVolverInicioSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVolverInicioSesion_LinkClicked);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.Location = new System.Drawing.Point(330, 170);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(135, 26);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Ingrese datos";
            // 
            // lblCrearNombre
            // 
            this.lblCrearNombre.AutoSize = true;
            this.lblCrearNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearNombre.Location = new System.Drawing.Point(230, 215);
            this.lblCrearNombre.Name = "lblCrearNombre";
            this.lblCrearNombre.Size = new System.Drawing.Size(80, 22);
            this.lblCrearNombre.TabIndex = 3;
            this.lblCrearNombre.Text = "Nombre:";
            // 
            // lblCrearMail
            // 
            this.lblCrearMail.AutoSize = true;
            this.lblCrearMail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearMail.Location = new System.Drawing.Point(247, 253);
            this.lblCrearMail.Name = "lblCrearMail";
            this.lblCrearMail.Size = new System.Drawing.Size(63, 22);
            this.lblCrearMail.TabIndex = 4;
            this.lblCrearMail.Text = "Email:";
            // 
            // textBoxCrearNombre
            // 
            this.textBoxCrearNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCrearNombre.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCrearNombre.Location = new System.Drawing.Point(335, 217);
            this.textBoxCrearNombre.Name = "textBoxCrearNombre";
            this.textBoxCrearNombre.Size = new System.Drawing.Size(189, 28);
            this.textBoxCrearNombre.TabIndex = 5;
            // 
            // textBoxCrearEmail
            // 
            this.textBoxCrearEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCrearEmail.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCrearEmail.Location = new System.Drawing.Point(335, 254);
            this.textBoxCrearEmail.Name = "textBoxCrearEmail";
            this.textBoxCrearEmail.Size = new System.Drawing.Size(189, 28);
            this.textBoxCrearEmail.TabIndex = 6;
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.BackColor = System.Drawing.Color.White;
            this.btnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearUsuario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearUsuario.ForeColor = System.Drawing.Color.Blue;
            this.btnCrearUsuario.Location = new System.Drawing.Point(335, 301);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(130, 39);
            this.btnCrearUsuario.TabIndex = 7;
            this.btnCrearUsuario.Text = "Crear";
            this.btnCrearUsuario.UseVisualStyleBackColor = false;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // lblCreado
            // 
            this.lblCreado.AutoSize = true;
            this.lblCreado.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreado.Location = new System.Drawing.Point(259, 352);
            this.lblCreado.Name = "lblCreado";
            this.lblCreado.Size = new System.Drawing.Size(101, 22);
            this.lblCreado.TabIndex = 8;
            this.lblCreado.Text = "-------------";
            // 
            // FormCrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCreado);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.textBoxCrearEmail);
            this.Controls.Add(this.textBoxCrearNombre);
            this.Controls.Add(this.lblCrearMail);
            this.Controls.Add(this.lblCrearNombre);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.linkVolverInicioSesion);
            this.Controls.Add(this.panelTitle);
            this.Name = "FormCrearUsuario";
            this.Text = "FormCrearUsuario";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}