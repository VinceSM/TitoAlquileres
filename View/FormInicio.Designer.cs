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
            btnEntrar.BackColor = Color.White;
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = Color.Blue;
            btnEntrar.Location = new Point(186, 306);
            btnEntrar.Margin = new Padding(2);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(313, 53);
            btnEntrar.TabIndex = 1;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBoxImageInicio
            // 
            pictureBoxImageInicio.Dock = DockStyle.Fill;
            pictureBoxImageInicio.Image = TitoAlquiler.Properties.Resources.Logo_Tito;
            pictureBoxImageInicio.Location = new Point(0, 0);
            pictureBoxImageInicio.Margin = new Padding(2);
            pictureBoxImageInicio.Name = "pictureBoxImageInicio";
            pictureBoxImageInicio.Size = new Size(700, 422);
            pictureBoxImageInicio.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxImageInicio.TabIndex = 0;
            pictureBoxImageInicio.TabStop = false;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(700, 422);
            Controls.Add(btnEntrar);
            Controls.Add(pictureBoxImageInicio);
            Margin = new Padding(2);
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

