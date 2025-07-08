using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WalletTransaction_WalletTransaction : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../WalletTransaction.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_WalletTransactions
                                join c2 in dbc.tbl_CustomerMasters on c.CustomerId equals c2.Id
                                select new
                                {
                                    c.Amount,
                                    c.CreatedAt,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.ReferenceNo,
                                    c.TransactionDate,
                                    c.TransactionFrom,
                                    c.TransactionName,
                                    c.TransactionType,
                                    c2.FirstName
                                }).ToList();
        ListView1.DataBind();


        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_wallettransactionmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_amount.Text = Convert.ToDecimal(b.Amount).ToString();
                    txt_customername.Text = Convert.ToInt64(b.CustomerId).ToString();
                    txt_referenceno.Text = b.ReferenceNo;
                    txt_transactiondate.Text = Convert.ToDateTime(b.TransactionDate).ToString();
                    txt_transactionfrom.Text = b.TransactionFrom;
                    txt_transactionname.Text = b.TransactionName;
                    txt_transactiontype.Text = b.TransactionType;
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_wallettransactionmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("WalletTransaction.aspx?action=delete");
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
                int i = s.update_wallettransactionmaster(Convert.ToInt64(Request.QueryString["open"].ToString()),Convert.ToInt64(txt_customername.Text),txt_transactionname.Text, txt_referenceno.Text, txt_transactionfrom.Text, Convert.ToDateTime(txt_transactiondate.Text), txt_transactiontype.SelectedValue, Convert.ToDecimal(txt_amount.Text),DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("WalletTransaction.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.wallettransactionmaster_insert(Convert.ToInt64(txt_customername.Text), txt_transactionname.Text, txt_referenceno.Text, txt_transactionfrom.Text, Convert.ToDateTime(txt_transactiondate.Text), txt_transactiontype.SelectedValue, Convert.ToDecimal(txt_amount.Text), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("WalletTransaction.aspx?action=Saved");
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