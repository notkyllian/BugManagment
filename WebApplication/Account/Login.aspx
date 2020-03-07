<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                <div class="card card-signin my-5">
                    <div class="card-body">
                        <h5 class="card-title text-center">Sign In</h5>
                        <form class="form-signin">
                            <div class="form-label-group">
                               <asp:TextBox CssClass="form-control" ID="inputUser" runat="server" placeholder="usernaùe" required="true" type="text" autofocus="true"></asp:TextBox>
                                <label for="ContentPlaceHolder1_inputUser">Username</label>
                            </div>

                            <div class="form-label-group">
                                <asp:TextBox CssClass="form-control" ID="inputPassword" runat="server" placeholder="password" required="true" type="password"></asp:TextBox>
                                <label for="ContentPlaceHolder1_inputPassword">Password</label>
                            </div>

                            <div class="custom-control custom-checkbox mb-3">
                                <input type="checkbox" class="custom-control-input" id="customCheck1">
                                <label class="custom-control-label" for="customCheck1">Remember password</label>
                            </div>

                            <asp:Button ID="LoginButton" runat="server" class="btn btn-lg btn-primary btn-block text-uppercase" type="submit" Text="Sign in" OnClick="Login_Click"/>
                             </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
