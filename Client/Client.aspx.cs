using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Client : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cookies["currentpage"].Value = ("Client.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }

        ListView1.DataSource = (from c in dbc.tbl_ClientMasters
                                join c2 in dbc.tbl_BranchMasters on c.BranchId equals c2.Id
                                select new
                                {
                                    c.AssignTo,
                                    c.ClientName,
                                    c.ContactNo,
                                    c.Email,
                                    c.Gender,
                                    c.Id,
                                    c.Service,
                                    c.Source,
                                    c.Status,
                                    c2.BranchName
                                }).ToList();
        ListView1.DataBind();

        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_clientmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_assignto.Text = b.AssignTo;
                    txt_clientname.Text = b.ClientName;
                    txt_contactno.Text = b.ContactNo;
                    txt_email.Text = b.Email;
                    txt_gender.Text = b.Gender;
                    txt_source.Text = b.Source;
                    Chk_status.Checked = Convert.ToBoolean(b.Status);
                    txt_branchname.Text = Convert.ToInt64(b.BranchId).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_clientmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Client.aspx?action=delete");
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
                int i = s.update_clientmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), Convert.ToInt64(txt_branchname.SelectedValue), txt_clientname.Text, txt_contactno.Text, txt_email.Text, txt_source.Text, txt_assignto.Text, txt_service.SelectedValue, txt_gender.SelectedValue, Convert.ToBoolean(Chk_status.Checked));
                if (i == 1)
                {
                    Response.Redirect("Client.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.Clientmaster_insert(Convert.ToInt64(txt_branchname.SelectedValue), txt_clientname.Text, txt_contactno.Text, txt_email.Text, txt_source.Text, txt_assignto.Text, txt_service.SelectedValue, txt_gender.SelectedValue, Convert.ToBoolean(Chk_status.Checked));
                if (i == 1)
                {
                    Response.Redirect("Client.aspx?action=Saved");
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