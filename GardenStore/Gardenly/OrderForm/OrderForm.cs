using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Librarygardenly.Orders;
using Librarygardenly.Products;

namespace Gardenly.OrderForm
{
    public partial class OrderForm : Form
    {
        private readonly int userId_;
        private readonly ProductService productService_;
        private readonly OrderService orderService_;

        private List<Product> products_;
        private List<OrderItem> items_;

        public OrderForm(int userId)
        {
            InitializeComponent();

            userId_ = userId;
            productService_ = new ProductService();
            orderService_ = new OrderService();

            products_ = new List<Product>();
            items_ = new List<OrderItem>();

            LoadProducts();
            ConfigureGrid();
        }

        // Загрузка товаров
        private void LoadProducts()
        {
            try
            {
                products_ = productService_.GetProducts().Where(p => p.Quantity > 0).ToList();

                comboBoxProduct.DataSource = null;
                comboBoxProduct.DisplayMember = "Name";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = products_;
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить товары. Проверьте подключение к базе данных.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Настройка таблицы
        private void ConfigureGrid()
        {
            dataGridViewItems.AutoGenerateColumns = true;
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewItems.MultiSelect = false;
        }

        // Обновление таблицы и суммы
        private void RefreshItems()
        {
            dataGridViewItems.DataSource = null;

            var rows = items_.Select(item => new
            {
                Товар = item.ProductName,
                Количество = item.Quantity,
                Цена = item.Price,
                Сумма = item.Quantity * item.Price
            }).ToList();

            dataGridViewItems.DataSource = rows;
            double total = items_.Sum(item => item.Quantity * item.Price);
            labelTotal.Text = "Итого: " + total.ToString("N2") + " ₽";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!(comboBoxProduct.SelectedItem is Product product))
            {
                MessageBox.Show("Выберите товар.");
                return;
            }

            int quantity = Convert.ToInt32(numericUpDownQuantity.Value);
            if (quantity <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.");
                return;
            }

            OrderItem existing = items_.FirstOrDefault(i => i.ProductId == product.Id);
            int alreadyAdded = existing == null ? 0 : existing.Quantity;

            if (alreadyAdded + quantity > product.Quantity)
            {
                MessageBox.Show("Недостаточно товара на складе. Доступно: " + product.Quantity + ". Уже добавлено: " + alreadyAdded, "Недостаточно товара",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                items_.Add(new OrderItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = quantity,
                    Price = product.Price
                });
            }
            RefreshItems();
            numericUpDownQuantity.Value = 1;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (items_.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один товар в продажу.");
                return;
            }

            try
            {
                Order order = new Order
                {
                    UserId = userId_,
                    OrderDate = DateTime.Now
                };

                orderService_.AddOrder(order, items_);

                MessageBox.Show("Продажа успешно оформлена.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось оформить продажу. " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
