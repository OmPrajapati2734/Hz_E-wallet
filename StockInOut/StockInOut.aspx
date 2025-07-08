<%@ Page Title="" Language="C#" MasterPageFile="~/Template/salon.master" AutoEventWireup="true" CodeFile="StockInOut.aspx.cs" Inherits="StockInOut_StockInOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Hair Zone Salon | StockInOut</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="right_col" role="main">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <div style="align-items: center;">
                            <h1 style="color: black;">Stock Detail</h1>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right" style="float: right;">
                            <li class="breadcrumb-item"><a href="StockInOutList.aspx">StockInOutList</a></li>
                            <li class="breadcrumb-item active">Add New Stock</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
        <div class="">
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_panel">
                            <div class="title_left">
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
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Branch Name</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList ID="txt_branchname" required="required" class="form-control col-md-7 col-xs-12" runat="server" DataSourceID="LinqDataSource1" DataTextField="BranchName" DataValueField="Id">
                                            </asp:DropDownList>
                                            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="DataClassesDataContext" Select="new (Id, BranchName)" TableName="tbl_BranchMasters"></asp:LinqDataSource>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Supplier Name</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList ID="txt_suppliername" required="required" class="form-control col-md-7 col-xs-12" runat="server" DataSourceID="LinqDataSource2" DataTextField="SuplierName" DataValueField="Id">
                                            </asp:DropDownList>
                                            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="DataClassesDataContext" Select="new (Id, SuplierName)" TableName="tbl_SuplierMasters"></asp:LinqDataSource>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">StockType</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList ID="txt_stocktype" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                                                <asp:ListItem>IN</asp:ListItem>
                                                <asp:ListItem>OUT</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Invoice Number</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_invoicenumber" required="required" class="form-control col-lg-12 " runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Invoice Date</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_invoicedate" required="required" class="form-control col-lg-12" TextMode="Date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <hr />

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total Quantity</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_totalquantity" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Price</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_price" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total price</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_Total" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Net Amount</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_netamount" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total GST</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_totalgst" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total CGST</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_totalcgst" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total IGST</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_totaligst" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total SGST</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_sgst" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total Taxable Amount</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_taxableamount" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>




                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total Discount</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_totaldiscount" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Total Amount</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_totalamount" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Remark</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_remark" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                            <button type="button" class="btn btn-round btn-success" data-toggle="modal" data-target="#modal-default" style="width: 45%; float: left;">Add New Stock</button>
                                            <button type="button" class="btn btn-round btn-success" data-target="#modal-default" style="width: 35%; float: left; background-color: lightcoral; border: none;">Reset</button>
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

</asp:Content>

