using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Librarygardenly;
using Librarygardenly.Categories;
using Librarygardenly.Products;

namespace Gardenly
{
    public partial class MainForm : Form
    {
        private User user_;
        private ProductService productService_;
        private CategoryService categoryService_;
        private List<Product> products_;

        public MainForm(User user)
        {
            InitializeComponent();
            user_ = user;

            labelUser.Text = "Вы вошли как: " + user_.FullName;

            productService_ = new ProductService();
            LoadProducts();

            categoryService_ = new CategoryService();
            LoadCategories();
        }

        private void LoadProducts()
        {
            try
            {
                products_ = productService_.GetProducts();

                dataGridViewProducts.DataSource = products_;

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

        private void LoadCategories()
        {
            try
            {
                List<Category> categories = categoryService_.GetCategories();

                categories.Insert(0, new Category(0, "Все категории"));

                comboBoxCategory.DataSource = categories;
                comboBoxCategory.DisplayMember = "Name";
                comboBoxCategory.ValueMember = "Id";
            }
            catch
            {
                MessageBox.Show(
                    "Не удалось загрузить категории.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        private void buttonSortiтпCategories_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem is Category selectedCategory)
            {
                if (selectedCategory.Id == 0)
                {
                    dataGridViewProducts.DataSource = products_;
                }
                else
                {
                    List<Product> filteredProducts = products_
                        .Where(p => p.CategoryId == selectedCategory.Id)
                        .ToList();

                    dataGridViewProducts.DataSource = filteredProducts;
                }
            }
        }
    }
}
