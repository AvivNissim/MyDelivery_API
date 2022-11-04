using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public sealed class DbServices
    {
        private static DbServices DbInstance = null;
        private SqlConnection connection;
        private DbServices(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public static DbServices GetDbServices()
        {
            if (DbInstance is null)
                DbInstance = new DbServices(@"workstation id=mydeliverydb.mssql.somee.com;packet size=4096;user id=avivnissim_SQLLogin_1;pwd=4ap1itatvx;data source=mydeliverydb.mssql.somee.com;persist security info=False;initial catalog=mydeliverydb");

            return DbInstance;
        }

        public SqlCommand CreateCommand(string commandSTR) // Create Sql Command
        {
            SqlCommand cmd = new SqlCommand(commandSTR, this.connection);
            cmd.CommandTimeout = 10;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        
        public void ExecuteAndClose(SqlCommand cmd) // Exec Sql Command
        {
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        
        public DataTable Select(SqlCommand cmd) // Get Rows From DB
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Table");
                DataTable dt = ds.Tables["Table"];
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        
        public List<T> ConvertDataTable<T>(DataTable dt) // Create a list of objects from a DataTable
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        
        private T GetItem<T>(DataRow dr) // Check for each column in each row
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}