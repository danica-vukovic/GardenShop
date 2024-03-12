using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GardenShop1.data.dataAccess;
using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;

namespace GardenShop1
{
    public partial class CreateProcurementForm : Form
    {
        DataTable table = new DataTable("table");
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        List<Article> listArticles = new List<Article>();
        Dictionary<int, int> procurementItems = new Dictionary<int, int>();
        public CreateProcurementForm()
        {
            InitializeComponent();
            InitializeDataTable();
            setTheme();
        }
        private void InitializeDataTable()
        {
            table.Columns.Add(Properties.Resources.code, typeof(string));
            table.Columns.Add(Properties.Resources.name, typeof(string));
            table.Columns.Add(Properties.Resources.price, typeof(decimal));
            table.Columns.Add(Properties.Resources.quantity, typeof(int));
            dataGridView1.DataSource = table;

            listArticles = new MySqlArticle().GetArticles();
            RefreshData(listArticles);

            buttonColumn.Name = "ButtonColumn";
            buttonColumn.HeaderText = Properties.Resources.addProcurement;
            buttonColumn.Text = Properties.Resources.add;
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
        }

        public void RefreshData(List<Article> list)
        {
            table.Clear();

            foreach (Article a in list)
            {
                DataRow row = table.NewRow();
                row[Properties.Resources.code] = a.Code;
                row[Properties.Resources.name] = a.Name;
                row[Properties.Resources.price] = a.ProcurementPrice;
                row[Properties.Resources.quantity] = a.AvailableQuantity;
                table.Rows.Add(row);
            }
            dataGridView1.Refresh();
        }

        private void textBoxSearchCode_TextChanged(object sender, EventArgs e)
        {
            string searchCode = textBoxSearchCode.Text.ToLower();

            List<Article> filteredArticles = listArticles
                .Where(article =>
                    article.Code.ToString().ToLower().Contains(searchCode)
                )
                .ToList();

            RefreshData(filteredArticles);
        }

        private void refreshDataGrid2()
        {

            dataGridView2.Rows.Clear();
            foreach (int code in procurementItems.Keys)
            {
                dataGridView2.Rows.Add(code.ToString(), procurementItems[code].ToString(), null);
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
            {
                int code = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[Properties.Resources.code].Value.ToString());
                int currentQuantity = (int)dataGridView1.Rows[e.RowIndex].Cells[Properties.Resources.quantity].Value;
                string enteredQuantityString = InputBox.Show(Properties.Resources.enterQuantity, Properties.Resources.quantityEntry);

                if (!string.IsNullOrEmpty(enteredQuantityString))
                {

                    if (int.TryParse(enteredQuantityString, out int enteredQuantity))
                    {
                        if (procurementItems.ContainsKey(code))
                        {
                            procurementItems[code] += enteredQuantity;
                        }
                        else
                        {
                            procurementItems.Add(code, enteredQuantity);
                        }

                        refreshDataGrid2();
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddProcurement_Click(object sender, EventArgs e)
        {
            ProcurementForm newProcurementForm = new ProcurementForm(procurementItems);
            procurementItems.Clear();
            dataGridView2.Rows.Clear();
            newProcurementForm.Show();
        }

        private void setTheme()
        {
            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;

            textBoxSearchCode.BackColor = Theme.pickedTheme.Medium;
            textBoxSearchCode.Font = new Font(Theme.pickedTheme.Font, textBoxSearchCode.Font.Size, textBoxSearchCode.Font.Style);

            dataGridView1.Font = new Font(Theme.pickedTheme.Font, dataGridView1.Font.Size, dataGridView1.Font.Style);
            dataGridView1.BackgroundColor = Theme.pickedTheme.Light;
            dataGridView1.DefaultCellStyle.BackColor = Theme.pickedTheme.Light;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Theme.pickedTheme.Dark;
            dataGridView1.DefaultCellStyle.Font = new Font(Theme.pickedTheme.Font, dataGridView1.DefaultCellStyle.Font.Size, dataGridView1.DefaultCellStyle.Font.Style);

            dataGridView2.Font = new Font(Theme.pickedTheme.Font, dataGridView1.Font.Size, dataGridView1.Font.Style);
            dataGridView2.BackgroundColor = Theme.pickedTheme.Light;
            dataGridView2.DefaultCellStyle.BackColor = Theme.pickedTheme.Light;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Theme.pickedTheme.Dark;
            dataGridView2.DefaultCellStyle.Font = new Font(Theme.pickedTheme.Font, dataGridView1.DefaultCellStyle.Font.Size, dataGridView1.DefaultCellStyle.Font.Style);

            panel1.BackColor = Theme.pickedTheme.Medium;

            btnAddProcurement.BackColor = Theme.pickedTheme.Dark;
            btnAddProcurement.Font = new Font(Theme.pickedTheme.Font, btnAddProcurement.Font.Size, btnAddProcurement.Font.Style);

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    Font Font = label.Font;
                    label.Font = new Font(Theme.pickedTheme.Font, Font.Size, Font.Style);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["remove"].Index)
            {
                string code = dataGridView2.Rows[e.RowIndex].Cells["code"].Value.ToString();
                procurementItems.Remove(Convert.ToInt32(code));
                refreshDataGrid2();
            }
        }
    }
}
