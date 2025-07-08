using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockInOut_StockInOutDetail : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("StockInOutDetail.aspx");
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
                foreach (var b in s.get_stokeinoutdetailmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_stockid.Text = Convert.ToInt64(b.StockInOutId).ToString();
                    txt_productname.Text = Convert.ToInt64(b.ProductId).ToString();
                    txt_hsncode.Text = b.HSNCode;
                    txt_productdetail.Text = b.ProductDetail;
                    txt_manfdate.Text = Convert.ToDateTime(b.ManufactureDate).ToString();
                    txt_expirydate.Text = Convert.ToDateTime(b.ExpiryDate).ToString();
                    txt_quantity.Text = Convert.ToDecimal(b.Quantity).ToString();
                    txt_rate.Text = Convert.ToDecimal(b.Rate).ToString();
                    txt_discount.Text = Convert.ToDecimal(b.Discount).ToString();
                    txt_discounttype.Text = b.DiscountType;
                    txt_disper.Text = Convert.ToDecimal(b.DiscountPercentage).ToString();
                    txt_amount.Text = Convert.ToDecimal(b.Amount).ToString();
                    txt_taxableamount.Text = Convert.ToDecimal(b.TaxableAmount).ToString();
                    txt_gstpercentage.Text = Convert.ToDecimal(b.GSTPercentage).ToString();
                    txt_gstamount.Text = Convert.ToDecimal(b.GSTAmount).ToString();
                    txt_cgstamount.Text = Convert.ToDecimal(b.CGSTamount).ToString();
                    txt_sgst.Text = Convert.ToDecimal(b.SGSTamount).ToString();
                    txt_igst.Text = Convert.ToDecimal(b.IGSTamount).ToString();
                    txt_netamount.Text = Convert.ToDecimal(b.Netamount).ToString();
                    txt_unit.Text = Convert.ToDecimal(b.Unit).ToString();
                    txt_remark.Text = b.Remark;
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_stokeinoutdetailmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("StockInOutDetail.aspx?action=delete");
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
                int i = s.update_stockinoutdetailmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), Convert.ToInt64(txt_productname.Text), Convert.ToInt64(txt_stockid.SelectedValue), txt_hsncode.Text, txt_productdetail.Text, Convert.ToDateTime(txt_manfdate.Text), Convert.ToDateTime(txt_expirydate.Text), Convert.ToDecimal(txt_quantity.Text), Convert.ToDecimal(txt_rate.Text), Convert.ToDecimal(txt_discount.Text), txt_discounttype.SelectedValue, Convert.ToDecimal(txt_disper.Text), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_netamount.Text), Convert.ToDecimal(txt_taxableamount.Text), Convert.ToDecimal(txt_gstpercentage.Text), Convert.ToDecimal(txt_gstamount.Text), Convert.ToDecimal(txt_cgstamount.Text), Convert.ToDecimal(txt_sgst.Text), Convert.ToDecimal(txt_igst.Text), Convert.ToDecimal(txt_netamount.Text), Convert.ToDecimal(txt_unit.Text), txt_remark.Text, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("StockInOutDetail.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.stockinoutdetailmaster_insert(Convert.ToInt64(txt_productname.Text), Convert.ToInt64(txt_stockid.SelectedValue), txt_hsncode.Text, txt_productdetail.Text, Convert.ToDateTime(txt_manfdate.Text), Convert.ToDateTime(txt_expirydate.Text), Convert.ToDecimal(txt_quantity.Text), Convert.ToDecimal(txt_rate.Text), Convert.ToDecimal(txt_discount.Text), txt_discounttype.SelectedValue, Convert.ToDecimal(txt_disper.Text), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_netamount.Text), Convert.ToDecimal(txt_taxableamount.Text), Convert.ToDecimal(txt_gstpercentage.Text), Convert.ToDecimal(txt_gstamount.Text), Convert.ToDecimal(txt_cgstamount.Text), Convert.ToDecimal(txt_sgst.Text), Convert.ToDecimal(txt_igst.Text), Convert.ToDecimal(txt_netamount.Text), Convert.ToDecimal(txt_unit.Text), txt_remark.Text, DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("StockInOutDetail.aspx?action=Saved");
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