using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace eCommerceApp
{
    public class DataAccess
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public DataAccess()
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["DBconnection"]);
            cmd = new SqlCommand();
        }

        public void SetQuery(string query)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
        }

        public void ExecuteRead() 
        {
            cmd.Connection = conn;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void ExecuteAction()
        {
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetParameter(string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value);
        }

        public void CloseConnection()
        {
            if (reader != null)
            {
                reader.Close();
            }
            conn.Close();
        }
    }
}
