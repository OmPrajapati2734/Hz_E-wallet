using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Supplier_Supplier : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("Supplier.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        } 

        ListView1.DataSource = (from c in dbc.tbl_SuplierMasters
                                join c2 in dbc.tbl_BranchMasters on c.BranchId equals c2.Id
                                select new
                                {
                                    c2.BranchName,
                                    c.CreatedAt,
                                    c.Email,
                                    c.GSTNumber,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.OpeningBalance,
                                    c.Status,
                                    c.SuplierAddress,
                                    c.SuplierMobile,
                                    c.SuplierName,
                                }).ToList();
        ListView1.DataBind();


        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_supliermasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_branchname.Text = Convert.ToInt64(b.BranchId).ToString();
                    txt_email.Text = b.Email;
                    txt_gstnumber.Text = Convert.ToDecimal(b.GSTNumber).ToString();
                    txt_openingbalance.Text = Convert.ToDecimal(b.OpeningBalance).ToString();
                    txt_status.Checked = Convert.ToBoolean(b.Status);
                    txt_supplieraddress.Text = b.SuplierAddress;
                    txt_suppliermobile.Text = b.SuplierMobile;
                    txt_suppliername.Text = b.SuplierName;
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_supliermaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Supplier.aspx?action=delete");
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
                int i = s.update_supliermaster(Convert.ToInt64(Request.QueryString["open"].ToString()), Convert.ToInt64(txt_branchname.Text), txt_suppliername.Text, txt_suppliermobile.Text, txt_supplieraddress.Text, Convert.ToBoolean(txt_status.Checked), txt_email.Text, Convert.ToDecimal(txt_openingbalance.Text), txt_gstnumber.Text, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Supplier.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.supliermaster_insert(Convert.ToInt64(txt_branchname.Text), txt_suppliername.Text, txt_suppliermobile.Text, txt_supplieraddress.Text, Convert.ToBoolean(txt_status.Checked), txt_email.Text, Convert.ToDecimal(txt_openingbalance.Text), txt_gstnumber.Text, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Supplier.aspx?action=Saved");
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