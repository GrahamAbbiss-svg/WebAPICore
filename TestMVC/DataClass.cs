using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestMVC
{
    public class DataClass
    {
        public static DataTable CustomerGroup()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\graha\source\repos\InterviewCode\InterviewCode\App_Data\Database1.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select CustomerGroupID,CustomerGroupName from CustomerGroup";

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds.Tables[0];
        }


        public static DataTable GovernanceGroup()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\graha\source\repos\InterviewCode\InterviewCode\App_Data\Database1.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 0 GovernanceGroupID,GovernanceGroupName from GovernanceGroup;";

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds.Tables[0];
        }


        public static DataTable DirectActivityType()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\graha\source\repos\InterviewCode\InterviewCode\App_Data\Database1.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select DirectTypeID,DirectTypeName from [CIMS].[DirectActivityType]";

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds.Tables[0];
        }

        public static DataTable StreamDetails()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\graha\source\repos\InterviewCode\InterviewCode\App_Data\Database1.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT streamID, streamName FROM [PPA].[CIMS].[Stream] where [Live] = 1 order by [streamName]";

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds.Tables[0];
        }

        public static SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<BO.SelectListItem> list = new List<BO.SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new BO.SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = int.Parse(row[valueField].ToString())
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public static DataTable GovernaceGroups(int? CustomerGroupID)
        {


            DataSet ds = new DataSet();
            DataTable _dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\graha\source\repos\InterviewCode\InterviewCode\App_Data\Database1.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select GovernanceGroupID,GovernanceGroupName from GovernanceGroup where CustomerGroupID = " + CustomerGroupID;

            da.SelectCommand = cmd;
            da.Fill(ds);

            _dt = ds.Tables[0];

            return _dt;
        }

        public static DataTable Products()
        {


            DataSet ds = new DataSet();
            DataTable _dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\graha\source\repos\InterviewCode\InterviewCode\App_Data\Database1.mdf; Integrated Security = True; Connect Timeout = 30");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ProductID,ProductName from [Products]";

            da.SelectCommand = cmd;
            da.Fill(ds);

            _dt = ds.Tables[0];

            return _dt;
        }


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
