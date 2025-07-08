using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News_News : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../News.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_NewsMasters
                                join c2 in dbc.tbl_StaffMasters on c.EmployeeId equals c2.Id
                                select new
                                {
                                    c.CreatedAt,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.NewsDate,
                                    c.NewsDescription,
                                    c.NewsHeading,
                                    c.NewsStyle,
                                    c.Status,
                                    c2.EmployeeName
                                }).ToList();
        ListView1.DataBind();


        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_newsmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_employeename.Text = Convert.ToInt64(b.EmployeeId).ToString();
                    txt_newsdate.Text = Convert.ToDateTime(b.NewsDate).ToString();
                    txt_newsdescription.Text = b.NewsDescription;
                    txt_newsheading.Text = b.NewsHeading;
                    txt_newsstyle.SelectedValue = b.NewsStyle;
                    Chk_status.Checked = Convert.ToBoolean(b.Status);
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_newsmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("News.aspx?action=delete");
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
                int i = s.update_newsmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), Convert.ToDateTime(txt_newsdate.Text), txt_newsheading.Text, txt_newsdescription.Text, Convert.ToInt64(txt_employeename.Text), Convert.ToBoolean(Chk_status.Checked), txt_newsstyle.SelectedValue, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("News.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.newsaster_insert(Convert.ToDateTime(txt_newsdate.Text), txt_newsheading.Text, txt_newsdescription.Text, Convert.ToInt64(txt_employeename.Text), Convert.ToBoolean(Chk_status.Checked), txt_newsstyle.SelectedValue, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("News.aspx?action=Saved");
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