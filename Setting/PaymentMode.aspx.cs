using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setting_PaymentMode : System.Web.UI.Page
{
    DataClassesDataContext dbc = new DataClassesDataContext();
    tbl_PaymentMode pm = new tbl_PaymentMode();
    BranchService s = new BranchService();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../PaymentMode.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }


        ListView1.DataSource = (from c in dbc.tbl_PaymentModes
                                select new
                                {
                                    c.CreatedAt,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.PaymentMode,
                                    c.Status
                                }).ToList();
        ListView1.DataBind();

        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var c in s.get_paymentmode_list(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_paymentmode.Text = c.PaymentMode;
                    Chk_status.Checked = Convert.ToBoolean(c.Status);
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_paymentmode(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("PaymentMode.aspx?action=delete");
            }
            else
            {
                Response.Redirect("#?action=Error");
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
                int i = s.update_paymentmode(txt_paymentmode.Text, Convert.ToBoolean(Chk_status.Checked), DateTime.Now, DateTime.Now, Convert.ToInt64(Request.QueryString["open"].ToString()));
                if (i == 1)
                {
                    Response.Redirect("PaymentMode.aspx?action=Update");
                }
                else
                {
                    Response.Redirect("#?action=Error");
                }
            }
            else
            {
                int i = s.paymentmode_insert(txt_paymentmode.Text, Convert.ToBoolean(Chk_status.Checked), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("PaymentMode.aspx?action=Saved");
                }
                else
                {
                    Response.Redirect("#?action=Error");
                }
            }
        }
        catch
        {
        }
    }
}