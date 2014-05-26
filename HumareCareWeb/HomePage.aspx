<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="HomePage.aspx.cs" Inherits="HumareCareWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content">
            <h3 class="h3">
                Welcome to Human Care Hospital Management System</h3>
            <ol class="round">
                <li class="one">Hospital Management provides a direct link between healthcare facilities
                    and those supplying the services they need. This procurement and reference resource
                    provides a one-stop-shop for professionals and decision makers within the hospital
                    management, healthcare and patient care industries. The project structure involves
                    Adminstration clerks, Doctors and Higher management. </li>
            </ol>
            <p>
                <a class="openPopup" data-dialog-id="popuplDialog" data-dialog-title="Popup" href="/Home/Popup">
                    Click here to open modal popup</a>
            </p>
           <asp:LinkButton ID="AdminLink" runat="server"><a href="MainPage.aspx">MainPage.aspx</a></asp:LinkButton>
        </div>
</asp:Content>


