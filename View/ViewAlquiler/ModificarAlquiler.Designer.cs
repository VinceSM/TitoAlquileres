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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewAlquileres = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            marca = new DataGridViewTextBoxColumn();
            modelo = new DataGridViewTextBoxColumn();
            item = new DataGridViewTextBoxColumn();
            usuario = new DataGridViewTextBoxColumn();
            dias = new DataGridViewTextBoxColumn();
            inicio = new DataGridViewTextBoxColumn();
            fin = new DataGridViewTextBoxColumn();
            total = new DataGridViewTextBoxColumn();
            estrategia = new DataGridViewTextBoxColumn();
            dateTimePickerNuevaFechaInicio = new DateTimePicker();
            dateTimePickerNuevaFechaFin = new DateTimePicker();
            btnActualizarAlquiler = new Button();
            lblDetalleAlquiler = new Label();
            linkVolver = new LinkLabel();
            panel1 = new Panel();
            lblTitulo = new Label();
            panelFecha = new Panel();
            lblFechaFin = new Label();
            lblFechaInicio = new Label();
            lblFecha = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlquileres).BeginInit();
            panel1.SuspendLayout();
            panelFecha.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewAlquileres
            // 
            dataGridViewAlquileres.AllowUserToAddRows = false;
            dataGridViewAlquileres.AllowUserToDeleteRows = false;
            dataGridViewAlquileres.AllowUserToOrderColumns = true;
            dataGridViewAlquileres.Anchor = AnchorStyles.Top;
            dataGridViewAlquileres.BackgroundColor = Color.LightBlue;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewAlquileres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlquileres.Columns.AddRange(new DataGridViewColumn[] { id, marca, modelo, item, usuario, dias, inicio, fin, total, estrategia });
            dataGridViewAlquileres.Location = new Point(151, 205);
            dataGridViewAlquileres.Margin = new Padding(3, 4, 3, 4);
            dataGridViewAlquileres.Name = "dataGridViewAlquileres";
            dataGridViewAlquileres.ReadOnly = true;
            dataGridViewAlquileres.RowHeadersVisible = false;
            dataGridViewAlquileres.RowHeadersWidth = 51;
            dataGridViewAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAlquileres.Size = new Size(1290, 223);
            dataGridViewAlquileres.TabIndex = 0;
            dataGridViewAlquileres.SelectionChanged += dataGridViewAlquileres_SelectionChanged;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 125;
            // 
            // marca
            // 
            marca.HeaderText = "MARCA";
            marca.MinimumWidth = 6;
            marca.Name = "marca";
            marca.ReadOnly = true;
            marca.Width = 125;
            // 
            // modelo
            // 
            modelo.HeaderText = "MODELO";
            modelo.MinimumWidth = 6;
            modelo.Name = "modelo";
            modelo.ReadOnly = true;
            modelo.Width = 125;
            // 
            // item
            // 
            item.HeaderText = "ITEM";
            item.MinimumWidth = 6;
            item.Name = "item";
            item.ReadOnly = true;
            item.Width = 125;
            // 
            // usuario
            // 
            usuario.HeaderText = "USUARIO";
            usuario.MinimumWidth = 6;
            usuario.Name = "usuario";
            usuario.ReadOnly = true;
            usuario.Width = 125;
            // 
            // dias
            // 
            dias.HeaderText = "DIAS";
            dias.MinimumWidth = 6;
            dias.Name = "dias";
            dias.ReadOnly = true;
            dias.Width = 125;
            // 
            // inicio
            // 
            inicio.HeaderText = "INICIO";
            inicio.MinimumWidth = 6;
            inicio.Name = "inicio";
            inicio.ReadOnly = true;
            inicio.Width = 125;
            // 
            // fin
            // 
            fin.HeaderText = "FIN";
            fin.MinimumWidth = 6;
            fin.Name = "fin";
            fin.ReadOnly = true;
            fin.Width = 125;
            // 
            // total
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            total.DefaultCellStyle = dataGridViewCellStyle2;
            total.HeaderText = "TOTAL";
            total.MinimumWidth = 6;
            total.Name = "total";
            total.ReadOnly = true;
            total.Width = 125;
            // 
            // estrategia
            // 
            estrategia.HeaderText = "ESTRATEGIA";
            estrategia.MinimumWidth = 6;
            estrategia.Name = "estrategia";
            estrategia.ReadOnly = true;
            estrategia.Width = 125;
            // 
            // dateTimePickerNuevaFechaInicio
            // 
            dateTimePickerNuevaFechaInicio.Anchor = AnchorStyles.Top;
            dateTimePickerNuevaFechaInicio.CalendarFont = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerNuevaFechaInicio.Location = new Point(102, 36);
            dateTimePickerNuevaFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerNuevaFechaInicio.Name = "dateTimePickerNuevaFechaInicio";
            dateTimePickerNuevaFechaInicio.Size = new Size(278, 27);
            dateTimePickerNuevaFechaInicio.TabIndex = 1;
            // 
            // dateTimePickerNuevaFechaFin
            // 
            dateTimePickerNuevaFechaFin.Anchor = AnchorStyles.Top;
            dateTimePickerNuevaFechaFin.CalendarFont = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerNuevaFechaFin.Location = new Point(102, 71);
            dateTimePickerNuevaFechaFin.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerNuevaFechaFin.Name = "dateTimePickerNuevaFechaFin";
            dateTimePickerNuevaFechaFin.Size = new Size(278, 27);
            dateTimePickerNuevaFechaFin.TabIndex = 2;
            // 
            // btnActualizarAlquiler
            // 
            btnActualizarAlquiler.Anchor = AnchorStyles.Top;
            btnActualizarAlquiler.BackColor = Color.White;
            btnActualizarAlquiler.FlatStyle = FlatStyle.Flat;
            btnActualizarAlquiler.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizarAlquiler.ForeColor = Color.Blue;
            btnActualizarAlquiler.Location = new Point(1288, 509);
            btnActualizarAlquiler.Margin = new Padding(3, 4, 3, 4);
            btnActualizarAlquiler.Name = "btnActualizarAlquiler";
            btnActualizarAlquiler.Size = new Size(153, 51);
            btnActualizarAlquiler.TabIndex = 3;
            btnActualizarAlquiler.Text = "Actualizar";
            btnActualizarAlquiler.UseVisualStyleBackColor = false;
            btnActualizarAlquiler.Click += btnActualizarAlquiler_Click;
            // 
            // lblDetalleAlquiler
            // 
            lblDetalleAlquiler.Anchor = AnchorStyles.Top;
            lblDetalleAlquiler.AutoSize = true;
            lblDetalleAlquiler.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleAlquiler.Location = new Point(151, 457);
            lblDetalleAlquiler.Name = "lblDetalleAlquiler";
            lblDetalleAlquiler.Size = new Size(115, 22);
            lblDetalleAlquiler.TabIndex = 4;
            lblDetalleAlquiler.Text = "---------------";
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.BorderStyle = BorderStyle.FixedSingle;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkVolver.LinkColor = Color.FromArgb(0, 0, 192);
            linkVolver.Location = new Point(11, 120);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(68, 26);
            linkVolver.TabIndex = 5;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.VisitedLinkColor = Color.Black;
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblTitulo);
            panel1.Location = new Point(-5, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(2419, 101);
            panel1.TabIndex = 6;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(756, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(452, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MODIFICAR ALQUILERES";
            // 
            // panelFecha
            // 
            panelFecha.Anchor = AnchorStyles.Top;
            panelFecha.BorderStyle = BorderStyle.FixedSingle;
            panelFecha.Controls.Add(lblFechaFin);
            panelFecha.Controls.Add(lblFechaInicio);
            panelFecha.Controls.Add(lblFecha);
            panelFecha.Controls.Add(dateTimePickerNuevaFechaInicio);
            panelFecha.Controls.Add(dateTimePickerNuevaFechaFin);
            panelFecha.Location = new Point(576, 457);
            panelFecha.Name = "panelFecha";
            panelFecha.Size = new Size(418, 114);
            panelFecha.TabIndex = 7;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaFin.Location = new Point(23, 67);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(38, 21);
            lblFechaFin.TabIndex = 2;
            lblFechaFin.Text = "Fin:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaInicio.Location = new Point(3, 36);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(56, 21);
            lblFechaInicio.TabIndex = 1;
            lblFechaInicio.Text = "Inicio:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(169, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(63, 22);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fechas";
            // 
            // ModificarAlquiler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1470, 605);
            Controls.Add(panelFecha);
            Controls.Add(dataGridViewAlquileres);
            Controls.Add(panel1);
            Controls.Add(linkVolver);
            Controls.Add(lblDetalleAlquiler);
            Controls.Add(btnActualizarAlquiler);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ModificarAlquiler";
            Text = "ModificarAlquiler";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlquileres).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelFecha.ResumeLayout(false);
            panelFecha.PerformLayout();
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
        private Panel panel1;
        private Label lblTitulo;
        private Panel panelFecha;
        private Label lblFechaFin;
        private Label lblFechaInicio;
        private Label lblFecha;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn marca;
        private DataGridViewTextBoxColumn modelo;
        private DataGridViewTextBoxColumn item;
        private DataGridViewTextBoxColumn usuario;
        private DataGridViewTextBoxColumn dias;
        private DataGridViewTextBoxColumn inicio;
        private DataGridViewTextBoxColumn fin;
        private DataGridViewTextBoxColumn total;
        private DataGridViewTextBoxColumn estrategia;
    }
}