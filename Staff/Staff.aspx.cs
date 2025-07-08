using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Staff : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["currentpage"].Value = ("../Staff.aspx");
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
                foreach (var b in s.get_staffmasterlistby_id(Convert.ToInt64(Request.QueryString["open"].ToString())))
                {
                    txt_address.Text = b.Address;
                    txt_contactno.Text = b.ContactNo;
                    txt_dob.Text = Convert.ToDateTime(b.DateOfBirth).ToString();
                    txt_email.Text = b.Email;
                    txt_emergencycontact.Text = b.EmergencyContactNo;
                    txt_emergencycontactperson.Text = b.EmergencyContactPerson;
                    txt_gender.Text = b.Gender;
                    txt_joindate.Text = Convert.ToDateTime(b.DateOfJoining).ToString();
                    txt_monthlysalary.Text = Convert.ToDecimal(b.MonthlySalary).ToString();
                    txt_password.Text = b.Password;
                    txt_idproof.Text = b.IdProofPhoto;
                    txt_userphoto.Text = b.UserPhoto;
                    txt_username.Text = b.Username;
                    txt_whe.Text = Convert.ToDateTime(b.WorkingHourEnd).ToString();
                    txt_whs.Text = Convert.ToDateTime(b.WorkingHourStart).ToString();
                    Chk_status.Checked = Convert.ToBoolean(b.Status);
                    txt_department.Text = b.Department;
                    txt_usertype.Text = b.UserType;
                    txt_employeename.Text = b.EmployeeName;
                }
            }
        }

        if (Request.QueryString["delete"] != null)
        {
            int i = s.delete_staffmaster(Convert.ToInt64(Request.QueryString["delete"].ToString()));
            if (i == 1)
            {
                Response.Redirect("Staff.aspx?action=delete");
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
                int i = s.update_staffmaster(Convert.ToInt64(Request.QueryString["open"].ToString()), txt_employeename.Text, Convert.ToDateTime(txt_dob.Text), txt_contactno.Text, txt_email.Text, Convert.ToDateTime(txt_whs.Text), Convert.ToDateTime(txt_whe.Text), Convert.ToDecimal(txt_monthlysalary.Text), txt_emergencycontact.Text, txt_emergencycontactperson.Text, txt_address.Text, txt_username.Text, txt_password.Text, txt_gender.SelectedValue, Convert.ToDateTime(txt_joindate.Text), txt_department.Text, txt_idproof.Text, txt_usertype.SelectedValue, txt_userphoto.Text, 1, Convert.ToBoolean(Chk_status.Checked));
                if (i == 1)
                {
                    Response.Redirect("Staff.aspx?action=update");
                }
                else
                {
                    Response.Redirect("#?action=error");
                }
            }
            else
            {
                int i = s.staffmaster_insert(txt_employeename.Text, Convert.ToDateTime(txt_dob.Text), txt_contactno.Text, txt_email.Text, Convert.ToDateTime(txt_whs.Text), Convert.ToDateTime(txt_whe.Text), Convert.ToDecimal(txt_monthlysalary.Text), txt_emergencycontact.Text, txt_emergencycontactperson.Text, txt_address.Text, txt_username.Text, txt_password.Text, txt_gender.SelectedValue, Convert.ToDateTime(txt_joindate.Text), txt_department.Text, txt_idproof.Text, txt_usertype.SelectedValue, txt_userphoto.Text, 1, Convert.ToBoolean(Chk_status.Checked));
                if (i == 1)
                {
                    Response.Redirect("Staff.aspx?action=Saved");
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