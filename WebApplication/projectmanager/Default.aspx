<%@ Page Title="" Language="C#" MasterPageFile="~/projectmanager/ProjectManagerMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.projectmanager.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- TODO: Make top bar included on master page-->

    <div class="container-fluid">
        <div class="d-sm-flex justify-content-between align-items-center mb-4">
            <h3 class="text-dark mb-0">Dashboard</h3>
        </div>
        <div class="row">

            <div class="col-md-6 col-xl-3 mb-4">
                <div class="card shadow border-left-warning py-2">
                    <div class="card-body">
                        <div class="row align-items-center no-gutters">
                            <div class="col mr-2">
                                <div class="text-uppercase text-warning font-weight-bold text-xs mb-1">
                                    <span>Tasks</span>
                                </div>
                                <div class="text-dark font-weight-bold h5 mb-0">
                                    <span><asp:Literal ID="ltrlTask" runat="server" 
                                          Text="0"></asp:Literal></span>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-comments fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-xl-3 mb-4">
                <div class="card shadow border-left-warning py-2">
                    <div class="card-body">
                        <div class="row align-items-center no-gutters">
                            <div class="col mr-2">
                                <div class="text-uppercase text-warning font-weight-bold text-xs mb-1">
                                    <span>Bugs</span>
                                </div>
                                <div class="text-dark font-weight-bold h5 mb-0">
                                    <span><asp:Literal ID="ltrlBug" runat="server" 
                                                       Text="0"></asp:Literal></span>
                                </div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-comments fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>