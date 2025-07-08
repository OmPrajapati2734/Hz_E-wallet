using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockInOut_StockInOutList : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("StockInOutList.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        ListView1.DataSource = (from c in dbc.tbl_StokeInOutMasters
                                join c2 in dbc.tbl_BranchMasters on c.BranchId equals c2.Id
                                join c3 in dbc.tbl_SuplierMasters on c.SuplierId equals c3.Id
                                select new {
                                    c.CreatedAt,
                                    c.Id,
                                    c.InvoiceDate,
                                    c.InvoiceNumber,
                                    c.ModifiedAt,
                                    c.NetAmount,
                                    c.Remark,
                                    c.TotalAmount,
                                    c.TotalCGST,
                                    c.TotalDiscount,
                                    c.TotalGST,
                                    c.TotalIGST,
                                    c.TotalQuantity,
                                    c.TotalSGST,
                                    c.TotalTaxableAmount,
                                    c.Type,
                                    c2.BranchName,
                                    c3.SuplierName
                                }).ToList();
        ListView1.DataBind();
    }
}