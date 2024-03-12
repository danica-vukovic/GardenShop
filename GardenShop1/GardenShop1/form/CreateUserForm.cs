using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;
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

namespace GardenShop1
{
    public partial class CreateUserForm : Form
    {

        public ViewUsersForm viewUsers;
        public CreateUserForm()
        {
            InitializeComponent();
            setTheme();
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void pictureBoxViewPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            pictureBoxViewPassword.Image = textBoxPassword.UseSystemPasswordChar ? Properties.Resources.eye : Properties.Resources.hidden;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) ||
                string.IsNullOrEmpty(textBoxSurname.Text) ||
                string.IsNullOrEmpty(textBoxUsername.Text) ||
                string.IsNullOrEmpty(textBoxPassword.Text) ||
                string.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                MessageBox.Show(Properties.Resources.fillFields);
                return;
            }
            User user = new User()
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Password = textBoxPassword.Text,
                Username = textBoxUsername.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                IsAdmin = false,
                Active = true
            };
            if (!new MySqlUser().FindByUsername(user.Username))
            {
                if (new MySqlUser().AddUser(user))
                {
                    MessageBox.Show(Properties.Resources.successfulCreate, Properties.Resources.successful, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBoxName.Text = string.Empty;
                textBoxSurname.Text = string.Empty;
                textBoxUsername.Text = string.Empty;
                textBoxPassword.Text = string.Empty;
                textBoxPhoneNumber.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(Properties.Resources.takenUsername, Properties.Resources.tryAgain, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void setTheme()
        {

            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;
            panel1.BackColor= Theme.pickedTheme.Medium;

            btnCreateUser.BackColor = Theme.pickedTheme.Dark;
            btnCreateUser.Font = new Font(Theme.pickedTheme.Font, btnCreateUser.Font.Size, btnCreateUser.Font.Style);

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    Font Font = label.Font;
                    label.Font = new Font(Theme.pickedTheme.Font, Font.Size, Font.Style);
                }
            }
            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    Font Font = textBox.Font;
                    textBox.BackColor = Theme.pickedTheme.Medium;
                    textBox.Font = new Font(Theme.pickedTheme.Font, Font.Size, Font.Style);
                }
            }

        }
    }
}
