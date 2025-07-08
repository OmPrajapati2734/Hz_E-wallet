using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_StaffList : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("StaffList.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_StaffMasters
                                select new
                                {
                                    c.Address,
                                    c.BranchId,
                                    c.ContactNo,
                                    c.DateOfBirth,
                                    c.DateOfJoining,
                                    c.Department,
                                    c.Email,
                                    c.EmergencyContactNo,
                                    c.EmergencyContactPerson,
                                    c.EmployeeName,
                                    c.Gender,
                                    c.Id,
                                    c.IdProofPhoto,
                                    c.MonthlySalary,
                                    c.Password,
                                    c.Status,
                                    c.Username,
                                    c.UserPhoto,
                                    c.UserType,
                                    c.WorkingHourEnd,
                                    c.WorkingHourStart
                                }).ToList();
        ListView1.DataBind();
    }
}