namespace GardenShop1.form
{
    partial class UserAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountForm));
            btnUpdate = new Button();
            pictureBox1 = new PictureBox();
            pictureBoxViewPassword = new PictureBox();
            textBoxPhoneNumber = new TextBox();
            lblPhoneName = new Label();
            textBoxPassword = new TextBox();
            lblPassword = new Label();
            textBoxUsername = new TextBox();
            lblUsername = new Label();
            textBoxSurname = new TextBox();
            lblSurname = new Label();
            textBoxName = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            lblName = new Label();
            lblNameAndSurname = new Label();
            comboBoxTheme = new ComboBox();
            comboBoxLanguage = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxViewPassword).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            resources.ApplyResources(btnUpdate, "btnUpdate");
            btnUpdate.BackColor = Color.FromArgb(144, 136, 123);
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // pictureBoxViewPassword
            // 
            resources.ApplyResources(pictureBoxViewPassword, "pictureBoxViewPassword");
            pictureBoxViewPassword.Name = "pictureBoxViewPassword";
            pictureBoxViewPassword.TabStop = false;
            pictureBoxViewPassword.Click += pictureBoxViewPassword_Click;
            // 
            // textBoxPhoneNumber
            // 
            resources.ApplyResources(textBoxPhoneNumber, "textBoxPhoneNumber");
            textBoxPhoneNumber.BackColor = Color.FromArgb(207, 195, 176);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            // 
            // lblPhoneName
            // 
            resources.ApplyResources(lblPhoneName, "lblPhoneName");
            lblPhoneName.Name = "lblPhoneName";
            // 
            // textBoxPassword
            // 
            resources.ApplyResources(textBoxPassword, "textBoxPassword");
            textBoxPassword.BackColor = Color.FromArgb(207, 195, 176);
            textBoxPassword.Name = "textBoxPassword";
            // 
            // lblPassword
            // 
            resources.ApplyResources(lblPassword, "lblPassword");
            lblPassword.Name = "lblPassword";
            // 
            // textBoxUsername
            // 
            resources.ApplyResources(textBoxUsername, "textBoxUsername");
            textBoxUsername.BackColor = Color.FromArgb(207, 195, 176);
            textBoxUsername.Name = "textBoxUsername";
            // 
            // lblUsername
            // 
            resources.ApplyResources(lblUsername, "lblUsername");
            lblUsername.Name = "lblUsername";
            // 
            // textBoxSurname
            // 
            resources.ApplyResources(textBoxSurname, "textBoxSurname");
            textBoxSurname.BackColor = Color.FromArgb(207, 195, 176);
            textBoxSurname.Name = "textBoxSurname";
            // 
            // lblSurname
            // 
            resources.ApplyResources(lblSurname, "lblSurname");
            lblSurname.Name = "lblSurname";
            // 
            // textBoxName
            // 
            resources.ApplyResources(textBoxName, "textBoxName");
            textBoxName.BackColor = Color.FromArgb(207, 195, 176);
            textBoxName.Name = "textBoxName";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.FromArgb(207, 195, 176);
            panel1.Controls.Add(label1);
            panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // lblNameAndSurname
            // 
            resources.ApplyResources(lblNameAndSurname, "lblNameAndSurname");
            lblNameAndSurname.Name = "lblNameAndSurname";
            // 
            // comboBoxTheme
            // 
            resources.ApplyResources(comboBoxTheme, "comboBoxTheme");
            comboBoxTheme.BackColor = Color.FromArgb(207, 195, 176);
            comboBoxTheme.FormattingEnabled = true;
            comboBoxTheme.Items.AddRange(new object[] { resources.GetString("comboBoxTheme.Items"), resources.GetString("comboBoxTheme.Items1"), resources.GetString("comboBoxTheme.Items2"), resources.GetString("comboBoxTheme.Items3") });
            comboBoxTheme.Name = "comboBoxTheme";
            // 
            // comboBoxLanguage
            // 
            resources.ApplyResources(comboBoxLanguage, "comboBoxLanguage");
            comboBoxLanguage.BackColor = Color.FromArgb(207, 195, 176);
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Items.AddRange(new object[] { resources.GetString("comboBoxLanguage.Items"), resources.GetString("comboBoxLanguage.Items1") });
            comboBoxLanguage.Name = "comboBoxLanguage";
            // 
            // UserAccountForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 227, 213);
            Controls.Add(comboBoxLanguage);
            Controls.Add(comboBoxTheme);
            Controls.Add(lblNameAndSurname);
            Controls.Add(panel1);
            Controls.Add(pictureBoxViewPassword);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(lblPhoneName);
            Controls.Add(textBoxPassword);
            Controls.Add(lblPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(lblUsername);
            Controls.Add(textBoxSurname);
            Controls.Add(lblSurname);
            Controls.Add(textBoxName);
            Controls.Add(lblName);
            Controls.Add(btnUpdate);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserAccountForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxViewPassword).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnUpdate;
        private PictureBox pictureBox1;
        private PictureBox pictureBoxViewPassword;
        private TextBox textBoxPhoneNumber;
        private Label lblPhoneName;
        private TextBox textBoxPassword;
        private Label lblPassword;
        private TextBox textBoxUsername;
        private Label lblUsername;
        private TextBox textBoxSurname;
        private Label lblSurname;
        private TextBox textBoxName;
        private Panel panel1;
        private Label label1;
        private Label lblName;
        private Label lblNameAndSurname;
        private ComboBox comboBoxTheme;
        private ComboBox comboBoxLanguage;
    }
}