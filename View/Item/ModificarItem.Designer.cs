namespace TitoAlquiler.View.Item
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
            linkVolver = new LinkLabel();
            panel1 = new Panel();
            lblTitle = new Label();
            txtNombreItem = new TextBox();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            txtTarifa = new TextBox();
            txtDescripcion = new TextBox();
            comboBoxCategoria = new ComboBox();
            lblCategoria = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // linkVolver
            // 
            linkVolver.AutoSize = true;
            linkVolver.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkVolver.Location = new Point(12, 128);
            linkVolver.Name = "linkVolver";
            linkVolver.Size = new Size(66, 24);
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
            panel1.Location = new Point(-5, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 108);
            panel1.TabIndex = 10;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(335, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(237, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Modificar Item";
            // 
            // txtNombreItem
            // 
            txtNombreItem.Anchor = AnchorStyles.Top;
            txtNombreItem.Cursor = Cursors.IBeam;
            txtNombreItem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreItem.Location = new Point(330, 195);
            txtNombreItem.Name = "txtNombreItem";
            txtNombreItem.PlaceholderText = "nombre";
            txtNombreItem.Size = new Size(220, 30);
            txtNombreItem.TabIndex = 11;
            txtNombreItem.Tag = "";
            // 
            // txtMarca
            // 
            txtMarca.Anchor = AnchorStyles.Top;
            txtMarca.Cursor = Cursors.IBeam;
            txtMarca.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarca.Location = new Point(330, 231);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "marca";
            txtMarca.Size = new Size(220, 30);
            txtMarca.TabIndex = 12;
            // 
            // txtModelo
            // 
            txtModelo.Anchor = AnchorStyles.Top;
            txtModelo.Cursor = Cursors.IBeam;
            txtModelo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtModelo.Location = new Point(330, 267);
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "modelo";
            txtModelo.Size = new Size(220, 30);
            txtModelo.TabIndex = 13;
            // 
            // txtTarifa
            // 
            txtTarifa.Anchor = AnchorStyles.Top;
            txtTarifa.Cursor = Cursors.IBeam;
            txtTarifa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTarifa.Location = new Point(330, 303);
            txtTarifa.Name = "txtTarifa";
            txtTarifa.PlaceholderText = "tarifa";
            txtTarifa.Size = new Size(220, 30);
            txtTarifa.TabIndex = 14;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top;
            txtDescripcion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcion.Location = new Point(256, 339);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "descripcion";
            txtDescripcion.Size = new Size(388, 30);
            txtDescripcion.TabIndex = 15;
            txtDescripcion.Visible = false;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Anchor = AnchorStyles.Top;
            comboBoxCategoria.BackColor = Color.LightBlue;
            comboBoxCategoria.Cursor = Cursors.Hand;
            comboBoxCategoria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(330, 159);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(220, 30);
            comboBoxCategoria.TabIndex = 17;
            // 
            // lblCategoria
            // 
            lblCategoria.Anchor = AnchorStyles.Top;
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(349, 134);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(179, 22);
            lblCategoria.TabIndex = 16;
            lblCategoria.Text = "Seleccione Categoria";
            // 
            // Modificar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(914, 600);
            Controls.Add(comboBoxCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtDescripcion);
            Controls.Add(txtTarifa);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(txtNombreItem);
            Controls.Add(panel1);
            Controls.Add(linkVolver);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Modificar";
            Text = "Modificar";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox txtDescripcion;
        private ComboBox comboBoxCategoria;
        private Label lblCategoria;
    }
}