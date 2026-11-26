namespace Gardenly.OrderForm
{
    partial class OrderViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderViewForm));
            this.labelDateOrder = new System.Windows.Forms.Label();
            this.labelSotrudnik = new System.Windows.Forms.Label();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelZagolovok = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDateOrder
            // 
            this.labelDateOrder.AutoSize = true;
            this.labelDateOrder.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Italic);
            this.labelDateOrder.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelDateOrder.Location = new System.Drawing.Point(168, 59);
            this.labelDateOrder.Name = "labelDateOrder";
            this.labelDateOrder.Size = new System.Drawing.Size(218, 32);
            this.labelDateOrder.TabIndex = 1;
            this.labelDateOrder.Text = "Дата продажи";
            // 
            // labelSotrudnik
            // 
            this.labelSotrudnik.AutoSize = true;
            this.labelSotrudnik.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelSotrudnik.ForeColor = System.Drawing.Color.SeaShell;
            this.labelSotrudnik.Location = new System.Drawing.Point(12, 116);
            this.labelSotrudnik.Name = "labelSotrudnik";
            this.labelSotrudnik.Size = new System.Drawing.Size(136, 27);
            this.labelSotrudnik.TabIndex = 2;
            this.labelSotrudnik.Text = "Сотрудник";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(12, 157);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.RowHeadersWidth = 51;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItems.Size = new System.Drawing.Size(610, 172);
            this.dataGridViewItems.TabIndex = 3;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelTotal.ForeColor = System.Drawing.Color.SeaShell;
            this.labelTotal.Location = new System.Drawing.Point(9, 348);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(163, 27);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "Общая сумма";
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonClose.ForeColor = System.Drawing.Color.Salmon;
            this.buttonClose.Location = new System.Drawing.Point(445, 348);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(177, 49);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.SeaShell;
            this.panelInfo.Controls.Add(this.labelName);
            this.panelInfo.Controls.Add(this.labelZagolovok);
            this.panelInfo.Controls.Add(this.labelDateOrder);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(634, 100);
            this.panelInfo.TabIndex = 22;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.Salmon;
            this.labelName.Location = new System.Drawing.Point(106, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(468, 46);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Просмотр продажи";
            // 
            // labelZagolovok
            // 
            this.labelZagolovok.AutoSize = true;
            this.labelZagolovok.Location = new System.Drawing.Point(172, 48);
            this.labelZagolovok.Name = "labelZagolovok";
            this.labelZagolovok.Size = new System.Drawing.Size(0, 27);
            this.labelZagolovok.TabIndex = 6;
            // 
            // OrderViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(634, 413);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.labelSotrudnik);
            this.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrderViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Магазин \"Gardenly\"";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDateOrder;
        private System.Windows.Forms.Label labelSotrudnik;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelZagolovok;
    }
}