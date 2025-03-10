namespace TitoAlquiler.View.ViewItem
{
    partial class CrearItem
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
            lblTitle = new Label();
            lblCategoria = new Label();
            categoriaBindingSource = new BindingSource(components);
            txtNombreItem = new TextBox();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            txtTarifa = new TextBox();
            btnCreaItem = new Button();
            linkVolver = new LinkLabel();
            comboBoxCategoria = new ComboBox();
            lblTransporte = new Label();
            lblInmuebles = new Label();
            lblIndumentaria = new Label();
            lblElectronicas = new Label();
            lblElectrodomesticos = new Label();
            txtWatss = new TextBox();
            txtTipoElec = new TextBox();
            txtResolucion = new TextBox();
            txtAlmacenamiento = new TextBox();
            txtTalla = new TextBox();
            txtMaterial = new TextBox();
            txtMetros = new TextBox();
            txtUbicacion = new TextBox();
            txtCapacidad = new TextBox();
            txtCombustible = new TextBox();
            groupBox1 = new GroupBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(-5, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 108);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(387, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(239, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CREAR ITEM";
            // 
            // lblCategoria
            // 
            lblCategoria.Anchor = AnchorStyles.Top;
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(107, 21);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(179, 22);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Seleccione Categoria";
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Model.Entities.Categoria);
            // 
            // txtNombreItem
            // 
            txtNombreItem.Anchor = AnchorStyles.Top;
            txtNombreItem.Cursor = Cursors.IBeam;
            txtNombreItem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreItem.Location = new Point(83, 96);
            txtNombreItem.Name = "txtNombreItem";
            txtNombreItem.PlaceholderText = "nombre";
            txtNombreItem.Size = new Size(220, 30);
            txtNombreItem.TabIndex = 3;
            txtNombreItem.Tag = "";
            // 
            // txtMarca
            // 
            txtMarca.Anchor = AnchorStyles.Top;
            txtMarca.Cursor = Cursors.IBeam;
            txtMarca.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarca.Location = new Point(83, 132);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "marca";
            txtMarca.Size = new Size(220, 30);
            txtMarca.TabIndex = 4;
            // 
            // txtModelo
            // 
            txtModelo.Anchor = AnchorStyles.Top;
            txtModelo.Cursor = Cursors.IBeam;
            txtModelo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtModelo.Location = new Point(83, 168);
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "modelo";
            txtModelo.Size = new Size(220, 30);
            txtModelo.TabIndex = 5;
            // 
            // txtTarifa
            // 
            txtTarifa.Anchor = AnchorStyles.Top;
            txtTarifa.Cursor = Cursors.IBeam;
            txtTarifa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTarifa.Location = new Point(83, 204);
            txtTarifa.Name = "txtTarifa";
            txtTarifa.PlaceholderText = "tarifa";
            txtTarifa.Size = new Size(220, 30);
            txtTarifa.TabIndex = 6;
            // 
            // btnCreaItem
            // 
            btnCreaItem.Anchor = AnchorStyles.Bottom;
            btnCreaItem.BackColor = Color.White;
            btnCreaItem.Cursor = Cursors.Hand;
            btnCreaItem.FlatStyle = FlatStyle.Flat;
            btnCreaItem.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreaItem.ForeColor = Color.Blue;
            btnCreaItem.Location = new Point(277, 316);
            btnCreaItem.Name = "btnCreaItem";
            btnCreaItem.Size = new Size(130, 49);
            btnCreaItem.TabIndex = 7;
            btnCreaItem.Text = "Crear";
            btnCreaItem.UseVisualStyleBackColor = false;
            btnCreaItem.Click += btnCreaItem_Click;
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkVolver.Location = new Point(12, 120);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(66, 24);
            linkVolver.TabIndex = 8;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Anchor = AnchorStyles.Top;
            comboBoxCategoria.BackColor = Color.LightBlue;
            comboBoxCategoria.Cursor = Cursors.Hand;
            comboBoxCategoria.DataSource = categoriaBindingSource;
            comboBoxCategoria.FlatStyle = FlatStyle.Flat;
            comboBoxCategoria.Font = new Font("Segoe UI", 10F);
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(83, 46);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(220, 31);
            comboBoxCategoria.TabIndex = 12;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged_1;
            // 
            // lblTransporte
            // 
            lblTransporte.Anchor = AnchorStyles.Top;
            lblTransporte.AutoSize = true;
            lblTransporte.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTransporte.Location = new Point(435, 46);
            lblTransporte.Name = "lblTransporte";
            lblTransporte.Size = new Size(95, 22);
            lblTransporte.TabIndex = 13;
            lblTransporte.Text = "Transporte";
            lblTransporte.Visible = false;
            // 
            // lblInmuebles
            // 
            lblInmuebles.Anchor = AnchorStyles.Top;
            lblInmuebles.AutoSize = true;
            lblInmuebles.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInmuebles.Location = new Point(440, 46);
            lblInmuebles.Name = "lblInmuebles";
            lblInmuebles.Size = new Size(90, 22);
            lblInmuebles.TabIndex = 14;
            lblInmuebles.Text = "Inmuebles";
            lblInmuebles.Visible = false;
            // 
            // lblIndumentaria
            // 
            lblIndumentaria.Anchor = AnchorStyles.Top;
            lblIndumentaria.AutoSize = true;
            lblIndumentaria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIndumentaria.Location = new Point(435, 46);
            lblIndumentaria.Name = "lblIndumentaria";
            lblIndumentaria.Size = new Size(112, 22);
            lblIndumentaria.TabIndex = 15;
            lblIndumentaria.Text = "Indumentaria";
            lblIndumentaria.Visible = false;
            // 
            // lblElectronicas
            // 
            lblElectronicas.Anchor = AnchorStyles.Top;
            lblElectronicas.AutoSize = true;
            lblElectronicas.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectronicas.Location = new Point(438, 46);
            lblElectronicas.Name = "lblElectronicas";
            lblElectronicas.Size = new Size(109, 22);
            lblElectronicas.TabIndex = 16;
            lblElectronicas.Text = "Electronicas";
            lblElectronicas.Visible = false;
            // 
            // lblElectrodomesticos
            // 
            lblElectrodomesticos.Anchor = AnchorStyles.Top;
            lblElectrodomesticos.AutoSize = true;
            lblElectrodomesticos.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectrodomesticos.Location = new Point(401, 46);
            lblElectrodomesticos.Name = "lblElectrodomesticos";
            lblElectrodomesticos.Size = new Size(157, 22);
            lblElectrodomesticos.TabIndex = 17;
            lblElectrodomesticos.Text = "Electrodomesticos";
            lblElectrodomesticos.Visible = false;
            // 
            // txtWatss
            // 
            txtWatss.Anchor = AnchorStyles.Top;
            txtWatss.Cursor = Cursors.IBeam;
            txtWatss.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWatss.Location = new Point(375, 96);
            txtWatss.Name = "txtWatss";
            txtWatss.PlaceholderText = "potencia-watts";
            txtWatss.Size = new Size(220, 30);
            txtWatss.TabIndex = 18;
            txtWatss.Tag = "";
            txtWatss.Visible = false;
            // 
            // txtTipoElec
            // 
            txtTipoElec.Anchor = AnchorStyles.Top;
            txtTipoElec.Cursor = Cursors.IBeam;
            txtTipoElec.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTipoElec.Location = new Point(375, 132);
            txtTipoElec.Name = "txtTipoElec";
            txtTipoElec.PlaceholderText = "tipo";
            txtTipoElec.Size = new Size(220, 30);
            txtTipoElec.TabIndex = 19;
            txtTipoElec.Tag = "";
            txtTipoElec.Visible = false;
            // 
            // txtResolucion
            // 
            txtResolucion.Anchor = AnchorStyles.Top;
            txtResolucion.Cursor = Cursors.IBeam;
            txtResolucion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResolucion.Location = new Point(375, 96);
            txtResolucion.Name = "txtResolucion";
            txtResolucion.PlaceholderText = "resolucion";
            txtResolucion.Size = new Size(220, 30);
            txtResolucion.TabIndex = 20;
            txtResolucion.Tag = "";
            txtResolucion.Visible = false;
            // 
            // txtAlmacenamiento
            // 
            txtAlmacenamiento.Anchor = AnchorStyles.Top;
            txtAlmacenamiento.Cursor = Cursors.IBeam;
            txtAlmacenamiento.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAlmacenamiento.Location = new Point(375, 132);
            txtAlmacenamiento.Name = "txtAlmacenamiento";
            txtAlmacenamiento.PlaceholderText = "almacenamiento-GB";
            txtAlmacenamiento.Size = new Size(220, 30);
            txtAlmacenamiento.TabIndex = 21;
            txtAlmacenamiento.Tag = "";
            txtAlmacenamiento.Visible = false;
            // 
            // txtTalla
            // 
            txtTalla.Anchor = AnchorStyles.Top;
            txtTalla.Cursor = Cursors.IBeam;
            txtTalla.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTalla.Location = new Point(375, 96);
            txtTalla.Name = "txtTalla";
            txtTalla.PlaceholderText = "talle";
            txtTalla.Size = new Size(220, 30);
            txtTalla.TabIndex = 22;
            txtTalla.Tag = "";
            txtTalla.Visible = false;
            // 
            // txtMaterial
            // 
            txtMaterial.Anchor = AnchorStyles.Top;
            txtMaterial.Cursor = Cursors.IBeam;
            txtMaterial.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaterial.Location = new Point(375, 132);
            txtMaterial.Name = "txtMaterial";
            txtMaterial.PlaceholderText = "material-tela";
            txtMaterial.Size = new Size(220, 30);
            txtMaterial.TabIndex = 23;
            txtMaterial.Tag = "";
            txtMaterial.Visible = false;
            // 
            // txtMetros
            // 
            txtMetros.Anchor = AnchorStyles.Top;
            txtMetros.Cursor = Cursors.IBeam;
            txtMetros.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMetros.Location = new Point(375, 96);
            txtMetros.Name = "txtMetros";
            txtMetros.PlaceholderText = "metros-cuadrados";
            txtMetros.Size = new Size(220, 30);
            txtMetros.TabIndex = 24;
            txtMetros.Tag = "";
            txtMetros.Visible = false;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Anchor = AnchorStyles.Top;
            txtUbicacion.Cursor = Cursors.IBeam;
            txtUbicacion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUbicacion.Location = new Point(375, 132);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.PlaceholderText = "ubicacion";
            txtUbicacion.Size = new Size(220, 30);
            txtUbicacion.TabIndex = 25;
            txtUbicacion.Tag = "";
            txtUbicacion.Visible = false;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Anchor = AnchorStyles.Top;
            txtCapacidad.Cursor = Cursors.IBeam;
            txtCapacidad.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCapacidad.Location = new Point(375, 96);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.PlaceholderText = "cant-pasajeros";
            txtCapacidad.Size = new Size(220, 30);
            txtCapacidad.TabIndex = 26;
            txtCapacidad.Tag = "";
            txtCapacidad.Visible = false;
            // 
            // txtCombustible
            // 
            txtCombustible.Anchor = AnchorStyles.Top;
            txtCombustible.Cursor = Cursors.IBeam;
            txtCombustible.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCombustible.Location = new Point(375, 132);
            txtCombustible.Name = "txtCombustible";
            txtCombustible.PlaceholderText = "tipo-combustible";
            txtCombustible.Size = new Size(220, 30);
            txtCombustible.TabIndex = 27;
            txtCombustible.Tag = "";
            txtCombustible.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtCombustible);
            groupBox1.Controls.Add(txtCapacidad);
            groupBox1.Controls.Add(txtUbicacion);
            groupBox1.Controls.Add(txtMetros);
            groupBox1.Controls.Add(txtMaterial);
            groupBox1.Controls.Add(txtTalla);
            groupBox1.Controls.Add(txtAlmacenamiento);
            groupBox1.Controls.Add(txtResolucion);
            groupBox1.Controls.Add(txtTipoElec);
            groupBox1.Controls.Add(txtWatss);
            groupBox1.Controls.Add(lblElectrodomesticos);
            groupBox1.Controls.Add(lblElectronicas);
            groupBox1.Controls.Add(lblIndumentaria);
            groupBox1.Controls.Add(lblInmuebles);
            groupBox1.Controls.Add(lblTransporte);
            groupBox1.Controls.Add(comboBoxCategoria);
            groupBox1.Controls.Add(btnCreaItem);
            groupBox1.Controls.Add(txtTarifa);
            groupBox1.Controls.Add(txtModelo);
            groupBox1.Controls.Add(txtMarca);
            groupBox1.Controls.Add(txtNombreItem);
            groupBox1.Controls.Add(lblCategoria);
            groupBox1.Location = new Point(236, 131);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(618, 371);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "INGRESE DATOS";
            // 
            // CrearItem
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(923, 533);
            Controls.Add(groupBox1);
            Controls.Add(linkVolver);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CrearItem";
            Text = "creaItem";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Label lblCategoria;
        private BindingSource categoriaBindingSource;
        private TextBox txtNombreItem;
        private TextBox txtMarca;
        private TextBox txtModelo;
        private TextBox txtTarifa;
        private Button btnCreaItem;
        private LinkLabel linkVolver;
        private ComboBox comboBoxCategoria;
        private Label lblTransporte;
        private Label lblInmuebles;
        private Label lblIndumentaria;
        private Label lblElectronicas;
        private Label lblElectrodomesticos;
        private TextBox txtWatss;
        private TextBox txtTipoElec;
        private TextBox txtResolucion;
        private TextBox txtAlmacenamiento;
        private TextBox txtTalla;
        private TextBox txtMaterial;
        private TextBox txtMetros;
        private TextBox txtUbicacion;
        private TextBox txtCapacidad;
        private TextBox txtCombustible;
        private GroupBox groupBox1;
    }
}