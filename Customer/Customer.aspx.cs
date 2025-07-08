using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Customer : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../Customer.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_CustomerMasters
                                select new
                                {
                                    c.CreatedAt,
                                    c.DateOfBirth,
                                    c.Email,
                                    c.FirstName,
                                    c.Gender,
                                    c.Id,
                                    c.LastName,
                                    c.Mobile,
                                    c.ModifiedAt,
                                    c.OpeningBalance,
                                    c.Status,
                                    c.Verified,
                                    c.WalletAccount
                                }).ToList();
        ListView1.DataBind();


        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_customermasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_dob.Text = Convert.ToDateTime(b.DateOfBirth).ToString();
                    txt_email.Text = b.Email;
                    txt_firstname.Text = b.FirstName;
                    txt_gender.Text = b.Gender;
                    txt_lastname.Text = b.LastName;
                    txt_mobile.Text = b.Mobile;
                    txt_openingbalance.Text = Convert.ToDecimal(b.OpeningBalance).ToString();
                    txt_status.Checked = Convert.ToBoolean(b.Status);
                    chk_verified.Checked = Convert.ToBoolean(b.Verified);
                    chk_walletaccount.Checked = Convert.ToBoolean(b.WalletAccount);
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_customermaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Customer.aspx?action=delete");
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
                int i = s.update_customermaster(Convert.ToInt64(Request.QueryString["open"].ToString()), txt_firstname.Text, txt_lastname.Text, txt_email.Text, txt_mobile.Text, Convert.ToDateTime(txt_dob.Text), txt_gender.SelectedValue, Convert.ToBoolean(txt_status.Checked), Convert.ToBoolean(chk_walletaccount.Checked), Convert.ToDecimal(txt_openingbalance.Text), Convert.ToBoolean(chk_verified.Checked), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Customer.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.Customermaster_insert(txt_firstname.Text, txt_lastname.Text, txt_email.Text, txt_mobile.Text, Convert.ToDateTime(txt_dob.Text), txt_gender.SelectedValue, Convert.ToBoolean(txt_status.Checked), Convert.ToBoolean(chk_walletaccount.Checked), Convert.ToDecimal(txt_openingbalance.Text), Convert.ToBoolean(chk_verified.Checked), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Customer.aspx?action=Saved");
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