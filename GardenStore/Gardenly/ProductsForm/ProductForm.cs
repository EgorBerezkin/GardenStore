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

        public ProductForm(bool receiptMode) :this()
        {
            receiptMode_ = receiptMode;
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
                string name = textBoxName.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Введите название товара.");
                    return;
                }

                if (comboBoxCategory.SelectedValue == null)
                {
                    MessageBox.Show("Выберите категорию товара.");
                    return;
                }

                int categoryId;

                if (!int.TryParse(comboBoxCategory.SelectedValue.ToString(), out categoryId) || categoryId <= 0)
                {
                    MessageBox.Show("Выберите корректную категорию.");
                    return;
                }

                double price;

                if (!double.TryParse(textBoxPrice.Text, out price) || double.IsNaN(price) || double.IsInfinity(price) || price < 0)
                {
                    MessageBox.Show("Введите корректную цену товара.");
                    return;
                }

                int quantity;

                if (!int.TryParse(textBoxQuantity.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Количество должно быть положительным целым числом.");
                    return;
                }

                string description = textBoxDescription.Text;

                if (product_ == null)
                {
                    Product product = new Product(0, name, categoryId, "", price, quantity, description);
                    if (receiptMode_)
                    {
                        CreatedProduct = product;
                        DialogResult = DialogResult.OK;
                        Close();
                        return;
                    }
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
