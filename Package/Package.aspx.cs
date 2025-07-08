using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Package_Package : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("Package.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_PackageMasters
                                select new
                                {
                                    c.BranchId,
                                    c.CreatedAt,
                                    c.Duration,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.PackageName,
                                    c.PackagePrice,
                                    c.PackageValidity
                                }).ToList();
        ListView1.DataBind();

        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_packagelistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_duration.Text = Convert.ToInt32(b.Duration).ToString();
                    txt_packagename.Text = b.PackageName;
                    txt_packageprice.Text = Convert.ToDecimal(b.PackagePrice).ToString();
                    txt_packagevalidity.Text = Convert.ToDateTime(b.PackageValidity).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_packagemaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Package.aspx?action=delete");
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
                int i = s.update_packagemaster(Convert.ToInt64(Request.QueryString["open"].ToString()), txt_packagename.Text, Convert.ToInt32(txt_duration.Text), Convert.ToDateTime(txt_packagevalidity.Text), Convert.ToDecimal(txt_packageprice.Text), 1, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Package.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.packagemaster_insert(txt_packagename.Text, Convert.ToInt32(txt_duration.Text), Convert.ToDateTime(txt_packagevalidity.Text), Convert.ToDecimal(txt_packageprice.Text), 1, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Package.aspx?action=Saved");
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