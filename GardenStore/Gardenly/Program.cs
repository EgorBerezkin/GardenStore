using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles(); // включает визуальные стили Windows для элементов интерфейса
            Application.SetCompatibleTextRenderingDefault(false); // способ отображения текста в элементах формы

            Application.Run(new LoginForm());
        }
    }
}
