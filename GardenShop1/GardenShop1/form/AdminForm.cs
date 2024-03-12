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
    public partial class AdminForm : Form
    {
        CreateUserForm newUserForm;
        ViewUsersForm usersForm;
        CreateArticleForm newArticleForm;
        ViewArticlesForm articleForm;
        CreateBillForm billForm;
        ViewBills viewBills;
        ViewProcurements viewProcurements;
        UserAccountForm userForm;
        User user;

        public AdminForm(User user)
        {
            this.user = user;
            setLanguage(user.Language);
            InitializeComponent();
            setTheme(user.Theme);

        }


        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            newArticleForm = new CreateArticleForm();
            newArticleForm.FormClosed += NewArticleForm_FormClosed;
            newArticleForm.MdiParent = this;
            newArticleForm.Dock = DockStyle.Fill;
            newArticleForm.Show();
        }

        private void NewArticleForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            newArticleForm = null;
        }

        bool sidebarExpand = true;
        private void sideBarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 37)
                {
                    sidebarExpand = false;
                    sideBarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 200)
                {
                    sidebarExpand = true;
                    sideBarTransition.Stop();
                }
            }
        }

        private void pictureMenu_Click(object sender, EventArgs e)
        {
            sideBarTransition.Start();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            newUserForm = new CreateUserForm();
            newUserForm.FormClosed += NewUserForm_FormClosed;
            newUserForm.MdiParent = this;
            newUserForm.Dock = DockStyle.Fill;
            newUserForm.Show();
        }

        private void NewUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            newUserForm = null;
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            usersForm = new ViewUsersForm();
            usersForm.FormClosed += UsersForm_FormClosed;
            usersForm.MdiParent = this;
            usersForm.Dock = DockStyle.Fill;
            usersForm.Show();
        }

        private void UsersForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            usersForm = null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Hide();

        }

        private void btnViewArticles_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            panelWelcome.Visible = false;
            articleForm = new ViewArticlesForm();
            articleForm.FormClosed += UsersForm_FormClosed;
            articleForm.MdiParent = this;
            articleForm.Dock = DockStyle.Fill;
            articleForm.Show();

        }

        private void btnViewBills_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            viewBills = new ViewBills(0);
            viewBills.FormClosed += ViewBills_FormClosed;
            viewBills.MdiParent = this;
            viewBills.Dock = DockStyle.Fill;
            viewBills.Show();
        }

        private void ViewBills_FormClosed(object? sender, FormClosedEventArgs e)
        {
            viewBills = null;

        }

        private void btnCurrentUser_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;

            userForm = new UserAccountForm(user);
            userForm.FormClosed += UserForm_FormClosed;
            userForm.reloadParent += UserForm_reloadParent;
            userForm.MdiParent = this;
            userForm.Dock = DockStyle.Fill;
            userForm.Show();
        }

        private void UserForm_reloadParent(object? sender, EventArgs e)
        {
            setLanguage(user.Language);
            this.Controls.Clear();
            InitializeComponent();
            setTheme(user.Theme);
        }

        private void setLanguage(int id)
        {
            switch (id)
            {
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Latn-RS");
                    break;
                case 2:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    break;
            }
        }

        private void setTheme(int theme)
        {
            Theme.setTheme(theme);
            this.panelWelcome.BackColor = Theme.pickedTheme.Light;
            this.label1.ForeColor = Theme.pickedTheme.Medium;
            this.panel1.BackColor = Theme.pickedTheme.Medium;
            this.panel2.BackColor = Theme.pickedTheme.Medium;
            this.sidebar.BackColor = Theme.pickedTheme.Medium;

            foreach (Control panelControl in this.Controls)
            {
                if (panelControl is Panel panel)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (control is Panel panel1)
                        {
                            foreach (Control control1 in panel1.Controls)
                            {
                                if (control1 is Button button)
                                {
                                    Font currentFont = button.Font;
                                    button.BackColor = Theme.pickedTheme.Dark;
                                    button.Font = new Font(Theme.pickedTheme.Font, currentFont.Size, currentFont.Style);
                                }
                            }

                        }
                    }
                }
            }

        }

        private void UserForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            userForm = null;
        }

        private void btnViewProcurement_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            viewProcurements = new ViewProcurements(0);
            viewProcurements.FormClosed += ViewProcurements_FormClosed;
            viewProcurements.MdiParent = this;
            viewProcurements.Dock = DockStyle.Fill;
            viewProcurements.Show();
        }

        private void ViewProcurements_FormClosed(object? sender, FormClosedEventArgs e)
        {
            viewProcurements = null;
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
