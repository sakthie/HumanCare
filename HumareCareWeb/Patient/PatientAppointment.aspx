<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Patient.Master" AutoEventWireup="true"
    CodeBehind="PatientAppointment.aspx.cs" Inherits="HumareCareWeb.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 144px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
<asp:Panel ID="RegPanel" align="center" runat="server">
    <table align=center style="width: 745px; margin-right: 46px;">
        <tr>
            <td class="style1">
                <asp:radiobutton runat="server" id="rdbNewReg" text="New Registration" 
                    AutoPostBack="True" Checked="True" oncheckedchanged="rdbNewReg_CheckedChanged"></asp:radiobutton></td>
                    <td>
                <asp:radiobutton runat="server" id="rdbOldReg" text="Old Registration" 
                    AutoPostBack="True" oncheckedchanged="rdbOldReg_CheckedChanged"></asp:radiobutton>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
                <td class="style1">
                    <asp:label runat="server" text="IC No" id="lblICNo"></asp:label>
                </td>
                <td>
                    <asp:textbox runat="server" id="txtICNo"></asp:textbox>
                </td>
                <td><asp:Button ID="CheckICButton" runat="server" 
                            onclick="btnCheckIc_Click" text="Check IC" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="ICRequiredFieldValidator" runat="server" 
                        ControlToValidate="txtICNo" validationgroup="PatientBooking" 
                        ErrorMessage="IC Number is Mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="PatientRegisterationPanel" align="center" runat="server">
            <table align="center" style="width: 745px; margin-right: 46px;">
            <tr>
            <td class="style12">
                <asp:label runat="server" text="Register Patient" id="lblPatientRegisteration" font-bold=true></asp:label>
            </td>
            </tr>
            <tr><td class="style12">
                <asp:label runat="server" text="Name" id="lblName"></asp:label>
            </td>
            <td class="style9">
                <asp:textbox runat="server" id="txtName"></asp:textbox>
            </td>
            <td class="style10">
                <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" 
                    ControlToValidate="txtName" validationgroup="PatientBooking" 
                    ErrorMessage="Name is Mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
            <td class="style12">
                <asp:label runat="server" text="DOB"></asp:label>
            </td>
            <td class="style9">
                <asp:dropdownlist runat="server" id="drpDay"></asp:dropdownlist>
                <asp:dropdownlist runat="server" id="drpMonth"></asp:dropdownlist>
                <asp:dropdownlist runat="server" id="drpYear"></asp:dropdownlist>
            </td><td class="style10">
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:label runat="server" text="Sex"></asp:label>
                </td>
                <td class="style9">
                    <asp:radiobutton runat="server" id="rdbMale" text="Male" AutoPostBack="True" 
                        Checked="True" oncheckedchanged="rdbMale_CheckedChanged1"></asp:radiobutton>
                    <asp:radiobutton runat="server" id="rdbFemale" text="Female" 
                        AutoPostBack="True" oncheckedchanged="rdbFemale_CheckedChanged1"></asp:radiobutton>
                </td><td class="style10">
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:label runat="server" text="Contact Number" id="lblContact"></asp:label>
                </td>
                <td class="style9">
                    <asp:textbox runat="server" id="txtContactNo"></asp:textbox>
                </td>
                <td class="style11">
                    <asp:RequiredFieldValidator ID="ContactNpRequiredValidator" runat="server" validationgroup="PatientBooking"
                        ControlToValidate="txtContactNo" ErrorMessage="Enter Contact Number" 
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td class="style10">
                    <asp:RegularExpressionValidator ID="ContactNoRegexValidator" runat="server" validationgroup="PatientBooking"
                        ControlToValidate="txtContactNo" ErrorMessage="Enter Valid Number" 
                        ValidationExpression="\d{8}" ForeColor="#FF3300"></asp:RegularExpressionValidator></td>

            </tr>
            <tr>
                <td class="style12">
                    <asp:label runat="server" text="Email" id="lblEmail"></asp:label>
                </td>
                <td class="style9">
                    <asp:textbox runat="server" id="txtEmail"></asp:textbox>
                </td>
                <td class="style10">
                    <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" validationgroup="PatientBooking"
                        ControlToValidate="txtEmail" ErrorMessage="Enter Email ID" 
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="EmailRegexValidator" runat="server" validationgroup="PatientBooking"
                        ErrorMessage="Enter Valid Email" ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ForeColor="#FF3300"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
            <td class="style12">
                <asp:label runat="server" text="Nationality" id="lblNationality"></asp:label>
            </td>
            <td class="style9">
                <asp:dropdownlist runat="server" id="drpNationality"></asp:dropdownlist>
            </td>
            <td class="style10">
                <asp:RequiredFieldValidator ID="NationalityRequiredValidator" runat="server" 
                    ControlToValidate="drpNationality" ErrorMessage="Select Nationality" 
                    validationgroup="PatientBooking" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
            <td class="style12">
                <asp:label runat="server" text="Street" id="lblStreet"></asp:label>
            </td>
            <td class="style9">
                <asp:textbox runat="server" id="txtStreet"></asp:textbox>
            </td>
            <td class="style10">
                <asp:RequiredFieldValidator ID="StreetRequiredFieldValidator" runat="server" 
                    ControlToValidate="txtStreet" ErrorMessage="Enter Street" 
                    validationgroup="PatientBooking" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
            <td class="style12">
                <asp:label runat="server" text="Area" id="lblArea"></asp:label>
            </td>
            <td class="style9">
                <asp:textbox runat="server" id="txtArea"></asp:textbox>
            </td>
            <td class="style10">
                <asp:RequiredFieldValidator ID="AreaRequiredFieldValidator" runat="server" 
                    ControlToValidate="txtArea" ErrorMessage="Enter Area" 
                    validationgroup="PatientBooking" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
            <td class="style12">
                <asp:label runat="server" text="Country" id="lblCountry"></asp:label>
            </td>
            <td class="style9">
                <asp:textbox runat="server" id="txtCountry"></asp:textbox>
            </td>
            <td class="style10">
                <asp:RequiredFieldValidator ID="CountryRequiredValidator" runat="server" 
                    ControlToValidate="txtCountry" ErrorMessage="Enter Country" 
                    validationgroup="PatientBooking" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
            <td class="style12">
                <asp:label runat="server" text="PostalCode" id="lblPostalCode"></asp:label>
            </td>
            <td class="style9">
                <asp:textbox runat="server" id="txtPostalCode" 
                    ValidationGroup="BookingAppointment"></asp:textbox>
            </td>
            <td class="style10">
                <asp:RequiredFieldValidator ID="PostalRequiredValidator" runat="server" 
                    ControlToValidate="txtPostalCode" ErrorMessage="Enter Postal Code" 
                    validationgroup="PatientBooking" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            <td>
                <asp:RegularExpressionValidator ID="PostalRegexValidator" runat="server" 
                    ControlToValidate="txtPostalCode" ErrorMessage="Enter Valid Postal Code" 
                    ValidationExpression="\d{6}" validationgroup="PatientBooking" 
                    ForeColor="#FF3300"></asp:RegularExpressionValidator></td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PatientAppointmentPanel" align="center" runat="server">
        <table align="center" style="width: 745px; margin-right: 46px;">
            <tr>
            <td class="style6">
                <asp:label runat="server" text="Book Appointment" font-bold=true id="lblBookAppointment"></asp:label>
            </td>
            </tr>
            <tr>
            <td class="style6">
                <asp:label runat="server" text="Speciality" id="lblSpeciality"></asp:label>
            </td>
            <td class="style14">
                <asp:dropdownlist runat="server" AutoPostBack="True" id="drpSpeciality"
                    onselectedindexchanged="drpSpeciality_SelectedIndexChanged" 
                    AppendDataBoundItems="True" Width="120px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td>
            </td>
            </tr>
            <tr>
            <td class="style6">
                <asp:label runat="server" text="Consulting Doctor" id="lblDoctor"></asp:label>
            </td>
            <td class="style14">
                <asp:dropdownlist runat="server" id="drpDoctor" AutoPostBack="True" 
                    AppendDataBoundItems="True" 
                    onselectedindexchanged="drpDoctor_SelectedIndexChanged" Width="120px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td><asp:RequiredFieldValidator ID="DoctorRequiredValidator" runat="server" 
                    ControlToValidate="drpDoctor" ErrorMessage="Select Doctor" InitialValue="Select"
                    validationgroup="PatientBooking" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
            <td class="style6">
                <asp:label runat="server" text="Preferred Date" id="lblDate"></asp:label>
            </td>
            <td class="style14">
                <asp:dropdownlist runat="server" id="drpPreferredDate" AutoPostBack="True"
                    onselectedindexchanged="drpPreferredDate_SelectedIndexChanged" 
                    AppendDataBoundItems="True" Width="120px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td><asp:RequiredFieldValidator ID="AppntDateRequiredValidator" runat="server" 
                    ControlToValidate="drpPreferredDate" InitialValue="Select"
                    ErrorMessage="Select Appointment Date" validationgroup="PatientBooking" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
            <td class="style6">
                <asp:label runat="server" text="Preferred Time Slot" id="lblTimeSlot"></asp:label>
            </td>
            <td class="style14">
                <asp:dropdownlist runat="server" id="drpTimeSlot" AppendDataBoundItems="True" 
                    Width="120px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td><asp:RequiredFieldValidator ID="AppntTimeRequiredValidator" runat="server" 
                    ControlToValidate="drpTimeSlot" ErrorMessage="Select Appointment Time" InitialValue="Select" 
                    validationgroup="PatientBooking" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <caption>
                <br />
                <tr>
                    <td>
                        <asp:Button ID="btnAppointment" runat="server" causesvalidation="true" 
                            onclick="btnAppointment_Click" text="Get Appointment" 
                            validationgroup="PatientBooking" />
                    </td>
                    <td class="style14">
                        <asp:Button ID="btnCancel" runat="server" text="Cancel" />
                    </td>
                </tr>
            </caption>
            </tr>
        </table>  
        </asp:Panel>
</asp:Content>
