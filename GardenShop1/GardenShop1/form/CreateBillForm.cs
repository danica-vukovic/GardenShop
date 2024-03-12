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
    public partial class CreateBillForm : Form
    {
        DataTable table = new DataTable("table");
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        List<Article> listArticles = new List<Article>();
        Dictionary<int, int> billItems = new Dictionary<int, int>();
        public CreateBillForm()
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
            buttonColumn.HeaderText = Properties.Resources.addToBill;
            buttonColumn.Text = Properties.Resources.add;
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
                        if (enteredQuantity <= currentQuantity)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[Properties.Resources.quantity].Value = currentQuantity - enteredQuantity;
                            if (billItems.ContainsKey(code))
                            {
                                billItems[code] += enteredQuantity;
                            }
                            else
                            {
                                billItems.Add(code, enteredQuantity);
                            }
                            refreshDataGrid2();
                        }
                        else
                        {
                            MessageBox.Show(Properties.Resources.state, Properties.Resources.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void RefreshData(List<Article> list)
        {
            table.Clear();

            foreach (Article a in list)
            {
                DataRow row = table.NewRow();
                row[Properties.Resources.code] = a.Code;
                row[Properties.Resources.name] = a.Name;
                row[Properties.Resources.price] = a.SalePrice;
                row[Properties.Resources.quantity] = a.AvailableQuantity;
                table.Rows.Add(row);
            }
            dataGridView1.Refresh();
        }

        private void refreshDataGrid2()
        {

            dataGridView2.Rows.Clear();
            foreach (int code in billItems.Keys)
            {
                dataGridView2.Rows.Add(code.ToString(), billItems[code].ToString(), null);
            }
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

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            BillForm newBillForm = new BillForm(billItems);
            billItems.Clear();
            dataGridView2.Rows.Clear();
            newBillForm.Show();
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

            btnAddBill.BackColor = Theme.pickedTheme.Dark;
            btnAddBill.Font = new Font(Theme.pickedTheme.Font, btnAddBill.Font.Size, btnAddBill.Font.Style);

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
                billItems.Remove(Convert.ToInt32(code));
                refreshDataGrid2();
            }
        }
    }
}
