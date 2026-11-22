using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Librarygardenly;
using Librarygardenly.Products;
using Librarygardenly.Restock;

namespace Gardenly.RestockRequest
{
    public partial class RestockRequestForm : Form
    {
        private int userId_;
        private ProductService productService_;
        private RestockRequestService requestService_;
        private List<Product> products_;
        private List<RestockRequestItem> items_;

        public RestockRequestForm(int userId)
        {
            InitializeComponent();

            userId_ = userId;

            productService_ = new ProductService();
            requestService_ = new RestockRequestService();

            products_ = new List<Product>();
            items_ = new List<RestockRequestItem>();

            LoadProducts();
            RefreshItems();
        }
        private void LoadProducts()
        {
            try
            {
                products_ = productService_.GetProducts();

                comboBoxProducts.DataSource = null;
                comboBoxProducts.DataSource = products_;
                comboBoxProducts.DisplayMember = "Name";
                comboBoxProducts.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить товары. " + ex.Message);
            }
        }
        private void RefreshItems()
        {
            dataGridViewItems.DataSource = null;
            dataGridViewItems.DataSource = items_.ToList();

            if (dataGridViewItems.Columns.Count > 0)
            {
                dataGridViewItems.Columns["Id"].Visible = false;
                dataGridViewItems.Columns["RequestId"].Visible = false;
                dataGridViewItems.Columns["ProductId"].Visible = false;

                dataGridViewItems.Columns["ProductName"].HeaderText = "Товар";
                dataGridViewItems.Columns["Quantity"].HeaderText = "Количество";
            }
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (items_.Count == 0)
            {
                MessageBox.Show("Добавьте товары в заявку.");
                return;
            }

            try
            {
                Librarygardenly.Restock.RestockRequest request =
                new Librarygardenly.Restock.RestockRequest
                {
                    UserId = userId_,
                    RequestDate = DateTime.Now,
                    Status = "Ожидает рассмотрения"
                };
                requestService_.AddRequest(request, items_);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить заявку. " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (!(comboBoxProducts.SelectedItem is Product product))
            {
                MessageBox.Show("Выберите товар.");
                return;
            }

            int quantity;
            if (!int.TryParse(textBoxQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество.");
                return;
            }

            RestockRequestItem existingItem = items_.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items_.Add(new RestockRequestItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = quantity,
                    Price = product.Price
                });
            }
            RefreshItems();
            textBoxQuantity.Clear();
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewItems.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для удаления.");
                return;
            }
            int index = dataGridViewItems.CurrentRow.Index;
            if (index >= 0 && index < items_.Count)
            {
                items_.RemoveAt(index);
                RefreshItems();
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
