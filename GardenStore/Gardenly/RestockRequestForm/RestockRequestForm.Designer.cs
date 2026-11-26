namespace Gardenly.RestockRequest
{
    partial class RestockRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestockRequestForm));
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelNameForm = new System.Windows.Forms.Label();
            this.labelZagolovok = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(21, 192);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.RowHeadersWidth = 51;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItems.Size = new System.Drawing.Size(563, 164);
            this.dataGridViewItems.TabIndex = 4;
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonSend.ForeColor = System.Drawing.Color.Salmon;
            this.buttonSend.Location = new System.Drawing.Point(101, 420);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(240, 52);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Отправить заявку";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonCancel.ForeColor = System.Drawing.Color.Salmon;
            this.buttonCancel.Location = new System.Drawing.Point(344, 420);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(240, 52);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonAddItem.ForeColor = System.Drawing.Color.YellowGreen;
            this.buttonAddItem.Location = new System.Drawing.Point(101, 362);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(240, 52);
            this.buttonAddItem.TabIndex = 4;
            this.buttonAddItem.Text = "Добавление товара";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.comboBoxProducts.ForeColor = System.Drawing.Color.Salmon;
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(285, 101);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(299, 35);
            this.comboBoxProducts.TabIndex = 5;
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonDeleteItem.ForeColor = System.Drawing.Color.YellowGreen;
            this.buttonDeleteItem.Location = new System.Drawing.Point(344, 362);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(240, 52);
            this.buttonDeleteItem.TabIndex = 7;
            this.buttonDeleteItem.Text = "Удаление товара";
            this.buttonDeleteItem.UseVisualStyleBackColor = true;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.SeaShell;
            this.label1.Location = new System.Drawing.Point(16, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите товар:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.Color.SeaShell;
            this.label2.Location = new System.Drawing.Point(16, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Введите количество:";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.SeaShell;
            this.panelInfo.Controls.Add(this.labelNameForm);
            this.panelInfo.Controls.Add(this.labelZagolovok);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(599, 86);
            this.panelInfo.TabIndex = 10;
            // 
            // labelNameForm
            // 
            this.labelNameForm.AutoSize = true;
            this.labelNameForm.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameForm.ForeColor = System.Drawing.Color.Salmon;
            this.labelNameForm.Location = new System.Drawing.Point(110, 18);
            this.labelNameForm.Name = "labelNameForm";
            this.labelNameForm.Size = new System.Drawing.Size(461, 46);
            this.labelNameForm.TabIndex = 7;
            this.labelNameForm.Text = "Оформление заявки";
            // 
            // labelZagolovok
            // 
            this.labelZagolovok.AutoSize = true;
            this.labelZagolovok.Location = new System.Drawing.Point(172, 48);
            this.labelZagolovok.Name = "labelZagolovok";
            this.labelZagolovok.Size = new System.Drawing.Size(0, 27);
            this.labelZagolovok.TabIndex = 6;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.numericUpDownQuantity.ForeColor = System.Drawing.Color.Salmon;
            this.numericUpDownQuantity.Location = new System.Drawing.Point(285, 143);
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
            this.numericUpDownQuantity.Size = new System.Drawing.Size(302, 34);
            this.numericUpDownQuantity.TabIndex = 30;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RestockRequestForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(599, 487);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDeleteItem);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.dataGridViewItems);
            this.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RestockRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Магазин \"Gardenly\"";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Button buttonDeleteItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelNameForm;
        private System.Windows.Forms.Label labelZagolovok;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
    }
}