using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalonManagementLogin : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    int check = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            if (Request.Cookies["username"] != null)
                txt_user.Text = Request.Cookies["username"].Value;
            if (Request.Cookies["password"] != null)
                txt_pass.Attributes.Add("value", Request.Cookies["password"].Value);
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                txt_check.Checked = true;
        }

    }

    protected void btnlogin_ServerClick(object sender, EventArgs e)
    {
        if (txt_logintype.SelectedValue == "ServiceProvider" && txt_user.Text != null && txt_pass.Text != null)
        {
            foreach (var q in (from c in dbc.tbl_ServiceProviderMasters where c.Username == txt_user.Text where c.Password == txt_pass.Text select c))
            {
                if (q != null)
                {
                    check = 1;
                    if (q.Status == true)
                    {
                        Session.Add("username", q.Username);
                        Session.Add("status", q.Status);
                        Session.Add("bid", q.BranchId);
                        if (q.BranchId == 0)
                        {
                            Response.Redirect("SalonManagementLogin.aspx");
                        }
                        else
                        {
                            if (txt_check.Checked == true)
                            {
                                Response.Cookies["username"].Value = txt_user.Text;
                                Response.Cookies["username"].Expires = DateTime.Now.AddHours(1);

                                Response.Cookies["password"].Value = txt_pass.Text;
                                Response.Cookies["password"].Expires = DateTime.Now.AddHours(1);
                            }
                            else
                            {
                                Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                            }
                            if (Request.Cookies["currentpage"] != null)
                            {
                                Response.Redirect("test.aspx");
                            }
                            else
                            {
                                Response.Redirect(Request.Cookies["currentpage"].Value.ToString());
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script> alert('Your Password Or username is invalid please check it!')</script>");
                    }
                }
            }
        }
        else if (txt_logintype.SelectedValue == "Staff" && txt_user.Text != null && txt_pass.Text != null)
        {
            foreach (var q in (from c in dbc.tbl_StaffMasters where c.Username == txt_user.Text where c.Password == txt_pass.Text select c))
            {
                if (q != null)
                {
                    check = 1;
                    if (q.Status == true)
                    {
                        Session.Add("username", q.Username);
                        Session.Add("status", q.Status);
                        Session.Add("bid", q.BranchId);
                        if (q.BranchId == 0)
                        {
                            Response.Redirect("SalonManagementLogin.aspx");
                        }
                        else
                        {
                            if (txt_check.Checked == true)
                            {
                                Response.Cookies["username"].Value = txt_user.Text;
                                Response.Cookies["username"].Expires = DateTime.Now.AddHours(1);

                                Response.Cookies["password"].Value = txt_pass.Text;
                                Response.Cookies["password"].Expires = DateTime.Now.AddHours(1);
                            }
                            else
                            {
                                Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                            }
                            if (Request.Cookies["currentpage"] != null)
                            {
                                Response.Redirect("test.aspx");
                            }
                            else
                            {
                                Response.Redirect(Request.Cookies["currentpage"].Value.ToString());
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script> alert('Your Password Or username is invalid please check it!')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script> alert('Plese Enter Username and Password and Select the Login Type')</script>");
        }
    }
}