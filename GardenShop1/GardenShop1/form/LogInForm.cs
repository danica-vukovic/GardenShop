using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GardenShop1
{
    public partial class LogInForm : Form
    {
        public static User u;
        public LogInForm()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text) || String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show(Form.ActiveForm, Properties.Resources.enterUsernameAndPassword, Properties.Resources.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                User user = MySqlUtil.SignIn(textBoxName.Text, textBoxPassword.Text);
                if (user.Id == 0)
                {
                    MessageBox.Show(Form.ActiveForm, Properties.Resources.incorrectCredentials, Properties.Resources.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if (user.Active == false)
                {
                    MessageBox.Show(Form.ActiveForm, Properties.Resources.notActive, Properties.Resources.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                { 
                    this.Hide();
                    if (user.IsAdmin)
                    {
                        u = user;
                        AdminForm mainForm = new AdminForm(user);
                        mainForm.ShowDialog();
                    }
                    else
                    {
                        u = user;
                        WorkerForm workerForm = new WorkerForm(user);
                        workerForm.Show();
                    }
                }
            }
        }

        private void pictureBoxViewPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            pictureBoxViewPassword.Image = textBoxPassword.UseSystemPasswordChar ? Properties.Resources.eye : Properties.Resources.hidden;
        }

        private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
