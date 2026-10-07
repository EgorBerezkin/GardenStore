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

            List<Category> categories = categoryService_.GetCategories();

            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";

            textBoxName.Text = product_.Name;
            comboBoxCategory.SelectedValue = product_.CategoryId;
            textBoxPrice.Text = product_.Price.ToString();
            textBoxQuantity.Text = product_.Quantity.ToString();
            textBoxDescription.Text = product_.Description;
        }

        private void LoadCategories()
        {
            categoryService_ = new CategoryService();
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
                string name = textBoxName.Text;
                int categoryId = (int)comboBoxCategory.SelectedValue;
                double price = Convert.ToDouble(textBoxPrice.Text);
                int quantity = Convert.ToInt32(textBoxQuantity.Text);
                string description = textBoxDescription.Text;

                if (product_ == null)
                {
                    Product product = new Product(0, name, categoryId, "", price, quantity, description);
                    productService_.AddProduct(product);
                }
                else
                {
                    product_.Name = name;
                    product_.CategoryId = categoryId;
                    product_.Price = price;
                    product_.Quantity = quantity;
                    product_.Description = description;

                    productService_.UpdateProduct(product_);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
