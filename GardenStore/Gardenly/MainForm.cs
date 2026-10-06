using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Librarygardenly;
using Librarygardenly.Products;

namespace Gardenly
{
    public partial class MainForm : Form
    {
        private User user_;
        private ProductService productService_;

        public MainForm(User user)
        {
            InitializeComponent();
            user_ = user;

            labelUser.Text = "Вы вошли как: " + user_.FullName;

            productService_ = new ProductService();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                List<Product> products = productService_.GetProducts();

                dataGridViewProducts.DataSource = products;

                dataGridViewProducts.Columns["Id"].HeaderText = "Код";
                dataGridViewProducts.Columns["Name"].HeaderText = "Название";
                dataGridViewProducts.Columns["CategoryId"].Visible = false;
                dataGridViewProducts.Columns["CategoryName"].HeaderText = "Категория";
                dataGridViewProducts.Columns["Price"].HeaderText = "Цена";
                dataGridViewProducts.Columns["Quantity"].HeaderText = "Количество";
                dataGridViewProducts.Columns["Description"].HeaderText = "Описание";
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте подключение и повторите попытку", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }
    }
}
