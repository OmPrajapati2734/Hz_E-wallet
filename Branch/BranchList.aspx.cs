using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Branch_BranchList : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../BranchList.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;

        } 
        ListView1.DataSource = (from c in dbc.tbl_BranchMasters
                                select new
                                {
                                    c.BranchName,
                                    c.BranchPhoto,
                                    c.BranchType,
                                    c.Category,
                                    c.City,
                                    c.CreatedAt,
                                    c.CreatedBy,
                                    c.Email,
                                    c.FullAddress,
                                    c.GoogleMapLocation,
                                    c.GSTNumber,
                                    c.Id,
                                    c.LandMark,
                                    c.Loginid,
                                    c.ManagerEmail,
                                    c.ManagerMobile,
                                    c.ManagerName,
                                    c.Mobile,
                                    c.ModifiedAt,
                                    c.ModifiedBy,
                                    c.Password,
                                    c.PINcode,
                                    c.Status,
                                    c.WhatsApp
                                }).ToList();
        ListView1.DataBind();
    }
}