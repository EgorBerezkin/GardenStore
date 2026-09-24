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
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.buttonCategory = new System.Windows.Forms.Button();
            this.buttonReceipts = new System.Windows.Forms.Button();
            this.buttonSales = new System.Windows.Forms.Button();
            this.buttonRemainingStock = new System.Windows.Forms.Button();
            this.buttonStatements = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(102, 16);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "Пользователь";
            // 
            // buttonProduct
            // 
            this.buttonProduct.Location = new System.Drawing.Point(12, 40);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(110, 23);
            this.buttonProduct.TabIndex = 1;
            this.buttonProduct.Text = "Товары";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // buttonCategory
            // 
            this.buttonCategory.Location = new System.Drawing.Point(15, 78);
            this.buttonCategory.Name = "buttonCategory";
            this.buttonCategory.Size = new System.Drawing.Size(99, 23);
            this.buttonCategory.TabIndex = 2;
            this.buttonCategory.Text = "Категории";
            this.buttonCategory.UseVisualStyleBackColor = true;
            this.buttonCategory.Click += new System.EventHandler(this.buttonCategory_Click);
            // 
            // buttonReceipts
            // 
            this.buttonReceipts.Location = new System.Drawing.Point(15, 148);
            this.buttonReceipts.Name = "buttonReceipts";
            this.buttonReceipts.Size = new System.Drawing.Size(122, 23);
            this.buttonReceipts.TabIndex = 3;
            this.buttonReceipts.Text = "Поступления";
            this.buttonReceipts.UseVisualStyleBackColor = true;
            this.buttonReceipts.Click += new System.EventHandler(this.buttonReceipts_Click);
            // 
            // buttonSales
            // 
            this.buttonSales.Location = new System.Drawing.Point(12, 190);
            this.buttonSales.Name = "buttonSales";
            this.buttonSales.Size = new System.Drawing.Size(143, 23);
            this.buttonSales.TabIndex = 4;
            this.buttonSales.Text = "Продажи/Заказы";
            this.buttonSales.UseVisualStyleBackColor = true;
            this.buttonSales.Click += new System.EventHandler(this.buttonSales_Click);
            // 
            // buttonRemainingStock
            // 
            this.buttonRemainingStock.Location = new System.Drawing.Point(15, 219);
            this.buttonRemainingStock.Name = "buttonRemainingStock";
            this.buttonRemainingStock.Size = new System.Drawing.Size(143, 23);
            this.buttonRemainingStock.TabIndex = 5;
            this.buttonRemainingStock.Text = "Остатки товаров";
            this.buttonRemainingStock.UseVisualStyleBackColor = true;
            this.buttonRemainingStock.Click += new System.EventHandler(this.buttonRemainingStock_Click);
            // 
            // buttonStatements
            // 
            this.buttonStatements.Location = new System.Drawing.Point(12, 260);
            this.buttonStatements.Name = "buttonStatements";
            this.buttonStatements.Size = new System.Drawing.Size(205, 23);
            this.buttonStatements.TabIndex = 6;
            this.buttonStatements.Text = "Заявление на поплнение";
            this.buttonStatements.UseVisualStyleBackColor = true;
            this.buttonStatements.Click += new System.EventHandler(this.buttonStatements_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(15, 305);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(15, 107);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(123, 23);
            this.buttonUsers.TabIndex = 8;
            this.buttonUsers.Text = "Пользователи";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 559);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStatements);
            this.Controls.Add(this.buttonRemainingStock);
            this.Controls.Add(this.buttonSales);
            this.Controls.Add(this.buttonReceipts);
            this.Controls.Add(this.buttonCategory);
            this.Controls.Add(this.buttonProduct);
            this.Controls.Add(this.labelUser);
            this.Name = "MainForm";
            this.Text = "Gardenly";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonCategory;
        private System.Windows.Forms.Button buttonReceipts;
        private System.Windows.Forms.Button buttonSales;
        private System.Windows.Forms.Button buttonRemainingStock;
        private System.Windows.Forms.Button buttonStatements;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonUsers;
    }
}