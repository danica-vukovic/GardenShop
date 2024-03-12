using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
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

namespace GardenShop1.form
{
    public partial class UserAccountForm : Form
    {
        User user;
        public event EventHandler reloadParent;
        public UserAccountForm(User user)
        {
            InitializeComponent();
            setTheme();
            textBoxPassword.UseSystemPasswordChar = true;
            this.user = user;
            textBoxName.Text = user.Name;
            textBoxPassword.Text = user.Password;
            textBoxPhoneNumber.Text = user.PhoneNumber;
            textBoxUsername.Text = user.Username;
            textBoxSurname.Text = user.Surname;
            lblNameAndSurname.Text = user.Name + " " + user.Surname;
            comboBoxLanguage.SelectedIndex = user.Language - 1;
            comboBoxTheme.SelectedIndex = user.Theme - 1;

        }

        private void pictureBoxViewPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            pictureBoxViewPassword.Image = textBoxPassword.UseSystemPasswordChar ? Properties.Resources.eye : Properties.Resources.hidden;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Properties.Resources.updateQuestion, Properties.Resources.confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
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

                if (user.Username == textBoxUsername.Text || !new MySqlUser().FindByUsername(textBoxUsername.Text))
                {
                    user.Name = textBoxName.Text;
                    user.Surname = textBoxSurname.Text;
                    user.PhoneNumber = textBoxPhoneNumber.Text;
                    user.Password = textBoxPassword.Text;
                    user.Username = textBoxUsername.Text;
                    lblNameAndSurname.Text = user.Name + " " + user.Surname;

                    if (comboBoxLanguage.SelectedIndex >= 0)
                    {
                        user.Language = comboBoxLanguage.SelectedIndex + 1;
                    }
                    if (comboBoxTheme.SelectedIndex >= 0)
                    {
                        user.Theme = comboBoxTheme.SelectedIndex + 1;
                    }

                    if (new MySqlUser().UpdateUser(user))
                    {
                        MessageBox.Show(Properties.Resources.successfulUpdate, Properties.Resources.successfulUpd, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadParent?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.takenUsername, Properties.Resources.tryAgain, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void setTheme()
        {

            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;
            panel1.BackColor = Theme.pickedTheme.Medium;

            comboBoxLanguage.BackColor = Theme.pickedTheme.Medium;
            comboBoxLanguage.Font = new Font(Theme.pickedTheme.Font, comboBoxLanguage.Font.Size, comboBoxLanguage.Font.Style);

            comboBoxTheme.BackColor = Theme.pickedTheme.Medium;
            comboBoxTheme.Font = new Font(Theme.pickedTheme.Font, comboBoxTheme.Font.Size, comboBoxTheme.Font.Style);

            btnUpdate.BackColor = Theme.pickedTheme.Dark;
            btnUpdate.Font = new Font(Theme.pickedTheme.Font, btnUpdate.Font.Size, btnUpdate.Font.Style);

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
