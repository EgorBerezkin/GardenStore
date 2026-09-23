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

namespace Gardenly
{
    public partial class MainForm : Form
    {
        private User user_;
        public MainForm(User user)
        {
            InitializeComponent();
            user_ = user;

            labelUser.Text = "Вы вошли как: " + user_.FullName;
            if (user_.Role == "sotrudnik")
            {
                buttonCategory.Visible = false;
                buttonUsers.Visible = false;
            }
            this.FormClosed += MainForm_FormClosed;

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {

        }

        private void buttonCategory_Click(object sender, EventArgs e)
        {

        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {

        }

        private void buttonReceipts_Click(object sender, EventArgs e)
        {

        }

        private void buttonSales_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemainingStock_Click(object sender, EventArgs e)
        {

        }

        private void buttonStatements_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }
    }
}
