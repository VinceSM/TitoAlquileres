namespace TitoAlquiler.View.ViewAlquiler
{
    partial class ModificarAlquiler
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
            dataGridViewAlquileres = new DataGridView();
            dateTimePickerNuevaFechaInicio = new DateTimePicker();
            dateTimePickerNuevaFechaFin = new DateTimePicker();
            btnActualizarAlquiler = new Button();
            lblDetalleAlquiler = new Label();
            linkVolver = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlquileres).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAlquileres
            // 
            dataGridViewAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlquileres.Location = new Point(19, 63);
            dataGridViewAlquileres.Name = "dataGridViewAlquileres";
            dataGridViewAlquileres.Size = new Size(769, 167);
            dataGridViewAlquileres.TabIndex = 0;
            // 
            // dateTimePickerNuevaFechaInicio
            // 
            dateTimePickerNuevaFechaInicio.Location = new Point(547, 297);
            dateTimePickerNuevaFechaInicio.Name = "dateTimePickerNuevaFechaInicio";
            dateTimePickerNuevaFechaInicio.Size = new Size(200, 23);
            dateTimePickerNuevaFechaInicio.TabIndex = 1;
            // 
            // dateTimePickerNuevaFechaFin
            // 
            dateTimePickerNuevaFechaFin.Location = new Point(547, 349);
            dateTimePickerNuevaFechaFin.Name = "dateTimePickerNuevaFechaFin";
            dateTimePickerNuevaFechaFin.Size = new Size(200, 23);
            dateTimePickerNuevaFechaFin.TabIndex = 2;
            // 
            // btnActualizarAlquiler
            // 
            btnActualizarAlquiler.Location = new Point(380, 297);
            btnActualizarAlquiler.Name = "btnActualizarAlquiler";
            btnActualizarAlquiler.Size = new Size(75, 23);
            btnActualizarAlquiler.TabIndex = 3;
            btnActualizarAlquiler.Text = "Actualizar";
            btnActualizarAlquiler.UseVisualStyleBackColor = true;
            // 
            // lblDetalleAlquiler
            // 
            lblDetalleAlquiler.AutoSize = true;
            lblDetalleAlquiler.Location = new Point(19, 265);
            lblDetalleAlquiler.Name = "lblDetalleAlquiler";
            lblDetalleAlquiler.Size = new Size(38, 15);
            lblDetalleAlquiler.TabIndex = 4;
            lblDetalleAlquiler.Text = "label1";
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.Location = new Point(19, 18);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(39, 15);
            linkVolver.TabIndex = 5;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // ModificarAlquiler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkVolver);
            Controls.Add(lblDetalleAlquiler);
            Controls.Add(btnActualizarAlquiler);
            Controls.Add(dateTimePickerNuevaFechaFin);
            Controls.Add(dateTimePickerNuevaFechaInicio);
            Controls.Add(dataGridViewAlquileres);
            Name = "ModificarAlquiler";
            Text = "ModificarAlquiler";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlquileres).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewAlquileres;
        private DateTimePicker dateTimePickerNuevaFechaInicio;
        private DateTimePicker dateTimePickerNuevaFechaFin;
        private Button btnActualizarAlquiler;
        private Label lblDetalleAlquiler;
        private LinkLabel linkVolver;
    }
}