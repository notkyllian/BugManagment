<%@ Page Title="" Language="C#" MasterPageFile="~/user/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.user.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card mb-4 py-3 border-bottom-primary text-center">
            <div class="card-header">
                Report Bug
            </div>
            <div class="card-body">
                <br/>
                <div class="form-group">
                    <label for="bugDescription">Bug description</label>
                    <textarea class="form-control" id="bugDescription" runat="server" rows="3"></textarea>
                </div>
                <br/>
                <asp:Button OnClick="Submit" Text="Report!" CssClass="btn btn-danger" runat="server"></asp:Button>
            </div>
        </div>
    </div>
    <div class="modal fade" id="NotificationModal" tabindex="-1" role="dialog" aria-labelledby="NotificationModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="NotificationLabel">Notification!</h5>
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
            $("#NotificationModal").modal();
        }
    </script>


</asp:Content>