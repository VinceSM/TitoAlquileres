namespace TitoAlquiler
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnEntrar = new Button();
            pictureBoxImageInicio = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImageInicio).BeginInit();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Anchor = AnchorStyles.Bottom;
            btnEntrar.BackColor = Color.White;
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = Color.Blue;
            btnEntrar.Location = new Point(213, 408);
            btnEntrar.Margin = new Padding(2, 3, 2, 3);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(358, 71);
            btnEntrar.TabIndex = 1;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBoxImageInicio
            // 
            pictureBoxImageInicio.Dock = DockStyle.Fill;
            pictureBoxImageInicio.Image = Properties.Resources.Logo_Tito;
            pictureBoxImageInicio.Location = new Point(0, 0);
            pictureBoxImageInicio.Margin = new Padding(2, 3, 2, 3);
            pictureBoxImageInicio.Name = "pictureBoxImageInicio";
            pictureBoxImageInicio.Size = new Size(800, 563);
            pictureBoxImageInicio.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxImageInicio.TabIndex = 0;
            pictureBoxImageInicio.TabStop = false;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(800, 563);
            Controls.Add(btnEntrar);
            Controls.Add(pictureBoxImageInicio);
            Margin = new Padding(2, 3, 2, 3);
            Name = "FormInicio";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImageInicio).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.PictureBox pictureBoxImageInicio;
    }
}

