using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Package_PackageDetail : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../PackageDetail.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_PackageDetailMasters
                                join cc in dbc.tbl_ServiceMasters on c.ServiceId equals cc.Id
                                join c2 in dbc.tbl_PackageMasters on c.PackageId equals c2.Id
                                select new
                                {
                                    c.BranchId,
                                    c.Category,
                                    c.CreatedAt,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.Price,
                                    c.Quantity,
                                    cc.ServiceName,
                                    c2.PackageName
                                }).ToList();
        ListView1.DataBind();

        if (Request.QueryString["open"] != null)
        {

            if (!IsPostBack)
            {
                foreach (var b in s.get_packagedetaillistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_category.Text = b.Category;
                    txt_packagename.Text = Convert.ToInt64(b.PackageId).ToString();
                    txt_price.Text = Convert.ToDecimal(b.Price).ToString();
                    txt_quantity.Text = Convert.ToDecimal(b.Quantity).ToString();
                    txt_servicename.Text = Convert.ToInt64(b.ServiceId).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_packagedetailmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("PackageDetail.aspx?action=delete");
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
                int i = s.update_packagedetailmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), 1, Convert.ToInt64(txt_packagename.Text), Convert.ToInt64(txt_servicename.Text), Convert.ToDecimal(txt_quantity.Text), Convert.ToDecimal(txt_price.Text), txt_category.SelectedValue, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("PackageDetail.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.packagedetailmaster_insert(1, Convert.ToInt64(txt_packagename.Text), Convert.ToInt64(txt_servicename.Text), Convert.ToDecimal(txt_quantity.Text), Convert.ToDecimal(txt_price.Text), txt_category.SelectedValue, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("PackageDetail.aspx?action=Saved");
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