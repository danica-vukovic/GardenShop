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
using GardenShop1.data.dataAccess;
using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;
using GardenShop1.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GardenShop1
{
    public partial class ArticleDetailsForm : Form
    {
        string code;
        String imageLocation = "";
        String imageName = "";
        Boolean isUpdatedPicture = false;
        ViewArticlesForm articleForm;
        public static readonly string PATH =Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\resources\\images\\";

        private void setTheme()
        {

            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;

            Font currentFont = richTextBoxDescription.Font;

            richTextBoxDescription.BackColor = Theme.pickedTheme.Medium;
            richTextBoxDescription.Font = new Font(Theme.pickedTheme.Font, currentFont.Size, currentFont.Style);

            comboBoxCategory.BackColor = Theme.pickedTheme.Medium;
            comboBoxCategory.Font = new Font(Theme.pickedTheme.Font, currentFont.Size, currentFont.Style);

            btnUpdate.BackColor = Theme.pickedTheme.Dark;
            btnUpdate.Font = new Font(Theme.pickedTheme.Font, btnUpdate.Font.Size, btnUpdate.Font.Style);

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    Font Font = label.Font;
                    label.Font = new Font(Theme.pickedTheme.Font, Font.Size, Font.Style);
                }
            }
            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    Font Font = textBox.Font;
                    textBox.BackColor = Theme.pickedTheme.Medium;
                    textBox.Font = new Font(Theme.pickedTheme.Font, Font.Size, Font.Style);
                }
            }

        }
        public ArticleDetailsForm(Article article, String previousCode, ViewArticlesForm form)
        {
            InitializeComponent();
            setTheme();
            code = previousCode;
            articleForm = form;

            List<Category> categories = new List<Category>();

            foreach (Category category in new MySqlCategory().GetCategories())
            {
                categories.Add(category);
            }

            comboBoxCategory.DataSource = null;
            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";

            textBoxCode.Text = Convert.ToString(article.Code);
            textBoxName.Text = article.Name;
            richTextBoxDescription.Text = article.Description;
            textBoxavailableQuantity.Text = article.AvailableQuantity.ToString();
            textBoxSalePrice.Text = article.SalePrice.ToString();
            textBoxProcurementPrice.Text = article.ProcurementPrice.ToString();
            imageName = article.Picture;
            if (System.IO.File.Exists(PATH + imageName))
            {
                Image image = Image.FromFile(PATH + imageName);
                pictureBox1.Image = image;
            }
            comboBoxCategory.SelectedValue= article.Category;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(Properties.Resources.updateQuestion, Properties.Resources.confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(textBoxName.Text) ||
                    string.IsNullOrEmpty(textBoxCode.Text) ||
                    string.IsNullOrEmpty(textBoxavailableQuantity.Text) ||
                    string.IsNullOrEmpty(textBoxProcurementPrice.Text) ||
                    string.IsNullOrEmpty(textBoxSalePrice.Text) ||
                    string.IsNullOrWhiteSpace(richTextBoxDescription.Text) || string.IsNullOrEmpty(imageName) || comboBoxCategory.SelectedIndex == -1)
                {
                    MessageBox.Show(Properties.Resources.fillFields);
                    return;
                }
                Article article = new Article()
                {
                    Code = Convert.ToInt32(textBoxCode.Text),
                    Name = textBoxName.Text,
                    Picture = imageName,
                    Description = richTextBoxDescription.Text,
                    ProcurementPrice = Convert.ToDecimal(textBoxProcurementPrice.Text),
                    SalePrice = Convert.ToDecimal(textBoxSalePrice.Text),
                    AvailableQuantity = Convert.ToInt32(textBoxavailableQuantity.Text),
                    Category = Convert.ToInt32(comboBoxCategory.SelectedValue)
                };
                
                    if (new MySqlArticle().UpdateArticle(article, code))
                    {
                        MessageBox.Show(Properties.Resources.successfulUpdate, Properties.Resources.successfulUpd, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(isUpdatedPicture)
                         {
                        File.Copy(imageLocation, PATH + imageName, true);
                         }
                        articleForm.RefreshData();

                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        imageName = Path.GetFileName(dialog.FileName);
                        imageLocation = dialog.FileName;
                        pictureBox1.Image = Image.FromFile(imageLocation);
                        isUpdatedPicture = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.uploadPicture, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
