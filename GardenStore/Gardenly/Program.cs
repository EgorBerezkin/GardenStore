using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Librarygardenly.DataBase;

namespace Gardenly
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DataBaseInitializer initializer =
                    new DataBaseInitializer();

                initializer.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось подготовить базу данных.\n\n" +
                    ex.Message,
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            Application.Run(new LoginForm());
        }
    }
}
