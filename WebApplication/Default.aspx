<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1>EPIC</h1>
  <asp:LoginView ID="LoginView1" runat="server">
      <RoleGroups>
          <asp:RoleGroup Roles="Admin">
          </asp:RoleGroup>
      </RoleGroups>
    </asp:LoginView>
</asp:Content>
