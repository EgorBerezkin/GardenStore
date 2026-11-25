using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            labelName.Text = "Просмотр заявки №" + request_.Id;
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
                Количество = item.Quantity
            }).ToList();

            dataGridViewItems.DataSource = null;
            dataGridViewItems.DataSource = rows;

            if (dataGridViewItems.Columns.Count > 0)
            {
                dataGridViewItems.Columns["Товар"].HeaderText = "Товар";
                dataGridViewItems.Columns["Количество"].HeaderText = "Количество";
            }
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
