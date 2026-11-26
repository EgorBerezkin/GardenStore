using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Librarygardenly.Orders;

namespace Gardenly.OrderForm
{
    public partial class OrderViewForm : Form
    {
        private int orderId_;
        private string orderDate_;
        private string userFullName_;
        private OrderService orderService_;

        public OrderViewForm(int orderId, string orderDate, string userFullName)
        {
            InitializeComponent();

            orderId_ = orderId;
            orderDate_ = orderDate;
            userFullName_ = userFullName;

            orderService_ = new OrderService();

            labelName.Text = "Просмотр продажи №" + orderId_;
            labelDateOrder.Text = "Дата: " + orderDate_;
            labelSotrudnik.Text = "Сотрудник: " + userFullName_;

            LoadItems();
        }

        // Загрузка товаров продажи
        private void LoadItems()
        {
            try
            {
                List<OrderItem> items = orderService_.GetOrderItems(orderId_);

                var rows = items.Select(item => new
                {
                    Товар = item.ProductName,
                    Количество = item.Quantity,
                    ЦенаЗаШтуку = item.Price,
                    Сумма = item.Quantity * item.Price
                }).ToList();

                dataGridViewItems.DataSource = rows;
                if (dataGridViewItems.Columns.Count > 0)
                {
                    dataGridViewItems.Columns["Товар"].HeaderText = "Товар";
                    dataGridViewItems.Columns["Количество"].HeaderText = "Количество";
                    dataGridViewItems.Columns["ЦенаЗаШтуку"].HeaderText = "Цена за штуку";
                    dataGridViewItems.Columns["Сумма"].HeaderText = "Сумма";
                }

                double total = items.Sum(item => (double)item.Quantity * item.Price);
                labelTotal.Text = "Итого: " + total.ToString() + " ₽";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить состав продажи. " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
