<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="HumareCareWeb.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content" align="center">
        <table align="center">
            <asp:label id="ErrorLabel" runat="Server" forecolor="Red" visible="false" />
            <tr>
                <td>
                    <asp:label id="lblUName" runat="server" text="Username"></asp:label>
                </td>
                <td width="100px">
                    <asp:textbox id="Username" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:label id="lblpwd" runat="server" text="Password"></asp:label>
                </td>
                <td>
                    <asp:textbox id="Password" runat="server" textmode="Password" width="150px"></asp:textbox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                   <asp:button id="btnLogin" runat="server" text="Login" onclick="btnLogin_Click" />
                </td>
                <td>
                   
                </td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td></td>
                 <td>
                    <asp:linkbutton runat="server"><a href="Register.aspx">Register</a></asp:linkbutton>
                
                </td>
                <td>
                If you don't have an account  
                </td>
                <td>
                   
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
