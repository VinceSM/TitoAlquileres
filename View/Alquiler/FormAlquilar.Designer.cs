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
            panel1 = new Panel();
            lblNombreUsuario = new Label();
            ccbItems = new ComboBox();
            dataGridViewItems = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Modelo = new DataGridViewTextBoxColumn();
            Reserva = new DataGridViewTextBoxColumn();
            lblPrecioPorDias = new Label();
            lblPrecioPorDia = new Label();
            panelFecha = new Panel();
            dateTimePickerFechaFin = new DateTimePicker();
            dateTimePickerFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            lblFechaInicio = new Label();
            lblFecha = new Label();
            btnCrear = new Button();
            linkVolver = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            panelFecha.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblNombreUsuario);
            panel1.Location = new Point(-4, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(811, 103);
            panel1.TabIndex = 0;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Times New Roman", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreUsuario.Location = new Point(301, 34);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(212, 37);
            lblNombreUsuario.TabIndex = 0;
            lblNombreUsuario.Text = "-------- ---------";
            // 
            // ccbItems
            // 
            ccbItems.DropDownStyle = ComboBoxStyle.DropDownList;
            ccbItems.FlatStyle = FlatStyle.Flat;
            ccbItems.FormattingEnabled = true;
            ccbItems.Location = new Point(266, 126);
            ccbItems.Name = "ccbItems";
            ccbItems.Size = new Size(270, 30);
            ccbItems.TabIndex = 1;
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewItems.BackgroundColor = Color.LightBlue;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { Id, Marca, Modelo, Reserva });
            dataGridViewItems.Location = new Point(210, 172);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.RowHeadersVisible = false;
            dataGridViewItems.RowHeadersWidth = 51;
            dataGridViewItems.RowTemplate.Height = 24;
            dataGridViewItems.Size = new Size(379, 150);
            dataGridViewItems.TabIndex = 2;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 125;
            // 
            // Marca
            // 
            Marca.HeaderText = "Marca";
            Marca.MinimumWidth = 6;
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            Marca.Width = 125;
            // 
            // Modelo
            // 
            Modelo.HeaderText = "Modelo";
            Modelo.MinimumWidth = 6;
            Modelo.Name = "Modelo";
            Modelo.ReadOnly = true;
            Modelo.Width = 125;
            // 
            // Reserva
            // 
            Reserva.HeaderText = "Reserva";
            Reserva.MinimumWidth = 6;
            Reserva.Name = "Reserva";
            Reserva.ReadOnly = true;
            Reserva.Width = 125;
            // 
            // lblPrecioPorDias
            // 
            lblPrecioPorDias.AutoSize = true;
            lblPrecioPorDias.Location = new Point(12, 383);
            lblPrecioPorDias.Name = "lblPrecioPorDias";
            lblPrecioPorDias.Size = new Size(138, 22);
            lblPrecioPorDias.TabIndex = 3;
            lblPrecioPorDias.Text = "Precio por dias:";
            // 
            // lblPrecioPorDia
            // 
            lblPrecioPorDia.AutoSize = true;
            lblPrecioPorDia.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrecioPorDia.Location = new Point(156, 386);
            lblPrecioPorDia.Name = "lblPrecioPorDia";
            lblPrecioPorDia.Size = new Size(63, 19);
            lblPrecioPorDia.TabIndex = 4;
            lblPrecioPorDia.Text = "---------";
            // 
            // panelFecha
            // 
            panelFecha.BorderStyle = BorderStyle.FixedSingle;
            panelFecha.Controls.Add(dateTimePickerFechaFin);
            panelFecha.Controls.Add(dateTimePickerFechaInicio);
            panelFecha.Controls.Add(lblFechaFin);
            panelFecha.Controls.Add(lblFechaInicio);
            panelFecha.Controls.Add(lblFecha);
            panelFecha.Location = new Point(237, 336);
            panelFecha.Name = "panelFecha";
            panelFecha.Size = new Size(418, 114);
            panelFecha.TabIndex = 5;
            // 
            // dateTimePickerFechaFin
            // 
            dateTimePickerFechaFin.Location = new Point(66, 66);
            dateTimePickerFechaFin.Name = "dateTimePickerFechaFin";
            dateTimePickerFechaFin.Size = new Size(344, 30);
            dateTimePickerFechaFin.TabIndex = 4;
            // 
            // dateTimePickerFechaInicio
            // 
            dateTimePickerFechaInicio.Location = new Point(66, 30);
            dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            dateTimePickerFechaInicio.Size = new Size(344, 30);
            dateTimePickerFechaInicio.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(23, 67);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(42, 22);
            lblFechaFin.TabIndex = 2;
            lblFechaFin.Text = "Fin:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(3, 36);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(62, 22);
            lblFechaInicio.TabIndex = 1;
            lblFechaInicio.Text = "Inicio:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(139, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(65, 22);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fechas";
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(692, 367);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(96, 55);
            btnCrear.TabIndex = 6;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkVolver.Location = new Point(12, 115);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(66, 24);
            linkVolver.TabIndex = 7;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // FormAlquilar
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(linkVolver);
            Controls.Add(btnCrear);
            Controls.Add(panelFecha);
            Controls.Add(lblPrecioPorDia);
            Controls.Add(lblPrecioPorDias);
            Controls.Add(dataGridViewItems);
            Controls.Add(ccbItems);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormAlquilar";
            Text = "FormAlquilar";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            panelFecha.ResumeLayout(false);
            panelFecha.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private LinkLabel linkVolver;
    }
}