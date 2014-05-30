<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="MainPage.aspx.cs" Inherits="HumareCareWeb.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="buttons">
        <%--<a class="button" href="/">Home</a> --%>
        <a class="button" href="PatientManagement.aspx">Patient Management</a> 
        <a class="button" href="PatientAppointment.aspx">Patient Appointment</a>
        <a class="button" href="PatientRoom.aspx">Patient Room Booking</a>
         <a class="button"href="DoctorsArena.aspx">Doctors arena</a> 
         <a class="button" href="Billing.aspx">Hospital billing</a>
    </div>
     <div class="content">
          
        </div>
</asp:Content>
