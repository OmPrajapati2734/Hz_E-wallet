using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setting_Coupon : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cookies["currentpage"].Value = ("../Coupon.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }

        ListView1.DataSource = (from c in dbc.tbl_CouponMasters
                                join cc in dbc.tbl_BranchMasters on c.BranchId equals cc.Id
                                select new
                                {
                                    c.CouponCode,
                                    c.CouponPerUser,
                                    c.CreatedAt,
                                    c.Discount,
                                    c.DiscountType,
                                    c.Id,
                                    c.MaxDiscountAmount,
                                    c.MinimumBillingAmount,
                                    c.ModifiedAt,
                                    c.RewardPoint,
                                    c.Validity,
                                    cc.BranchName
                                }).ToList();
        ListView1.DataBind();

        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_couponlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_branchname.Text = Convert.ToInt64(b.BranchId).ToString();
                    txt_couponcode.Text = b.CouponCode;
                    txt_couponperuser.Text = Convert.ToInt32(b.CouponPerUser).ToString();
                    txt_discount.Text = Convert.ToDecimal(b.Discount).ToString();
                    txt_discounttype.Text = b.DiscountType;
                    txt_maxdisamt.Text = Convert.ToDecimal(b.MaxDiscountAmount).ToString();
                    txt_minbillamt.Text = Convert.ToDecimal(b.MinimumBillingAmount).ToString();
                    txt_rewardpoint.Text = Convert.ToDecimal(b.RewardPoint).ToString();
                    txt_validity.Text = Convert.ToDateTime(b.Validity).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_couponmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Coupon.aspx?action=delete");
            }
            else
            {
                Response.Redirect("#?action=error");
            }
        }
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["open"] != null)
            {
                Response.Write("<script>alert('" + Request.QueryString["open"].ToString() + "')</script>");
                int i = s.update_couponmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), Convert.ToInt64(txt_branchname.SelectedValue), txt_couponcode.Text, Convert.ToDecimal(txt_discount.Text), txt_discounttype.SelectedValue, Convert.ToDecimal(txt_minbillamt.Text), Convert.ToDecimal(txt_maxdisamt.Text), Convert.ToInt32(txt_couponperuser.Text),Convert.ToDateTime(txt_validity.Text), Convert.ToDecimal(txt_rewardpoint.Text), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Coupon.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.couponmaster_insert(Convert.ToInt64(txt_branchname.SelectedValue), txt_couponcode.Text, Convert.ToDecimal(txt_discount.Text), txt_discounttype.SelectedValue, Convert.ToDecimal(txt_minbillamt.Text), Convert.ToDecimal(txt_maxdisamt.Text), Convert.ToInt32(txt_couponperuser.Text), Convert.ToDateTime(txt_validity.Text), Convert.ToDecimal(txt_rewardpoint.Text), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Coupon.aspx?action=Saved");
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