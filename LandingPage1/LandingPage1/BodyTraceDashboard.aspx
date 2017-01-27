<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BodyTraceDashboard.aspx.vb" Inherits="LandingPage1.BodyTraceDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Body Trace Dashboard</h1>
    <hr />
    <div class="form-group">
            <label for="usr">Imei:</label>
            <asp:TextBox ID="txtImei" CssClass="form-control input-lg" runat="server"></asp:TextBox>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnConnect" CssClass="btn btn-default" runat="server" Text="Connect" />
        </div>
    </div>
    <br />
    <div class="form-group">
            <label for="usr">Request URL:</label>
            <asp:TextBox ID="txtEndpoint" CssClass="form-control input-lg" runat="server"></asp:TextBox>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnGet" CssClass="btn btn-default" runat="server" Text="Get" />
        </div>
    </div>
    <br />
    <div class="form-group">
            <label for="usr">Response:</label>
            <asp:TextBox ID="txtResponse"  TextMode="MultiLine" CssClass="form-control input-lg" runat="server"></asp:TextBox>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnDeserialize" CssClass="btn btn-default" runat="server" Text="Deserialize" />
        </div>
    </div>
    <br />
    <div class="form-group">
            <label for="usr">Deserialized:</label>
            <asp:GridView ID="gvFeed" runat="server"></asp:GridView>
    </div>
    
</asp:Content>
