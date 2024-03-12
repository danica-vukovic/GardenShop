using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenShop1.form
{
    public partial class ProcurementForm : Form
    {
        DataTable table = new DataTable("table");
        List<Article> list = new List<Article>();
        public ProcurementForm(Dictionary<int, int> procurementItems)
        {
            InitializeComponent();
            InitializeDataTable();
            setTheme();

            decimal sum = 0;
            table.Clear();
            foreach (int code in procurementItems.Keys)
            {
                Article article = new MySqlArticle().FindByCode(code);
                DataRow row = table.NewRow();
                row[Properties.Resources.code] = article.Code;
                row[Properties.Resources.name] = article.Name;
                row[Properties.Resources.quantity] = procurementItems[code];
                row[Properties.Resources.price] = article.ProcurementPrice;
                table.Rows.Add(row);
                sum += article.ProcurementPrice * procurementItems[code];
                list.Add(article);
            }
            dataGridView1.DataSource = table;
            Random rand = new Random();
            Procurement procurement = new Procurement()
            {
                TotalPrice = sum,
                Date = DateTime.Now,
                IdUser = LogInForm.u.Id,
                IdProcurer = rand.Next(3) + 1,
            };
            int idProcurement = new MySqlProcurement().AddProcurement(procurement);

            lblPrice.Text = procurement.TotalPrice.ToString() + " KM";
            lblDate.Text = procurement.Date.ToString();
            lblProcurementCreator.Text = LogInForm.u.Name + " " + LogInForm.u.Surname;

            foreach (Article a in list)
            {
                ProcurementItem procurementItem = new ProcurementItem()
                {
                    Quantity = procurementItems[a.Code],
                    Price = a.ProcurementPrice,
                    IdArticle = a.Code,
                    IdProcurement = idProcurement
                };
                new MySqlArticle().UpdateQuantity(a.AvailableQuantity + procurementItem.Quantity, a.Code);
                new MySqlProcurementItem().AddProcurementItem(procurementItem);
            }
        }
        private void InitializeDataTable()
        {
            table.Columns.Add(Properties.Resources.code, typeof(string));
            table.Columns.Add(Properties.Resources.name, typeof(string));
            table.Columns.Add(Properties.Resources.quantity, typeof(int));
            table.Columns.Add(Properties.Resources.price, typeof(double));
        }

        public ProcurementForm(Procurement procurement)
        {

            List<ProcurementItem> list = new MySqlProcurementItem().GetProcurementItems(procurement.Id);
            InitializeComponent();
            InitializeDataTable();
            setTheme();
            decimal sum = 0;
            table.Clear();
            foreach (ProcurementItem procurementItem in list)
            {
                Article article = new MySqlArticle().FindByCode(procurementItem.IdArticle);
                DataRow row = table.NewRow();
                row[Properties.Resources.code] = article.Code;
                row[Properties.Resources.name] = article.Name;
                row[Properties.Resources.quantity] = procurementItem.Quantity;
                row[Properties.Resources.price] = article.ProcurementPrice;
                table.Rows.Add(row);
                sum += article.ProcurementPrice * procurementItem.Quantity;
            }
            dataGridView1.DataSource = table;
            lblPrice.Text = sum + " KM";
            lblDate.Text = procurement.Date.ToString();
            User user = new MySqlUser().FindById(procurement.IdUser);
            lblProcurementCreator.Text = user.Name + " " + user.Surname;
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
