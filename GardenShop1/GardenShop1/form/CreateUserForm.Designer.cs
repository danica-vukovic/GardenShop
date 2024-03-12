namespace GardenShop1
{
    partial class CreateUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserForm));
            panel1 = new Panel();
            label1 = new Label();
            lblName = new Label();
            textBoxName = new TextBox();
            lblSurname = new Label();
            textBoxUsername = new TextBox();
            lblUsername = new Label();
            textBoxPassword = new TextBox();
            lblPassword = new Label();
            textBoxPhoneNumber = new TextBox();
            lblPhoneName = new Label();
            textBoxSurname = new TextBox();
            pictureBoxUser = new PictureBox();
            btnCreateUser = new Button();
            pictureBoxViewPassword = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxViewPassword).BeginInit();
            SuspendLayout();
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
            // textBoxName
            // 
            resources.ApplyResources(textBoxName, "textBoxName");
            textBoxName.BackColor = Color.FromArgb(207, 195, 176);
            textBoxName.Name = "textBoxName";
            // 
            // lblSurname
            // 
            resources.ApplyResources(lblSurname, "lblSurname");
            lblSurname.Name = "lblSurname";
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
            // textBoxSurname
            // 
            resources.ApplyResources(textBoxSurname, "textBoxSurname");
            textBoxSurname.BackColor = Color.FromArgb(207, 195, 176);
            textBoxSurname.Name = "textBoxSurname";
            // 
            // pictureBoxUser
            // 
            resources.ApplyResources(pictureBoxUser, "pictureBoxUser");
            pictureBoxUser.Name = "pictureBoxUser";
            pictureBoxUser.TabStop = false;
            // 
            // btnCreateUser
            // 
            resources.ApplyResources(btnCreateUser, "btnCreateUser");
            btnCreateUser.BackColor = Color.FromArgb(144, 136, 123);
            btnCreateUser.ForeColor = Color.Black;
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.UseVisualStyleBackColor = false;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // pictureBoxViewPassword
            // 
            resources.ApplyResources(pictureBoxViewPassword, "pictureBoxViewPassword");
            pictureBoxViewPassword.Name = "pictureBoxViewPassword";
            pictureBoxViewPassword.TabStop = false;
            pictureBoxViewPassword.Click += pictureBoxViewPassword_Click;
            // 
            // NewUserForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 227, 213);
            ControlBox = false;
            Controls.Add(pictureBoxViewPassword);
            Controls.Add(btnCreateUser);
            Controls.Add(pictureBoxUser);
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
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewUserForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxViewPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label lblName;
        private TextBox textBoxName;
        private Label lblSurname;
        private TextBox textBoxUsername;
        private Label lblUsername;
        private TextBox textBoxPassword;
        private Label lblPassword;
        private TextBox textBoxPhoneNumber;
        private Label lblPhoneName;
        private TextBox textBoxSurname;
        private PictureBox pictureBoxUser;
        private Button btnCreateUser;
        private PictureBox pictureBoxViewPassword;
    }
}