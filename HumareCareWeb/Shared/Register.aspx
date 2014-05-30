<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HumareCareWeb.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="content">
        <table class="style1">
        <asp:label id="ErrorLabel" runat="Server" forecolor="Red" visible="false" />
            <tr>
                <td class="style2">
                    <asp:label id="lblUName" runat="server" text="Username"></asp:label>
                </td>
                <td>
                    <asp:textbox id="Username" runat="server"></asp:textbox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    
                    <asp:label id="lblpwd" runat="server" text="Password"></asp:label>
                </td>
                <td>
                    <asp:textbox id="Password" runat="server" textmode="Password"></asp:textbox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <asp:button id="btnLogin" runat="server" text="Login" onclick="btnLogin_Click" />
        </table>
        
    </div>
</asp:Content>
