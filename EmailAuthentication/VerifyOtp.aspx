<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyOtp.aspx.cs" Inherits="EmailAuthentication.VerifyOtp" MasterPageFile="~/Site.master" %>



<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Verify OTP</h2>
        <label>OTP:</label>
        <asp:TextBox ID="txtOtp" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP" OnClick="btnVerifyOtp_Click" />
        <br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

