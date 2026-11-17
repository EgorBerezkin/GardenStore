using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gardenly.ReceiptForm;
using Librarygardenly;
using Librarygardenly.Categories;
using Librarygardenly.Orders;
using Librarygardenly.Products;
using Librarygardenly.Receipts;
using Librarygardenly.Registration;

namespace Gardenly
{
    public partial class MainForm : Form
    {
        private User user_;                         // хранение данных о пользователе
        private ProductService productService_;     // для работы с товарами
        private CategoryService categoryService_;   // для работы с категориями
        private List<Product> products_;            // список загруженных товаров
        private List<Product> filteredProducts_;    // список товаров после фильтрации
        private ReceiptService receiptService_;     // для работы с поступлениями
        private OrderService orderService_;         // для работы с продажами


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
            LoadReceiptEmployees();

            orderService_ = new OrderService();
            LoadOrders();
        }
        // ----------------------------------Вкладка товары---------------------------------------
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
        // Кнопка фильтрации товаров по категории
        private void buttonFilterCategories_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem is Category selectedCategory)
            {
                filteredProducts_ = productService_.FilterProductsByCategory(products_, selectedCategory.Id);

                if (filteredProducts_.Count == 0)
                {
                    dataGridViewProducts.DataSource = filteredProducts_;
                    MessageBox.Show("Товаров в выбранной категории нет.\nВыберите другую категорию или выберите «Все категории».", "Фильтр",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                dataGridViewProducts.DataSource = filteredProducts_;
            }
        }
        // Кнопка поиска товара по наименованию
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text;
            List<Product> searchResults = productService_.SearchProducts(filteredProducts_, searchText);

            if (searchResults.Count == 0)
            {
                List<Product> allResults = productService_.SearchProducts(products_, searchText);

                if (allResults.Count == 0)
                {
                    MessageBox.Show("Такого товара нет в базе.", "Поиск");
                }
                else
                {
                    MessageBox.Show("Товар не найден в выбранной категории.\nВыберите другую категорию.", "Поиск");
                }
                return;
            }
            dataGridViewProducts.DataSource = searchResults;
        }
        // Добавление товара (открытие формы добавления товара)
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();
            LoadProducts();
        }
        // Редактирование товара (открытие формы добавления товара)
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
        // Удаление товара
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
                LoadProducts();
            }
        }
        // -------------------------------Вкладка товары, работа с категориями-------------------------------
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
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить категории." + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Кнопка для добавления новой категории
        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
            LoadCategories();
        }
        // -------------------------------------Работа с поступлениями--------------------------------------------
        private void LoadReceipts(List<Receipt> receipts = null)
        {
            try
            {
                if (receipts == null)
                {
                    receipts = receiptService_.GetReceipts();
                }

                dataGridViewReceipts.DataSource = null;
                dataGridViewReceipts.DataSource = receipts;

                if (dataGridViewReceipts.Columns.Count == 0)
                    return;

                dataGridViewReceipts.Columns["Id"].HeaderText = "Номер";
                dataGridViewReceipts.Columns["UserId"].Visible = false;

                dataGridViewReceipts.Columns["ReceiptDate"].HeaderText = "Дата";
                dataGridViewReceipts.Columns["ReceiptDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                dataGridViewReceipts.Columns["UserFullName"].HeaderText = "Сотрудник";
                dataGridViewReceipts.Columns["ItemsCount"].HeaderText = "Количество";
                dataGridViewReceipts.Columns["TotalAmount"].HeaderText = "Сумма";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить поступления. Проверьте подключение к базе данных.\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadReceiptEmployees()
        {
            try
            {
                UserService userService = new UserService();
                var employees = userService.GetUsers()
                    .Select(u => new { Id = u.Id, FullName = u.FullName })
                    .ToList();

                comboBoxReceiptSotrudnik.DataSource = null;

                var allEmployees = new[] { new { Id = 0, FullName = "Все сотрудники" } };

                comboBoxReceiptSotrudnik.DataSource = allEmployees.Concat(employees).ToList();
                comboBoxReceiptSotrudnik.DisplayMember = "FullName";
                comboBoxReceiptSotrudnik.ValueMember = "Id";
                comboBoxReceiptSotrudnik.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить список сотрудников. " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Кнопка просмотра выбранного поступления
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
        // Кнопка добавления нового поступления
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
        // Кнопка поиска поступления по дате и сотруднику
        private void buttonSearchReceipts_Click(object sender, EventArgs e)
        {
            DateTime? date = dateTimePickerReceipt.Checked ? dateTimePickerReceipt.Value.Date : (DateTime?)null;

            int employeeId = Convert.ToInt32(comboBoxReceiptSotrudnik.SelectedValue);
            int? userId = employeeId == 0 ? (int?)null : employeeId;
            List<Receipt> receipts = receiptService_.GetReceiptsByFilters(date, userId);

            dataGridViewReceipts.DataSource = null;
            dataGridViewReceipts.DataSource = receipts;

            LoadReceipts(receipts);
            if (receipts.Count == 0)
            {
                MessageBox.Show("Поступлений по выбранным условиям не найдено.", "Поиск поступлений");
            }
        }
        // Кнопка сброса фильтра
        private void buttonResetReceipts_Click(object sender, EventArgs e)
        {
            LoadReceipts();
        }
        // --------------------------------------Вкладка продажи-----------------------------------------
        private void LoadOrders()
        {
            try
            {
                List<Order> orders = orderService_.GetOrders();

                dataGridViewOrders.DataSource = null;
                dataGridViewOrders.DataSource = orders;

                if (dataGridViewOrders.Columns.Count == 0)
                    return;

                dataGridViewOrders.Columns["Id"].HeaderText = "Номер";
                dataGridViewOrders.Columns["UserId"].Visible = false;
                dataGridViewOrders.Columns["OrderDate"].HeaderText = "Дата";
                dataGridViewOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                dataGridViewOrders.Columns["UserFullName"].HeaderText = "Сотрудник";
                dataGridViewOrders.Columns["TotalAmount"].HeaderText = "Сумма";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить продажи. Проверьте подключение к базе данных.\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Кнопка просмотра продажи
        private void buttonViewOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow == null)
            {
                MessageBox.Show("Выберите продажу.");
                return;
            }

            Order order = dataGridViewOrders.CurrentRow.DataBoundItem as Order;

            if (order == null)
                return;

            using (OrderForm.OrderViewForm form = new OrderForm.OrderViewForm(order.Id, order.OrderDate.ToString("dd.MM.yyyy HH:mm"), order.UserFullName))
            {
                form.ShowDialog();
            }
        }
        // Кнопка добавление продажи
        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            using (OrderForm.OrderForm form = new OrderForm.OrderForm(user_.Id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                    LoadProducts();
                }
            }
        }
        // -------------------------Кнопка выхода с главной формы-------------------------------
        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        
    }
}
