using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Librarygardenly.Categories;

namespace Gardenly
{
    public partial class CategoryForm : Form
    {
        private CategoryService categoryService_;
        public CategoryForm()
        {
            InitializeComponent();
            categoryService_ = new CategoryService();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;

            try
            {
                if (categoryService_.CategoryExists(name))
                {
                    MessageBox.Show("Категория с таким названием уже существует", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                categoryService_.AddCategory(name);

                MessageBox.Show("Категория успешно добавлена.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить категорию.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
