namespace GardenShop1
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            sidebar = new FlowLayoutPanel();
            panel2 = new Panel();
            panelNewUser = new Panel();
            btnCurrentUser = new Button();
            panelUsers = new Panel();
            btnAddNewUser = new Button();
            panelNewArticle = new Panel();
            btnViewUsers = new Button();
            panel3 = new Panel();
            btnAddArticle = new Button();
            panel4 = new Panel();
            btnViewArticles = new Button();
            panel6 = new Panel();
            btnViewBills = new Button();
            panelLogOut = new Panel();
            btnViewProcurement = new Button();
            panel5 = new Panel();
            panel7 = new Panel();
            btnLogOut = new Button();
            panel1 = new Panel();
            pictureMenu = new PictureBox();
            sideBarTransition = new System.Windows.Forms.Timer(components);
            fileSystemWatcher1 = new FileSystemWatcher();
            panelWelcome = new Panel();
            label1 = new Label();
            sidebar.SuspendLayout();
            panelNewUser.SuspendLayout();
            panelUsers.SuspendLayout();
            panelNewArticle.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panelLogOut.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            panelWelcome.SuspendLayout();
            SuspendLayout();
            // 
            // sidebar
            // 
            resources.ApplyResources(sidebar, "sidebar");
            sidebar.BackColor = Color.FromArgb(207, 195, 176);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(panelNewUser);
            sidebar.Controls.Add(panelUsers);
            sidebar.Controls.Add(panelNewArticle);
            sidebar.Controls.Add(panel3);
            sidebar.Controls.Add(panel4);
            sidebar.Controls.Add(panel6);
            sidebar.Controls.Add(panelLogOut);
            sidebar.Controls.Add(panel7);
            sidebar.Name = "sidebar";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = Color.FromArgb(207, 195, 176);
            panel2.Name = "panel2";
            // 
            // panelNewUser
            // 
            resources.ApplyResources(panelNewUser, "panelNewUser");
            panelNewUser.Controls.Add(btnCurrentUser);
            panelNewUser.Name = "panelNewUser";
            // 
            // btnCurrentUser
            // 
            resources.ApplyResources(btnCurrentUser, "btnCurrentUser");
            btnCurrentUser.BackColor = Color.FromArgb(176, 166, 149);
            btnCurrentUser.Name = "btnCurrentUser";
            btnCurrentUser.UseVisualStyleBackColor = false;
            btnCurrentUser.Click += btnCurrentUser_Click;
            // 
            // panelUsers
            // 
            resources.ApplyResources(panelUsers, "panelUsers");
            panelUsers.Controls.Add(btnAddNewUser);
            panelUsers.Name = "panelUsers";
            // 
            // btnAddNewUser
            // 
            resources.ApplyResources(btnAddNewUser, "btnAddNewUser");
            btnAddNewUser.BackColor = Color.FromArgb(176, 166, 149);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.UseVisualStyleBackColor = false;
            btnAddNewUser.Click += btnAddNewUser_Click;
            // 
            // panelNewArticle
            // 
            resources.ApplyResources(panelNewArticle, "panelNewArticle");
            panelNewArticle.Controls.Add(btnViewUsers);
            panelNewArticle.Name = "panelNewArticle";
            // 
            // btnViewUsers
            // 
            resources.ApplyResources(btnViewUsers, "btnViewUsers");
            btnViewUsers.BackColor = Color.FromArgb(176, 166, 149);
            btnViewUsers.Name = "btnViewUsers";
            btnViewUsers.UseVisualStyleBackColor = false;
            btnViewUsers.Click += btnViewUsers_Click;
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Controls.Add(btnAddArticle);
            panel3.Name = "panel3";
            // 
            // btnAddArticle
            // 
            resources.ApplyResources(btnAddArticle, "btnAddArticle");
            btnAddArticle.BackColor = Color.FromArgb(176, 166, 149);
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.UseVisualStyleBackColor = false;
            btnAddArticle.Click += btnAddArticle_Click;
            // 
            // panel4
            // 
            resources.ApplyResources(panel4, "panel4");
            panel4.Controls.Add(btnViewArticles);
            panel4.Name = "panel4";
            // 
            // btnViewArticles
            // 
            resources.ApplyResources(btnViewArticles, "btnViewArticles");
            btnViewArticles.BackColor = Color.FromArgb(176, 166, 149);
            btnViewArticles.Name = "btnViewArticles";
            btnViewArticles.UseVisualStyleBackColor = false;
            btnViewArticles.Click += btnViewArticles_Click;
            // 
            // panel6
            // 
            resources.ApplyResources(panel6, "panel6");
            panel6.Controls.Add(btnViewBills);
            panel6.Name = "panel6";
            // 
            // btnViewBills
            // 
            resources.ApplyResources(btnViewBills, "btnViewBills");
            btnViewBills.BackColor = Color.FromArgb(176, 166, 149);
            btnViewBills.Name = "btnViewBills";
            btnViewBills.UseVisualStyleBackColor = false;
            btnViewBills.Click += btnViewBills_Click;
            // 
            // panelLogOut
            // 
            resources.ApplyResources(panelLogOut, "panelLogOut");
            panelLogOut.Controls.Add(btnViewProcurement);
            panelLogOut.Controls.Add(panel5);
            panelLogOut.Name = "panelLogOut";
            // 
            // btnViewProcurement
            // 
            resources.ApplyResources(btnViewProcurement, "btnViewProcurement");
            btnViewProcurement.BackColor = Color.FromArgb(176, 166, 149);
            btnViewProcurement.Name = "btnViewProcurement";
            btnViewProcurement.UseVisualStyleBackColor = false;
            btnViewProcurement.Click += btnViewProcurement_Click;
            // 
            // panel5
            // 
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // panel7
            // 
            resources.ApplyResources(panel7, "panel7");
            panel7.Controls.Add(btnLogOut);
            panel7.Name = "panel7";
            // 
            // btnLogOut
            // 
            resources.ApplyResources(btnLogOut, "btnLogOut");
            btnLogOut.BackColor = Color.FromArgb(176, 166, 149);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.FromArgb(207, 195, 176);
            panel1.Controls.Add(pictureMenu);
            panel1.Name = "panel1";
            // 
            // pictureMenu
            // 
            resources.ApplyResources(pictureMenu, "pictureMenu");
            pictureMenu.Name = "pictureMenu";
            pictureMenu.TabStop = false;
            pictureMenu.Click += pictureMenu_Click;
            // 
            // sideBarTransition
            // 
            sideBarTransition.Interval = 10;
            sideBarTransition.Tick += sideBarTransition_Tick;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panelWelcome
            // 
            resources.ApplyResources(panelWelcome, "panelWelcome");
            panelWelcome.BackColor = Color.FromArgb(216, 207, 192);
            panelWelcome.Controls.Add(label1);
            panelWelcome.Name = "panelWelcome";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.FromArgb(176, 166, 149);
            label1.Name = "label1";
            // 
            // AdminForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 227, 213);
            Controls.Add(panelWelcome);
            Controls.Add(panel1);
            Controls.Add(sidebar);
            ForeColor = Color.Black;
            IsMdiContainer = true;
            MaximizeBox = false;
            Name = "AdminForm";
            FormClosed += AdminForm_FormClosed;
            sidebar.ResumeLayout(false);
            panelNewUser.ResumeLayout(false);
            panelUsers.ResumeLayout(false);
            panelNewArticle.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panelLogOut.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel sidebar;
        private Panel panel1;
        private PictureBox pictureMenu;
        private Panel panel2;
        private Button btnAddNewUser;
        private Panel panelNewUser;
        private Panel panelUsers;
        private Button btnViewUsers;
        private Panel panelNewArticle;
        private Button btnAddArticle;
        private Panel panel3;
        private Button btnViewArticles;
        private Panel panel4;
        private Panel panel6;
        private Panel panelLogOut;
        private Button btnLogOut;
        private System.Windows.Forms.Timer sideBarTransition;
        private FileSystemWatcher fileSystemWatcher1;
        private Button btnCurrentUser;
        private Button btnViewBills;
        private Button btnViewProcurement;
        private Panel panelWelcome;
        private Label label1;
        private Panel panel5;
        private Panel panel7;
    }
}