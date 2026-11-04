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

        public ProductForm(bool receiptMode) : this()
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
                string name = textBoxName.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Введите название товара.");
                    return;
                }

                if (!(comboBoxCategory.SelectedItem is Category category))
                {
                    MessageBox.Show("Выберите категорию товара.");
                    return;
                }

                double price;
                if (!double.TryParse(textBoxPrice.Text, out price) || double.IsNaN(price) || double.IsInfinity(price) || price < 0)
                {
                    MessageBox.Show("Введите корректную цену.");
                    return;
                }

                int quantity;
                if (!int.TryParse(textBoxQuantity.Text, out quantity) || quantity < 0 || (receiptMode_ && quantity == 0))
                {
                    MessageBox.Show(receiptMode_ ? "Количество поступающего товара должно быть больше нуля." : "Количество должно быть целым неотрицательным числом.");
                    return;
                }

                Product product = new Product(
                    product_ == null ? 0 : product_.Id,
                    name,
                    category.Id,
                    category.Name,
                    price,
                    quantity,
                    textBoxDescription.Text
                );

                if (receiptMode_)
                {
                    CreatedProduct = product;
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                if (product_ == null)
                {
                    productService_.AddProduct(product);
                    MessageBox.Show("Товар успешно добавлен.", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    productService_.UpdateProduct(product);
                    MessageBox.Show("Товар успешно изменён.", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить товар. " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
