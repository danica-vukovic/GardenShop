using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;
using Org.BouncyCastle.Asn1.Mozilla;

namespace GardenShop1
{
    public partial class ViewArticlesForm : Form
    {

        DataTable table = new DataTable("table");
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        List<Article> listArticles = new List<Article>();
        public ViewArticlesForm()
        {
            InitializeComponent();
            InitializeDataTable();
            setTheme();
        }
        private void InitializeDataTable()
        {
            table.Columns.Add(Properties.Resources.code, typeof(string));
            table.Columns.Add(Properties.Resources.name, typeof(string));
            table.Columns.Add(Properties.Resources.category, typeof(string));

            listArticles = new MySqlArticle().GetArticles();
            RefreshFilteredData(listArticles);

            dataGridView1.DataSource = table;
            buttonColumn.Name = "ButtonColumn";
            buttonColumn.HeaderText = Properties.Resources.removeArticle;
            buttonColumn.Text = Properties.Resources.remove;
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void setTheme()
        {
            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;

            textBoxSearchCategory.BackColor = Theme.pickedTheme.Medium;
            textBoxSearchCategory.Font = new Font(Theme.pickedTheme.Font, textBoxSearchCategory.Font.Size, textBoxSearchCategory.Font.Style);

            textBoxSearchCode.BackColor = Theme.pickedTheme.Medium;
            textBoxSearchCode.Font = new Font(Theme.pickedTheme.Font, textBoxSearchCategory.Font.Size, textBoxSearchCategory.Font.Style);

            dataGridView1.Font = new Font(Theme.pickedTheme.Font, dataGridView1.Font.Size, dataGridView1.Font.Style);
            dataGridView1.BackgroundColor = Theme.pickedTheme.Light;
            dataGridView1.DefaultCellStyle.BackColor = Theme.pickedTheme.Light;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Theme.pickedTheme.Dark;
            dataGridView1.DefaultCellStyle.Font = new Font(Theme.pickedTheme.Font, dataGridView1.DefaultCellStyle.Font.Size, dataGridView1.DefaultCellStyle.Font.Style);

            panel1.BackColor = Theme.pickedTheme.Medium;

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    Font Font = label.Font;
                    label.Font = new Font(Theme.pickedTheme.Font, Font.Size, Font.Style);
                }
            }
        }
        public void RefreshFilteredData(List<Article> list)
        {
            table.Clear();
            foreach (Article a in list)
            {
                DataRow row = table.NewRow();
                row[Properties.Resources.code] = a.Code;
                row[Properties.Resources.name] = a.Name;
                row[Properties.Resources.category] = new MySqlCategory().FindById(a.Category);
                table.Rows.Add(row);
            }
            dataGridView1.Refresh();
        }

        public void RefreshData()
        {
            listArticles = new MySqlArticle().GetArticles();
            RefreshFilteredData(listArticles);

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchCode = textBoxSearchCode.Text.ToLower();
            string searchCategory = textBoxSearchCategory.Text.ToLower();

            List<Article> filteredArticles = listArticles
                .Where(article =>
                    article.Code.ToString().ToLower().Contains(searchCode) &&
                    new MySqlCategory().FindById(article.Category).ToLower().Contains(searchCategory)
                )
                .ToList();

            RefreshFilteredData(filteredArticles);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex != dataGridView1.Columns["ButtonColumn"].Index)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string selectedCode = selectedRow.Cells[Properties.Resources.code].Value.ToString();
                Article selectedArticle = listArticles.FirstOrDefault(article => article.Code.ToString() == selectedCode);

                if (selectedArticle != null)
                {
                    OpenNewForm(selectedArticle, selectedCode);
                }

            }
        }
        private void OpenNewForm(Article article, string selectedCode)
        {

            ArticleDetailsForm detailsForm = new ArticleDetailsForm(article, selectedCode, this);

            detailsForm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
            {
                string articleToDelete = dataGridView1.Rows[e.RowIndex].Cells[Properties.Resources.code].Value.ToString();

                DialogResult result = MessageBox.Show(Properties.Resources.removeArticleQuestion, Properties.Resources.confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool isDeleted = new MySqlArticle().DeleteArticle(Convert.ToInt32(articleToDelete));

                    if (isDeleted)
                    {
                        MessageBox.Show(Properties.Resources.successfulRemove, Properties.Resources.successfulRmv, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshData();

                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
