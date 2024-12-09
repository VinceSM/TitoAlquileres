namespace TitoAlquiler.View.Alquiler
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lblNombreUsuario = new Label();
            categoriaBindingSource = new BindingSource(components);
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
            dataGridViewUsuarios = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dniDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            membresiaPremiumDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            deletedAtDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alquileresDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioBindingSource = new BindingSource(components);
            usuarioBindingSource1 = new BindingSource(components);
            sistemaAlquilerContextBindingSource = new BindingSource(components);
            btnCrearUsuario = new Button();
            cmbCategorias = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            panelFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblNombreUsuario);
            panel1.Location = new Point(-4, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1312, 103);
            panel1.TabIndex = 0;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Times New Roman", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreUsuario.Location = new Point(566, 28);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(174, 31);
            lblNombreUsuario.TabIndex = 0;
            lblNombreUsuario.Text = "-------- ---------";
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Model.Entities.Categoria);
            // 
            // lblPrecioPorDias
            // 
            lblPrecioPorDias.AutoSize = true;
            lblPrecioPorDias.Location = new Point(12, 567);
            lblPrecioPorDias.Name = "lblPrecioPorDias";
            lblPrecioPorDias.Size = new Size(104, 19);
            lblPrecioPorDias.TabIndex = 3;
            lblPrecioPorDias.Text = "Precio por dias:";
            // 
            // lblPrecioPorDia
            // 
            lblPrecioPorDia.AutoSize = true;
            lblPrecioPorDia.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrecioPorDia.Location = new Point(156, 570);
            lblPrecioPorDia.Name = "lblPrecioPorDia";
            lblPrecioPorDia.Size = new Size(52, 16);
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
            panelFecha.Location = new Point(433, 530);
            panelFecha.Name = "panelFecha";
            panelFecha.Size = new Size(418, 114);
            panelFecha.TabIndex = 5;
            // 
            // dateTimePickerFechaFin
            // 
            dateTimePickerFechaFin.Location = new Point(66, 66);
            dateTimePickerFechaFin.Name = "dateTimePickerFechaFin";
            dateTimePickerFechaFin.Size = new Size(344, 26);
            dateTimePickerFechaFin.TabIndex = 4;
            dateTimePickerFechaFin.ValueChanged += dateTimePickerFechaFin_ValueChanged;
            // 
            // dateTimePickerFechaInicio
            // 
            dateTimePickerFechaInicio.Location = new Point(66, 30);
            dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            dateTimePickerFechaInicio.Size = new Size(344, 26);
            dateTimePickerFechaInicio.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(23, 67);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(31, 19);
            lblFechaFin.TabIndex = 2;
            lblFechaFin.Text = "Fin:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(3, 36);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(45, 19);
            lblFechaInicio.TabIndex = 1;
            lblFechaInicio.Text = "Inicio:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(139, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(52, 19);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fechas";
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(1195, 562);
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
            linkVolver.Size = new Size(54, 19);
            linkVolver.TabIndex = 7;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AllowUserToDeleteRows = false;
            dataGridViewUsuarios.AutoGenerateColumns = false;
            dataGridViewUsuarios.BackgroundColor = Color.LightBlue;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, dniDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, membresiaPremiumDataGridViewCheckBoxColumn, deletedAtDataGridViewTextBoxColumn, alquileresDataGridViewTextBoxColumn });
            dataGridViewUsuarios.DataSource = usuarioBindingSource;
            dataGridViewUsuarios.Location = new Point(12, 162);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.RowHeadersVisible = false;
            dataGridViewUsuarios.RowHeadersWidth = 51;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.Size = new Size(503, 352);
            dataGridViewUsuarios.TabIndex = 8;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "NOMBRE";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // dniDataGridViewTextBoxColumn
            // 
            dniDataGridViewTextBoxColumn.DataPropertyName = "dni";
            dniDataGridViewTextBoxColumn.HeaderText = "DNI";
            dniDataGridViewTextBoxColumn.MinimumWidth = 6;
            dniDataGridViewTextBoxColumn.Name = "dniDataGridViewTextBoxColumn";
            dniDataGridViewTextBoxColumn.ReadOnly = true;
            dniDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            emailDataGridViewTextBoxColumn.HeaderText = "EMAIL";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // membresiaPremiumDataGridViewCheckBoxColumn
            // 
            membresiaPremiumDataGridViewCheckBoxColumn.DataPropertyName = "membresiaPremium";
            membresiaPremiumDataGridViewCheckBoxColumn.HeaderText = "MEMBRESIA";
            membresiaPremiumDataGridViewCheckBoxColumn.MinimumWidth = 6;
            membresiaPremiumDataGridViewCheckBoxColumn.Name = "membresiaPremiumDataGridViewCheckBoxColumn";
            membresiaPremiumDataGridViewCheckBoxColumn.ReadOnly = true;
            membresiaPremiumDataGridViewCheckBoxColumn.Width = 125;
            // 
            // deletedAtDataGridViewTextBoxColumn
            // 
            deletedAtDataGridViewTextBoxColumn.DataPropertyName = "deletedAt";
            deletedAtDataGridViewTextBoxColumn.HeaderText = "deletedAt";
            deletedAtDataGridViewTextBoxColumn.MinimumWidth = 6;
            deletedAtDataGridViewTextBoxColumn.Name = "deletedAtDataGridViewTextBoxColumn";
            deletedAtDataGridViewTextBoxColumn.ReadOnly = true;
            deletedAtDataGridViewTextBoxColumn.Visible = false;
            deletedAtDataGridViewTextBoxColumn.Width = 125;
            // 
            // alquileresDataGridViewTextBoxColumn
            // 
            alquileresDataGridViewTextBoxColumn.DataPropertyName = "Alquileres";
            alquileresDataGridViewTextBoxColumn.HeaderText = "Alquileres";
            alquileresDataGridViewTextBoxColumn.MinimumWidth = 6;
            alquileresDataGridViewTextBoxColumn.Name = "alquileresDataGridViewTextBoxColumn";
            alquileresDataGridViewTextBoxColumn.ReadOnly = true;
            alquileresDataGridViewTextBoxColumn.Visible = false;
            alquileresDataGridViewTextBoxColumn.Width = 125;
            // 
            // usuarioBindingSource
            // 
            usuarioBindingSource.DataSource = typeof(Model.Entities.Usuarios);
            // 
            // usuarioBindingSource1
            // 
            usuarioBindingSource1.DataSource = typeof(Model.Entities.Usuarios);
            // 
            // sistemaAlquilerContextBindingSource
            // 
            sistemaAlquilerContextBindingSource.DataSource = typeof(SistemaAlquilerContext);
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.Location = new Point(156, 105);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(188, 29);
            btnCrearUsuario.TabIndex = 10;
            btnCrearUsuario.Text = "Crear Usuario";
            btnCrearUsuario.UseVisualStyleBackColor = true;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // cmbCategorias
            // 
            cmbCategorias.BackColor = SystemColors.WindowFrame;
            cmbCategorias.Cursor = Cursors.Hand;
            cmbCategorias.DataSource = categoriaBindingSource;
            cmbCategorias.FlatStyle = FlatStyle.Flat;
            cmbCategorias.Font = new Font("Segoe UI", 10F);
            cmbCategorias.FormattingEnabled = true;
            cmbCategorias.Location = new Point(869, 105);
            cmbCategorias.Name = "cmbCategorias";
            cmbCategorias.Size = new Size(223, 25);
            cmbCategorias.TabIndex = 11;
            cmbCategorias.SelectedIndexChanged += cmbCategorias_SelectedIndexChanged;
            // 
            // FormAlquilar
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1303, 645);
            Controls.Add(cmbCategorias);
            Controls.Add(btnCrearUsuario);
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(linkVolver);
            Controls.Add(btnCrear);
            Controls.Add(panelFecha);
            Controls.Add(lblPrecioPorDia);
            Controls.Add(lblPrecioPorDias);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormAlquilar";
            Text = "FormAlquilar";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            panelFecha.ResumeLayout(false);
            panelFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombreUsuario;
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
        private DataGridView dataGridViewUsuarios;
        private BindingSource usuarioBindingSource1;
        private BindingSource usuarioBindingSource;
        private BindingSource categoriaBindingSource;
        private BindingSource sistemaAlquilerContextBindingSource;
        private Button btnCrearUsuario;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dniDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn membresiaPremiumDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn deletedAtDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alquileresDataGridViewTextBoxColumn;
        private ComboBox cmbCategorias;
    }
}