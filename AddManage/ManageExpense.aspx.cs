using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddManage_ManageExpense : System.Web.UI.Page
{
    DataClassesDataContext dbc = new DataClassesDataContext();
    tbl_ExpenseMaster eh = new tbl_ExpenseMaster();
    BranchService b = new BranchService();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../ManageExpense.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }

        ListView1.DataSource = (from c in dbc.tbl_ExpenseMasters
                                join cc in dbc.tbl_BranchMasters on c.BranchId equals cc.Id
                                join c2 in dbc.tbl_PaymentModes on c.PaymentModeId equals c2.Id
                                select new
                                {
                                    c.Amount,
                                    c.Cancel_Delete,
                                    c.CreatedAt,
                                    c.ExpenseDate,
                                    c.HeadId,
                                    c.Id,
                                    c.ModifiedAt,
                                    c.Reason,
                                    c.Remark,
                                    c.TypeOfExpense,
                                    c2.PaymentMode,
                                    cc.BranchName
                                }).ToList();
        ListView1.DataBind();

        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var s in b.get_expensemasterbylist(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_amount.Text = Convert.ToDecimal(s.Amount).ToString();
                    txt_expense.Text = Convert.ToDateTime(s.ExpenseDate).ToString();
                    txt_paymentmode.Text = Convert.ToInt64(s.PaymentModeId).ToString();
                    txt_remark.Text = s.Remark;
                    txt_typeofexpense.Text = s.TypeOfExpense;
                    txt_branchname.Text = Convert.ToInt64(s.BranchId).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = b.delete_expensemaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("ManageExpense.aspx?action=delete");
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
                int i = b.update_expensemaster(Convert.ToDateTime(txt_expense.Text), txt_typeofexpense.Text, Convert.ToDecimal(txt_amount.Text), 0, Convert.ToInt64(txt_paymentmode.SelectedValue), txt_remark.Text, "no","no", DateTime.Now, DateTime.Now, Convert.ToInt64(txt_branchname.SelectedValue), Convert.ToInt64(Request.QueryString["open"].ToString()));
                if (i == 1)
                {
                    Response.Redirect("ManageExpense.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = b.expensemaster_insert(Convert.ToDateTime(txt_expense.Text), txt_typeofexpense.Text, Convert.ToDecimal(txt_amount.Text), 0, Convert.ToInt64(txt_paymentmode.SelectedValue), txt_remark.Text, "no", "no", DateTime.Now, DateTime.Now, Convert.ToInt64(txt_branchname.SelectedValue));
                if (i == 1)
                {
                    Response.Redirect("ManageExpense.aspx?action=Saved");
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