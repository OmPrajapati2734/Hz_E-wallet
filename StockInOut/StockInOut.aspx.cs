using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockInOut_StockInOut : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("StockInOut.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }

        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_stokeinoutmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_branchname.Text = Convert.ToInt64(b.BranchId).ToString();
                    txt_invoicedate.Text = Convert.ToDateTime(b.InvoiceDate).ToString();
                    txt_invoicenumber.Text = b.InvoiceNumber;
                    txt_netamount.Text = Convert.ToDecimal(b.NetAmount).ToString();
                    txt_remark.Text = b.Remark;
                    txt_sgst.Text = Convert.ToDecimal(b.TotalSGST).ToString();
                    txt_suppliername.Text = Convert.ToInt64(b.SuplierId).ToString();
                    txt_taxableamount.Text = Convert.ToDecimal(b.TotalTaxableAmount).ToString();
                    txt_totalamount.Text = Convert.ToDecimal(b.TotalAmount).ToString();
                    txt_totalcgst.Text = Convert.ToInt64(b.TotalCGST).ToString();
                    txt_totaldiscount.Text = Convert.ToInt64(b.TotalDiscount).ToString();
                    txt_totalgst.Text = Convert.ToInt64(b.TotalGST).ToString();
                    txt_totalquantity.Text = Convert.ToDecimal(b.TotalQuantity).ToString();
                    txt_stocktype.Text = b.Type;
                    txt_totaligst.Text = Convert.ToInt64(b.TotalIGST).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_stokeinoutmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("StockInOut.aspx?action=delete");
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
                int i = s.update_stockinoutmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), Convert.ToInt64(txt_suppliername.Text), Convert.ToInt64(txt_branchname.Text), txt_stocktype.SelectedValue, txt_invoicenumber.Text, Convert.ToDateTime(txt_invoicedate.Text), "", Convert.ToDecimal(txt_totalquantity.Text), Convert.ToDecimal(txt_taxableamount.Text), Convert.ToDecimal(txt_totalgst.Text), Convert.ToDecimal(txt_totaligst.Text), Convert.ToDecimal(txt_sgst.Text), Convert.ToDecimal(txt_totalcgst.Text), Convert.ToDecimal(txt_netamount.Text), Convert.ToDecimal(txt_totaldiscount.Text), Convert.ToDecimal(txt_totalamount.Text), txt_remark.Text, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("StockInOut.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.stockinoutmaster_insert(Convert.ToInt64(txt_suppliername.Text), Convert.ToInt64(txt_branchname.Text), txt_stocktype.SelectedValue, txt_invoicenumber.Text, Convert.ToDateTime(txt_invoicedate.Text), "", Convert.ToDecimal(txt_totalquantity.Text), Convert.ToDecimal(txt_taxableamount.Text), Convert.ToDecimal(txt_totalgst.Text), Convert.ToDecimal(txt_totaligst.Text), Convert.ToDecimal(txt_sgst.Text), Convert.ToDecimal(txt_totalcgst.Text), Convert.ToDecimal(txt_netamount.Text), Convert.ToDecimal(txt_totaldiscount.Text), Convert.ToDecimal(txt_totalamount.Text), txt_remark.Text, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("StockInOut.aspx?action=Saved");
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