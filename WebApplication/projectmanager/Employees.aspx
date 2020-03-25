<%@ Page Title="" Language="C#" MasterPageFile="~/projectmanager/ProjectManagerMaster.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="WebApplication.projectmanager.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
        <div class="table table-borderless table-hover table-responsive table-striped">
            <asp:GridView ID="grvEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" BorderWidth="0px" CssClass="col-sm-12" Style="margin: auto;" OnSelectedIndexChanged="grvEmployees_OnSelectedIndexChanged">
                <Columns>
                   <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                       <ItemStyle Width="10%" />
                       <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                   </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name">
                        <ItemStyle Width="30%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" DataFormatString="{0:dd/MM/yyyy}">
                        <ItemStyle Width="50%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-secondary rounded-circle" SelectText="<i aria-hidden='true' class='fas fa-tasks'></i>">
                        <ControlStyle CssClass="btn btn-secondary rounded-circle" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:CommandField>
                </Columns>
                <EmptyDataTemplate>
                    <h5>No employees!</h5>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
