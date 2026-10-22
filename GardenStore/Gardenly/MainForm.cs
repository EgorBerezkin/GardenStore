using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gardenly.ReceiptForm;
using Librarygardenly;
using Librarygardenly.Categories;
using Librarygardenly.Products;
using Librarygardenly.Receipts;

namespace Gardenly
{
    public partial class MainForm : Form
    {
        private User user_;
        private ProductService productService_;
        private CategoryService categoryService_;
        private List<Product> products_;
        private List<Product> filteredProducts_;    // для поиска товара в фильтре по категориям
        private ReceiptService receiptService_;

        public MainForm(User user)
        {
            InitializeComponent();

            user_ = user;
            labelUser.Text = "Вы вошли как: " + user_.FullName;
            if (user_.Role == "sotrudnik")
            {
                panelAdministrator.Visible = false;
                // tabPageUsers.Parent = null;
            }

            productService_ = new ProductService();
            LoadProducts();

            categoryService_ = new CategoryService();
            LoadCategories();

            receiptService_ = new ReceiptService();
            LoadReceipts();
        }

        private void LoadReceipts()
        {
            try
            {
                List<Receipt> receipts = receiptService_.GetReceipts();

                dataGridViewReceipts.DataSource = null;
                dataGridViewReceipts.DataSource = receipts;

                dataGridViewReceipts.Columns["Id"].HeaderText = "Номер";
                dataGridViewReceipts.Columns["UserId"].Visible = false;

                dataGridViewReceipts.Columns["ReceiptDate"].HeaderText = "Дата";
                dataGridViewReceipts.Columns["ReceiptDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                dataGridViewReceipts.Columns["UserFullName"].HeaderText = "Сотрудник";
                dataGridViewReceipts.Columns["ItemsCount"].HeaderText = "Позиций";
                dataGridViewReceipts.Columns["TotalAmount"].HeaderText = "Сумма";
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить поступления. " + "Проверьте подключение к базе данных.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                products_ = productService_.GetProducts();
                filteredProducts_ = products_.ToList();
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
            categoryService_ = new CategoryService();
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
                MessageBox.Show("Не удалось загрузить категории.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text;
            if (searchText == "")
            {
                dataGridViewProducts.DataSource = filteredProducts_;
                return;
            }
            List<Product> searchResults = filteredProducts_.Where(p => p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (searchResults.Count == 0)
            {
                List<Product> allSearchResults = products_.Where(p => p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                if (allSearchResults.Count == 0)
                {
                    MessageBox.Show("Такого товара нет в базе.", "Поиск",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Товар не найден в выбранной категории.\n" + "Выберите другую категорию или выберите «Все категории».", "Поиск",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dataGridViewProducts.DataSource = searchResults;
        }

        private void buttonFilterCategories_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem is Category selectedCategory)
            {
                if (selectedCategory.Id == 0)
                {
                    filteredProducts_ = products_.ToList();
                }
                else
                {
                    filteredProducts_ = products_.Where(p => p.CategoryId == selectedCategory.Id).ToList();
                }
                if (filteredProducts_.Count == 0)
                {
                    MessageBox.Show("Товаров в выбранной категории нет.\n" + "Выберите другую категорию или выберите «Все категории».", "Фильтр",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dataGridViewProducts.DataSource = filteredProducts_;
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();
            LoadProducts();
        }

        private void buttonEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Редактирование",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Product selectedProduct = dataGridViewProducts.CurrentRow.DataBoundItem as Product;
            if (selectedProduct == null)
            {
                return;
            }

            ProductForm productForm = new ProductForm(selectedProduct);
            productForm.ShowDialog();
            LoadProducts();
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для удаления.", "Удаление",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Product selectedProduct = dataGridViewProducts.CurrentRow.DataBoundItem as Product;

            if (selectedProduct == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить товар \"" + selectedProduct.Name + "\"?", "Удаление товара",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                productService_.DeleteProduct(selectedProduct.Id);

                MessageBox.Show("Товар успешно удалён.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
            LoadCategories();
        }

        private void buttonAddReceipt_Click(object sender, EventArgs e)
        {
            using (ReceiptForm.ReceiptForm form = new ReceiptForm.ReceiptForm(user_.Id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReceipts();
                    LoadProducts();
                }
            }
        }

        private void buttonViewReceipt_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceipts.CurrentRow == null)
            {
                MessageBox.Show("Выберите поступление.");
                return;
            }

            Receipt receipt = dataGridViewReceipts.CurrentRow.DataBoundItem as Receipt;
            if (receipt == null)
                return;

            using (ReceiptViewForm form = new ReceiptViewForm(receipt.Id, receipt.ReceiptDate.ToString("dd.MM.yyyy"), receipt.UserFullName))
            {
                form.ShowDialog();
            }
        }
    }
}
