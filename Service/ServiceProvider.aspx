<%@ Page Title="" Language="C#" MasterPageFile="~/Template/salon.master" AutoEventWireup="true" CodeFile="ServiceProvider.aspx.cs" Inherits="Service_ServiceProvider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Hair Zone Salon|Service Provider</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet" />
    <!-- iCheck -->
    <link href="../vendors/iCheck/skins/flat/green.css" rel="stylesheet" />
    <!-- Datatables -->
    <link href="../vendors/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="../vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet" />
    <link href="../vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet" />
    <link href="../vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet" />
    <link href="../vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet" />
    <!-- bootstrap-daterangepicker -->
    <link href="../vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet" />

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet" />
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet" />
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet" />
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="right_col" role="main">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <div style="align-items: center;">
                            <h1 style="color: black;">ServiceProvider Detail</h1>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right" style="float: right;">
                            <li class="breadcrumb-item"><a href="ServiceProviderList.aspx">ServiceProvider List</a></li>
                            <li class="breadcrumb-item active">Add New ServiceProvider</li>
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
                                <strong>Deletd !</strong>
                            </div>

                            <%}
                                } %>

                            <br />


                            <form runat="server" class="form-horizontal form-label-left">
                                <div style="width: 100%; float: left;">
                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">ProviderName</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_providername" required="required" class="form-control col-lg-12 " runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Service Comission</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_servicecomission" required="required" class="form-control col-lg-12" textmode="Number" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Product Comission</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_productcomission" required="required" class="form-control col-lg-12" textmode="Number" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">DateOfBirth</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_dob" required="required" class="form-control col-lg-12" textmode="Date" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Working Hour Start</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_whs" required="required" class="form-control col-lg-12" textmode="Time" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Working Hour End</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_whe" required="required" class="form-control col-lg-12" textmode="Time" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Salary</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_monthlysalary" required="required" class="form-control col-lg-12" textmode="Number" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">ServiceProviderType</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:dropdownlist id="txt_serviceprovidertype" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                                                <asp:ListItem>Maintenance</asp:ListItem>
                                                <asp:ListItem>Product Service</asp:ListItem>
                                            </asp:dropdownlist>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">ContactNo</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_contact" required="required" class="form-control col-lg-12" textmode="Phone" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">E-mail</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_email" required="required" class="form-control col-lg-12" textmode="Email" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Emergency Contact</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_emergencycontact" required="required" class="form-control col-lg-12" textmode="Phone" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Emergency Contact Person</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_emergencycontactperson" required="required" class="form-control col-lg-12" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Address</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_address" required="required" class="form-control col-lg-12" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Username</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_username" required="required" class="form-control col-lg-12" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Password</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_password" required="required" class="form-control col-lg-12" textmode="Password" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Gender</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:dropdownlist id="txt_gender" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                                <asp:ListItem>None</asp:ListItem>
                                            </asp:dropdownlist>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">DateOfJoining</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_joindate" required="required" class="form-control col-lg-12" textmode="Date" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Photo</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_photo" required="required" class="form-control col-lg-12" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Provider Photo</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:textbox id="txt_serviceproviderphoto" required="required" class="form-control col-lg-12" runat="server"></asp:textbox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Status</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="far fa-address-card"></i></span>
                                            </div>
                                            <asp:checkbox class="form-control" id="txt_status" text="  Active / NotActive" runat="server"></asp:checkbox>
                                        </div>
                                    </div>


                                    <div class="ln_solid"></div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                            <div class="card-header">
                                                <button type="button" class="btn btn-round btn-success" data-toggle="modal" data-target="#modal-default" style="width: 45%; float: left;">Add Service Provider</button>
                                                <button type="button" class="btn btn-round btn-success" data-target="#modal-default" style="width: 35%; float: left; background-color: lightcoral; border: none;">Reset</button>
                                            </div>
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
                                                        <asp:button id="Button2" onclick="Button2_Click" class="btn btn-primary" runat="server" text="Save"></asp:button>
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

