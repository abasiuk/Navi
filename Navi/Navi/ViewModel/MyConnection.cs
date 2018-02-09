using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Navi.ViewModel
{
    public class MyConnection
    {
        private string connectionString = "SERVER=localhost;DATABASE=abas;UID=root;PASSWORD=;";

        public DataSet GetData(string sqlQuery)
        {
            DataSet data_set = new DataSet();
            using (MySqlConnection cn = new MySqlConnection())
            {
                cn.ConnectionString = this.connectionString;
                try
                {
                    cn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn);

                    da.Fill(data_set, "Table_DATA");
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    cn.Close();
                }
            }

            return data_set;
        }

        public void UpdateData(DataSet ds, string nameTable)
        {
            string sqlQuery = "Select * from " + nameTable + ";";
            using (MySqlConnection cn = new MySqlConnection())
            {
                cn.ConnectionString = this.connectionString;
                try
                {
                    cn.Open();

                    MySqlCommandBuilder cb = new MySqlCommandBuilder();
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn);

                    cb.DataAdapter.Update(ds.Tables[0]);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}
