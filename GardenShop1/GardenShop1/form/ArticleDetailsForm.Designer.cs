namespace GardenShop1
{
    partial class ArticleDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleDetailsForm));
            textBoxName = new TextBox();
            lblName = new Label();
            pictureBox1 = new PictureBox();
            btnUploadPicture = new Button();
            richTextBoxDescription = new RichTextBox();
            lblDescription = new Label();
            textBoxavailableQuantity = new TextBox();
            lblavailableQuantity = new Label();
            textBoxProcurementPrice = new TextBox();
            lblProcurementPrice = new Label();
            textBoxSalePrice = new TextBox();
            lblSalePrice = new Label();
            comboBoxCategory = new ComboBox();
            btnUpdate = new Button();
            label1 = new Label();
            lblCode = new Label();
            textBoxCode = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // btnUploadPicture
            // 
            resources.ApplyResources(btnUploadPicture, "btnUploadPicture");
            btnUploadPicture.BackColor = Color.FromArgb(235, 227, 213);
            btnUploadPicture.FlatAppearance.BorderSize = 0;
            btnUploadPicture.Name = "btnUploadPicture";
            btnUploadPicture.UseVisualStyleBackColor = false;
            btnUploadPicture.Click += btnUploadPicture_Click;
            // 
            // richTextBoxDescription
            // 
            resources.ApplyResources(richTextBoxDescription, "richTextBoxDescription");
            richTextBoxDescription.BackColor = Color.FromArgb(207, 195, 176);
            richTextBoxDescription.Name = "richTextBoxDescription";
            // 
            // lblDescription
            // 
            resources.ApplyResources(lblDescription, "lblDescription");
            lblDescription.Name = "lblDescription";
            // 
            // textBoxavailableQuantity
            // 
            resources.ApplyResources(textBoxavailableQuantity, "textBoxavailableQuantity");
            textBoxavailableQuantity.BackColor = Color.FromArgb(207, 195, 176);
            textBoxavailableQuantity.Name = "textBoxavailableQuantity";
            // 
            // lblavailableQuantity
            // 
            resources.ApplyResources(lblavailableQuantity, "lblavailableQuantity");
            lblavailableQuantity.Name = "lblavailableQuantity";
            // 
            // textBoxProcurementPrice
            // 
            resources.ApplyResources(textBoxProcurementPrice, "textBoxProcurementPrice");
            textBoxProcurementPrice.BackColor = Color.FromArgb(207, 195, 176);
            textBoxProcurementPrice.Name = "textBoxProcurementPrice";
            // 
            // lblProcurementPrice
            // 
            resources.ApplyResources(lblProcurementPrice, "lblProcurementPrice");
            lblProcurementPrice.Name = "lblProcurementPrice";
            // 
            // textBoxSalePrice
            // 
            resources.ApplyResources(textBoxSalePrice, "textBoxSalePrice");
            textBoxSalePrice.BackColor = Color.FromArgb(207, 195, 176);
            textBoxSalePrice.Name = "textBoxSalePrice";
            // 
            // lblSalePrice
            // 
            resources.ApplyResources(lblSalePrice, "lblSalePrice");
            lblSalePrice.Name = "lblSalePrice";
            // 
            // comboBoxCategory
            // 
            resources.ApplyResources(comboBoxCategory, "comboBoxCategory");
            comboBoxCategory.BackColor = Color.FromArgb(207, 195, 176);
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Items.AddRange(new object[] { resources.GetString("comboBoxCategory.Items"), resources.GetString("comboBoxCategory.Items1"), resources.GetString("comboBoxCategory.Items2") });
            comboBoxCategory.Name = "comboBoxCategory";
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
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblCode
            // 
            resources.ApplyResources(lblCode, "lblCode");
            lblCode.Name = "lblCode";
            // 
            // textBoxCode
            // 
            resources.ApplyResources(textBoxCode, "textBoxCode");
            textBoxCode.BackColor = Color.FromArgb(207, 195, 176);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.ReadOnly = true;
            // 
            // ArticleDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 227, 213);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(comboBoxCategory);
            Controls.Add(textBoxProcurementPrice);
            Controls.Add(lblProcurementPrice);
            Controls.Add(textBoxSalePrice);
            Controls.Add(lblSalePrice);
            Controls.Add(textBoxCode);
            Controls.Add(lblCode);
            Controls.Add(textBoxavailableQuantity);
            Controls.Add(lblavailableQuantity);
            Controls.Add(richTextBoxDescription);
            Controls.Add(lblDescription);
            Controls.Add(btnUploadPicture);
            Controls.Add(pictureBox1);
            Controls.Add(textBoxName);
            Controls.Add(lblName);
            MaximizeBox = false;
            Name = "ArticleDetailsForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Label lblName;
        private PictureBox pictureBox1;
        private Button btnUploadPicture;
        private RichTextBox richTextBoxDescription;
        private Label lblDescription;
        private TextBox textBoxavailableQuantity;
        private Label lblavailableQuantity;
        private TextBox textBoxProcurementPrice;
        private Label lblProcurementPrice;
        private TextBox textBoxSalePrice;
        private Label lblSalePrice;
        private ComboBox comboBoxCategory;
        private Button btnUpdate;
        private Label label1;
        private Label lblCode;
        private TextBox textBoxCode;
    }
}