using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

public partial class example : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    [WebMethod]
    public static bool InsertEmpDetails(string Name, string Salary, Int64 DeptId)
    {
        bool status;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SalonMSConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("usp_emp_insert", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@salary", Salary);
                cmd.Parameters.AddWithValue("@deptid", DeptId);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                Int32 retVal = cmd.ExecuteNonQuery();
                if (retVal > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                return status;
            }
        }
    }
}
