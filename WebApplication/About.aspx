<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-flex flex-column" id="content-wrapper">
        <div id="content">
            <nav class="navbar navbar-light navbar-expand bg-white shadow mb-4 topbar static-top">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item dropdown no-arrow mx-1">
                        <a class="btn btn-sm align-middle btn-primary" href="/Account/Register.aspx">Register</a>
                    </li>
                    <li class="nav-item dropdown no-arrow mx-1">
                        <a class="btn btn-sm align-middle btn-primary" href="/Account/Login.aspx">Login</a>
                    </li>
                   
                </ul>
            </nav>

            <div class="container-fluid">
                <div class="jumbotron">
                    <h1 class="display-4">Hello, world!</h1>
                    <p class="lead">Kyllian Lissens</p>
                    <hr class="my-4">
                    <p>Ik ben een 19-jarige programmeur.</p>
                    <p>Ik studeer dit jaar af in de richting Informaticabeheer aan de Secundaire Handelsschool Sint-Lodewijk.</p>
                    <p>Voor mijn eindwerk, mocht ik een web-applicatie maken die gebruikers het toe laat om bugs te rapporteren, projectmanagers taken laten toevoegen en de werknemers een overzicht geven over hun taken</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
