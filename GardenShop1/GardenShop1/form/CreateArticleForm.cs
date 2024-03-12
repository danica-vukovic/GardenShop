using GardenShop1.data.dataAccess.mySQL;
using GardenShop1.data.model;
using GardenShop1.form;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenShop1
{
    public partial class CreateArticleForm : Form
    {
        String imageName = "";
        String imageLocation = "";

        public CreateArticleForm()
        {
            InitializeComponent();
            List<Category> categories = new List<Category>();

            foreach (Category category in new MySqlCategory().GetCategories())
            {
                categories.Add(category);
            }
            comboBoxCategory.DataSource = null;
            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";
            setTheme();

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

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.uploadPicture, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
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
                AvailableQuantity = Convert.ToInt32(textBoxavailableQuantity.Text),
                ProcurementPrice = Convert.ToDecimal(textBoxProcurementPrice.Text),
                SalePrice = Convert.ToDecimal(textBoxSalePrice.Text),
                Description = richTextBoxDescription.Text,
                Category = Convert.ToInt32(comboBoxCategory.SelectedValue),
                isAvailable = true

            };

            if (new MySqlArticle().FindByCode(article.Code) == null)
            {
                if (new MySqlArticle().AddArticle(article))
                {
                    string destination = ArticleDetailsForm.PATH + imageName;
                    File.Copy(imageLocation, destination, true);
                    MessageBox.Show(Properties.Resources.successfulCreate, Properties.Resources.successful, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.errorMessage, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBoxName.Text = string.Empty;
                textBoxCode.Text = string.Empty;
                textBoxavailableQuantity.Text = string.Empty;
                textBoxProcurementPrice.Text = string.Empty;
                textBoxSalePrice.Text = string.Empty;
                richTextBoxDescription.Text = string.Empty;
                imageName = string.Empty;
                comboBoxCategory.SelectedItem = null;
            }
            else
            {
                MessageBox.Show(Properties.Resources.existsProduct, Properties.Resources.tryAgain, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void setTheme()
        {

            Theme.setTheme(LogInForm.u.Theme);
            this.BackColor = Theme.pickedTheme.Light;

            Font currentFont = richTextBoxDescription.Font;

            richTextBoxDescription.BackColor = Theme.pickedTheme.Medium;
            richTextBoxDescription.Font = new Font(Theme.pickedTheme.Font, currentFont.Size, currentFont.Style);

            comboBoxCategory.BackColor = Theme.pickedTheme.Medium;
            comboBoxCategory.Font = new Font(Theme.pickedTheme.Font, currentFont.Size, currentFont.Style);

            btnAddArticle.BackColor = Theme.pickedTheme.Dark;
            btnAddArticle.Font = new Font(Theme.pickedTheme.Font, btnAddArticle.Font.Size, btnAddArticle.Font.Style);

            panel1.BackColor = Theme.pickedTheme.Medium;

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

    }
}

