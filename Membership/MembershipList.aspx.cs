using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Membership_MembershipList : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../MembershipList.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_MembershipMasters
                                join c2 in dbc.tbl_BranchMasters on c.BranchId equals c2.Id
                                select new
                                {

                                    c.CreatedAt,
                                    c.DiscountOnPackage,
                                    c.DiscountOnPackageType,
                                    c.DiscountOnProduct,
                                    c.DiscountOnProductType,
                                    c.DiscountOnService,
                                    c.DiscountOnServiceType,
                                    c.Duration,
                                    c.Id,
                                    c.MembershipPrice,
                                    c.MembershipType,
                                    c.MinimumBillAmount,
                                    c.MinimumRewardPoint,
                                    c.ModifiedAt,
                                    c.RewardPointBoost,
                                    c.RewardPointOnPurchase,
                                    c.Status,
                                    c2.BranchName
                                }).ToList();
        ListView1.DataBind();


    }
}