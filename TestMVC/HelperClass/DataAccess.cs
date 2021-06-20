using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.HelperClass
{
    public static class DataAccess
    {
        public static DataSet GetPrompts(int id)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\graha\source\repos\InterviewCode\InterviewCode\App_Data\Database1.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPrompts";

            SqlParameter objsqlParameter = new SqlParameter("@Id", id);
            objsqlParameter.DbType = DbType.Int32;
            objsqlParameter.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(objsqlParameter);

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds;

        }
    }
}
