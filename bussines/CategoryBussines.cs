using domain;
using eCommerceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bussines
{
    public class CategoryBussines
    {
        private DataAccess dataAccess = new DataAccess();
        public List<Category> MakeList()
        {
            List<Category> list = new List<Category>();
            try
            {
                dataAccess.SetQuery("select Id, Descripcion from CATEGORIAS\r\n");
                dataAccess.ExecuteRead();

                while (dataAccess.Reader.Read())
                {
                    Category category = new Category();
                    category.Id = (int)dataAccess.Reader["Id"];
                    category.Description = (string)dataAccess.Reader["Descripcion"];
                    list.Add(category);
                }
                return list;
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
    }
}
