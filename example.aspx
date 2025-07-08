<%@ Page Language="C#" AutoEventWireup="true" CodeFile="example.aspx.cs" Inherits="example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript">               </script>  
   <script src="../JScripts/jquery-1.2.1.min.js" type="text/javascript"></script>  
   <script type="text/javascript">  
  
    function SaveRecord() {  
      //Get control's values  
      var Name = $.trim($('#<%=txtName.ClientID %>').val());  
      var Salary = $.trim($('#<%=txtSalary.ClientID %>').val());  
      var DeptId = $('#<%=ddlDeptId.ClientID %>').val();  
      var msg = "";  
         //check for validation  
         if (Name == '') {  
            msg += "Please enter Name";  
         }  
         if (Salary == '') {  
            msg += "Please enter Salary";  
         }  
         if (DeptId == 0) {  
            msg += "Please select your Department";  
         }  
            if (msg.length == 0) {  
         //Jquery Ajax call to server side method  
               $.ajax({  
               type: "POST",  
               dataType: "json",  
               contentType: "application/json; charset=utf-8",  
               url: "/Application/InsertByAjaxJquery.aspx/InsertEmpDetails",  
               data: "{'Name':'" + Name + "', 'Salary':'" + Salary + "','DeptId':'" + DeptId + "'}",  
               success: function (response) {  
               if (response.d == true) {  
                  $('#dvResult').text("Saved successfully");  
                  //Clear/Reset controls  
                  $('#txtName').val('');  
                  $('#txtSalary').val('');  
                  $('#ddlDeptId').val("0");  
               }  
               else {  
                     $('#lblMsg').text("Not Saved");  
                     }  
                  },  
                  error: function (xhr, textStatus, error) {  
                  $('#lblMsg').text("Error: " + error);  
                  }  
               });  
            }  
            else {  
               $('#lblMsg').html('');  
               $('#lblMsg').html(msg);  
            }  
         }  
        </script>  
    </head>  
    <body>  
        <form id="form1" runat="server">  
            <div>  
                <table>  
                    <tr>  
                        <td>  
                           Name:  
                        </td>  
                        <td>  
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>  
                        </td>  
                    </tr>  
                    <tr>  
                        <td>  
                           Salary:  
                        </td>  
                        <td>  
                            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>  
                        </td>  
                    </tr>  
                    <tr>  
                        <td>  
                           Department:  
                        </td>  
                        <td>  
                            <asp:DropDownList ID="ddlDeptId" runat="server">  
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>  
                                <asp:ListItem Text="IT" Value="1"></asp:ListItem>  
                                <asp:ListItem Text="HR" Value="2"></asp:ListItem>  
                                <asp:ListItem Text="Accounts" Value="3"></asp:ListItem>  
                            </asp:DropDownList>  
                        </td>  
                    </tr>  
                    <tr>  
                        <td></td>  
                        <td>  
                            <button type="submit" onclick="SaveRecord();return false">Submit</button>  
                        </td>  
                    </tr>  
                    <tr>  
                        <td></td>  
                        <td>  
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>  
                        </td>  
                    </tr>  
                </table>  
            </div>  
        </form>  
    </body>  
</html>
