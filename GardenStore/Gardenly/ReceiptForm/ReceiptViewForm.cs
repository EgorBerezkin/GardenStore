using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Librarygardenly.Receipts;

namespace Gardenly.ReceiptForm
{
    public partial class ReceiptViewForm : Form
    {
        private readonly int receiptId_;
        private readonly string receiptDate_;
        private readonly string userFullName_;
        private readonly ReceiptService receiptService_;

        public ReceiptViewForm(int receiptId, string receiptDate, string userFullName)
        {
            InitializeComponent();

            receiptId_ = receiptId;
            receiptDate_ = receiptDate;
            userFullName_ = userFullName;

            receiptService_ = new ReceiptService();
            labelReceiptInfo.Text = "Поступление №" + receiptId_;
            labelDateReceipt.Text = "Дата: " + receiptDate_;
            labelSotrudnik.Text = "Сотрудник: " + userFullName_;
            LoadItems();
        }

        private void LoadItems()
        {
            try
            {
                List<ReceiptItem> items = receiptService_.GetReceiptItems(receiptId_);
                var rows = items.Select(item => new { Товар = item.ProductName, Количество = item.Quantity, ЦенаЗаШтуку = item.Price, Сумма = item.Quantity * item.Price}).ToList();

                dataGridViewItems.DataSource = rows;

                if (dataGridViewItems.Columns.Count > 0)
                {
                    dataGridViewItems.Columns["Товар"].HeaderText = "Товар";
                    dataGridViewItems.Columns["Количество"].HeaderText = "Количество";
                    dataGridViewItems.Columns["ЦенаЗаШтуку"].HeaderText = "Цена за штуку";
                    dataGridViewItems.Columns["Сумма"].HeaderText = "Сумма";
                }
                double total = items.Sum(item => (double)item.Quantity * (double)item.Price);
                labelTotal.Text = "Итого: " + total.ToString("N2") + " ₽";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить состав поступления. " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
