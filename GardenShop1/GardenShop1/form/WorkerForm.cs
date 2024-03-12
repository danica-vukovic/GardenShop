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
    public partial class WorkerForm : Form
    {
        CreateBillForm billForm;
        CreateProcurementForm procurementForm;
        UserAccountForm userForm;
        ViewBills viewBills;
        ViewProcurements viewProcurements;
        User user;
        public WorkerForm(User u)
        {
            user = u;
            setLanguage(u.Language);
            InitializeComponent();
            setTheme(u.Theme);
        }

        private void pictureMenu_Click(object sender, EventArgs e)
        {
            timerSideBarTransition.Start();
        }
        bool sidebarExpand = true;

        private void timerSideBarTransition_Tick(object sender, EventArgs e)
        {

            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 37)
                {
                    sidebarExpand = false;
                    timerSideBarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 200)
                {
                    sidebarExpand = true;
                    timerSideBarTransition.Stop();
                }
            }
        }

        private void btnAddProcurement_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            procurementForm = new CreateProcurementForm();
            procurementForm.FormClosed += ProcurementForm_FormClosed;
            procurementForm.MdiParent = this;
            procurementForm.Dock = DockStyle.Fill;
            procurementForm.Show();

        }

        private void ProcurementForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            procurementForm = null;
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

        private void UserForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            userForm = null;
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            billForm = new CreateBillForm();
            billForm.FormClosed += BillForm_FormClosed;
            billForm.MdiParent = this;
            billForm.Dock = DockStyle.Fill;
            billForm.Show();

        }

        private void BillForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            billForm = null;
        }

        private void btnViewBills_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            viewBills = new ViewBills(user.Id);
            viewBills.FormClosed += ViewBills_FormClosed;
            viewBills.MdiParent = this;
            viewBills.Dock = DockStyle.Fill;
            viewBills.Show();
        }

        private void ViewBills_FormClosed(object? sender, FormClosedEventArgs e)
        {
            viewBills = null;
        }

        private void btnViewProcurement_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            viewProcurements = new ViewProcurements(user.Id);
            viewProcurements.FormClosed += ViewProcurements_FormClosed;
            viewProcurements.MdiParent = this;
            viewProcurements.Dock = DockStyle.Fill;
            viewProcurements.Show();
        }

        private void ViewProcurements_FormClosed(object? sender, FormClosedEventArgs e)
        {
            viewProcurements = null;
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Hide();
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

        private void WorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
