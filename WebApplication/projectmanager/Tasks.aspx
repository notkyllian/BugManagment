<%@ Page Title="" Language="C#" MasterPageFile="~/projectmanager/ProjectManagerMaster.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="WebApplication.projectmanager.Tasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        
            <h4>Add task</h4>
            <div class="input-group mb-3">
                
                <div class="input-group-prepend">
                    <label class="input-group-text" for="inputGroupSelect01">Bug</label>
                </div>
                <asp:DropDownList ID="DropDownList1" CssClass="custom-select" runat="server"></asp:DropDownList>

                <div class="input-group-prepend">
                    <span class="input-group-text ml-3">Description</span>
                </div>
                <input type="text" runat="server" class="form-control" id="iptTitel"/>

                <div class="input-group-prepend">
                    <span class="input-group-text ml-3">Size (1-10)</span>
                </div>
                <input type="text" runat="server" class="form-control" id="iptSize"/>

                <div class="input-group-append ml-3">
                    <asp:LinkButton ID="btnAddTask" CssClass="btn btn-outline-primary" runat="server" Text="<i class='fas fa-plus'> </i>Add" OnClick="btnAddTask_OnClick"></asp:LinkButton>
                </div>
            </div>
       

        <div class="table table-borderless table-hover table-responsive table-striped">
            <asp:GridView ID="grvTasks" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" BorderWidth="0px" CssClass="col-sm-12" Style="margin: auto;" EnableViewState="False" OnRowEditing="grvTasks_OnRowEditing" OnRowUpdating="grvTasks_OnRowUpdating" OnRowCancelingEdit="grvTasks_OnRowCancelingEdit" OnRowDeleting="grvTasks_OnRowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                        <ItemStyle Width="5%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Employee">
                        <ItemStyle Width="15%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Employee.Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEmployees" CssClass="custom-select" runat="server" DataSourceID="odsEmployees" DataTextField="Name" DataValueField="Id" >
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsEmployees" runat="server" SelectMethod="GetEmployees" TypeName="Domain.Business.Controller"></asp:ObjectDataSource>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description">
                        <ItemStyle Width="80%" />
                        <HeaderStyle BackColor="#3498DB" ForeColor="White" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <input type="text" class="form-control" placeholder="Description" aria-label="Description" id="txtDescription" value="<%# Eval("Description") %>"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                   
                    
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
                   <div class="container text-center">
                       <p class="text-center">There are no tasks! </p>
                   </div>
                        
                </EmptyDataTemplate>
            </asp:GridView>
            
        </div>
        <asp:Panel ID="backPanel" runat="server">
            <div style="width: 200px;" class="mx-auto">
                <asp:Button Style="width: 200px;" CssClass="btn btn-secondary mx-auto" ID="btnBack" runat="server" Text="Back" />
            </div>
        </asp:Panel>

    </div>
    
    <div class="modal fade" id="ErrorModal" tabindex="-1" role="dialog" aria-labelledby="ErrorModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ErrorLabel">Error!</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
    
    <script>
        function Notify() {

            $("#ErrorModal").modal();
        }
    </script>
</asp:Content>
