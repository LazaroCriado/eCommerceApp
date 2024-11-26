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
    public class BrandBussines
    {
        private DataAccess dataAccess = new DataAccess();
        public List<Brand> MakeList()
        {
            List<Brand> list = new List<Brand>();

            try
            {
                dataAccess.SetQuery("select Id, Descripcion from MARCAS\r\n");
                dataAccess.ExecuteRead();
                while (dataAccess.Reader.Read())
                {
                    Brand brand = new Brand();
                    brand.Id = (int)dataAccess.Reader["Id"];
                    brand.Description = (string)dataAccess.Reader["Descripcion"];
                    list.Add(brand);
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
