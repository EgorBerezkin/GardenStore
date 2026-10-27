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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelReceiptInfo = new System.Windows.Forms.Label();
            this.labelDateReceipt = new System.Windows.Forms.Label();
            this.labelSotrudnik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AccessibleRole = System.Windows.Forms.AccessibleRole.Column;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(9, 137);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowHeadersWidth = 51;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(626, 177);
            this.dataGridViewItems.TabIndex = 1;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotal.Location = new System.Drawing.Point(12, 329);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(122, 21);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "Итого: 0,00 ";
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(491, 329);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(144, 40);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Salmon;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(-8, -5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(655, 56);
            this.panel5.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(150, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(332, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Информация о поступлении";
            // 
            // labelReceiptInfo
            // 
            this.labelReceiptInfo.AutoSize = true;
            this.labelReceiptInfo.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReceiptInfo.Location = new System.Drawing.Point(12, 75);
            this.labelReceiptInfo.Name = "labelReceiptInfo";
            this.labelReceiptInfo.Size = new System.Drawing.Size(189, 21);
            this.labelReceiptInfo.TabIndex = 21;
            this.labelReceiptInfo.Text = "Номер поступления ";
            // 
            // labelDateReceipt
            // 
            this.labelDateReceipt.AutoSize = true;
            this.labelDateReceipt.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateReceipt.Location = new System.Drawing.Point(454, 75);
            this.labelDateReceipt.Name = "labelDateReceipt";
            this.labelDateReceipt.Size = new System.Drawing.Size(178, 21);
            this.labelDateReceipt.TabIndex = 22;
            this.labelDateReceipt.Text = "Дата поступления";
            // 
            // labelSotrudnik
            // 
            this.labelSotrudnik.AutoSize = true;
            this.labelSotrudnik.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSotrudnik.Location = new System.Drawing.Point(12, 106);
            this.labelSotrudnik.Name = "labelSotrudnik";
            this.labelSotrudnik.Size = new System.Drawing.Size(109, 21);
            this.labelSotrudnik.TabIndex = 23;
            this.labelSotrudnik.Text = "Сотрудник";
            // 
            // ReceiptViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(644, 385);
            this.Controls.Add(this.labelSotrudnik);
            this.Controls.Add(this.labelDateReceipt);
            this.Controls.Add(this.labelReceiptInfo);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridViewItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReceiptViewForm";
            this.Text = "Магазин \"Gardenly\"";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelReceiptInfo;
        private System.Windows.Forms.Label labelDateReceipt;
        private System.Windows.Forms.Label labelSotrudnik;
    }
}