<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/css/main.css" />
    <link rel="stylesheet" href="/Content/bootstrap.min.css" />
    
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.0/css/all.css" />
    <title>Register | Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                    <div class="card card-signin my-5">
                        <div class="card-body">
                            <%
                                if (Session["error"] != null)
                                {
                            %>

                            <div class="alert alert-warning alert-dismissible">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>Warning!</strong> <%=Session["error"]%>
                            </div>

                            <%
                                }
                            %>
                            <h5 class="card-title text-center">Sign In</h5>
                            <div class="form-signin">
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
</body>
</html>
