namespace TitoAlquiler.View.ViewItem
{
    partial class ModificarItem
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
            linkVolver = new LinkLabel();
            panel1 = new Panel();
            lblTitle = new Label();
            txtNombreItem = new TextBox();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            txtTarifa = new TextBox();
            lblCategoria = new Label();
            lblElectrodomestico = new Label();
            txtWatss = new TextBox();
            txtTipo = new TextBox();
            lblElectronica = new Label();
            txtResolucion = new TextBox();
            txtAlmacenamiento = new TextBox();
            lblIndumentaria = new Label();
            txtTalla = new TextBox();
            txtMaterial = new TextBox();
            lblInmueble = new Label();
            txtMetros = new TextBox();
            txtUbicacion = new TextBox();
            lblTransporte = new Label();
            txtCantidad = new TextBox();
            txtCombustible = new TextBox();
            btnModificaItem = new Button();
            sistemaAlquilerContextBindingSource = new BindingSource(components);
            categoriaDaoBindingSource = new BindingSource(components);
            categoriaBindingSource = new BindingSource(components);
            comboBoxCategoria = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaDaoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkVolver.Location = new Point(10, 96);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(54, 19);
            linkVolver.TabIndex = 9;
            linkVolver.TabStop = true;
            linkVolver.Text = "Volver";
            linkVolver.LinkClicked += linkVolver_LinkClicked;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(-4, -2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(817, 81);
            panel1.TabIndex = 10;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(293, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(254, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MODIFICAR ITEM";
            // 
            // txtNombreItem
            // 
            txtNombreItem.Anchor = AnchorStyles.Top;
            txtNombreItem.Cursor = Cursors.IBeam;
            txtNombreItem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreItem.Location = new Point(289, 146);
            txtNombreItem.Margin = new Padding(3, 2, 3, 2);
            txtNombreItem.Name = "txtNombreItem";
            txtNombreItem.PlaceholderText = "nombre";
            txtNombreItem.Size = new Size(193, 26);
            txtNombreItem.TabIndex = 11;
            txtNombreItem.Tag = "";
            // 
            // txtMarca
            // 
            txtMarca.Anchor = AnchorStyles.Top;
            txtMarca.Cursor = Cursors.IBeam;
            txtMarca.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarca.Location = new Point(289, 173);
            txtMarca.Margin = new Padding(3, 2, 3, 2);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "marca";
            txtMarca.Size = new Size(193, 26);
            txtMarca.TabIndex = 12;
            // 
            // txtModelo
            // 
            txtModelo.Anchor = AnchorStyles.Top;
            txtModelo.Cursor = Cursors.IBeam;
            txtModelo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtModelo.Location = new Point(289, 200);
            txtModelo.Margin = new Padding(3, 2, 3, 2);
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "modelo";
            txtModelo.Size = new Size(193, 26);
            txtModelo.TabIndex = 13;
            // 
            // txtTarifa
            // 
            txtTarifa.Anchor = AnchorStyles.Top;
            txtTarifa.Cursor = Cursors.IBeam;
            txtTarifa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTarifa.Location = new Point(289, 227);
            txtTarifa.Margin = new Padding(3, 2, 3, 2);
            txtTarifa.Name = "txtTarifa";
            txtTarifa.PlaceholderText = "tarifa";
            txtTarifa.Size = new Size(193, 26);
            txtTarifa.TabIndex = 14;
            // 
            // lblCategoria
            // 
            lblCategoria.Anchor = AnchorStyles.Top;
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(305, 100);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(137, 19);
            lblCategoria.TabIndex = 16;
            lblCategoria.Text = "Seleccione Categoria";
            lblCategoria.Visible = false;
            // 
            // lblElectrodomestico
            // 
            lblElectrodomestico.Anchor = AnchorStyles.Top;
            lblElectrodomestico.AutoSize = true;
            lblElectrodomestico.Location = new Point(612, 127);
            lblElectrodomestico.Name = "lblElectrodomestico";
            lblElectrodomestico.Size = new Size(99, 15);
            lblElectrodomestico.TabIndex = 18;
            lblElectrodomestico.Text = "Electrodomestico";
            lblElectrodomestico.Visible = false;
            // 
            // txtWatss
            // 
            txtWatss.Anchor = AnchorStyles.Top;
            txtWatss.Cursor = Cursors.IBeam;
            txtWatss.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWatss.Location = new Point(567, 146);
            txtWatss.Margin = new Padding(3, 2, 3, 2);
            txtWatss.Name = "txtWatss";
            txtWatss.PlaceholderText = "potenciaWatts";
            txtWatss.Size = new Size(193, 26);
            txtWatss.TabIndex = 19;
            txtWatss.Tag = "";
            txtWatss.WordWrap = false;
            // 
            // txtTipo
            // 
            txtTipo.Anchor = AnchorStyles.Top;
            txtTipo.Cursor = Cursors.IBeam;
            txtTipo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTipo.Location = new Point(567, 173);
            txtTipo.Margin = new Padding(3, 2, 3, 2);
            txtTipo.Name = "txtTipo";
            txtTipo.PlaceholderText = "tipoElectrodomestico";
            txtTipo.Size = new Size(193, 26);
            txtTipo.TabIndex = 20;
            txtTipo.Tag = "";
            txtTipo.WordWrap = false;
            // 
            // lblElectronica
            // 
            lblElectronica.Anchor = AnchorStyles.Top;
            lblElectronica.AutoSize = true;
            lblElectronica.Location = new Point(634, 127);
            lblElectronica.Name = "lblElectronica";
            lblElectronica.Size = new Size(65, 15);
            lblElectronica.TabIndex = 21;
            lblElectronica.Text = "Electronica";
            lblElectronica.Visible = false;
            // 
            // txtResolucion
            // 
            txtResolucion.Anchor = AnchorStyles.Top;
            txtResolucion.Cursor = Cursors.IBeam;
            txtResolucion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResolucion.Location = new Point(567, 146);
            txtResolucion.Margin = new Padding(3, 2, 3, 2);
            txtResolucion.Name = "txtResolucion";
            txtResolucion.PlaceholderText = "resolucion";
            txtResolucion.Size = new Size(193, 26);
            txtResolucion.TabIndex = 22;
            txtResolucion.Tag = "";
            txtResolucion.Visible = false;
            // 
            // txtAlmacenamiento
            // 
            txtAlmacenamiento.Anchor = AnchorStyles.Top;
            txtAlmacenamiento.Cursor = Cursors.IBeam;
            txtAlmacenamiento.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAlmacenamiento.Location = new Point(567, 173);
            txtAlmacenamiento.Margin = new Padding(3, 2, 3, 2);
            txtAlmacenamiento.Name = "txtAlmacenamiento";
            txtAlmacenamiento.PlaceholderText = "almacenamientoGB";
            txtAlmacenamiento.Size = new Size(193, 26);
            txtAlmacenamiento.TabIndex = 23;
            txtAlmacenamiento.Tag = "";
            txtAlmacenamiento.Visible = false;
            // 
            // lblIndumentaria
            // 
            lblIndumentaria.Anchor = AnchorStyles.Top;
            lblIndumentaria.AutoSize = true;
            lblIndumentaria.Location = new Point(621, 127);
            lblIndumentaria.Name = "lblIndumentaria";
            lblIndumentaria.Size = new Size(78, 15);
            lblIndumentaria.TabIndex = 24;
            lblIndumentaria.Text = "Indumentaria";
            lblIndumentaria.Visible = false;
            // 
            // txtTalla
            // 
            txtTalla.Anchor = AnchorStyles.Top;
            txtTalla.Cursor = Cursors.IBeam;
            txtTalla.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTalla.Location = new Point(567, 146);
            txtTalla.Margin = new Padding(3, 2, 3, 2);
            txtTalla.Name = "txtTalla";
            txtTalla.PlaceholderText = "talla";
            txtTalla.Size = new Size(193, 26);
            txtTalla.TabIndex = 25;
            txtTalla.Tag = "";
            txtTalla.Visible = false;
            // 
            // txtMaterial
            // 
            txtMaterial.Anchor = AnchorStyles.Top;
            txtMaterial.Cursor = Cursors.IBeam;
            txtMaterial.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaterial.Location = new Point(567, 173);
            txtMaterial.Margin = new Padding(3, 2, 3, 2);
            txtMaterial.Name = "txtMaterial";
            txtMaterial.PlaceholderText = "material";
            txtMaterial.Size = new Size(193, 26);
            txtMaterial.TabIndex = 26;
            txtMaterial.Tag = "";
            txtMaterial.Visible = false;
            // 
            // lblInmueble
            // 
            lblInmueble.Anchor = AnchorStyles.Top;
            lblInmueble.AutoSize = true;
            lblInmueble.Location = new Point(634, 127);
            lblInmueble.Name = "lblInmueble";
            lblInmueble.Size = new Size(57, 15);
            lblInmueble.TabIndex = 27;
            lblInmueble.Text = "Inmueble";
            lblInmueble.Visible = false;
            // 
            // txtMetros
            // 
            txtMetros.Anchor = AnchorStyles.Top;
            txtMetros.Cursor = Cursors.IBeam;
            txtMetros.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMetros.Location = new Point(567, 146);
            txtMetros.Margin = new Padding(3, 2, 3, 2);
            txtMetros.Name = "txtMetros";
            txtMetros.PlaceholderText = "metrosCuadrados";
            txtMetros.Size = new Size(193, 26);
            txtMetros.TabIndex = 28;
            txtMetros.Tag = "";
            txtMetros.Visible = false;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Anchor = AnchorStyles.Top;
            txtUbicacion.Cursor = Cursors.IBeam;
            txtUbicacion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUbicacion.Location = new Point(567, 173);
            txtUbicacion.Margin = new Padding(3, 2, 3, 2);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.PlaceholderText = "ubicacion";
            txtUbicacion.Size = new Size(193, 26);
            txtUbicacion.TabIndex = 29;
            txtUbicacion.Tag = "";
            txtUbicacion.Visible = false;
            // 
            // lblTransporte
            // 
            lblTransporte.Anchor = AnchorStyles.Top;
            lblTransporte.AutoSize = true;
            lblTransporte.Location = new Point(634, 127);
            lblTransporte.Name = "lblTransporte";
            lblTransporte.Size = new Size(63, 15);
            lblTransporte.TabIndex = 30;
            lblTransporte.Text = "Transporte";
            lblTransporte.Visible = false;
            // 
            // txtCantidad
            // 
            txtCantidad.Anchor = AnchorStyles.Top;
            txtCantidad.Cursor = Cursors.IBeam;
            txtCantidad.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCantidad.Location = new Point(567, 173);
            txtCantidad.Margin = new Padding(3, 2, 3, 2);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.PlaceholderText = "capasidadPasajeros";
            txtCantidad.Size = new Size(193, 26);
            txtCantidad.TabIndex = 31;
            txtCantidad.Tag = "";
            txtCantidad.Visible = false;
            // 
            // txtCombustible
            // 
            txtCombustible.Anchor = AnchorStyles.Top;
            txtCombustible.Cursor = Cursors.IBeam;
            txtCombustible.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCombustible.Location = new Point(567, 146);
            txtCombustible.Margin = new Padding(3, 2, 3, 2);
            txtCombustible.Name = "txtCombustible";
            txtCombustible.PlaceholderText = "combustible";
            txtCombustible.Size = new Size(193, 26);
            txtCombustible.TabIndex = 32;
            txtCombustible.Tag = "";
            txtCombustible.Visible = false;
            // 
            // btnModificaItem
            // 
            btnModificaItem.Anchor = AnchorStyles.Top;
            btnModificaItem.BackColor = Color.White;
            btnModificaItem.Cursor = Cursors.Hand;
            btnModificaItem.FlatStyle = FlatStyle.Flat;
            btnModificaItem.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificaItem.ForeColor = Color.Blue;
            btnModificaItem.Location = new Point(335, 296);
            btnModificaItem.Margin = new Padding(3, 2, 3, 2);
            btnModificaItem.Name = "btnModificaItem";
            btnModificaItem.Size = new Size(114, 37);
            btnModificaItem.TabIndex = 33;
            btnModificaItem.Text = "Modificar";
            btnModificaItem.UseVisualStyleBackColor = false;
            btnModificaItem.Click += btnModificaItem_Click;
            // 
            // sistemaAlquilerContextBindingSource
            // 
            sistemaAlquilerContextBindingSource.DataSource = typeof(SistemaAlquilerContext);
            // 
            // categoriaDaoBindingSource
            // 
            categoriaDaoBindingSource.DataSource = typeof(Model.Dao.CategoriaDao);
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Model.Entities.Categoria);
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Anchor = AnchorStyles.Top;
            comboBoxCategoria.BackColor = Color.LightBlue;
            comboBoxCategoria.Cursor = Cursors.Hand;
            comboBoxCategoria.FlatStyle = FlatStyle.Flat;
            comboBoxCategoria.Font = new Font("Segoe UI", 10F);
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(289, 118);
            comboBoxCategoria.Margin = new Padding(3, 2, 3, 2);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(193, 25);
            comboBoxCategoria.TabIndex = 34;
            comboBoxCategoria.Visible = false;
            // 
            // ModificarItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxCategoria);
            Controls.Add(btnModificaItem);
            Controls.Add(txtCombustible);
            Controls.Add(txtCantidad);
            Controls.Add(lblTransporte);
            Controls.Add(txtUbicacion);
            Controls.Add(txtMetros);
            Controls.Add(lblInmueble);
            Controls.Add(txtMaterial);
            Controls.Add(txtTalla);
            Controls.Add(lblIndumentaria);
            Controls.Add(txtAlmacenamiento);
            Controls.Add(txtResolucion);
            Controls.Add(lblElectronica);
            Controls.Add(txtTipo);
            Controls.Add(txtWatss);
            Controls.Add(lblElectrodomestico);
            Controls.Add(lblCategoria);
            Controls.Add(txtTarifa);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(txtNombreItem);
            Controls.Add(panel1);
            Controls.Add(linkVolver);
            Name = "ModificarItem";
            Text = "Modificar";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sistemaAlquilerContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriaDaoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkVolver;
        private Panel panel1;
        private Label lblTitle;
        private TextBox txtNombreItem;
        private TextBox txtMarca;
        private TextBox txtModelo;
        private TextBox txtTarifa;
        private Label lblCategoria;
        private Label lblElectrodomestico;
        private TextBox txtWatss;
        private TextBox txtTipo;
        private Label lblElectronica;
        private TextBox txtResolucion;
        private TextBox txtAlmacenamiento;
        private Label lblIndumentaria;
        private TextBox txtTalla;
        private TextBox txtMaterial;
        private Label lblInmueble;
        private TextBox txtMetros;
        private TextBox txtUbicacion;
        private Label lblTransporte;
        private TextBox txtCantidad;
        private TextBox txtCombustible;
        private Button btnModificaItem;
        private BindingSource sistemaAlquilerContextBindingSource;
        private BindingSource categoriaDaoBindingSource;
        private BindingSource categoriaBindingSource;
        private ComboBox comboBoxCategoria;
    }
}