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

        public DataSet GetData(string sqlQuery, string nameTable)
        {
            DataSet data_set = new DataSet();
            using (MySqlConnection cn = new MySqlConnection())
            {
                cn.ConnectionString = this.connectionString;
                try
                {
                    cn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn);

                    da.Fill(data_set, nameTable);
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

                    DataSet localDS = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, cn);
                    da.FillSchema(localDS, SchemaType.Source, nameTable);
                    da.Fill(localDS, nameTable);

                    localDS = ds;

                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

                    da.Update(localDS, nameTable);
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
