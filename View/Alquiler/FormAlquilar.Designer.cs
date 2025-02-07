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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblTitulo = new Label();
            categoriaBindingSource = new BindingSource(components);
            lblTotal = new Label();
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
            dataGridViewItems = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            nombreItem = new DataGridViewTextBoxColumn();
            marca = new DataGridViewTextBoxColumn();
            modelo = new DataGridViewTextBoxColumn();
            tarifaXDia = new DataGridViewTextBoxColumn();
            estado = new DataGridViewTextBoxColumn();
            btnVerAlquileres = new Button();
            btnSoftDelete = new Button();
            btnCrearItem = new Button();
            btnSoftDeleteItem = new Button();
            btnEditarTarifa = new Button();
            btnModificarItem = new Button();
            bntModificarUser = new Button();
            btnVerDetalle = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            panelFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblTitulo);
            panel1.Location = new Point(-4, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(2101, 102);
            panel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(756, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(332, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TITO ALQUILERES";
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Model.Entities.Categoria);
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top;
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(429, 566);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 22);
            lblTotal.TabIndex = 3;
            // 
            // lblPrecioPorDia
            // 
            lblPrecioPorDia.Anchor = AnchorStyles.Top;
            lblPrecioPorDia.AutoSize = true;
            lblPrecioPorDia.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrecioPorDia.Location = new Point(541, 566);
            lblPrecioPorDia.Name = "lblPrecioPorDia";
            lblPrecioPorDia.Size = new Size(0, 19);
            lblPrecioPorDia.TabIndex = 4;
            // 
            // panelFecha
            // 
            panelFecha.Anchor = AnchorStyles.Top;
            panelFecha.BorderStyle = BorderStyle.FixedSingle;
            panelFecha.Controls.Add(dateTimePickerFechaFin);
            panelFecha.Controls.Add(dateTimePickerFechaInicio);
            panelFecha.Controls.Add(lblFechaFin);
            panelFecha.Controls.Add(lblFechaInicio);
            panelFecha.Controls.Add(lblFecha);
            panelFecha.Location = new Point(692, 520);
            panelFecha.Name = "panelFecha";
            panelFecha.Size = new Size(418, 114);
            panelFecha.TabIndex = 5;
            // 
            // dateTimePickerFechaFin
            // 
            dateTimePickerFechaFin.Cursor = Cursors.Hand;
            dateTimePickerFechaFin.Location = new Point(66, 66);
            dateTimePickerFechaFin.Name = "dateTimePickerFechaFin";
            dateTimePickerFechaFin.Size = new Size(344, 30);
            dateTimePickerFechaFin.TabIndex = 4;
            // 
            // dateTimePickerFechaInicio
            // 
            dateTimePickerFechaInicio.Cursor = Cursors.Hand;
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
            btnCrear.Anchor = AnchorStyles.Top;
            btnCrear.BackColor = Color.White;
            btnCrear.Cursor = Cursors.Hand;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrear.ForeColor = Color.Blue;
            btnCrear.Location = new Point(1195, 551);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(96, 55);
            btnCrear.TabIndex = 6;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.BackColor = Color.LightBlue;
            linkVolver.BorderStyle = BorderStyle.FixedSingle;
            linkVolver.Cursor = Cursors.Hand;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkVolver.LinkColor = Color.FromArgb(0, 0, 192);
            linkVolver.Location = new Point(12, 120);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(68, 26);
            linkVolver.TabIndex = 7;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.VisitedLinkColor = Color.Black;
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AllowUserToDeleteRows = false;
            dataGridViewUsuarios.Anchor = AnchorStyles.Top;
            dataGridViewUsuarios.AutoGenerateColumns = false;
            dataGridViewUsuarios.BackgroundColor = Color.LightBlue;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, dniDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, membresiaPremiumDataGridViewCheckBoxColumn, deletedAtDataGridViewTextBoxColumn, alquileresDataGridViewTextBoxColumn });
            dataGridViewUsuarios.Cursor = Cursors.Hand;
            dataGridViewUsuarios.DataSource = usuarioBindingSource;
            dataGridViewUsuarios.Location = new Point(234, 162);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.RowHeadersVisible = false;
            dataGridViewUsuarios.RowHeadersWidth = 51;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.Size = new Size(615, 352);
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
            btnCrearUsuario.Anchor = AnchorStyles.Top;
            btnCrearUsuario.Cursor = Cursors.Hand;
            btnCrearUsuario.Font = new Font("Tahoma", 12F);
            btnCrearUsuario.Location = new Point(308, 127);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(140, 29);
            btnCrearUsuario.TabIndex = 10;
            btnCrearUsuario.Text = "Crear Usuario";
            btnCrearUsuario.UseVisualStyleBackColor = true;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // cmbCategorias
            // 
            cmbCategorias.Anchor = AnchorStyles.Top;
            cmbCategorias.BackColor = Color.LightBlue;
            cmbCategorias.Cursor = Cursors.Hand;
            cmbCategorias.DataSource = categoriaBindingSource;
            cmbCategorias.FlatStyle = FlatStyle.Flat;
            cmbCategorias.Font = new Font("Segoe UI", 10F);
            cmbCategorias.FormattingEnabled = true;
            cmbCategorias.Location = new Point(1126, 125);
            cmbCategorias.Name = "cmbCategorias";
            cmbCategorias.Size = new Size(253, 31);
            cmbCategorias.TabIndex = 11;
            cmbCategorias.SelectedIndexChanged += cmbCategorias_SelectedIndexChanged;
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.Anchor = AnchorStyles.Top;
            dataGridViewItems.BackgroundColor = Color.LightBlue;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { ID, nombreItem, marca, modelo, tarifaXDia, estado });
            dataGridViewItems.Cursor = Cursors.Hand;
            dataGridViewItems.Location = new Point(857, 162);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.RowHeadersVisible = false;
            dataGridViewItems.RowHeadersWidth = 51;
            dataGridViewItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewItems.Size = new Size(768, 352);
            dataGridViewItems.TabIndex = 8;
            // 
            // ID
            // 
            ID.HeaderText = "id";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.Width = 125;
            // 
            // nombreItem
            // 
            nombreItem.HeaderText = "NOMBRE";
            nombreItem.MinimumWidth = 6;
            nombreItem.Name = "nombreItem";
            nombreItem.ReadOnly = true;
            nombreItem.Width = 125;
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
            // tarifaXDia
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            tarifaXDia.DefaultCellStyle = dataGridViewCellStyle1;
            tarifaXDia.HeaderText = "TARIFA";
            tarifaXDia.MinimumWidth = 6;
            tarifaXDia.Name = "tarifaXDia";
            tarifaXDia.ReadOnly = true;
            tarifaXDia.Width = 125;
            // 
            // estado
            // 
            estado.HeaderText = "ESTADO";
            estado.MinimumWidth = 6;
            estado.Name = "estado";
            estado.ReadOnly = true;
            estado.Width = 125;
            // 
            // btnVerAlquileres
            // 
            btnVerAlquileres.Anchor = AnchorStyles.Top;
            btnVerAlquileres.BackColor = Color.White;
            btnVerAlquileres.FlatStyle = FlatStyle.Flat;
            btnVerAlquileres.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerAlquileres.ForeColor = Color.Blue;
            btnVerAlquileres.Location = new Point(1364, 551);
            btnVerAlquileres.Name = "btnVerAlquileres";
            btnVerAlquileres.Size = new Size(163, 55);
            btnVerAlquileres.TabIndex = 12;
            btnVerAlquileres.Text = "Ver Alquileres";
            btnVerAlquileres.UseVisualStyleBackColor = false;
            btnVerAlquileres.Click += btnVerAlquileres_Click;
            // 
            // btnSoftDelete
            // 
            btnSoftDelete.Anchor = AnchorStyles.Top;
            btnSoftDelete.Cursor = Cursors.Hand;
            btnSoftDelete.Font = new Font("Tahoma", 12F);
            btnSoftDelete.Location = new Point(454, 127);
            btnSoftDelete.Name = "btnSoftDelete";
            btnSoftDelete.Size = new Size(134, 29);
            btnSoftDelete.TabIndex = 13;
            btnSoftDelete.Text = "Borrar usuario";
            btnSoftDelete.UseVisualStyleBackColor = true;
            btnSoftDelete.Click += btnSoftDelete_Click;
            // 
            // btnCrearItem
            // 
            btnCrearItem.Anchor = AnchorStyles.Top;
            btnCrearItem.Cursor = Cursors.Hand;
            btnCrearItem.Font = new Font("Tahoma", 12F);
            btnCrearItem.Location = new Point(1652, 162);
            btnCrearItem.Name = "btnCrearItem";
            btnCrearItem.Size = new Size(144, 29);
            btnCrearItem.TabIndex = 14;
            btnCrearItem.Text = "Crear Item";
            btnCrearItem.UseVisualStyleBackColor = true;
            btnCrearItem.Click += btnCrearItem_Click;
            // 
            // btnSoftDeleteItem
            // 
            btnSoftDeleteItem.Anchor = AnchorStyles.Top;
            btnSoftDeleteItem.Font = new Font("Tahoma", 12F);
            btnSoftDeleteItem.Location = new Point(1652, 232);
            btnSoftDeleteItem.Name = "btnSoftDeleteItem";
            btnSoftDeleteItem.Size = new Size(144, 29);
            btnSoftDeleteItem.TabIndex = 15;
            btnSoftDeleteItem.Text = "Borrar Item";
            btnSoftDeleteItem.UseVisualStyleBackColor = true;
            btnSoftDeleteItem.Click += btnSoftDeleteItem_Click;
            // 
            // btnEditarTarifa
            // 
            btnEditarTarifa.Anchor = AnchorStyles.Top;
            btnEditarTarifa.Font = new Font("Tahoma", 12F);
            btnEditarTarifa.Location = new Point(1652, 267);
            btnEditarTarifa.Name = "btnEditarTarifa";
            btnEditarTarifa.Size = new Size(144, 29);
            btnEditarTarifa.TabIndex = 16;
            btnEditarTarifa.Text = "Editar Tarifa";
            btnEditarTarifa.UseVisualStyleBackColor = true;
            btnEditarTarifa.Click += btnEditarTarifa_Click;
            // 
            // btnModificarItem
            // 
            btnModificarItem.Anchor = AnchorStyles.Top;
            btnModificarItem.Font = new Font("Tahoma", 12F);
            btnModificarItem.Location = new Point(1652, 197);
            btnModificarItem.Name = "btnModificarItem";
            btnModificarItem.Size = new Size(144, 29);
            btnModificarItem.TabIndex = 17;
            btnModificarItem.Text = "Modifcar Item";
            btnModificarItem.UseVisualStyleBackColor = true;
            btnModificarItem.Click += btnModificarItem_Click;
            // 
            // bntModificarUser
            // 
            bntModificarUser.Anchor = AnchorStyles.Top;
            bntModificarUser.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bntModificarUser.Location = new Point(594, 127);
            bntModificarUser.Name = "bntModificarUser";
            bntModificarUser.Size = new Size(143, 29);
            bntModificarUser.TabIndex = 18;
            bntModificarUser.Text = "Modificar Usuario";
            bntModificarUser.UseVisualStyleBackColor = true;
            bntModificarUser.Click += bntModificarUser_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Anchor = AnchorStyles.Top;
            btnVerDetalle.Font = new Font("Tahoma", 12F);
            btnVerDetalle.Location = new Point(1652, 302);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(144, 29);
            btnVerDetalle.TabIndex = 19;
            btnVerDetalle.Text = "Detalle item";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click_1;
            // 
            // FormAlquilar
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1808, 645);
            Controls.Add(btnVerDetalle);
            Controls.Add(bntModificarUser);
            Controls.Add(btnModificarItem);
            Controls.Add(btnEditarTarifa);
            Controls.Add(cmbCategorias);
            Controls.Add(btnSoftDeleteItem);
            Controls.Add(btnCrearItem);
            Controls.Add(btnSoftDelete);
            Controls.Add(btnVerAlquileres);
            Controls.Add(dataGridViewItems);
            Controls.Add(btnCrearUsuario);
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(linkVolver);
            Controls.Add(btnCrear);
            Controls.Add(panelFecha);
            Controls.Add(lblPrecioPorDia);
            Controls.Add(lblTotal);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormAlquilar";
            Text = "Alquilar";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            panelFecha.ResumeLayout(false);
            panelFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotal;
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
        private DataGridView dataGridViewItems;
        private Button btnVerAlquileres;
        private Button btnSoftDelete;
        private Button btnCrearItem;
        private Button btnSoftDeleteItem;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn nombreItem;
        private DataGridViewTextBoxColumn marca;
        private DataGridViewTextBoxColumn modelo;
        private DataGridViewTextBoxColumn tarifaXDia;
        private DataGridViewTextBoxColumn estado;
        private Button btnEditarTarifa;
        private Button btnModificarItem;
        private Button bntModificarUser;
        private Button btnVerDetalle;
    }
}