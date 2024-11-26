using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using domain;
using eCommerceApp;

namespace bussines
{
    public class ArticleBussines
    {
        private DataAccess dataAccess = new DataAccess();
        
        public List<Article> MakeList()
        {
            List<Article> ArticlesList = new List<Article>();
            try
            {
                dataAccess.SetQuery("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS Marca, A.IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl as Foto, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C\r\nwhere A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                dataAccess.ExecuteRead();
                
                while (dataAccess.Reader.Read())
                {
                    Article article = new Article();
                    article.Id = (int)dataAccess.Reader["Id"];
                    article.Code = (string)dataAccess.Reader["Codigo"];
                    article.Name = (string)dataAccess.Reader["Nombre"];
                    article.Description = (string)dataAccess.Reader["Descripcion"];
                    article.Brand = new Brand();
                    article.Brand.Id = (int)dataAccess.Reader["IdMarca"];
                    article.Brand.Description = (string)dataAccess.Reader["Marca"];
                    article.Category = new Category();
                    article.Category.Id = (int)dataAccess.Reader["IdCategoria"];
                    article.Category.Description = (string)dataAccess.Reader["Categoria"];
                    article.UrlPicture = (string)dataAccess.Reader["Foto"];
                    article.Price = (decimal)dataAccess.Reader["Precio"];
                    ArticlesList.Add(article);
                }
                return ArticlesList;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

        public void Add(Article article)
        {
            try
            {
                dataAccess.SetQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@code, @name, @description, @idBrand, @idCategory, @UrlImagen, @Price)");
                dataAccess.SetParameter("@code", article.Code);
                dataAccess.SetParameter("@name", article.Name);
                dataAccess.SetParameter("@description", article.Description);
                dataAccess.SetParameter("@idBrand", article.Brand.Id);
                dataAccess.SetParameter("@idCategory", article.Category.Id);
                dataAccess.SetParameter("@UrlImagen", article.UrlPicture);
                dataAccess.SetParameter("@Price", article.Price);
                dataAccess.SetParameter("@id", article.Id);
                dataAccess.ExecuteAction();
            }
            catch (Exception)
            {
                throw;
            }
            finally { dataAccess.CloseConnection(); }
        }

        public void Modify(Article article)
        {
            try
            {
                dataAccess.SetQuery("update ARTICULOS set Codigo = @code, Nombre = @name, Descripcion = @description, IdMarca = @idBrand, IdCategoria = @idCategory, ImagenUrl=@UrlFoto, Precio = @price where id = @id");
                dataAccess.SetParameter("@code", article.Code);
                dataAccess.SetParameter("@name", article.Name);
                dataAccess.SetParameter("@description", article.Description);
                dataAccess.SetParameter("@idBrand", article.Brand.Id);
                dataAccess.SetParameter("@idCategory", article.Category.Id);
                dataAccess.SetParameter("@UrlFoto", article.UrlPicture);
                dataAccess.SetParameter("@Price",article.Price);
                dataAccess.SetParameter("@id", article.Id);
                dataAccess.ExecuteAction();
            }
            catch (Exception)
            {
                throw;
            }
            finally { dataAccess.CloseConnection(); }
        }

        public void Delete(Article article)
        {
            DataAccess dataAccess = new DataAccess();
            try
            {
                dataAccess.SetQuery("delete FROM ARTICULOS where id = @id");
                dataAccess.SetParameter("@id", article.Id);
                dataAccess.ExecuteAction();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

        public List<Article> Filter(string field, string criteria, string filter)
        {
            List<Article> FilteredArticles = new List<Article>();
            
            try
            {
                if(filter != string.Empty)
                {
                    string query = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS Marca, A.IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl as Foto, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id AND ";
                    if (field == "Texto")
                    {
                        switch (criteria)
                        {
                            case "Su Codigo contiene":
                                query += "Codigo like '%" + filter + "%'";
                                break;
                            case "Su Nombre contiene":
                                query += "Nombre like '%" + filter + "%'";
                                break;
                            case "Su Descripcion contiene":
                                query += "A.Descripcion like '%" + filter + "%'";
                                break;
                            case "Su Marca contiene":
                                query += "M.Descripcion like '%" + filter + "%'";
                                break;
                            case "Su Categoria contiene":
                                query += "C.Descripcion like '%" + filter + "%'";
                                break;
                            default:
                                query += "Nombre like '%" + filter + "%'";
                                break;
                        }
                    }
                    else
                    {
                        switch (criteria)
                        {
                            case "Mayor a":
                                query += "A.Precio > " + System.Convert.ToDecimal(filter);
                                break;
                            case "Menor a":
                                query += "A.Precio < " + System.Convert.ToDecimal(filter);
                                break;
                            default:
                                    query += "A.Precio = " + System.Convert.ToDecimal(filter);
                                break;
                        }
                    }
                
                    dataAccess.SetQuery(query);
                    dataAccess.ExecuteRead();
                    while (dataAccess.Reader.Read())
                    {
                        Article article = new Article();
                        article.Id = (int)dataAccess.Reader["Id"];
                        article.Code = (string)dataAccess.Reader["Codigo"];
                        article.Name = (string)dataAccess.Reader["Nombre"];
                        article.Description = (string)dataAccess.Reader["Descripcion"];
                        article.Brand = new Brand();
                        article.Brand.Id = (int)dataAccess.Reader["IdMarca"];
                        article.Brand.Description = (string)dataAccess.Reader["Marca"];
                        article.Category = new Category();
                        article.Category.Id = (int)dataAccess.Reader["IdCategoria"];
                        article.Category.Description = (string)dataAccess.Reader["Categoria"];
                        article.UrlPicture = (string)dataAccess.Reader["Foto"];
                        article.Price = (decimal)dataAccess.Reader["Precio"];
                        FilteredArticles.Add(article);
                    }
                }
                else
                {
                    string query = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS Marca, A.IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl as Foto, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                    dataAccess.SetQuery(query);
                    dataAccess.ExecuteRead();
                    while (dataAccess.Reader.Read())
                    {
                        Article article = new Article();
                        article.Id = (int)dataAccess.Reader["Id"];
                        article.Code = (string)dataAccess.Reader["Codigo"];
                        article.Name = (string)dataAccess.Reader["Nombre"];
                        article.Description = (string)dataAccess.Reader["Descripcion"];
                        article.Brand = new Brand();
                        article.Brand.Id = (int)dataAccess.Reader["IdMarca"];
                        article.Brand.Description = (string)dataAccess.Reader["Marca"];
                        article.Category = new Category();
                        article.Category.Id = (int)dataAccess.Reader["IdCategoria"];
                        article.Category.Description = (string)dataAccess.Reader["Categoria"];
                        article.UrlPicture = (string)dataAccess.Reader["Foto"];
                        article.Price = (decimal)dataAccess.Reader["Precio"];
                        FilteredArticles.Add(article);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { dataAccess.CloseConnection(); }
            return FilteredArticles;
        }
    }
}
