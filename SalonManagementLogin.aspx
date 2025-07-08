<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalonManagementLogin.aspx.cs" Inherits="SalonManagementLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hair Zone | Login Form</title>
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <header>
         <div class="blur">
         </div>
        <div class="back">
            <form runat="server" >
                <h1>Login</h1>
                <hr />
                <h3>Hair Zone Admin Login</h3>
                <p>
                    <asp:DropDownList ID="txt_logintype" CssClass="dropdown" runat="server">
                        <asp:ListItem>Staff</asp:ListItem>
                        <asp:ListItem>ServiceProvider</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:TextBox ID="txt_user" placeholder="Username" runat="server" required="required"></asp:TextBox>
                </p>
                <p>
                    <asp:TextBox ID="txt_pass" TextMode="Password" placeholder="Password" runat="server" required="required"></asp:TextBox>
                </p>
                <p>
                    <asp:CheckBox ID="txt_check" class="chk" runat="server" required="required" />
                    Remember Me
                </p>
                <p>
                    <button id="btnlogin" onserverclick="btnlogin_ServerClick" runat="server">
                        Login</button>
                </p>
            </form>
        </div>
    </header>
</body>

</html>

