namespace Gardenly.ReceiptForm
{
    partial class ReceiptViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptViewForm));
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelDateReceipt = new System.Windows.Forms.Label();
            this.labelSotrudnik = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelZagolovok = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AccessibleRole = System.Windows.Forms.AccessibleRole.Column;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewItems.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(17, 155);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowHeadersWidth = 51;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(679, 177);
            this.dataGridViewItems.TabIndex = 1;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelTotal.ForeColor = System.Drawing.Color.SeaShell;
            this.labelTotal.Location = new System.Drawing.Point(12, 347);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(163, 27);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "Общая сумма";
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.buttonClose.ForeColor = System.Drawing.Color.Salmon;
            this.buttonClose.Location = new System.Drawing.Point(519, 347);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(177, 49);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelDateReceipt
            // 
            this.labelDateReceipt.AutoSize = true;
            this.labelDateReceipt.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Italic);
            this.labelDateReceipt.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelDateReceipt.Location = new System.Drawing.Point(208, 55);
            this.labelDateReceipt.Name = "labelDateReceipt";
            this.labelDateReceipt.Size = new System.Drawing.Size(277, 32);
            this.labelDateReceipt.TabIndex = 22;
            this.labelDateReceipt.Text = "Дата поступления";
            // 
            // labelSotrudnik
            // 
            this.labelSotrudnik.AutoSize = true;
            this.labelSotrudnik.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelSotrudnik.ForeColor = System.Drawing.Color.SeaShell;
            this.labelSotrudnik.Location = new System.Drawing.Point(12, 115);
            this.labelSotrudnik.Name = "labelSotrudnik";
            this.labelSotrudnik.Size = new System.Drawing.Size(136, 27);
            this.labelSotrudnik.TabIndex = 23;
            this.labelSotrudnik.Text = "Сотрудник";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.SeaShell;
            this.panelInfo.Controls.Add(this.labelName);
            this.panelInfo.Controls.Add(this.labelZagolovok);
            this.panelInfo.Controls.Add(this.labelDateReceipt);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(708, 100);
            this.panelInfo.TabIndex = 24;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Georgia", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.Salmon;
            this.labelName.Location = new System.Drawing.Point(106, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(564, 46);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Просмотр поступления";
            // 
            // labelZagolovok
            // 
            this.labelZagolovok.AutoSize = true;
            this.labelZagolovok.Location = new System.Drawing.Point(172, 48);
            this.labelZagolovok.Name = "labelZagolovok";
            this.labelZagolovok.Size = new System.Drawing.Size(0, 27);
            this.labelZagolovok.TabIndex = 6;
            // 
            // ReceiptViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(708, 408);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.labelSotrudnik);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridViewItems);
            this.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReceiptViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Магазин \"Gardenly\"";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelDateReceipt;
        private System.Windows.Forms.Label labelSotrudnik;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelZagolovok;
    }
}