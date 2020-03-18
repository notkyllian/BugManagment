<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/css/main.css"/>
    <link rel="stylesheet" href="/Content/bootstrap.min.css"/>

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.0/css/all.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css"/>
    <title>Register | Management</title>
</head>
<body>
<form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                <div class="card card-signin my-5">
                    <div class="card-body">
                        <div class="alert alert-warning alert-dismissible" id="error" runat="server" visible="false" enableviewstate="true">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Warning! <asp:Literal ID="message" runat="server"></asp:Literal></strong> 
                        </div>

                        <div style="display: flex;">
                            <a class="btn btn-primary" style="height: 40px;" href="/">Back</a>
                            <h5 style="margin-left: 23%;" class="card-title text-center">Register</h5>

                        </div>


                        <div class="form-signin">
                            <div class="form-label-group">
                                <asp:TextBox CssClass="form-control" ID="inputName" runat="server" placeholder="name" required="true" type="text" autofocus="true"></asp:TextBox>
                                <label for="inputName">Name</label>
                            </div>
                            <asp:HiddenField runat="server" ID="hdnDate" Value="01/01/2001"/>

                            <!--  possible solution -> <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>-->
                            <div class="border rounded" style="margin-bottom: 20px; border-radius: 2rem !important;">
                                <p class="text-center">Birthday</p>
                                <div class="form-label-group">

                                    <div style="margin-left: 23%; width: 52%; border-radius: 1rem !important;" id="txtDate" class="border rounded"></div>
                                </div>
                            </div>


                            <div class="form-label-group">
                                <asp:TextBox CssClass="form-control" ID="inputUser" runat="server" placeholder="username" required="true" type="text" autofocus="true"></asp:TextBox>
                                <label for="inputUser">Username</label>
                            </div>

                            <div class="form-label-group">
                                <asp:TextBox CssClass="form-control" ID="inputPassword" runat="server" placeholder="password" required="true" type="password"></asp:TextBox>
                                <label for="inputPassword">Password</label>
                            </div>

                            <asp:DropDownList ID="Role" runat="server" CssClass="form-control">
                                <asp:ListItem>User</asp:ListItem>
                                <asp:ListItem>Employee</asp:ListItem>
                                <asp:ListItem>Projectmanager</asp:ListItem>
                            </asp:DropDownList>

                            <asp:Button ID="RegisterButton" runat="server" class="btn btn-lg btn-primary btn-block text-uppercase" Text="Register" OnClick="RegisterButton_OnClick"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</form>


<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {

        $('[id*=txtDate]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                defaultDate: '01/01/01'

            })
            .change(dateChanged)
            .on('changeDate', dateChanged);

        function dateChanged(e) {

            $('[id*=txtDate]').val(e.format(0, "dd/mm/yyyy"));

            $("#<%= hdnDate.ClientID %>").val(e.format(0, "dd/mm/yyyy"));

        }

    });
</script>
</body>
</html>