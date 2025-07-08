using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Booking_Inquiry : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    tbl_InquiryMaster im = new tbl_InquiryMaster();
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cookies["currentpage"].Value = ("../inquiry.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }


        ListView1.DataSource = (from c in dbc.tbl_InquiryMasters 
                                join cc in dbc.tbl_BranchMasters on c.BranchId equals cc.Id
                                select new
                                {
                                    c.Address,
                                    c.ClientName,
                                    c.ContactNo,
                                    c.CreatedAt,
                                    c.DateToFollow,
                                    c.Email,
                                    c.Id,
                                    c.InquiryFor,
                                    c.InquiryType,
                                    c.LeadBy,
                                    c.LeadStatus,
                                    c.ModifiedAt,
                                    c.Response,
                                    c.SourceOfInquiry,
                                    cc.BranchName
                                }).ToList();
        ListView1.DataBind();


        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_inquirymasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_address.Text = b.Address;
                    txt_clientname.Text = b.ClientName;
                    txt_contactno.Text = b.ContactNo;
                    txt_datetofollow.Text = Convert.ToDateTime(b.DateToFollow).ToString();
                    txt_email.Text = b.Email;
                    txt_inquiryfor.Text = b.InquiryFor;
                    txt_inquirytype.Text = b.InquiryType;
                    txt_leadby.Text = b.LeadBy;
                    txt_response.Text = b.Response;
                    txt_sourceofinquiry.Text = b.SourceOfInquiry;
                    Chk_leadstatus.Checked = Convert.ToBoolean(b.LeadStatus);
                    txt_branchname.Text = Convert.ToInt64(b.BranchId).ToString();
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_inquirymaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Inquiry.aspx?action=delete");
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
                int i = s.update_inquirymaster(Convert.ToInt64(Request.QueryString["open"].ToString()),Convert.ToInt64(txt_branchname.Text), txt_contactno.Text, txt_clientname.Text, txt_email.Text, txt_address.Text, txt_inquiryfor.Text, txt_inquirytype.SelectedValue, txt_response.Text, Convert.ToDateTime(txt_datetofollow.Text), txt_sourceofinquiry.Text, txt_leadby.Text, Convert.ToBoolean(Chk_leadstatus.Checked), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Inquiry.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.inquirymaster_insert(Convert.ToInt64(txt_branchname.Text), txt_contactno.Text, txt_clientname.Text, txt_email.Text, txt_address.Text, txt_inquiryfor.Text, txt_inquirytype.SelectedValue, txt_response.Text, Convert.ToDateTime(txt_datetofollow.Text), txt_sourceofinquiry.Text, txt_leadby.Text, Convert.ToBoolean(Chk_leadstatus.Checked), DateTime.Now, DateTime.Now);
                if (i == 1)
                {
                    Response.Redirect("Inquiry.aspx?action=Saved");
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