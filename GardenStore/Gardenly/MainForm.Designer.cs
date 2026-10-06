namespace Gardenly
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.tabPageSales = new System.Windows.Forms.TabPage();
            this.tabPageReceipts = new System.Windows.Forms.TabPage();
            this.tabPageRemainingStock = new System.Windows.Forms.TabPage();
            this.tabPageStatements = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUser.Location = new System.Drawing.Point(790, 109);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(141, 20);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "Пользователь";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(29, 99);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(143, 39);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Location = new System.Drawing.Point(-17, 780);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1291, 150);
            this.panel1.TabIndex = 9;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageProducts);
            this.tabControl.Controls.Add(this.tabPageUsers);
            this.tabControl.Controls.Add(this.tabPageSales);
            this.tabControl.Controls.Add(this.tabPageReceipts);
            this.tabControl.Controls.Add(this.tabPageRemainingStock);
            this.tabControl.Controls.Add(this.tabPageStatements);
            this.tabControl.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(-1, -2);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1260, 875);
            this.tabControl.TabIndex = 10;
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Location = new System.Drawing.Point(4, 29);
            this.tabPageProducts.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageProducts.Size = new System.Drawing.Size(1252, 842);
            this.tabPageProducts.TabIndex = 0;
            this.tabPageProducts.Text = "Товары";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            this.tabPageProducts.Click += new System.EventHandler(this.tabPageProducts_Click);
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Location = new System.Drawing.Point(4, 26);
            this.tabPageUsers.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageUsers.Size = new System.Drawing.Size(1252, 845);
            this.tabPageUsers.TabIndex = 1;
            this.tabPageUsers.Text = "Пользователи";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // tabPageSales
            // 
            this.tabPageSales.Location = new System.Drawing.Point(4, 26);
            this.tabPageSales.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSales.Name = "tabPageSales";
            this.tabPageSales.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSales.Size = new System.Drawing.Size(1252, 845);
            this.tabPageSales.TabIndex = 2;
            this.tabPageSales.Text = "Продажи/Заказы";
            this.tabPageSales.UseVisualStyleBackColor = true;
            // 
            // tabPageReceipts
            // 
            this.tabPageReceipts.Location = new System.Drawing.Point(4, 26);
            this.tabPageReceipts.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageReceipts.Name = "tabPageReceipts";
            this.tabPageReceipts.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageReceipts.Size = new System.Drawing.Size(1252, 845);
            this.tabPageReceipts.TabIndex = 3;
            this.tabPageReceipts.Text = "Поступления";
            this.tabPageReceipts.UseVisualStyleBackColor = true;
            // 
            // tabPageRemainingStock
            // 
            this.tabPageRemainingStock.Location = new System.Drawing.Point(4, 26);
            this.tabPageRemainingStock.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageRemainingStock.Name = "tabPageRemainingStock";
            this.tabPageRemainingStock.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageRemainingStock.Size = new System.Drawing.Size(1252, 845);
            this.tabPageRemainingStock.TabIndex = 4;
            this.tabPageRemainingStock.Text = "Остатки товаров";
            this.tabPageRemainingStock.UseVisualStyleBackColor = true;
            // 
            // tabPageStatements
            // 
            this.tabPageStatements.Location = new System.Drawing.Point(4, 26);
            this.tabPageStatements.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageStatements.Name = "tabPageStatements";
            this.tabPageStatements.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageStatements.Size = new System.Drawing.Size(1252, 845);
            this.tabPageStatements.TabIndex = 5;
            this.tabPageStatements.Text = "Заявление на поплнение";
            this.tabPageStatements.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1248, 929);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Магазин садоводства \"Gardenly\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageSales;
        private System.Windows.Forms.TabPage tabPageReceipts;
        private System.Windows.Forms.TabPage tabPageRemainingStock;
        private System.Windows.Forms.TabPage tabPageStatements;
    }
}