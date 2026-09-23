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
    public partial class LoginForm : Form
    {
        // переменные для попыток блокировки
        private int attempts_ = 3;
        private DateTime blockUntil_;
        public LoginForm()
        {
            InitializeComponent();
            labelAttemps.Text = "Осталось попыток: " + attempts_;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Проверяем, закончилась ли блокировка
            if (DateTime.Now < blockUntil_)
            {
                TimeSpan remaining = blockUntil_ - DateTime.Now;

                MessageBox.Show(
                    "Вход заблокирован. Попробуйте снова через "
                    + remaining.Minutes + " мин. "
                    + remaining.Seconds + " сек.",
                    "Вход заблокирован",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Если блокировка закончилась, возвращаем 3 попытки
            if (attempts_ == 0)
            {
                attempts_ = 3;
                labelAttemps.Text = "Осталось попыток: " + attempts_;
            }

            // Проверяем пустые поля
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            UserService service = new UserService();

            User user = service.AuthorizeUser(
                textBoxLogin.Text.Trim(),
                textBoxPassword.Text);

            if (user != null)
            {
                MainForm mainForm = new MainForm(user);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Уменьшаем количество попыток
                attempts_--;

                labelAttemps.Text = "Осталось попыток: " + attempts_;

                if (attempts_ == 0)
                {
                    blockUntil_ = DateTime.Now.AddMinutes(5);

                    MessageBox.Show(
                        "Вы три раза ввели неверный логин или пароль.\n\n" +
                        "Вход заблокирован на 5 минут.",
                        "Вход заблокирован",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Неверный логин или пароль",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }
    }
}
