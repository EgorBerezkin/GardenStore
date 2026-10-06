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
using Librarygardenly.Registration;

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

        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        private void tabPageProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
