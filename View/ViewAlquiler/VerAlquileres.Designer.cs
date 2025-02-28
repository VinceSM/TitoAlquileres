namespace TitoAlquiler.View.ViewAlquiler
{
    partial class VerAlquileres
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
            labelTitulo = new Label();
            dataGridViewAlquileres = new DataGridView();
            alquileresBindingSource = new BindingSource(components);
            sistemaAlquilerContextBindingSource = new BindingSource(components);
            btnCerrarAlquiler = new Button();
            linkLabelVolver = new LinkLabel();
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
            panel1.Size = new Size(2785, 114);
            panel1.TabIndex = 0;
            // 
            // labelTitulo
            // 
            labelTitulo.Anchor = AnchorStyles.Top;
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(769, 42);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(134, 31);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Alquileres";
            // 
            // dataGridViewAlquileres
            // 
            dataGridViewAlquileres.AllowUserToAddRows = false;
            dataGridViewAlquileres.AllowUserToDeleteRows = false;
            dataGridViewAlquileres.AllowUserToOrderColumns = true;
            dataGridViewAlquileres.Anchor = AnchorStyles.Top;
            dataGridViewAlquileres.BackgroundColor = Color.LightBlue;
            dataGridViewAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlquileres.Columns.AddRange(new DataGridViewColumn[] { id, marca, modelo, item, usuario, dias, inicio, fin, total, estrategia });
            dataGridViewAlquileres.Cursor = Cursors.Hand;
            dataGridViewAlquileres.Location = new Point(138, 170);
            dataGridViewAlquileres.Margin = new Padding(4);
            dataGridViewAlquileres.Name = "dataGridViewAlquileres";
            dataGridViewAlquileres.ReadOnly = true;
            dataGridViewAlquileres.RowHeadersVisible = false;
            dataGridViewAlquileres.RowHeadersWidth = 51;
            dataGridViewAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAlquileres.Size = new Size(1379, 280);
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
            btnCerrarAlquiler.Location = new Point(698, 482);
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
            linkLabelVolver.Size = new Size(54, 19);
            linkLabelVolver.TabIndex = 3;
            linkLabelVolver.TabStop = true;
            linkLabelVolver.Text = "Volver";
            linkLabelVolver.LinkClicked += linkLabelVolver_LinkClicked;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
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
            // VerAlquileres
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1364, 557);
            Controls.Add(linkLabelVolver);
            Controls.Add(btnCerrarAlquiler);
            Controls.Add(dataGridViewAlquileres);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "VerAlquileres";
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