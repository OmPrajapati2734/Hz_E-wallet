using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profile_CustomerProfileList : System.Web.UI.Page
{
    BranchService s = new BranchService();
    DataClassesDataContext dbc = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        ListView1.DataSource = (from c in dbc.tbl_CustomerMasters
                                select new
                                {
                                    c.CreatedAt,
                                    c.DateOfBirth,
                                    c.Email,
                                    c.FirstName,
                                    c.Gender,
                                    c.Id,
                                    c.LastName,
                                    c.Mobile,
                                    c.ModifiedAt,
                                    c.OpeningBalance,
                                    c.Status,
                                    c.Verified,
                                    c.WalletAccount
                                }).ToList();
        ListView1.DataBind();

       
       
    }

    

}