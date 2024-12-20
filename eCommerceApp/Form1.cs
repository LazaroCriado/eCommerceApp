﻿using System;
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
using System.Net.NetworkInformation;

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
                MessageBox.Show(ex.Message);
                throw ex; 
            }
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedField = cmbField.SelectedItem.ToString();
            if (selectedField == "Texto")
            {
                cmbCriteria.Items.Clear();
                cmbCriteria.Items.Add("Su Codigo contiene");
                cmbCriteria.Items.Add("Su Nombre contiene");
                cmbCriteria.Items.Add("Su Descripcion contiene");
                cmbCriteria.Items.Add("Su Marca contiene");
                cmbCriteria.Items.Add("Su Categoria contiene");
                cmbCriteria.SelectedIndex = 1;
            }
            else
            {
                cmbCriteria.Items.Clear();
                cmbCriteria.Items.Add("Mayor a");
                cmbCriteria.Items.Add("Menor a");
                cmbCriteria.Items.Add("Igual a");
                cmbCriteria.SelectedItem = "Menor a";
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cmbField.SelectedItem.ToString() == "Precio")
            {
                if (txtFilter.Text.Any(char.IsLetter))
                {
                    txtFilter.ForeColor = Color.Red;
                }
                else
                {
                    txtFilter.ForeColor = Color.Black;
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ArticleBussines articleBussines = new ArticleBussines();
            if (!validateFilter())
            {
                try
                {
                    string field = cmbField.SelectedItem.ToString();
                    string criteria = cmbCriteria.SelectedItem.ToString();
                    string filter = txtFilter.Text;
                    List<Article> list = articleBussines.Filter(field, criteria, filter);
                    dgvArticles.DataSource = list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Complete los campos correctamente");
            }
        }
        private bool validateFilter()
        {
            if (cmbField.SelectedIndex < 0)
            {
                return true;
            }
            if (cmbCriteria.SelectedIndex < 0)
            {
                return true;
            }
            if (cmbField.SelectedItem.ToString() == "Precio" && txtFilter.Text.Any(char.IsLetter))
            {
                return true;
            }
            return false;
        
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            AddArticle viewArticle = new AddArticle((Article)dgvArticles.CurrentRow.DataBoundItem, true);
            viewArticle.ShowDialog();
        }
    }
}
