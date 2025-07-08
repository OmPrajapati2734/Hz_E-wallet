using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Service_Service : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../Service.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_ServiceMasters
                                join c2 in dbc.tbl_BranchMasters on c.BranchId equals c2.Id
                                select new
                                {
                                    c.Category,
                                    c.CreatedAt,
                                    c.Duration,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.Price,
                                    c.RewardPoints,
                                    c.ServiceFor,
                                    c.ServiceName,
                                    c2.BranchName
                                }).ToList();
        ListView1.DataBind();


        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_servicelistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_category.Text = b.Category;
                    txt_duration.Text = Convert.ToInt32(b.Duration).ToString();
                    txt_price.Text = Convert.ToDecimal(b.Price).ToString();
                    txt_rewardpoint.Text = b.RewardPoints;
                    txt_servicefor.Text = b.ServiceFor;
                    txt_servicename.Text = b.ServiceName;
                    txt_branchname.Text = Convert.ToInt64(b.BranchId).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_servicemaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Service.aspx?action=delete");
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
                int i = s.update_servicematser(Convert.ToInt64(Request.QueryString["open"].ToString()), txt_servicename.Text, txt_category.SelectedValue, Convert.ToInt32(txt_duration.Text), Convert.ToDecimal(txt_price.Text), txt_rewardpoint.Text, txt_servicefor.Text, DateTime.Now, DateTime.Now,Convert.ToInt64(txt_branchname.Text));
                if (i == 1)
                {
                    Response.Redirect("Service.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.servicemaster_insert(txt_servicename.Text, txt_category.SelectedValue, Convert.ToInt32(txt_duration.Text), Convert.ToDecimal(txt_price.Text), txt_rewardpoint.Text, txt_servicefor.Text, DateTime.Now, DateTime.Now, Convert.ToInt64(txt_branchname.Text));
                if (i == 1)
                {
                    Response.Redirect("Service.aspx?action=Saved");
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