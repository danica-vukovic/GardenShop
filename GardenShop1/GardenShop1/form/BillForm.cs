using GardenShop1.data.dataAccess;
using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenShop1
{
    public partial class BillForm : Form
    {
        DataTable table = new DataTable("table");
        List<Article> list = new List<Article>();
        public BillForm(Dictionary<int, int> billItems)
        {
            InitializeComponent();
            InitializeDataTable();
            setTheme();
            decimal sum = 0;
            table.Clear();
            foreach (int code in billItems.Keys)
            {
                Article article = new MySqlArticle().FindByCode(code);
                DataRow row = table.NewRow();
                row[Properties.Resources.code] = article.Code;
                row[Properties.Resources.name] = article.Name;
                row[Properties.Resources.quantity] = billItems[code];
                row[Properties.Resources.price] = article.SalePrice;
                table.Rows.Add(row);
                sum += article.SalePrice * billItems[code];
                list.Add(article);
            }
            dataGridView1.DataSource = table;

            Bill bill = new Bill()
            {
                TotalPrice = sum,
                Date = DateTime.Now,
                IdUser = LogInForm.u.Id
            };
            int idBill = new MySqlBill().AddBill(bill);

            lblPrice.Text = bill.TotalPrice.ToString() + " KM";
            lblDate.Text = bill.Date.ToString();
            lblBillCreator.Text = LogInForm.u.Name + " " + LogInForm.u.Surname;

            foreach (Article a in list)
            {
                BillItem billItem = new BillItem()
                {
                    Quantity = billItems[a.Code],
                    Price = a.SalePrice,
                    IdArticle = a.Code,
                    IdBill = idBill
                };
                new MySqlArticle().UpdateQuantity(a.AvailableQuantity - billItem.Quantity, a.Code);
                new MySqlBillItem().AddBillItem(billItem);
            }
        }
        private void InitializeDataTable()
        {
            table.Columns.Add(Properties.Resources.code, typeof(string));
            table.Columns.Add(Properties.Resources.name, typeof(string));
            table.Columns.Add(Properties.Resources.quantity, typeof(int));
            table.Columns.Add(Properties.Resources.price, typeof(double));
        }

        public BillForm(Bill bill)
        {
            List<BillItem> list = new MySqlBillItem().GetBillItems(bill.Id);
            InitializeComponent();
            InitializeDataTable();
            setTheme();
            decimal sum = 0;
            table.Clear();
            foreach (BillItem billItem in list)
            {
                Article article = new MySqlArticle().FindByCode(billItem.IdArticle);
                DataRow row = table.NewRow();
                row[Properties.Resources.code] = article.Code;
                row[Properties.Resources.name] = article.Name;
                row[Properties.Resources.quantity] = billItem.Quantity;
                row[Properties.Resources.price] = article.SalePrice;
                table.Rows.Add(row);
                sum += article.SalePrice * billItem.Quantity;
            }
            dataGridView1.DataSource = table;
            lblPrice.Text = sum + " KM";
            lblDate.Text = bill.Date.ToString();
            User user = new MySqlUser().FindById(bill.IdUser);
            lblBillCreator.Text = user.Name + " " + user.Surname;
        }

        private void setTheme()
        {
            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;

            dataGridView1.Font = new Font(Theme.pickedTheme.Font, dataGridView1.Font.Size, dataGridView1.Font.Style);
            dataGridView1.BackgroundColor = Theme.pickedTheme.Light;
            dataGridView1.DefaultCellStyle.BackColor = Theme.pickedTheme.Light;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Theme.pickedTheme.Dark;
            dataGridView1.DefaultCellStyle.Font = new Font(Theme.pickedTheme.Font, dataGridView1.DefaultCellStyle.Font.Size, dataGridView1.DefaultCellStyle.Font.Style);

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    Font Font = label.Font;
                    label.Font = new Font(Theme.pickedTheme.Font, Font.Size, Font.Style);
                    label.BackColor = Theme.pickedTheme.Light;
                }
            }
        }

    }
}
