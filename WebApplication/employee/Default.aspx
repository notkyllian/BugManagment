<%@ Page Title="" Language="C#" MasterPageFile="~/employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.employee.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="table table-borderless table-hover table-responsive table-striped">
            <asp:GridView ID="grvTasks" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" BorderWidth="0px" CssClass="col-sm-12" Style="margin: auto;" EnableViewState="False" OnRowEditing="grvTasks_OnRowEditing" OnRowCancelingEdit="grvTasks_OnRowCancelingEdit" OnRowUpdating="grvTasks_OnRowUpdating" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                        <ItemStyle Width="5%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True">
                        <ItemStyle Width="60%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:BoundField>

                    <asp:BoundField DataField="TimeSpent" HeaderText="TimeSpent" DataFormatString="{0:t}">
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
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
                </Columns>
                <EmptyDataTemplate>
                   <div class="container text-center">
                       <p class="text-center">There are no tasks! </p>
                   </div>
                </EmptyDataTemplate>
            </asp:GridView>
            
        </div>
    </div>
    
</asp:Content>
