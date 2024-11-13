<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmailAuthentication.Login" MasterPageFile="Site.master" %>
   
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Email OTP Authentication</title>
</asp:Content>--%>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Email OTP Authentication</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <label>Email:</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />

        <asp:Button ID="btnSendOtp" runat="server" Text="Send OTP" OnClick="btnSendOtp_Click" /><br />
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtEmail"
  ErrorMessage="Email is a required field."
  ForeColor="Red">
</asp:RequiredFieldValidator>
    </div>
</asp:Content>
