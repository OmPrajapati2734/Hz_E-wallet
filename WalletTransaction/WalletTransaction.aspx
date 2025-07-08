<%@ Page Title="" Language="C#" MasterPageFile="~/Template/salon.master" AutoEventWireup="true" CodeFile="WalletTransaction.aspx.cs" Inherits="WalletTransaction_WalletTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Hair Zone Salon|Wallet Transaction</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

    <div class="right_col" role="main">
        <div class="">
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_panel">
                            <div class="title_left">
                                <h1 style="color: black;">Wallet Transaction</h1>
                            </div>

                            <br />
                            <% if (Request.QueryString["action"] != null)
                                {
                                    if (Request.QueryString["action"] == "Saved")
                                    {
                            %>
                            <div class="alert alert-success alert-dismissible fade in" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                                <strong>Saved Sucessfully!</strong>

                            </div>
                            <%}
                                if (Request.QueryString["action"] == "delete")
                                {%>
                            <div class="alert alert-danger alert-dismissible fade in" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                                <strong>Record Deletd !</strong>
                            </div>

                            <%}
                                } %>

                            <form runat="server" class="form-horizontal form-label-left">
                                <div style="width: 80%; float: left;">

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Customer Name</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList ID="txt_customername" required="required" class="form-control col-md-7 col-xs-12" runat="server" DataSourceID="LinqDataSource1" DataTextField="FirstName" DataValueField="Id">
                                            </asp:DropDownList>
                                            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="DataClassesDataContext" Select="new (Id, FirstName, LastName)" TableName="tbl_CustomerMasters"></asp:LinqDataSource>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Transaction Name</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_transactionname" required="required" class="form-control col-lg-12 " runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Reference Number</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_referenceno" required="required" class="form-control col-lg-12 " runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Transaction From</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_transactionfrom" required="required" class="form-control col-lg-12 " runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">TransactionDate</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_transactiondate" required="required" class="form-control col-lg-12 " TextMode="Date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">TransactionType</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList ID="txt_transactiontype" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                                                <asp:ListItem>CREDIT</asp:ListItem>
                                                <asp:ListItem>DEBIT</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Amount</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_amount" TextMode="Number" required="required" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                            <button type="button" class="btn btn-round btn-success" data-toggle="modal" data-target="#modal-default" style="width: 45%; float: left;">Add New Wallet</button>
                                        </div>
                                    </div>

                                    <section class="content">
                                        <div class="modal fade" id="modal-default">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">Confirmation</h4>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">

                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <p>Make Sure All the fields are not be empty&hellip;</p>
                                                    </div>
                                                    <div class="modal-footer justify-content-between">
                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                        <asp:Button ID="Button2" OnClick="Button2_Click" class="btn btn-primary" runat="server" Text="Save"></asp:Button>
                                                    </div>
                                                </div>
                                                <!-- /.modal-content -->
                                            </div>
                                            <!-- /.modal-dialog -->
                                        </div>

                                    </section>
                                </div>
                            </form>
                            <br />

                            <div class="comming-soon-wrapper">
                                <div class="content">
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="card">
                                                <div class="card-header">
                                                    <h3 class="card-title" style="text-align: center; color: black;">Wallet Account List</h3>
                                                </div>
                                                <br />
                                                <div class="card-body" style="overflow-x: auto;">
                                                    <table id="example1" class="table table-bordered" style="color: black;">
                                                        <thead>
                                                            <tr>
                                                                <td>#</td>
                                                                <td>Customer Name</td>
                                                                <td>Transaction Name</td>
                                                                <td>Reference No</td>
                                                                <td>Transaction From</td>
                                                                <td>Transaction Date</td>
                                                                <td>Transaction Type</td>
                                                                <td>Amount</td>
                                                                <td>CreatedAt</td>
                                                                <td>ModifiedAt</td>
                                                                <td>Action</td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="ListView1" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td><%# Eval("Id") %></td>
                                                                        <td><%# Eval("FirstName")  %></td>
                                                                        <td><%# Eval("TransactionName") %></td>
                                                                        <td><%# Eval("ReferenceNo") %></td>
                                                                        <td><%# Eval("TransactionFrom") %></td>
                                                                        <td><%# Eval("TransactionDate") %></td>
                                                                        <td><%# Eval("TransactionType") %></td>
                                                                        <td><%# Eval("Amount") %></td>
                                                                        <td><%# Eval("CreatedAt") %></td>
                                                                        <td><%# Eval("ModifiedAt") %></td>
                                                                        <td><a href='WalletTransaction.aspx?open=<%# Eval("Id") %>'>
                                                                            <button class="btn btn-primary">Open</button></a>
                                                                            <a href='WalletTransaction.aspx?delete=<%# Eval("Id") %>'>
                                                                                <button class="btn btn-danger">delete</button></a>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                        <tfoot>
                                                            <tr>
                                                                <td>#</td>
                                                                <td>Customer Name</td>
                                                                <td>Transaction Name</td>
                                                                <td>Reference No</td>
                                                                <td>Transaction From</td>
                                                                <td>Transaction Date</td>
                                                                <td>Transaction Type</td>
                                                                <td>Amount</td>
                                                                <td>CreatedAt</td>
                                                                <td>ModifiedAt</td>
                                                                <td>Action</td>
                                                            </tr>
                                                        </tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- Chart.js -->
    <script src="../vendors/Chart.js/dist/Chart.min.js"></script>
    <!-- jQuery Sparklines -->
    <script src="../vendors/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
    <!-- Flot -->
    <script src="../vendors/Flot/jquery.flot.js"></script>
    <script src="../vendors/Flot/jquery.flot.pie.js"></script>
    <script src="../vendors/Flot/jquery.flot.time.js"></script>
    <script src="../vendors/Flot/jquery.flot.stack.js"></script>
    <script src="../vendors/Flot/jquery.flot.resize.js"></script>
    <!-- Flot plugins -->
    <script src="../vendors/flot.orderbars/js/jquery.flot.orderBars.js"></script>
    <script src="../vendors/flot-spline/js/jquery.flot.spline.min.js"></script>
    <script src="../vendors/flot.curvedlines/curvedLines.js"></script>
    <!-- DateJS -->
    <script src="../vendors/DateJS/build/date.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="../vendors/moment/min/moment.min.js"></script>
    <script src="../vendors/bootstrap-daterangepicker/daterangepicker.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- iCheck -->
    <script src="../vendors/iCheck/icheck.min.js"></script>
    <!-- Datatables -->
    <script src="../vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../vendors/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="../vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/buttons.flash.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="../vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
    <script src="../vendors/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
    <script src="../vendors/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="../vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
    <script src="../vendors/datatables.net-scroller/js/dataTables.scroller.min.js"></script>
    <script src="../vendors/jszip/dist/jszip.min.js"></script>
    <script src="../vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="../vendors/pdfmake/build/vfs_fonts.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- jQuery custom content scroller -->
    <script src="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- Chart.js -->
    <script src="../vendors/Chart.js/dist/Chart.min.js"></script>
    <!-- jQuery Sparklines -->
    <script src="../vendors/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
    <!-- Flot -->
    <script src="../vendors/Flot/jquery.flot.js"></script>
    <script src="../vendors/Flot/jquery.flot.pie.js"></script>
    <script src="../vendors/Flot/jquery.flot.time.js"></script>
    <script src="../vendors/Flot/jquery.flot.stack.js"></script>
    <script src="../vendors/Flot/jquery.flot.resize.js"></script>
    <!-- Flot plugins -->
    <script src="../vendors/flot.orderbars/js/jquery.flot.orderBars.js"></script>
    <script src="../vendors/flot-spline/js/jquery.flot.spline.min.js"></script>
    <script src="../vendors/flot.curvedlines/curvedLines.js"></script>
    <!-- DateJS -->
    <script src="../vendors/DateJS/build/date.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="../vendors/moment/min/moment.min.js"></script>
    <script src="../vendors/bootstrap-daterangepicker/daterangepicker.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- iCheck -->
    <script src="../vendors/iCheck/icheck.min.js"></script>
    <!-- Datatables -->
    <script src="../vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../vendors/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="../vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/buttons.flash.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="../vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="../vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
    <script src="../vendors/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
    <script src="../vendors/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="../vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
    <script src="../vendors/datatables.net-scroller/js/dataTables.scroller.min.js"></script>
    <script src="../vendors/jszip/dist/jszip.min.js"></script>
    <script src="../vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="../vendors/pdfmake/build/vfs_fonts.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- jQuery custom content scroller -->
    <script src="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
</asp:Content>

