using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Service_ServiceProviderList : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("ServiceProviderList.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_ServiceProviderMasters
                                select new
                                {
                                    c.Address,
                                    c.BranchId,
                                    c.ContactNumber,
                                    c.CreatedAt,
                                    c.DateOfBirth,
                                    c.DateOfJoinning,
                                    c.Email,
                                    c.EmergencyContactNo,
                                    c.EmergencyContactPerson,
                                    c.Gender,
                                    c.Id,
                                    c.IdProofPhoto,
                                    c.ModifiedAt,
                                    c.MonthlySalary,
                                    c.Password,
                                    c.ProductComission,
                                    c.ProviderName,
                                    c.ServiceComission,
                                    c.ServiceProviderPhoto,
                                    c.ServiceProviderType,
                                    c.Status,
                                    c.Username,
                                    c.WorkingHourEnd,
                                    c.WorkingHourStart
                                }).ToList();
        ListView1.DataBind();
    }
}