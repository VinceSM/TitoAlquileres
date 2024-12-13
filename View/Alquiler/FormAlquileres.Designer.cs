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
            itemIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tiempoDiasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaInicioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaFinDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipoEstrategiaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descuentoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
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
            labelTitulo.Size = new Size(134, 31);
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
            dataGridViewAlquileres.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, itemIDDataGridViewTextBoxColumn, usuarioIDDataGridViewTextBoxColumn, tiempoDiasDataGridViewTextBoxColumn, fechaInicioDataGridViewTextBoxColumn, fechaFinDataGridViewTextBoxColumn, precioTotalDataGridViewTextBoxColumn, tipoEstrategiaDataGridViewTextBoxColumn, descuentoDataGridViewCheckBoxColumn, deletedAtDataGridViewTextBoxColumn });
            dataGridViewAlquileres.DataSource = alquileresBindingSource;
            dataGridViewAlquileres.Location = new Point(58, 176);
            dataGridViewAlquileres.Margin = new Padding(4);
            dataGridViewAlquileres.Name = "dataGridViewAlquileres";
            dataGridViewAlquileres.ReadOnly = true;
            dataGridViewAlquileres.RowHeadersVisible = false;
            dataGridViewAlquileres.RowHeadersWidth = 51;
            dataGridViewAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAlquileres.Size = new Size(1232, 298);
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
            btnCerrarAlquiler.Location = new Point(572, 482);
            btnCerrarAlquiler.Margin = new Padding(4);
            btnCerrarAlquiler.Name = "btnCerrarAlquiler";
            btnCerrarAlquiler.Size = new Size(221, 32);
            btnCerrarAlquiler.TabIndex = 2;
            btnCerrarAlquiler.Text = "Cerrar alquiler";
            btnCerrarAlquiler.UseVisualStyleBackColor = true;
            btnCerrarAlquiler.Click += btnCerrarAlquiler_Click;
            // 
            // linkLabelVolver
            // 
            linkLabelVolver.AutoSize = true;
            linkLabelVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabelVolver.Location = new Point(12, 124);
            linkLabelVolver.Name = "linkLabelVolver";
            linkLabelVolver.Size = new Size(54, 19);
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
            // itemIDDataGridViewTextBoxColumn
            // 
            itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            itemIDDataGridViewTextBoxColumn.HeaderText = "ITEM";
            itemIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            itemIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // usuarioIDDataGridViewTextBoxColumn
            // 
            usuarioIDDataGridViewTextBoxColumn.DataPropertyName = "UsuarioID";
            usuarioIDDataGridViewTextBoxColumn.HeaderText = "USUARIO";
            usuarioIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            usuarioIDDataGridViewTextBoxColumn.Name = "usuarioIDDataGridViewTextBoxColumn";
            usuarioIDDataGridViewTextBoxColumn.ReadOnly = true;
            usuarioIDDataGridViewTextBoxColumn.Width = 125;
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
            // descuentoDataGridViewCheckBoxColumn
            // 
            descuentoDataGridViewCheckBoxColumn.DataPropertyName = "descuento";
            descuentoDataGridViewCheckBoxColumn.HeaderText = "DESCUENTO";
            descuentoDataGridViewCheckBoxColumn.MinimumWidth = 6;
            descuentoDataGridViewCheckBoxColumn.Name = "descuentoDataGridViewCheckBoxColumn";
            descuentoDataGridViewCheckBoxColumn.ReadOnly = true;
            descuentoDataGridViewCheckBoxColumn.Width = 125;
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
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1364, 527);
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
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tiempoDiasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaFinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipoEstrategiaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn descuentoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn deletedAtDataGridViewTextBoxColumn;
    }
}