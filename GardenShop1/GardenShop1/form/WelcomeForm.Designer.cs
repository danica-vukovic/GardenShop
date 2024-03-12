namespace GardenShop1
{
    partial class WelcomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            lblTitle = new Label();
            pictureGarden = new PictureBox();
            btnLogIn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureGarden).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.BackColor = Color.FromArgb(235, 227, 213);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Name = "lblTitle";
            // 
            // pictureGarden
            // 
            resources.ApplyResources(pictureGarden, "pictureGarden");
            pictureGarden.Name = "pictureGarden";
            pictureGarden.TabStop = false;
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
            // WelcomeForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 227, 213);
            Controls.Add(btnLogIn);
            Controls.Add(pictureGarden);
            Controls.Add(lblTitle);
            ForeColor = Color.Black;
            MaximizeBox = false;
            Name = "WelcomeForm";
            FormClosed += WelcomeForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureGarden).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private PictureBox pictureGarden;
        private Button btnLogIn;
    }
}