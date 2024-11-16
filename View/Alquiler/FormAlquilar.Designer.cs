namespace SistemaAlquileres.View.Alquiler
{
    partial class FormAlquilar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.ccbItems = new System.Windows.Forms.ComboBox();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPrecioPorDias = new System.Windows.Forms.Label();
            this.lblPrecioPorDia = new System.Windows.Forms.Label();
            this.panelFecha = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panelFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblNombreUsuario);
            this.panel1.Location = new System.Drawing.Point(-4, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 103);
            this.panel1.TabIndex = 0;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(301, 34);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(212, 37);
            this.lblNombreUsuario.TabIndex = 0;
            this.lblNombreUsuario.Text = "-------- ---------";
            // 
            // ccbItems
            // 
            this.ccbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccbItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ccbItems.FormattingEnabled = true;
            this.ccbItems.Location = new System.Drawing.Point(266, 126);
            this.ccbItems.Name = "ccbItems";
            this.ccbItems.Size = new System.Drawing.Size(270, 30);
            this.ccbItems.TabIndex = 1;
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Marca,
            this.Modelo,
            this.Reserva});
            this.dataGridViewItems.Location = new System.Drawing.Point(210, 172);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.RowHeadersVisible = false;
            this.dataGridViewItems.RowHeadersWidth = 51;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(379, 150);
            this.dataGridViewItems.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 6;
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Width = 125;
            // 
            // Modelo
            // 
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.MinimumWidth = 6;
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            this.Modelo.Width = 125;
            // 
            // Reserva
            // 
            this.Reserva.HeaderText = "Reserva";
            this.Reserva.MinimumWidth = 6;
            this.Reserva.Name = "Reserva";
            this.Reserva.ReadOnly = true;
            this.Reserva.Width = 125;
            // 
            // lblPrecioPorDias
            // 
            this.lblPrecioPorDias.AutoSize = true;
            this.lblPrecioPorDias.Location = new System.Drawing.Point(12, 383);
            this.lblPrecioPorDias.Name = "lblPrecioPorDias";
            this.lblPrecioPorDias.Size = new System.Drawing.Size(138, 22);
            this.lblPrecioPorDias.TabIndex = 3;
            this.lblPrecioPorDias.Text = "Precio por dias:";
            // 
            // lblPrecioPorDia
            // 
            this.lblPrecioPorDia.AutoSize = true;
            this.lblPrecioPorDia.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioPorDia.Location = new System.Drawing.Point(156, 386);
            this.lblPrecioPorDia.Name = "lblPrecioPorDia";
            this.lblPrecioPorDia.Size = new System.Drawing.Size(63, 19);
            this.lblPrecioPorDia.TabIndex = 4;
            this.lblPrecioPorDia.Text = "---------";
            // 
            // panelFecha
            // 
            this.panelFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFecha.Controls.Add(this.dateTimePickerFechaFin);
            this.panelFecha.Controls.Add(this.dateTimePickerFechaInicio);
            this.panelFecha.Controls.Add(this.lblFechaFin);
            this.panelFecha.Controls.Add(this.lblFechaInicio);
            this.panelFecha.Controls.Add(this.lblFecha);
            this.panelFecha.Location = new System.Drawing.Point(237, 336);
            this.panelFecha.Name = "panelFecha";
            this.panelFecha.Size = new System.Drawing.Size(418, 114);
            this.panelFecha.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(139, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(65, 22);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fechas";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(3, 36);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(62, 22);
            this.lblFechaInicio.TabIndex = 1;
            this.lblFechaInicio.Text = "Inicio:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(23, 67);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(42, 22);
            this.lblFechaFin.TabIndex = 2;
            this.lblFechaFin.Text = "Fin:";
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(66, 30);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(344, 30);
            this.dateTimePickerFechaInicio.TabIndex = 3;
            // 
            // dateTimePickerFechaFin
            // 
            this.dateTimePickerFechaFin.Location = new System.Drawing.Point(66, 66);
            this.dateTimePickerFechaFin.Name = "dateTimePickerFechaFin";
            this.dateTimePickerFechaFin.Size = new System.Drawing.Size(344, 30);
            this.dateTimePickerFechaFin.TabIndex = 4;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(692, 367);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(96, 55);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // FormAlquilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.panelFecha);
            this.Controls.Add(this.lblPrecioPorDia);
            this.Controls.Add(this.lblPrecioPorDias);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.ccbItems);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAlquilar";
            this.Text = "FormAlquilar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panelFecha.ResumeLayout(false);
            this.panelFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.ComboBox ccbItems;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reserva;
        private System.Windows.Forms.Label lblPrecioPorDias;
        private System.Windows.Forms.Label lblPrecioPorDia;
        private System.Windows.Forms.Panel panelFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFin;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Button btnCrear;
    }
}