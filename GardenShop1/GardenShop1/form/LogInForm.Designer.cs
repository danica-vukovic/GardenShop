namespace GardenShop1
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            pictureBoxUser = new PictureBox();
            textBoxName = new TextBox();
            lblName = new Label();
            pictureBoxViewPassword = new PictureBox();
            textBoxPassword = new TextBox();
            lblPassword = new Label();
            btnLogIn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxViewPassword).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxUser
            // 
            resources.ApplyResources(pictureBoxUser, "pictureBoxUser");
            pictureBoxUser.Name = "pictureBoxUser";
            pictureBoxUser.TabStop = false;
            // 
            // textBoxName
            // 
            resources.ApplyResources(textBoxName, "textBoxName");
            textBoxName.BackColor = Color.FromArgb(207, 195, 176);
            textBoxName.Name = "textBoxName";
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // pictureBoxViewPassword
            // 
            resources.ApplyResources(pictureBoxViewPassword, "pictureBoxViewPassword");
            pictureBoxViewPassword.Name = "pictureBoxViewPassword";
            pictureBoxViewPassword.TabStop = false;
            pictureBoxViewPassword.Click += pictureBoxViewPassword_Click;
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
            // btnLogIn
            // 
            resources.ApplyResources(btnLogIn, "btnLogIn");
            btnLogIn.BackColor = Color.FromArgb(144, 136, 123);
            btnLogIn.ForeColor = Color.Black;
            btnLogIn.Name = "btnLogIn";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // LogInForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 227, 213);
            Controls.Add(btnLogIn);
            Controls.Add(pictureBoxViewPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(lblPassword);
            Controls.Add(textBoxName);
            Controls.Add(lblName);
            Controls.Add(pictureBoxUser);
            MaximizeBox = false;
            Name = "LogInForm";
            FormClosed += LogInForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxViewPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxUser;
        private TextBox textBoxName;
        private Label lblName;
        private PictureBox pictureBoxViewPassword;
        private TextBox textBoxPassword;
        private Label lblPassword;
        private Button btnLogIn;
    }
}