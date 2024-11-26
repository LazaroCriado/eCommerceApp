using bussines;
using domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCommerceApp
{
    public partial class AddArticle : Form
    {
        private Article article = null;
        private bool ViewDetail = false;
        private OpenFileDialog openFileDialog = null;
        public AddArticle()
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }
        public AddArticle(Article article)
        {
            InitializeComponent();
            this.article = article;
            Text = "Modificar Articulo";
            btnAcept.Text = "Modificar";
        }

        public AddArticle(Article currentArticle, bool detail)
        {
            InitializeComponent();
            this.article = currentArticle;
            this.ViewDetail = detail;
            Text = "Detalle de Articulo";
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
                if (this.ViewDetail)
                {
                    onlyView();
                }
            }
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            ArticleBussines articleBussines = new ArticleBussines();

            
            try
            {
                if (this.article == null)
                {   
                    article = new Article();
                }
                article.Code = txtCode.Text;
                article.Name = txtName.Text;
                article.Description = txtDescription.Text;
                article.Brand= (Brand)cmbBrand.SelectedItem;
                article.Category = (Category)cmbCategory.SelectedItem;
                article.UrlPicture = txtFoto.Text;
                article.Price = UpDownPrice.Value;

                if (article.Id != 0)
                {
                    if (ArticleValidation())
                    {
                        articleBussines.Modify(article);
                        MessageBox.Show("Articulo modificado exitosamente");
                    }
                }
                else
                {
                    if (ArticleValidation())
                    {
                        articleBussines.Add(article);
                        MessageBox.Show("Articulo agregado exitosamente");
                    }
                }

                if (openFileDialog != null && !txtFoto.Text.ToUpper().Contains("HTTP") && !File.Exists(ConfigurationManager.AppSettings["images_folder"] + openFileDialog.SafeFileName))
                {
                    File.Copy(openFileDialog.FileName, ConfigurationManager.AppSettings["images_folder"] + openFileDialog.SafeFileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            Close();
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
            else if (txtCode.Text.Length>1 && txtCode.Text.Contains("*"))
            {
                int index = txtCode.Text.IndexOf("*"); // Find its position
                txtCode.Text = txtCode.Text.Remove(index, 1); // Remove it
                txtCode.ForeColor = Color.Black;
                txtCode.SelectionStart = txtCode.Text.Length;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = "*";
                txtName.ForeColor = Color.Red;
            }
            else if (txtName.Text.Length > 1 && txtName.Text.Contains("*"))
            {
                int index = txtName.Text.IndexOf("*"); // Find its position
                txtName.Text = txtName.Text.Remove(index, 1); // Remove it
                txtName.ForeColor = Color.Black;
                txtName.SelectionStart = txtName.Text.Length;
            }
        }

        private void txtDescrption_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                txtDescription.Text = "*";
                txtDescription.ForeColor = Color.Red;
            }
            else if (txtDescription.Text.Length > 1 && txtDescription.Text.Contains("*"))
            {
                
                int index = txtDescription.Text.IndexOf("*"); // Find its position
                txtDescription.Text = txtDescription.Text.Remove(index, 1); // Remove it
                txtDescription.ForeColor = Color.Black;
                txtDescription.SelectionStart = txtDescription.Text.Length;
            }
        }

        private void correctCursorPosition(TextBox txtBox)
        {
            txtBox.SelectionStart = 0;
        }

        private void onlyView()
        {
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtFoto.Enabled = false;
            btnAddImage.Enabled = false;
            txtDescription.Enabled = false;
            cmbBrand.Enabled = false;
            cmbCategory.Enabled = false;
            btnAcept.Enabled = false;
            btnCancel.Text = "Listo";
            UpDownPrice.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_Click(object sender, EventArgs e)
        {
            correctCursorPosition(txtCode);
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            correctCursorPosition(txtName);
        }

        private void txtDescription_Click(object sender, EventArgs e)
        {
            correctCursorPosition(txtDescription);
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpg|*.jpg|png|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFoto.Text = openFileDialog.FileName;
                LoadPic();

                //para guardar la imagen en una carpeta

                //File.Copy(openFileDialog.FileName, ConfigurationManager.AppSettings["images_folder"] + openFileDialog.SafeFileName);
            }
        }
    }
}
