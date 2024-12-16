namespace TitoAlquiler.View.CrearItem
{
    partial class creaItem
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
            comboBoxCategoria = new ComboBox();
            categoriaBindingSource = new BindingSource(components);
            txtNombreItem = new TextBox();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            textBox1 = new TextBox();
            btnCreaItem = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
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
            lblTitle.Size = new Size(179, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Crear Item";
            // 
            // lblCategoria
            // 
            lblCategoria.Anchor = AnchorStyles.Top;
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(382, 137);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(179, 22);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Seleccione Categoria";
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Anchor = AnchorStyles.Top;
            comboBoxCategoria.BackColor = Color.LightBlue;
            comboBoxCategoria.DataSource = categoriaBindingSource;
            comboBoxCategoria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(357, 162);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(220, 30);
            comboBoxCategoria.TabIndex = 2;
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Model.Entities.Categoria);
            // 
            // txtNombreItem
            // 
            txtNombreItem.Anchor = AnchorStyles.Top;
            txtNombreItem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreItem.Location = new Point(357, 221);
            txtNombreItem.Name = "txtNombreItem";
            txtNombreItem.PlaceholderText = "nombre";
            txtNombreItem.Size = new Size(220, 30);
            txtNombreItem.TabIndex = 3;
            txtNombreItem.Tag = "";
            // 
            // txtMarca
            // 
            txtMarca.Anchor = AnchorStyles.Top;
            txtMarca.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarca.Location = new Point(357, 257);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "marca";
            txtMarca.Size = new Size(220, 30);
            txtMarca.TabIndex = 4;
            // 
            // txtModelo
            // 
            txtModelo.Anchor = AnchorStyles.Top;
            txtModelo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtModelo.Location = new Point(357, 293);
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "modelo";
            txtModelo.Size = new Size(220, 30);
            txtModelo.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(357, 329);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "tarifa";
            textBox1.Size = new Size(220, 30);
            textBox1.TabIndex = 6;
            // 
            // btnCreaItem
            // 
            btnCreaItem.Anchor = AnchorStyles.Top;
            btnCreaItem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreaItem.Location = new Point(414, 380);
            btnCreaItem.Name = "btnCreaItem";
            btnCreaItem.Size = new Size(94, 29);
            btnCreaItem.TabIndex = 7;
            btnCreaItem.Text = "Crear";
            btnCreaItem.UseVisualStyleBackColor = true;
            // 
            // creaItem
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(923, 533);
            Controls.Add(btnCreaItem);
            Controls.Add(textBox1);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(txtNombreItem);
            Controls.Add(comboBoxCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "creaItem";
            Text = "creaItem";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Label lblCategoria;
        private ComboBox comboBoxCategoria;
        private BindingSource categoriaBindingSource;
        private TextBox txtNombreItem;
        private TextBox txtMarca;
        private TextBox txtModelo;
        private TextBox textBox1;
        private Button btnCreaItem;
    }
}