using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Branch_BranchAdd : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../BranchAdd.aspx");
        Response.Cookies["currentpage"].Expires = DateTime.Now.AddDays(1);
        if (Session["username"] == null && Session["status"] == null && Session["bid"] == null)
        {
            Response.Redirect("../SalonManagementLogin.aspx");
        }
        else
        {
            Response.Cookies["currentpage"].Value = null;
        }
        if (Request.QueryString["open"] != null)
        {
            if (!IsPostBack)
            {
                foreach (var b in s.get_branchmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_branchname.Text = b.BranchName;
                    txt_branchphoto.Text = b.BranchPhoto;
                    txt_branchtype.Text = b.BranchType;
                    txt_category.Text = b.Category;
                    txt_city.Text = b.City;
                    txt_email.Text = b.Email;
                    txt_fulladdress.Text = b.FullAddress;
                    txt_googlemap.Text = b.GoogleMapLocation;
                    txt_gstnumber.Text = b.GSTNumber;
                    txt_landmark.Text = b.LandMark;
                    txt_loginid.Text = b.Loginid;
                    txt_manageremail.Text = b.ManagerEmail;
                    txt_managermobile.Text = b.ManagerMobile;
                    txt_managername.Text = b.ManagerMobile;
                    txt_mobile.Text = b.Mobile;
                    txt_password.Text = b.Password;
                    txt_pincode.Text = b.PINcode;
                    txt_whatsapp.Text = b.WhatsApp;
                    Chk_status.Checked = Convert.ToBoolean(b.Status);
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_branchmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("BranchAdd.aspx?action=delete");
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
                int i = s.update_branchmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), txt_branchname.Text, txt_city.Text, txt_pincode.Text, txt_fulladdress.Text, txt_landmark.Text, txt_mobile.Text, txt_whatsapp.Text, txt_email.Text, txt_category.SelectedValue, txt_googlemap.Text, txt_gstnumber.Text, txt_managername.Text, txt_managermobile.Text, txt_manageremail.Text, txt_loginid.Text, txt_password.Text, Convert.ToBoolean(Chk_status.Checked), DateTime.Now, 1, DateTime.Now, 1, txt_branchphoto.Text, txt_branchtype.SelectedValue);
                if (i == 1)
                {
                    Response.Redirect("BranchAdd.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.branchmaster_insert(txt_branchname.Text, txt_city.Text, txt_pincode.Text, txt_fulladdress.Text, txt_landmark.Text, txt_mobile.Text, txt_whatsapp.Text, txt_email.Text, txt_category.SelectedValue, txt_googlemap.Text, txt_gstnumber.Text, txt_managername.Text, txt_managermobile.Text, txt_manageremail.Text, txt_loginid.Text, txt_password.Text, Convert.ToBoolean(Chk_status.Checked), DateTime.Now, 1, DateTime.Now, 1, txt_branchphoto.Text, txt_branchtype.SelectedValue);
                if (i == 1)
                {
                    Response.Redirect("BranchAdd.aspx?action=Saved");
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