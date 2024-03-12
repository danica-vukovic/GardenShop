using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenShop1
{
    public partial class ViewBills : Form
    {
        DataTable table = new DataTable("table");
        List<Bill> bills = new List<Bill>();
        int idUser = 0;
        public ViewBills(int id)
        {
            idUser = id;
            InitializeComponent();
            InitializeDataTable();
            setTheme();
        }
        private void InitializeDataTable()
        {
            table.Columns.Add(Properties.Resources.idBill, typeof(int));
            table.Columns.Add(Properties.Resources.date, typeof(string));
            table.Columns.Add(Properties.Resources.totalPrice, typeof(decimal));
            bills = new MySqlBill().GetBills(idUser);
            RefreshData(bills);
            textBoxSearchDate.Text = DateTime.Now.ToShortDateString();
            dataGridView1.DataSource = table;
        }

        public void RefreshData(List<Bill> filteredBills)
        {
            table.Clear();
            foreach (Bill bill in filteredBills)
            {
                DataRow row = table.NewRow();
                row[Properties.Resources.idBill] = bill.Id;
                row[Properties.Resources.date] = bill.Date;
                row[Properties.Resources.totalPrice] = bill.TotalPrice;
                table.Rows.Add(row);
            }

            dataGridView1.Refresh();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                int id = int.Parse(selectedRow.Cells[Properties.Resources.idBill].Value.ToString());
                Bill bill = bills.FirstOrDefault(bill => bill.Id == id);
                if (bill != null)
                {
                    OpenNewForm(bill);
                }
            }
        }

        private void OpenNewForm(Bill bill)
        {
            BillForm newBillForm = new BillForm(bill);
            newBillForm.Show();
        }

        private void textBoxSearchDate_TextChanged(object sender, EventArgs e)
        {
            string searchDate = textBoxSearchDate.Text;
            List<Bill> filteredBills = bills.Where(bill =>
                   bill.Date.ToString().ToLower().Contains(searchDate.ToLower())).ToList();

            RefreshData(filteredBills);
        }

        private void setTheme()
        {
            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;

            textBoxSearchDate.BackColor = Theme.pickedTheme.Medium;
            textBoxSearchDate.Font = new Font(Theme.pickedTheme.Font, textBoxSearchDate.Font.Size, textBoxSearchDate.Font.Style);

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
    }
}
