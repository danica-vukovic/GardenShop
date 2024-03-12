namespace GardenShop1
{
    partial class WorkerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerForm));
            panel1 = new Panel();
            pictureMenu = new PictureBox();
            sidebar = new FlowLayoutPanel();
            panel3 = new Panel();
            panel4 = new Panel();
            btnCurrentUser = new Button();
            panelLogOut = new Panel();
            btnAddBill = new Button();
            panel5 = new Panel();
            btnViewBills = new Button();
            panel7 = new Panel();
            panel6 = new Panel();
            btnAddProcurement = new Button();
            panel2 = new Panel();
            btnViewProcurement = new Button();
            panel9 = new Panel();
            panel10 = new Panel();
            panel8 = new Panel();
            btnLogOut = new Button();
            timerSideBarTransition = new System.Windows.Forms.Timer(components);
            panelWelcome = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureMenu).BeginInit();
            sidebar.SuspendLayout();
            panel4.SuspendLayout();
            panelLogOut.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panelWelcome.SuspendLayout();
            SuspendLayout();
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
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(207, 195, 176);
            sidebar.Controls.Add(panel3);
            sidebar.Controls.Add(panel4);
            sidebar.Controls.Add(panelLogOut);
            sidebar.Controls.Add(panel5);
            sidebar.Controls.Add(panel6);
            sidebar.Controls.Add(panel2);
            sidebar.Controls.Add(panel10);
            sidebar.Controls.Add(panel8);
            resources.ApplyResources(sidebar, "sidebar");
            sidebar.Name = "sidebar";
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCurrentUser);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // btnCurrentUser
            // 
            btnCurrentUser.BackColor = Color.FromArgb(176, 166, 149);
            resources.ApplyResources(btnCurrentUser, "btnCurrentUser");
            btnCurrentUser.Name = "btnCurrentUser";
            btnCurrentUser.UseVisualStyleBackColor = false;
            btnCurrentUser.Click += btnCurrentUser_Click;
            // 
            // panelLogOut
            // 
            panelLogOut.Controls.Add(btnAddBill);
            resources.ApplyResources(panelLogOut, "panelLogOut");
            panelLogOut.Name = "panelLogOut";
            // 
            // btnAddBill
            // 
            btnAddBill.BackColor = Color.FromArgb(176, 166, 149);
            resources.ApplyResources(btnAddBill, "btnAddBill");
            btnAddBill.Name = "btnAddBill";
            btnAddBill.UseVisualStyleBackColor = false;
            btnAddBill.Click += btnAddBill_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnViewBills);
            panel5.Controls.Add(panel7);
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // btnViewBills
            // 
            btnViewBills.BackColor = Color.FromArgb(176, 166, 149);
            resources.ApplyResources(btnViewBills, "btnViewBills");
            btnViewBills.Name = "btnViewBills";
            btnViewBills.UseVisualStyleBackColor = false;
            btnViewBills.Click += btnViewBills_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(207, 195, 176);
            resources.ApplyResources(panel7, "panel7");
            panel7.Name = "panel7";
            // 
            // panel6
            // 
            panel6.Controls.Add(btnAddProcurement);
            resources.ApplyResources(panel6, "panel6");
            panel6.Name = "panel6";
            // 
            // btnAddProcurement
            // 
            btnAddProcurement.BackColor = Color.FromArgb(176, 166, 149);
            resources.ApplyResources(btnAddProcurement, "btnAddProcurement");
            btnAddProcurement.Name = "btnAddProcurement";
            btnAddProcurement.UseVisualStyleBackColor = false;
            btnAddProcurement.Click += btnAddProcurement_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnViewProcurement);
            panel2.Controls.Add(panel9);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // btnViewProcurement
            // 
            btnViewProcurement.BackColor = Color.FromArgb(176, 166, 149);
            resources.ApplyResources(btnViewProcurement, "btnViewProcurement");
            btnViewProcurement.Name = "btnViewProcurement";
            btnViewProcurement.UseVisualStyleBackColor = false;
            btnViewProcurement.Click += btnViewProcurement_Click;
            // 
            // panel9
            // 
            resources.ApplyResources(panel9, "panel9");
            panel9.Name = "panel9";
            // 
            // panel10
            // 
            resources.ApplyResources(panel10, "panel10");
            panel10.Name = "panel10";
            // 
            // panel8
            // 
            panel8.Controls.Add(btnLogOut);
            resources.ApplyResources(panel8, "panel8");
            panel8.Name = "panel8";
            // 
            // btnLogOut
            // 
            resources.ApplyResources(btnLogOut, "btnLogOut");
            btnLogOut.BackColor = Color.FromArgb(176, 166, 149);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // timerSideBarTransition
            // 
            timerSideBarTransition.Interval = 10;
            timerSideBarTransition.Tick += timerSideBarTransition_Tick;
            // 
            // panelWelcome
            // 
            panelWelcome.BackColor = Color.FromArgb(216, 207, 192);
            panelWelcome.Controls.Add(label1);
            resources.ApplyResources(panelWelcome, "panelWelcome");
            panelWelcome.Name = "panelWelcome";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.FromArgb(176, 166, 149);
            label1.Name = "label1";
            // 
            // WorkerForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(207, 195, 176);
            Controls.Add(panelWelcome);
            Controls.Add(panel1);
            Controls.Add(sidebar);
            IsMdiContainer = true;
            MaximizeBox = false;
            Name = "WorkerForm";
            FormClosed += WorkerForm_FormClosed;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureMenu).EndInit();
            sidebar.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panelLogOut.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureMenu;
        private FlowLayoutPanel sidebar;
        private Panel panel4;
        private Button btnAddBill;
        private Panel panel6;
        private Panel panelLogOut;
        private Button btnLogOut;
        private System.Windows.Forms.Timer sideBarTransition;
        private System.Windows.Forms.Timer timerSideBarTransition;
        private Button btnAddProcurement;
        private Panel panel3;
        private Button btnCurrentUser;
        private Panel panel5;
        private Panel panel7;
        private Button btnViewBills;
        private Panel panel2;
        private Panel panel9;
        private Panel panel10;
        private Panel panel8;
        private Button btnViewProcurement;
        private Panel panelWelcome;
        private Label label1;
        //private System.Windows.Forms.Timer sideBarTransition;
    }
}