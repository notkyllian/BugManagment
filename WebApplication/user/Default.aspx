<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.user.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="jumbotron">
            <h1 class="display-4">Hello, <asp:Literal ID="ltrlName" runat="server"></asp:Literal></h1>
            <p class="lead">Here you can report bugs regarding our software</p>
            <hr class="my-4">
            <p>On the left you can see the different type of actions you can do.</p>
        </div>
    </div>

   
</asp:Content>
