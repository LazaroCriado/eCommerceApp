using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using domain;
using bussines;

namespace eCommerceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvArticlesLoad();
            cmbFiltersLoad();
            LoadPic();
        }
        private void cmbFiltersLoad()
        {
            cmbField.Items.Add("Texto");
            //cmbField.Items.Add("Marca");
            //cmbField.Items.Add("Categoria");
            cmbField.Items.Add("Precio");
        }
        private void LoadPic()
        {
            Article aux = (Article)dgvArticles.CurrentRow.DataBoundItem;
            
            try
            {
                if (aux.UrlPicture != null && aux.UrlPicture != "")
                {
                    picBoxArticle.Load(aux.UrlPicture);
                }
            }
            catch (Exception ex)
            {
                picBoxArticle.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQpZaeWxczipxrTdSIThz5hmwrRYhEeeAl5A&s");
                //MessageBox.Show(ex.Message);
                //throw ex;
            }
        }
        private void dgvArticlesLoad()
        {
            ArticleBussines articleBussines = new ArticleBussines();
            try
            {
                dgvArticles.DataSource = articleBussines.MakeList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvArticles_SelectionChanged(object sender, EventArgs e)
        {
            LoadPic();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddArticle addArticle = new AddArticle();
                addArticle.ShowDialog();
                dgvArticlesLoad();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ArticleBussines articleBussines = new ArticleBussines();
            try
            {
                DialogResult rta = MessageBox.Show("Está seguro de que desea eliminar el articulo?", "Eliminar Articulo", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    articleBussines.Delete((Article)dgvArticles.CurrentRow.DataBoundItem);
                    dgvArticlesLoad();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnModifiy_Click(object sender, EventArgs e)
        {
            try
            {
                AddArticle modifiyArticle = new AddArticle((Article)dgvArticles.CurrentRow.DataBoundItem);
                modifiyArticle.ShowDialog();
                dgvArticlesLoad();
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedField = cmbField.SelectedItem.ToString();
            if (selectedField == "Texto")
            {
                cmbCriteria.Items.Clear();
                cmbCriteria.Items.Add("Contiene");
            }
            else
            {
                cmbCriteria.Items.Clear();
                cmbCriteria.Items.Add("Mayor a");
                cmbCriteria.Items.Add("Menor a");
                cmbCriteria.Items.Add("Igual a");
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(cmbField.SelectedItem.ToString() == "Texto")
            {
                if (string.IsNullOrEmpty(txtFilter.Text))
                {
                    txtFilter.Text = "*";
                    txtFilter.ForeColor = Color.Red;
                }
                else 
                {
                    txtFilter.ForeColor= Color.Black;
                }
            }
            else
            {
                if (!txtFilter.Text.All(char.IsDigit))
                {
                    txtFilter.ForeColor = Color.Red;
                }
                else
                {
                    txtFilter.ForeColor= Color.Black;
                }
                
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ArticleBussines articleBussines = new ArticleBussines();
            List<Article> list = articleBussines.Filter(cmbField.SelectedItem.ToString(), cmbCriteria.SelectedItem.ToString(), txtFilter.Text);
            dgvArticles.DataSource = list;
        }
    }
}
