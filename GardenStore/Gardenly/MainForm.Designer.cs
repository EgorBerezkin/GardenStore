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
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonFilterCategories = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.tabPageSales = new System.Windows.Forms.TabPage();
            this.tabPageReceipts = new System.Windows.Forms.TabPage();
            this.tabPageRemainingStock = new System.Windows.Forms.TabPage();
            this.tabPageStatements = new System.Windows.Forms.TabPage();
            this.panelAdministrator = new System.Windows.Forms.Panel();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEditProduct = new System.Windows.Forms.Button();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageProducts.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.panelAdministrator.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUser.Location = new System.Drawing.Point(948, 21);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(141, 20);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "Пользователь";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(29, 11);
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
            this.panel1.Size = new System.Drawing.Size(1451, 60);
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
            this.tabControl.Size = new System.Drawing.Size(1420, 785);
            this.tabControl.TabIndex = 10;
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Controls.Add(this.panelAdministrator);
            this.tabPageProducts.Controls.Add(this.panel3);
            this.tabPageProducts.Controls.Add(this.panel2);
            this.tabPageProducts.Controls.Add(this.dataGridViewProducts);
            this.tabPageProducts.Location = new System.Drawing.Point(4, 29);
            this.tabPageProducts.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageProducts.Size = new System.Drawing.Size(1412, 752);
            this.tabPageProducts.TabIndex = 0;
            this.tabPageProducts.Text = "Товары";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.buttonSearch);
            this.panel3.Controls.Add(this.textBoxSearch);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(864, 174);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 92);
            this.panel3.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(310, 42);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(169, 34);
            this.buttonSearch.TabIndex = 8;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(226, 9);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(253, 27);
            this.textBoxSearch.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Поиск по наименованию";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.Controls.Add(this.buttonFilterCategories);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxCategory);
            this.panel2.Location = new System.Drawing.Point(864, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 133);
            this.panel2.TabIndex = 4;
            // 
            // buttonFilterCategories
            // 
            this.buttonFilterCategories.Location = new System.Drawing.Point(323, 63);
            this.buttonFilterCategories.Name = "buttonFilterCategories";
            this.buttonFilterCategories.Size = new System.Drawing.Size(156, 46);
            this.buttonFilterCategories.TabIndex = 5;
            this.buttonFilterCategories.Text = "Фильтруем";
            this.buttonFilterCategories.UseVisualStyleBackColor = true;
            this.buttonFilterCategories.Click += new System.EventHandler(this.buttonFilterCategories_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Категория";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(152, 16);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(327, 28);
            this.comboBoxCategory.TabIndex = 3;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.BurlyWood;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(19, 21);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(810, 674);
            this.dataGridViewProducts.TabIndex = 2;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Location = new System.Drawing.Point(4, 29);
            this.tabPageUsers.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageUsers.Size = new System.Drawing.Size(1412, 752);
            this.tabPageUsers.TabIndex = 1;
            this.tabPageUsers.Text = "Пользователи";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // tabPageSales
            // 
            this.tabPageSales.Location = new System.Drawing.Point(4, 29);
            this.tabPageSales.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSales.Name = "tabPageSales";
            this.tabPageSales.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSales.Size = new System.Drawing.Size(1412, 752);
            this.tabPageSales.TabIndex = 2;
            this.tabPageSales.Text = "Продажи/Заказы";
            this.tabPageSales.UseVisualStyleBackColor = true;
            // 
            // tabPageReceipts
            // 
            this.tabPageReceipts.Location = new System.Drawing.Point(4, 29);
            this.tabPageReceipts.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageReceipts.Name = "tabPageReceipts";
            this.tabPageReceipts.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageReceipts.Size = new System.Drawing.Size(1412, 752);
            this.tabPageReceipts.TabIndex = 3;
            this.tabPageReceipts.Text = "Поступления";
            this.tabPageReceipts.UseVisualStyleBackColor = true;
            // 
            // tabPageRemainingStock
            // 
            this.tabPageRemainingStock.Location = new System.Drawing.Point(4, 29);
            this.tabPageRemainingStock.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageRemainingStock.Name = "tabPageRemainingStock";
            this.tabPageRemainingStock.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageRemainingStock.Size = new System.Drawing.Size(1412, 752);
            this.tabPageRemainingStock.TabIndex = 4;
            this.tabPageRemainingStock.Text = "Остатки товаров";
            this.tabPageRemainingStock.UseVisualStyleBackColor = true;
            // 
            // tabPageStatements
            // 
            this.tabPageStatements.Location = new System.Drawing.Point(4, 29);
            this.tabPageStatements.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageStatements.Name = "tabPageStatements";
            this.tabPageStatements.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageStatements.Size = new System.Drawing.Size(1412, 752);
            this.tabPageStatements.TabIndex = 5;
            this.tabPageStatements.Text = "Заявление на поплнение";
            this.tabPageStatements.UseVisualStyleBackColor = true;
            // 
            // panelAdministrator
            // 
            this.panelAdministrator.BackColor = System.Drawing.Color.IndianRed;
            this.panelAdministrator.Controls.Add(this.buttonDeleteProduct);
            this.panelAdministrator.Controls.Add(this.buttonEditProduct);
            this.panelAdministrator.Controls.Add(this.label3);
            this.panelAdministrator.Controls.Add(this.buttonAddProduct);
            this.panelAdministrator.Location = new System.Drawing.Point(864, 294);
            this.panelAdministrator.Name = "panelAdministrator";
            this.panelAdministrator.Size = new System.Drawing.Size(498, 401);
            this.panelAdministrator.TabIndex = 6;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(14, 46);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(151, 44);
            this.buttonAddProduct.TabIndex = 0;
            this.buttonAddProduct.Text = "Добавить товар";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Товары: добавить, удалить и отредактировать";
            // 
            // buttonEditProduct
            // 
            this.buttonEditProduct.Location = new System.Drawing.Point(171, 46);
            this.buttonEditProduct.Name = "buttonEditProduct";
            this.buttonEditProduct.Size = new System.Drawing.Size(151, 44);
            this.buttonEditProduct.TabIndex = 2;
            this.buttonEditProduct.Text = "Изменить товар";
            this.buttonEditProduct.UseVisualStyleBackColor = true;
            this.buttonEditProduct.Click += new System.EventHandler(this.buttonEditProduct_Click);
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(328, 46);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(151, 44);
            this.buttonDeleteProduct.TabIndex = 3;
            this.buttonDeleteProduct.Text = "Удалить товар";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1408, 839);
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
            this.tabPageProducts.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.panelAdministrator.ResumeLayout(false);
            this.panelAdministrator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageSales;
        private System.Windows.Forms.TabPage tabPageReceipts;
        private System.Windows.Forms.TabPage tabPageRemainingStock;
        private System.Windows.Forms.TabPage tabPageStatements;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonFilterCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAdministrator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonEditProduct;
        private System.Windows.Forms.Button buttonDeleteProduct;
    }
}