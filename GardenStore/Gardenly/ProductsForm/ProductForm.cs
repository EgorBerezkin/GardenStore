using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Librarygardenly.Categories;
using Librarygardenly.Products;

namespace Gardenly
{
    public partial class ProductForm : Form
    {
        private CategoryService categoryService_;
        private ProductService productService_;
        private Product product_;

        public Product CreatedProduct { get; private set; }
        private bool receiptMode_ = false;

        public ProductForm()
        {
            InitializeComponent();

            categoryService_ = new CategoryService();
            productService_ = new ProductService();
            LoadCategories();
        }

        public ProductForm(Product product)
        {
            InitializeComponent();
            product_ = product;

            categoryService_ = new CategoryService();
            productService_ = new ProductService();

            LoadCategories();

            textBoxName.Text = product_.Name;
            comboBoxCategory.SelectedValue = product_.CategoryId;
            textBoxPrice.Text = product_.Price.ToString();
            textBoxQuantity.Text = product_.Quantity.ToString();
            textBoxDescription.Text = product_.Description;
        }

        public ProductForm(bool receiptMode) :this()
        {
            receiptMode_ = receiptMode;
        }

        private void LoadCategories()
        {
            try
            {
                List<Category> categories = categoryService_.GetCategories();

                comboBoxCategory.DataSource = categories;
                comboBoxCategory.DisplayMember = "Name";
                comboBoxCategory.ValueMember = "Id";
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить категории.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                categoryService_.AddCategory(textBoxName.Text);

                MessageBox.Show("Категория успешно добавлена.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось добавить категорию.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
