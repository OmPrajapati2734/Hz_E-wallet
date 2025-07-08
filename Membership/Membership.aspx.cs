using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Membership_Membership : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("Membership.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        } 

        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_membershipmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_disonpackage.Text = Convert.ToDecimal(b.DiscountOnPackage).ToString();
                    txt_disonpackagetype.Text = Convert.ToDecimal(b.DiscountOnPackageType).ToString();
                    txt_disonproduct.Text = Convert.ToDecimal(b.DiscountOnProduct).ToString();
                    txt_disonproducttype.Text = Convert.ToDecimal(b.DiscountOnProductType).ToString();
                    txt_disonservice.Text = Convert.ToDecimal(b.DiscountOnService).ToString();
                    txt_disonservicetype.Text = Convert.ToDecimal(b.DiscountOnServiceType).ToString();
                    txt_duration.Text = Convert.ToInt32(b.Duration).ToString();
                    txt_membershipprice.Text = Convert.ToDecimal(b.MembershipPrice).ToString();
                    txt_membershiptype.Text = b.MembershipType;
                    txt_minbillamount.Text = Convert.ToDecimal(b.MinimumBillAmount).ToString();
                    txt_rewardpointboost.Text = Convert.ToDecimal(b.RewardPointBoost).ToString();
                    txt_rewardpointonpurchase.Text = Convert.ToDecimal(b.RewardPointOnPurchase).ToString();
                    txt_status.Checked = Convert.ToBoolean(b.Status);
                    txt_minrewardpoint.Text = Convert.ToDecimal(b.MinimumRewardPoint).ToString();
                    txt_branchname.Text = Convert.ToInt64(b.BranchId).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_membershipmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("MembershipList.aspx?action=delete");
            }
            else
            {
                Response.Redirect("#?action=error");
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["open"] != null)
            {
                Response.Write("<script>alert('" + Request.QueryString["open"].ToString() + "')</script>");
                int i = s.update_membershipmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), Convert.ToInt64(txt_branchname.SelectedValue), txt_membershiptype.SelectedValue, Convert.ToDecimal(txt_membershipprice.Text), Convert.ToInt32(txt_duration.Text), Convert.ToDecimal(txt_rewardpointonpurchase.Text), Convert.ToDecimal(txt_disonservice.Text), Convert.ToDecimal(txt_disonservicetype.Text), Convert.ToDecimal(txt_disonproduct.Text), Convert.ToDecimal(txt_disonproducttype.Text), Convert.ToDecimal(txt_disonpackage.Text), Convert.ToDecimal(txt_disonpackagetype.Text), Convert.ToInt32(txt_rewardpointboost.Text), Convert.ToInt32(txt_minrewardpoint.Text), Convert.ToInt32(txt_minbillamount.Text), Convert.ToBoolean(txt_status.Checked), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Membership.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.membershipmaster_insert(Convert.ToInt64(txt_branchname.SelectedValue), txt_membershiptype.SelectedValue, Convert.ToDecimal(txt_membershipprice.Text), Convert.ToInt32(txt_duration.Text), Convert.ToDecimal(txt_rewardpointonpurchase.Text), Convert.ToDecimal(txt_disonservice.Text), Convert.ToDecimal(txt_disonservicetype.Text), Convert.ToDecimal(txt_disonproduct.Text), Convert.ToDecimal(txt_disonproducttype.Text), Convert.ToDecimal(txt_disonpackage.Text), Convert.ToDecimal(txt_disonpackagetype.Text), Convert.ToInt32(txt_rewardpointboost.Text), Convert.ToInt32(txt_minrewardpoint.Text), Convert.ToInt32(txt_minbillamount.Text), Convert.ToBoolean(txt_status.Checked), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Membership.aspx?action=Saved");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
        }
        catch
        {

        }
    }
}