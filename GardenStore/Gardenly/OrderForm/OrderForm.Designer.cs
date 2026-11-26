namespace Gardenly.OrderForm
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelCountProduct = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelZagolovok = new System.Windows.Forms.Label();
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.comboBoxProduct.ForeColor = System.Drawing.Color.Salmon;
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(269, 107);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(325, 35);
            this.comboBoxProduct.TabIndex = 0;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.numericUpDownQuantity.ForeColor = System.Drawing.Color.Salmon;
            this.numericUpDownQuantity.Location = new System.Drawing.Point(269, 149);
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
            this.numericUpDownQuantity.Size = new System.Drawing.Size(325, 34);
            this.numericUpDownQuantity.TabIndex = 1;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonAdd.ForeColor = System.Drawing.Color.YellowGreen;
            this.buttonAdd.Location = new System.Drawing.Point(68, 428);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(262, 52);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавление товара";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(12, 198);
            this.dataGridViewItems.MultiSelect = false;
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.RowHeadersWidth = 51;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItems.Size = new System.Drawing.Size(582, 169);
            this.dataGridViewItems.TabIndex = 3;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelTotal.ForeColor = System.Drawing.Color.SeaShell;
            this.labelTotal.Location = new System.Drawing.Point(12, 384);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(163, 27);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "Общая сумма";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonSave.ForeColor = System.Drawing.Color.Salmon;
            this.buttonSave.Location = new System.Drawing.Point(68, 486);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(262, 52);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Оформить продажу";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonCancel.ForeColor = System.Drawing.Color.Salmon;
            this.buttonCancel.Location = new System.Drawing.Point(332, 486);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(262, 52);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отменить операцию";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelProductName.ForeColor = System.Drawing.Color.SeaShell;
            this.labelProductName.Location = new System.Drawing.Point(12, 107);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(209, 27);
            this.labelProductName.TabIndex = 21;
            this.labelProductName.Text = "Выберите товар:";
            // 
            // labelCountProduct
            // 
            this.labelCountProduct.AutoSize = true;
            this.labelCountProduct.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelCountProduct.ForeColor = System.Drawing.Color.SeaShell;
            this.labelCountProduct.Location = new System.Drawing.Point(12, 149);
            this.labelCountProduct.Name = "labelCountProduct";
            this.labelCountProduct.Size = new System.Drawing.Size(242, 27);
            this.labelCountProduct.TabIndex = 22;
            this.labelCountProduct.Text = "Количество товара:";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.SeaShell;
            this.panelInfo.Controls.Add(this.labelName);
            this.panelInfo.Controls.Add(this.labelZagolovok);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(606, 86);
            this.panelInfo.TabIndex = 24;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.Salmon;
            this.labelName.Location = new System.Drawing.Point(91, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(512, 46);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Оформление продажи";
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
            this.buttonDeleteItem.Location = new System.Drawing.Point(332, 428);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(262, 52);
            this.buttonDeleteItem.TabIndex = 25;
            this.buttonDeleteItem.Text = "Удаление товара";
            this.buttonDeleteItem.UseVisualStyleBackColor = true;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(606, 546);
            this.Controls.Add(this.buttonDeleteItem);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.labelCountProduct);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.comboBoxProduct);
            this.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Магазин \"Gardenly\"";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelCountProduct;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelZagolovok;
        private System.Windows.Forms.Button buttonDeleteItem;
    }
}