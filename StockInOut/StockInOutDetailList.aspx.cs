using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockInOut_StockInOutDetailList : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("StockInOutDetailList.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_StockInOutDetailMasters
                                join c2 in dbc.tbl_StokeInOutMasters on c.StockInOutId equals c2.Id
                                select new {
                                    c.Amount,
                                    c.CGSTamount,
                                    c.CreatedAt,
                                    c.Discount,
                                    c.DiscountPercentage,
                                    c.DiscountType,
                                    c.ExpiryDate,
                                    c.GSTAmount,
                                    c.GSTPercentage,
                                    c.HSNCode,
                                    c.Id,
                                    c.IGSTamount,
                                    c.ManufactureDate,
                                    c.ModifiedAt,
                                    c.Netamount,
                                    c.ProductDetail,
                                    c.ProductId,
                                    c.Quantity,
                                    c.Rate,
                                    c.Remark,
                                    c.SGSTamount,
                                    c.TaxableAmount,
                                    c.Unit,
                                    c2.Type
                                }).ToList();
        ListView1.DataBind();
    }
}