<%@ Page Title="" Language="C#" MasterPageFile="~/Template/salon.master" AutoEventWireup="true" CodeFile="BranchAdd.aspx.cs" Inherits="Branch_BranchAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Hair Zone Salon| Branch Add</title>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

    <div class="right_col" role="main">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <div style="align-items: center;">
                            <h1 style="color: black;">Branch Detail</h1>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right" style="float: right;">
                            <li class="breadcrumb-item"><a href="BranchList.aspx">Branch List</a></li>
                            <li class="breadcrumb-item active">Add Branch</li>
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
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Branch Name</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_branchname" required="required" class="form-control col-lg-12 " runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">City</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_city" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">PIN Code</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_pincode" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Full Address</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_fulladdress" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Land Mark</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_landmark" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Mobile</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_mobile" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">What's App</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_whatsapp" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">E-mail</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_email" required="required" class="form-control col-lg-12" TextMode="Email" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Category</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList ID="txt_category" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                                <asp:ListItem>Both</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">GoogleMapLocation</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_googlemap" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">GST Number</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_gstnumber" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Manager Name</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_managername" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Manager Mobile</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_managermobile" required="required" class="form-control col-lg-12" TextMode="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Manager E-mail</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_manageremail" required="required" class="form-control col-lg-12" TextMode="Email" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Login Id</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_loginid" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Password</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_password" required="required" class="form-control col-lg-12" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Status</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="far fa-address-card"></i></span>
                                            </div>
                                            <asp:CheckBox class="form-control" ID="Chk_status" Text="  Active / NotActive" runat="server"></asp:CheckBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Branch Photo</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txt_branchphoto" required="required" class="form-control col-lg-12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label style="color: black;" class="control-label col-md-3 col-sm-3 col-xs-12"><span class="required">Branch Type</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList ID="txt_branchtype" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                                                <asp:ListItem>Head Branch</asp:ListItem>
                                                <asp:ListItem>Branch</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="ln_solid"></div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                            <div class="card-header">
                                                <button type="button" class="btn btn-round btn-success" data-toggle="modal" data-target="#modal-default" style="width: 45%; float: left;">Add New Branch</button>
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
</asp:Content>


