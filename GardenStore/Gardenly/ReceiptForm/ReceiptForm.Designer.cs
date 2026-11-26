namespace Gardenly.ReceiptForm
{
    partial class ReceiptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptForm));
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.labelNameProduct = new System.Windows.Forms.Label();
            this.labelCountProduct = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.buttonNewProduct = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelNameForm = new System.Windows.Forms.Label();
            this.labelZagolovok = new System.Windows.Forms.Label();
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.comboBoxProduct.ForeColor = System.Drawing.Color.Salmon;
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(309, 94);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(498, 35);
            this.comboBoxProduct.TabIndex = 0;
            // 
            // labelNameProduct
            // 
            this.labelNameProduct.AutoSize = true;
            this.labelNameProduct.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelNameProduct.ForeColor = System.Drawing.Color.SeaShell;
            this.labelNameProduct.Location = new System.Drawing.Point(12, 94);
            this.labelNameProduct.Name = "labelNameProduct";
            this.labelNameProduct.Size = new System.Drawing.Size(209, 27);
            this.labelNameProduct.TabIndex = 1;
            this.labelNameProduct.Text = "Выберите товар:";
            // 
            // labelCountProduct
            // 
            this.labelCountProduct.AutoSize = true;
            this.labelCountProduct.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelCountProduct.ForeColor = System.Drawing.Color.SeaShell;
            this.labelCountProduct.Location = new System.Drawing.Point(12, 138);
            this.labelCountProduct.Name = "labelCountProduct";
            this.labelCountProduct.Size = new System.Drawing.Size(242, 27);
            this.labelCountProduct.TabIndex = 3;
            this.labelCountProduct.Text = "Количество товара:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.textBoxPrice.ForeColor = System.Drawing.Color.Salmon;
            this.textBoxPrice.Location = new System.Drawing.Point(309, 184);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(498, 34);
            this.textBoxPrice.TabIndex = 4;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelPrice.ForeColor = System.Drawing.Color.SeaShell;
            this.labelPrice.Location = new System.Drawing.Point(12, 184);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(298, 27);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "Цена, за единицу товара:";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AccessibleRole = System.Windows.Forms.AccessibleRole.Column;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(17, 237);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowHeadersWidth = 51;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(790, 147);
            this.dataGridViewItems.TabIndex = 6;
            // 
            // buttonNewProduct
            // 
            this.buttonNewProduct.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonNewProduct.ForeColor = System.Drawing.Color.YellowGreen;
            this.buttonNewProduct.Location = new System.Drawing.Point(548, 442);
            this.buttonNewProduct.Name = "buttonNewProduct";
            this.buttonNewProduct.Size = new System.Drawing.Size(262, 54);
            this.buttonNewProduct.TabIndex = 8;
            this.buttonNewProduct.Text = "Создание товара";
            this.buttonNewProduct.UseVisualStyleBackColor = true;
            this.buttonNewProduct.Click += new System.EventHandler(this.buttonNewProduct_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonSave.ForeColor = System.Drawing.Color.Salmon;
            this.buttonSave.Location = new System.Drawing.Point(12, 502);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(386, 54);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Оформить поступление";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonCancel.ForeColor = System.Drawing.Color.Salmon;
            this.buttonCancel.Location = new System.Drawing.Point(404, 502);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(406, 54);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отменить операцию";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonAddItem.ForeColor = System.Drawing.Color.YellowGreen;
            this.buttonAddItem.Location = new System.Drawing.Point(12, 440);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(262, 54);
            this.buttonAddItem.TabIndex = 11;
            this.buttonAddItem.Text = "Добавление товара";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelTotal.ForeColor = System.Drawing.Color.SeaShell;
            this.labelTotal.Location = new System.Drawing.Point(12, 401);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(163, 27);
            this.labelTotal.TabIndex = 12;
            this.labelTotal.Text = "Общая сумма";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.SeaShell;
            this.panelInfo.Controls.Add(this.labelNameForm);
            this.panelInfo.Controls.Add(this.labelZagolovok);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(819, 76);
            this.panelInfo.TabIndex = 27;
            // 
            // labelNameForm
            // 
            this.labelNameForm.AutoSize = true;
            this.labelNameForm.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameForm.ForeColor = System.Drawing.Color.Salmon;
            this.labelNameForm.Location = new System.Drawing.Point(226, 15);
            this.labelNameForm.Name = "labelNameForm";
            this.labelNameForm.Size = new System.Drawing.Size(608, 46);
            this.labelNameForm.TabIndex = 7;
            this.labelNameForm.Text = "Оформление поступления";
            // 
            // labelZagolovok
            // 
            this.labelZagolovok.AutoSize = true;
            this.labelZagolovok.Location = new System.Drawing.Point(172, 48);
            this.labelZagolovok.Name = "labelZagolovok";
            this.labelZagolovok.Size = new System.Drawing.Size(0, 27);
            this.labelZagolovok.TabIndex = 6;
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonDeleteItem.ForeColor = System.Drawing.Color.YellowGreen;
            this.buttonDeleteItem.Location = new System.Drawing.Point(280, 442);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(262, 52);
            this.buttonDeleteItem.TabIndex = 28;
            this.buttonDeleteItem.Text = "Удаление товара";
            this.buttonDeleteItem.UseVisualStyleBackColor = true;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.numericUpDownQuantity.ForeColor = System.Drawing.Color.Salmon;
            this.numericUpDownQuantity.Location = new System.Drawing.Point(309, 138);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(498, 34);
            this.numericUpDownQuantity.TabIndex = 29;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ReceiptForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(819, 573);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.buttonDeleteItem);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonNewProduct);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelCountProduct);
            this.Controls.Add(this.labelNameProduct);
            this.Controls.Add(this.comboBoxProduct);
            this.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maгазин \"Gardenly\"";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label labelNameProduct;
        private System.Windows.Forms.Label labelCountProduct;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button buttonNewProduct;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelNameForm;
        private System.Windows.Forms.Label labelZagolovok;
        private System.Windows.Forms.Button buttonDeleteItem;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
    }
}