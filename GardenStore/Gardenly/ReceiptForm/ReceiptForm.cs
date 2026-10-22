using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Librarygardenly.Products;
using Librarygardenly.Receipts;

namespace Gardenly.ReceiptForm
{
    public partial class ReceiptForm : Form
    {
        private readonly int userId_;
        private readonly ProductService productService_;
        private readonly ReceiptService receiptService_;

        private List<Product> products_;
        private List<ReceiptItem> items_;

        public ReceiptForm(int userId)
        {
            InitializeComponent();

            userId_ = userId;
            productService_ = new ProductService();
            receiptService_ = new ReceiptService();

            products_ = new List<Product>();
            items_ = new List<ReceiptItem>();

            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                products_ = productService_.GetProducts();

                comboBoxProduct.DataSource = null;
                comboBoxProduct.DisplayMember = "Name";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = products_;
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. " + "Проверьте подключение и повторите попытку.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshItems()
        {
            dataGridViewItems.DataSource = null;
            var rows = items_.Select(item => new
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

            double total = items_.Sum(item => (double)item.Quantity * (double)item.Price);
            labelTotal.Text = "Итого: " + total.ToString("N2") + " ₽";
        }

        private void buttonNewProduct_Click(object sender, EventArgs e)
        {
            using (ProductForm productForm = new ProductForm(true))
            {
                if (productForm.ShowDialog() != DialogResult.OK)
                    return;

                Product product = productForm.CreatedProduct;

                if (product == null)
                    return;

                items_.Add(new ReceiptItem {ProductId = 0, ProductName = product.Name, Quantity = product.Quantity, Price = product.Price, NewProduct = product});
                RefreshItems();
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (!(comboBoxProduct.SelectedItem is Product product))
            {
                MessageBox.Show("Выберите товар.");
                return;
            }

            int quantity;
            double price;

            if (!int.TryParse(textBoxQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Количество должно быть положительным целым числом.");
                return;
            }

            if (!double.TryParse(textBoxPrice.Text, out price) || double.IsNaN(price) || double.IsInfinity(price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену.");
                return;
            }

            ReceiptItem existing = items_.FirstOrDefault(i => i.ProductId == product.Id && i.NewProduct == null);

            if (existing != null)
            {
                existing.Quantity += quantity;
                existing.Price = price;
            }
            else
            {
                items_.Add(new ReceiptItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = quantity,
                    Price = price
                });
            }

            RefreshItems();
            textBoxQuantity.Clear();
            textBoxPrice.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (items_.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один товар в поступление.");
                return;
            }
            try
            {
                Receipt receipt = new Receipt
                {
                    UserId = userId_,
                    ReceiptDate = DateTime.Now
                };

                receiptService_.AddReceipt(receipt, items_);

                MessageBox.Show("Поступление успешно зарегистрировано.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить поступление. " + ex.Message,  "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
