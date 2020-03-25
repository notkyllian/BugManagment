<%@ Page Title="" Language="C#" MasterPageFile="~/projectmanager/ProjectManagerMaster.Master" AutoEventWireup="true" CodeBehind="Bugs.aspx.cs" Inherits="WebApplication.projectmanager.Bugs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="table table-borderless table-hover table-responsive table-striped">
            <asp:GridView ID="grvBugs" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" BorderWidth="0px" CssClass="col-sm-12" Style="margin: auto;" OnRowEditing="grvBugs_RowEditing" OnRowUpdating="grvBugs_OnRowUpdating" OnRowCancelingEdit="grvBugs_OnRowCancelingEdit" OnRowDeleting="grvBugs_OnRowDeleting" EnableViewState="False" OnSelectedIndexChanged="grvBugs_OnSelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                        <ItemStyle Width="10%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description">
                        <ItemStyle Width="80%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:BoundField>
                    
                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-secondary rounded-circle" SelectText="<i aria-hidden='true' class='fas fa-tasks'></i>">
                        <ControlStyle CssClass="btn btn-secondary rounded-circle" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:CommandField>
                    <asp:TemplateField>
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" HorizontalAlign="Center"/>
                        <ItemTemplate>
                            <asp:LinkButton ID="editRow" runat="server" CommandName="Edit" Text="<i aria-hidden='true' class='fas fa-pen'></i>" CssClass="btn btn-secondary rounded-circle"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton id="btnUpdate" runat="server" commandname="Update" text="Update" CssClass="btn btn-primary mb-1 btn-block" />
                            <asp:LinkButton id="btnCancel" runat="server" commandname="Cancel" text="Cancel" CssClass="btn btn-primary btn-block" />
                        </EditItemTemplate>

                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger rounded-circle" DeleteText="<i aria-hidden='true' class='fas fa-trash-alt'></i>">
                        <ControlStyle CssClass="btn btn-danger rounded-pill" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:CommandField>
                </Columns>
                <EmptyDataTemplate>
                    <h5>All bugs are resolved!</h5>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>

    </div>


</asp:Content>