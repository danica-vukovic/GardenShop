namespace GardenShop1
{
    partial class CreateArticleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateArticleForm));
            panel1 = new Panel();
            label1 = new Label();
            lblPicture = new Label();
            textBoxName = new TextBox();
            lblName = new Label();
            btnUploadPicture = new Button();
            lblDescription = new Label();
            richTextBoxDescription = new RichTextBox();
            textBoxavailableQuantity = new TextBox();
            lblavailableQuantity = new Label();
            textBoxSalePrice = new TextBox();
            lblSalePrice = new Label();
            textBoxProcurementPrice = new TextBox();
            lblProcurementPrice = new Label();
            comboBoxCategory = new ComboBox();
            btnAddArticle = new Button();
            textBoxCode = new TextBox();
            lblCode = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
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
            // lblPicture
            // 
            resources.ApplyResources(lblPicture, "lblPicture");
            lblPicture.Name = "lblPicture";
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
            // btnUploadPicture
            // 
            resources.ApplyResources(btnUploadPicture, "btnUploadPicture");
            btnUploadPicture.BackColor = Color.Transparent;
            btnUploadPicture.FlatAppearance.BorderSize = 0;
            btnUploadPicture.Name = "btnUploadPicture";
            btnUploadPicture.UseVisualStyleBackColor = false;
            btnUploadPicture.Click += btnUploadPicture_Click;
            // 
            // lblDescription
            // 
            resources.ApplyResources(lblDescription, "lblDescription");
            lblDescription.Name = "lblDescription";
            // 
            // richTextBoxDescription
            // 
            resources.ApplyResources(richTextBoxDescription, "richTextBoxDescription");
            richTextBoxDescription.BackColor = Color.FromArgb(207, 195, 176);
            richTextBoxDescription.Name = "richTextBoxDescription";
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
            // comboBoxCategory
            // 
            resources.ApplyResources(comboBoxCategory, "comboBoxCategory");
            comboBoxCategory.BackColor = Color.FromArgb(207, 195, 176);
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Items.AddRange(new object[] { resources.GetString("comboBoxCategory.Items"), resources.GetString("comboBoxCategory.Items1"), resources.GetString("comboBoxCategory.Items2") });
            comboBoxCategory.Name = "comboBoxCategory";
            // 
            // btnAddArticle
            // 
            resources.ApplyResources(btnAddArticle, "btnAddArticle");
            btnAddArticle.BackColor = Color.FromArgb(144, 136, 123);
            btnAddArticle.ForeColor = Color.Black;
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.UseVisualStyleBackColor = false;
            btnAddArticle.Click += btnAddArticle_Click;
            // 
            // textBoxCode
            // 
            resources.ApplyResources(textBoxCode, "textBoxCode");
            textBoxCode.BackColor = Color.FromArgb(207, 195, 176);
            textBoxCode.Name = "textBoxCode";
            // 
            // lblCode
            // 
            resources.ApplyResources(lblCode, "lblCode");
            lblCode.Name = "lblCode";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // NewArticleForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 227, 213);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(textBoxCode);
            Controls.Add(lblCode);
            Controls.Add(btnAddArticle);
            Controls.Add(comboBoxCategory);
            Controls.Add(textBoxProcurementPrice);
            Controls.Add(lblProcurementPrice);
            Controls.Add(textBoxSalePrice);
            Controls.Add(lblSalePrice);
            Controls.Add(textBoxavailableQuantity);
            Controls.Add(lblavailableQuantity);
            Controls.Add(richTextBoxDescription);
            Controls.Add(lblDescription);
            Controls.Add(btnUploadPicture);
            Controls.Add(lblPicture);
            Controls.Add(textBoxName);
            Controls.Add(lblName);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewArticleForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label lblPicture;
        private TextBox textBoxName;
        private Label lblName;
        private Button btnUploadPicture;
        private Label lblDescription;
        private RichTextBox richTextBoxDescription;
        private TextBox textBoxavailableQuantity;
        private Label lblavailableQuantity;
        private TextBox textBoxSalePrice;
        private Label lblSalePrice;
        private TextBox textBoxProcurementPrice;
        private Label lblProcurementPrice;
        private ComboBox comboBoxCategory;
        private Button btnAddArticle;
        private TextBox textBoxCode;
        private Label lblCode;
        private Label label2;
    }
}