namespace TitoAlquiler.View.Alquiler
{
    partial class FormAlquileres
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
            labelTitulo = new Label();
            dataGridViewAlquileres = new DataGridView();
            alquileresBindingSource = new BindingSource(components);
            sistemaAlquilerContextBindingSource = new BindingSource(components);
            btnCerrarAlquiler = new Button();
            linkLabelVolver = new LinkLabel();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            marca = new DataGridViewTextBoxColumn();
            modelo = new DataGridViewTextBoxColumn();
            item = new DataGridViewTextBoxColumn();
            usuario = new DataGridViewTextBoxColumn();
            tiempoDiasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaInicioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaFinDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipoEstrategiaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            deletedAtDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlquileres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alquileresBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(labelTitulo);
            panel1.Location = new Point(-6, -3);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(2533, 114);
            panel1.TabIndex = 0;
            // 
            // labelTitulo
            // 
            labelTitulo.Anchor = AnchorStyles.Top;
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(643, 42);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(163, 38);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Alquileres";
            // 
            // dataGridViewAlquileres
            // 
            dataGridViewAlquileres.AllowUserToAddRows = false;
            dataGridViewAlquileres.AllowUserToDeleteRows = false;
            dataGridViewAlquileres.Anchor = AnchorStyles.Top;
            dataGridViewAlquileres.AutoGenerateColumns = false;
            dataGridViewAlquileres.BackgroundColor = Color.LightBlue;
            dataGridViewAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlquileres.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, marca, modelo, item, usuario, tiempoDiasDataGridViewTextBoxColumn, fechaInicioDataGridViewTextBoxColumn, fechaFinDataGridViewTextBoxColumn, precioTotalDataGridViewTextBoxColumn, tipoEstrategiaDataGridViewTextBoxColumn, deletedAtDataGridViewTextBoxColumn });
            dataGridViewAlquileres.Cursor = Cursors.Hand;
            dataGridViewAlquileres.DataSource = alquileresBindingSource;
            dataGridViewAlquileres.Location = new Point(58, 170);
            dataGridViewAlquileres.Margin = new Padding(4);
            dataGridViewAlquileres.Name = "dataGridViewAlquileres";
            dataGridViewAlquileres.ReadOnly = true;
            dataGridViewAlquileres.RowHeadersVisible = false;
            dataGridViewAlquileres.RowHeadersWidth = 51;
            dataGridViewAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAlquileres.Size = new Size(1226, 280);
            dataGridViewAlquileres.TabIndex = 1;
            // 
            // alquileresBindingSource
            // 
            alquileresBindingSource.DataSource = typeof(Model.Entities.Alquileres);
            // 
            // sistemaAlquilerContextBindingSource
            // 
            sistemaAlquilerContextBindingSource.DataSource = typeof(SistemaAlquilerContext);
            // 
            // btnCerrarAlquiler
            // 
            btnCerrarAlquiler.Anchor = AnchorStyles.Top;
            btnCerrarAlquiler.BackColor = Color.White;
            btnCerrarAlquiler.FlatStyle = FlatStyle.Flat;
            btnCerrarAlquiler.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarAlquiler.ForeColor = Color.Blue;
            btnCerrarAlquiler.Location = new Point(572, 482);
            btnCerrarAlquiler.Margin = new Padding(4);
            btnCerrarAlquiler.Name = "btnCerrarAlquiler";
            btnCerrarAlquiler.Size = new Size(221, 55);
            btnCerrarAlquiler.TabIndex = 2;
            btnCerrarAlquiler.Text = "Cerrar alquiler";
            btnCerrarAlquiler.UseVisualStyleBackColor = false;
            btnCerrarAlquiler.Click += btnCerrarAlquiler_Click;
            // 
            // linkLabelVolver
            // 
            linkLabelVolver.AutoSize = true;
            linkLabelVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelVolver.Location = new Point(12, 124);
            linkLabelVolver.Name = "linkLabelVolver";
            linkLabelVolver.Size = new Size(66, 24);
            linkLabelVolver.TabIndex = 3;
            linkLabelVolver.TabStop = true;
            linkLabelVolver.Text = "Volver";
            linkLabelVolver.LinkClicked += linkLabelVolver_LinkClicked;
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
            item.DataPropertyName = "item";
            item.HeaderText = "ITEM";
            item.MinimumWidth = 6;
            item.Name = "item";
            item.ReadOnly = true;
            item.Width = 125;
            // 
            // usuario
            // 
            usuario.DataPropertyName = "usuario";
            usuario.HeaderText = "USUARIO";
            usuario.MinimumWidth = 6;
            usuario.Name = "usuario";
            usuario.ReadOnly = true;
            usuario.Width = 125;
            // 
            // tiempoDiasDataGridViewTextBoxColumn
            // 
            tiempoDiasDataGridViewTextBoxColumn.DataPropertyName = "tiempoDias";
            tiempoDiasDataGridViewTextBoxColumn.HeaderText = "DIAS";
            tiempoDiasDataGridViewTextBoxColumn.MinimumWidth = 6;
            tiempoDiasDataGridViewTextBoxColumn.Name = "tiempoDiasDataGridViewTextBoxColumn";
            tiempoDiasDataGridViewTextBoxColumn.ReadOnly = true;
            tiempoDiasDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "fechaInicio";
            fechaInicioDataGridViewTextBoxColumn.HeaderText = "INICIO";
            fechaInicioDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            fechaInicioDataGridViewTextBoxColumn.ReadOnly = true;
            fechaInicioDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaFinDataGridViewTextBoxColumn
            // 
            fechaFinDataGridViewTextBoxColumn.DataPropertyName = "fechaFin";
            fechaFinDataGridViewTextBoxColumn.HeaderText = "FIN";
            fechaFinDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaFinDataGridViewTextBoxColumn.Name = "fechaFinDataGridViewTextBoxColumn";
            fechaFinDataGridViewTextBoxColumn.ReadOnly = true;
            fechaFinDataGridViewTextBoxColumn.Width = 125;
            // 
            // precioTotalDataGridViewTextBoxColumn
            // 
            precioTotalDataGridViewTextBoxColumn.DataPropertyName = "precioTotal";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            precioTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            precioTotalDataGridViewTextBoxColumn.HeaderText = "TOTAL";
            precioTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioTotalDataGridViewTextBoxColumn.Name = "precioTotalDataGridViewTextBoxColumn";
            precioTotalDataGridViewTextBoxColumn.ReadOnly = true;
            precioTotalDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipoEstrategiaDataGridViewTextBoxColumn
            // 
            tipoEstrategiaDataGridViewTextBoxColumn.DataPropertyName = "tipoEstrategia";
            tipoEstrategiaDataGridViewTextBoxColumn.HeaderText = "ESTRATEGIA";
            tipoEstrategiaDataGridViewTextBoxColumn.MinimumWidth = 6;
            tipoEstrategiaDataGridViewTextBoxColumn.Name = "tipoEstrategiaDataGridViewTextBoxColumn";
            tipoEstrategiaDataGridViewTextBoxColumn.ReadOnly = true;
            tipoEstrategiaDataGridViewTextBoxColumn.Width = 125;
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
            // FormAlquileres
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1364, 557);
            Controls.Add(linkLabelVolver);
            Controls.Add(btnCerrarAlquiler);
            Controls.Add(dataGridViewAlquileres);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormAlquileres";
            Text = "FormAlquileres";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlquileres).EndInit();
            ((System.ComponentModel.ISupportInitialize)alquileresBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridViewAlquileres;
        private BindingSource sistemaAlquilerContextBindingSource;
        private BindingSource alquileresBindingSource;
        private Button btnCerrarAlquiler;
        private LinkLabel linkLabelVolver;
        private Label labelTitulo;
        private DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioIDDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn descuentoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn marca;
        private DataGridViewTextBoxColumn modelo;
        private DataGridViewTextBoxColumn item;
        private DataGridViewTextBoxColumn usuario;
        private DataGridViewTextBoxColumn tiempoDiasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaFinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipoEstrategiaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deletedAtDataGridViewTextBoxColumn;
    }
}