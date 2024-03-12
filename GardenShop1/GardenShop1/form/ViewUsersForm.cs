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
using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;

namespace GardenShop1
{

    public partial class ViewUsersForm : Form
    {

        DataTable table = new DataTable("table");
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

        int index;

        public ViewUsersForm()
        {
            InitializeComponent();
            InitializeDataTable();
            setTheme();
        }

        private void InitializeDataTable()
        {
            table.Columns.Add(Properties.Resources.firstname, typeof(string));
            table.Columns.Add(Properties.Resources.lastname, typeof(string));
            table.Columns.Add(Properties.Resources.username, typeof(string));
            table.Columns.Add(Properties.Resources.phoneNumber, typeof(string));

            List<User> users = new MySqlUser().GetUsers();
            RefreshFilteredData(users);
            dataGridView1.DataSource = table;
            buttonColumn.Name = "ButtonColumn";
            buttonColumn.HeaderText = Properties.Resources.removeAccount;
            buttonColumn.Text = Properties.Resources.remove;
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

        }
        public void RefreshFilteredData(List<User> list)
        {
            table.Clear();

            foreach (User user in list)
            {
                DataRow row = table.NewRow();
                row[Properties.Resources.firstname] = user.Name;
                row[Properties.Resources.lastname] = user.Surname;
                row[Properties.Resources.username] = user.Username;
                row[Properties.Resources.phoneNumber] = user.PhoneNumber;
                table.Rows.Add(row);
            }
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
            {
                string usernameToDelete = dataGridView1.Rows[e.RowIndex].Cells[Properties.Resources.username].Value.ToString();

                DialogResult result = MessageBox.Show(Properties.Resources.removeAccountQuestion, Properties.Resources.confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool isDeleted = new MySqlUser().DeleteUser(usernameToDelete);

                    if (isDeleted)
                    {
                        MessageBox.Show(Properties.Resources.successfulRemoveAccount, Properties.Resources.successfulRmv, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshFilteredData(new MySqlUser().GetUsers());
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
