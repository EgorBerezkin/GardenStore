using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Librarygardenly.Restock;

namespace Gardenly.RestockRequest
{
    public partial class RequestViewForm : Form
    {
        private Librarygardenly.Restock.RestockRequest request_;
        private RestockRequestService requestService_;
        private bool isAdministrator_;

        public RequestViewForm(Librarygardenly.Restock.RestockRequest request, bool isAdministrator)
        {
            InitializeComponent();
            request_ = request;
            isAdministrator_ = isAdministrator;

            requestService_ = new RestockRequestService();

            LoadRequestInfo();
            LoadRequestItems();

            buttonApprove.Visible = isAdministrator_;
            buttonReject.Visible = isAdministrator_;

            if (request_.Status != "Ожидает рассмотрения")
            {
                buttonApprove.Enabled = false;
                buttonReject.Enabled = false;
            }
        }

        private void LoadRequestInfo()
        {
            labelRequestNumber.Text = "Заявка №" + request_.Id;
            labelSotrudnik.Text = "Сотрудник: " + request_.UserFullName;
            labelDate.Text = "Дата: " + request_.RequestDate.ToString("dd.MM.yyyy HH:mm");
            labelStatus.Text = "Статус: " + request_.Status;
        }

        private void LoadRequestItems()
        {
            List<RestockRequestItem> items = requestService_.GetRequestItems(request_.Id);
            var rows = items.Select(item => new
            {
                Товар = item.ProductName,
                Количество = item.Quantity,
                ЦенаЗаЕдиницу = item.Price,
                ОбщаяСумма = item.TotalPrice
            }).ToList();

            dataGridViewItems.DataSource = null;
            dataGridViewItems.DataSource = rows;

            if (dataGridViewItems.Columns.Count > 0)
            {
                dataGridViewItems.Columns["Товар"].HeaderText = "Товар";
                dataGridViewItems.Columns["Количество"].HeaderText = "Количество";
                dataGridViewItems.Columns["ЦенаЗаЕдиницу"].HeaderText = "Цена за единицу";
                dataGridViewItems.Columns["ОбщаяСумма"].HeaderText = "Общая сумма";
                dataGridViewItems.Columns["ЦенаЗаЕдиницу"].DefaultCellStyle.Format = "N2";
                dataGridViewItems.Columns["ОбщаяСумма"].DefaultCellStyle.Format = "N2";
            }
            double total = items.Sum(item => item.TotalPrice);
            labelTotalRequest.Text = "Общая сумма заявки: " + total.ToString("N2") + " ₽";
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            if (request_.Status != "Ожидает рассмотрения")
            {
                MessageBox.Show("Эта заявка уже обработана.");
                return;
            }

            DialogResult result = MessageBox.Show("Вы действительно хотите одобрить заявку №" + request_.Id + "?", "Одобрение заявки",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    requestService_.UpdateRequestStatus(request_.Id, "Одобрена");
                    MessageBox.Show("Заявка успешно одобрена.", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось одобрить заявку. " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (request_.Status != "Ожидает рассмотрения")
            {
                MessageBox.Show("Эта заявка уже обработана.");
                return;
            }

            DialogResult result = MessageBox.Show("Вы действительно хотите отклонить заявку №" + request_.Id + "?", "Отклонение заявки",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    requestService_.UpdateRequestStatus(request_.Id, "Отклонена");
                    MessageBox.Show("Заявка отклонена.", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось отклонить заявку. " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
