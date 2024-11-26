using bussines;
using domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCommerceApp
{
    public partial class AddArticle : Form
    {
        private Article article = null;
        public AddArticle()
        {
            InitializeComponent();
        }
        public AddArticle(Article article)
        {
            InitializeComponent();
            this.article = article;

        }

        private void AddArticle_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadPic();
        }

        
        public void LoadPic()
        {
            try
            {
                if (txtFoto.Text != "")
                {
                    picBoxArticle.Load(txtFoto.Text);
                }
            }
            catch (Exception ex)
            {
                picBoxArticle.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQpZaeWxczipxrTdSIThz5hmwrRYhEeeAl5A&s");
                //MessageBox.Show(ex.Message);
                //throw ex;
            }
        }

        public void LoadComboBoxes()
        {
            BrandBussines brandBussines = new BrandBussines();
            CategoryBussines categoryBussines = new CategoryBussines();
            cmbBrand.DataSource = brandBussines.MakeList();
            //cmbBrand.ValueMember = "Id";
            //cmbBrand.DisplayMember = "Descripcion";
            cmbCategory.DataSource = categoryBussines.MakeList();
            //cmbCategory.ValueMember = "Id";
            //cmbCategory.DisplayMember = "Descripcion";
            if (this.article != null)
            {
                txtCode.Text = article.Code.ToString();
                txtName.Text = article.Name.ToString();
                txtDescription.Text = article.Description.ToString();
                cmbBrand.SelectedIndex = article.Brand.Id;
                cmbCategory.SelectedIndex = article.Category.Id;
                txtFoto.Text = article.UrlPicture.ToString();
                UpDownPrice.Value = article.Price;
            }
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            ArticleBussines articleBussines = new ArticleBussines();

            Article article = new Article();
            try
            {
                article.Code = txtCode.Text;
                article.Name = txtName.Text;
                article.Description = txtDescription.Text;
                article.Brand= (Brand)cmbBrand.SelectedItem;
                article.Category = (Category)cmbCategory.SelectedItem;
                article.UrlPicture = txtFoto.Text;
                article.Price = UpDownPrice.Value;
                if (ArticleValidation())
                {
                    articleBussines.Add(article);
                }
                if (string.IsNullOrEmpty(article.Id.ToString()))
                {
                    MessageBox.Show("Articulo agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("Articulo modificado exitosamente");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private bool ArticleValidation()
        {
            if (txtCode.Text == "*" || txtName.Text == "*" || txtDescription.Text == "*")
            {
                MessageBox.Show("Complete los campos obligatorios");
                return false;
            }
            else if (txtFoto.Text == string.Empty)
            {
                DialogResult rta = MessageBox.Show("El articulo se agregara sin foto, desea continuar?", "Foto" ,MessageBoxButtons.YesNo);
                if (rta == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    txtFoto.Text = null;
                }
            }
            if (UpDownPrice.Value == 0)
            {
                MessageBox.Show("El producto debe tener un precio mayor a 0");
                return false;
            }
            return true;

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                txtCode.Text = "*";
                txtCode.ForeColor = Color.Red;
            }
            else
            {
                txtCode.ForeColor = Color.Black;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = "*";
                txtName.ForeColor = Color.Red;
            }
            else
            {
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtDescrption_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                txtDescription.Text = "*";
                txtDescription.ForeColor = Color.Red;
            }
            else
            {
                txtDescription.ForeColor = Color.Black;
            }
        }
    }
}
