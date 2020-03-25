<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

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
                    <h1 class="display-4">Hello!</h1>
                    <p class="lead">Dit is mijn schoolproject!</p>
                    <hr class="my-4">
                    <p>Het is gebaseert op de activiteit van mijn stagebedrijf Progreso HR!</p>
                    <p>HR software is de core business van Progreso. Dit is ons vak, onze métier, vanaf de technologische zijde over de implementatie tot support bij het pragmatische gebruik ervan.</p>
                    <p>Ze beschikken daartoe over een uitgebreide expertise in HR, IT, veranderingsmanagement, projectmanagement en organisatieontwikkeling, essentiële voeding voor onze samenwerkingstrajecten.</p>
                    <p>Progreso staat voor een team van enthousiaste mensen die zich 100% inzetten voor een goed resultaat. We geloven in samenwerking en partnership en streven steeds naar een win-win, waarbij een aangename én rendabele relatie voorop staat.</p>
                    <p>Progreso staat tevens voor een systeem, een software oplossing die inzicht brengt in uw HR data. De uitgebreide informatie over mensen en hun ambities en realisaties wordt op een logische en transparante manier ter beschikking gesteld van de verschilende stakeholders, gevolgd door de juiste acties en de relevante beslissingen.</p>
                    <p class="lead">
                        <a class="btn btn-primary btn-lg" href="About.aspx" role="button">Leer mee over mij!</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
