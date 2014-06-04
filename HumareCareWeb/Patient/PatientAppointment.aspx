<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="PatientAppointment.aspx.cs" Inherits="HumareCareWeb.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:DropDownList ID="DropDownList1" runat="server">
</asp:DropDownList>
    <asp:button runat="server" text="Button" onclick="Unnamed1_Click" />--%>
    
    <table align="center">
   
        <tr>
            <td colspan="5">
                <asp:radiobutton runat="server" id="rdbNewReg" text="New Registration" 
                    AutoPostBack="True" Checked="True" oncheckedchanged="rdbNewReg_CheckedChanged"></asp:radiobutton>
                <asp:radiobutton runat="server" id="rdbOldReg" text="Old Registration" 
                    AutoPostBack="True" oncheckedchanged="rdbOldReg_CheckedChanged"></asp:radiobutton>
            
        </tr>        
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
            <td></td>
            <td>
            <asp:requiredfieldvalidator runat="server" errormessage="*Please Enter ICNum" 
                    ControlToValidate="txtICNo" ForeColor="Red" SetFocusOnError="True"></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server" text="IC No" id="lblICNo"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtICNo" Width="150px" AutoPostBack="True" 
                    ontextchanged="txtICNo_TextChanged"  ></asp:textbox>
            </td>
            <td style="width:20px"> </td>
            <td>
                <asp:label runat="server" text="Name" id="lblName"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtName" Width="150px"></asp:textbox>
            </td>            
            <td>
                
                    <asp:requiredfieldvalidator runat="server" errormessage="*Please Enter Name" 
                    ControlToValidate="txtName" ForeColor="Red" SetFocusOnError="True"></asp:requiredfieldvalidator>
                
            </td>            
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtICNo" ErrorMessage="Enter valid ICNo" ForeColor="Red" 
                    ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{9,9}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server" text="DOB"></asp:label>
            </td>
            <td>
                <asp:dropdownlist runat="server" ID="drpDay" Width="40px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                </asp:dropdownlist>
                <asp:dropdownlist runat="server" ID="drpMonth" Width="50px">
                    <asp:ListItem Value="1">Jan</asp:ListItem>
                    <asp:ListItem Value="2">Feb</asp:ListItem>
                    <asp:ListItem Value="3">Mar</asp:ListItem>
                    <asp:ListItem Value="4">Apr</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">Aug</asp:ListItem>
                    <asp:ListItem Value="9">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:dropdownlist>
                <asp:dropdownlist runat="server" ID="drpYear" Width="60px">
                    <asp:ListItem Value="2014">2014</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2007</asp:ListItem>
                    <asp:ListItem>2006</asp:ListItem>
                    <asp:ListItem>2005</asp:ListItem>
                    <asp:ListItem>2004</asp:ListItem>
                    <asp:ListItem>2003</asp:ListItem>
                    <asp:ListItem>2002</asp:ListItem>
                    <asp:ListItem>2001</asp:ListItem>
                    <asp:ListItem>2000</asp:ListItem>
                    <asp:ListItem>1999</asp:ListItem>
                    <asp:ListItem>1998</asp:ListItem>
                    <asp:ListItem>1997</asp:ListItem>
                    <asp:ListItem>1996</asp:ListItem>
                    <asp:ListItem>1995</asp:ListItem>
                    <asp:ListItem>1994</asp:ListItem>
                    <asp:ListItem>1993</asp:ListItem>
                    <asp:ListItem>1992</asp:ListItem>
                    <asp:ListItem>1991</asp:ListItem>
                    <asp:ListItem>1990</asp:ListItem>
                    <asp:ListItem>1989</asp:ListItem>
                    <asp:ListItem>1988</asp:ListItem>
                    <asp:ListItem>1987</asp:ListItem>
                    <asp:ListItem>1986</asp:ListItem>
                    <asp:ListItem>1985</asp:ListItem>
                    <asp:ListItem>1984</asp:ListItem>
                    <asp:ListItem>1983</asp:ListItem>
                    <asp:ListItem>1982</asp:ListItem>
                    <asp:ListItem>1981</asp:ListItem>
                    <asp:ListItem>1980</asp:ListItem>
                    <asp:ListItem>1979</asp:ListItem>
                    <asp:ListItem>1978</asp:ListItem>
                    <asp:ListItem>1977</asp:ListItem>
                    <asp:ListItem>1976</asp:ListItem>
                    <asp:ListItem>1975</asp:ListItem>
                     <asp:ListItem>1974</asp:ListItem>
                    <asp:ListItem>1973</asp:ListItem>
                    <asp:ListItem>1972</asp:ListItem>
                    <asp:ListItem>1971</asp:ListItem>
                    <asp:ListItem>1970</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td style="width:20px"> </td>
            <td>
                <asp:label runat="server" text="Sex"></asp:label>
            </td>
            <td>
                <asp:radiobutton runat="server" id="rdbMale" text="Male" AutoPostBack="True" 
                    Checked="True" oncheckedchanged="rdbMale_CheckedChanged"></asp:radiobutton>
                <asp:radiobutton runat="server" id="rdbFemale" text="Female" 
                    AutoPostBack="True" oncheckedchanged="rdbFemale_CheckedChanged"></asp:radiobutton>
            </td>
            <td>
                <asp:requiredfieldvalidator runat="server" errormessage="*Please Select DOB" 
                    ControlToValidate="drpYear" ForeColor="Red" SetFocusOnError="True"></asp:requiredfieldvalidator>
                
            </td>    
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
             <asp:regularexpressionvalidator runat="server" 
                    errormessage="Enter valid Phone number" ForeColor="Red" 
                    ValidationExpression="[0-9]{8,10}$" ControlToValidate="txtContactNo"></asp:regularexpressionvalidator>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:label runat="server" text="Contact Number" id="lblContact"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtContactNo" Width="150px"></asp:textbox>
            </td>
            <td style="width:20px"> </td>
            <td>
                <asp:label runat="server" text="Email" id="lblEmail"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtEmail" Width="150px"></asp:textbox>
            </td>
             <td>
                <asp:requiredfieldvalidator runat="server" errormessage="*Please Enter Phone No" 
                    ControlToValidate="txtContactNo" ForeColor="Red" SetFocusOnError="True"></asp:requiredfieldvalidator>
                
            </td>    
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                    <asp:requiredfieldvalidator runat="server" errormessage="*Please Enter Email" 
                    ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True" 
                    ID="requiredfieldvalidator2"></asp:requiredfieldvalidator>
                
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:label runat="server" text="Nationality" id="lblNationality"></asp:label>
            </td>
            <td>
                <asp:dropdownlist runat="server" id="drpNationality" 
                    AppendDataBoundItems="True" Width="150px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td style="width:20px"> </td>
            <td>
                <asp:label runat="server" text="Street" id="lblStreet"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtStreet" Width="150px"></asp:textbox>
            </td>
             <td>
            <asp:regularexpressionvalidator runat="server" errormessage="Enter valid Mail ID" 
                    ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txtEmail" ID="regularexpressionvalidator2"></asp:regularexpressionvalidator>
                
            </td>   
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                <asp:requiredfieldvalidator runat="server" errormessage="*Please Select Nationality" 
                    ControlToValidate="drpNationality" ForeColor="Red" SetFocusOnError="True" 
                    ID="requiredfieldvalidator1"></asp:requiredfieldvalidator>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server" text="Area" id="lblArea"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtArea" Width="150px"></asp:textbox>
            </td>
            <td style="width:20px"> </td>
            <td>
                <asp:label runat="server" text="Country" id="lblCountry"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtCountry" Width="150px"></asp:textbox>
            </td>
             <td>
                    <asp:requiredfieldvalidator runat="server" errormessage="*Please Enter Country" 
                    ControlToValidate="txtCountry" ForeColor="Red" SetFocusOnError="True"></asp:requiredfieldvalidator>
                
            </td>   
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
            <asp:regularexpressionvalidator runat="server" 
                    errormessage="Enter valid Postal Code" ControlToValidate="txtPostalCode" 
                    ForeColor="Red" ValidationExpression="[0-9]{5,10}$"></asp:regularexpressionvalidator>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:label runat="server" text="PostalCode" id="lblPostalCode"></asp:label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtPostalCode" Width="150px"></asp:textbox>
            </td>
            <td style="width:20px"> </td>
            <td>
                <asp:label runat="server" text="Speciality" id="lblSpeciality"></asp:label>
            </td>
            <td>
                <asp:dropdownlist runat="server" id="drpSpeciality" AppendDataBoundItems="True" 
                    Width="150px" onselectedindexchanged="drpSpeciality_SelectedIndexChanged1">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td>
                <asp:requiredfieldvalidator runat="server" errormessage="*Please Select Postal Code" 
                    ControlToValidate="txtPostalCode" ForeColor="Red" SetFocusOnError="True"></asp:requiredfieldvalidator>
                
            </td>   
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                    <asp:requiredfieldvalidator runat="server" errormessage="*Please Select Speciality" 
                    ControlToValidate="drpSpeciality" ForeColor="Red" SetFocusOnError="True" 
                    ID="requiredfieldvalidator3"></asp:requiredfieldvalidator>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server" text="Consulting Doctor" id="lblDoctor"></asp:label>
            </td>
            <td>
                <asp:dropdownlist runat="server" id="drpDoctor" AppendDataBoundItems="True" 
                    Width="150px" onselectedindexchanged="drpDoctor_SelectedIndexChanged1">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td style="width:20px"> </td>
            <td>
                <asp:label runat="server" text="Preferred Date" id="lblDate"></asp:label>
            </td>
            <td>
                <asp:dropdownlist runat="server" id="drpPreferredDate" 
                    AppendDataBoundItems="True" Width="150px" 
                    onselectedindexchanged="drpPreferredDate_SelectedIndexChanged1">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
             <td>
                <asp:requiredfieldvalidator runat="server" errormessage="*Please Select Doctor" 
                    ControlToValidate="drpDoctor" ForeColor="Red" SetFocusOnError="True"></asp:requiredfieldvalidator>
                
            </td>   
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                    <asp:requiredfieldvalidator runat="server" errormessage="*Please Select Preferred Date" 
                    ControlToValidate="drpPreferredDate" ForeColor="Red" 
                    SetFocusOnError="True" ID="requiredfieldvalidator4"></asp:requiredfieldvalidator>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server" text="Preferred Time Slot" id="lblTimeSlot"></asp:label>
            </td>
            <td>
                <asp:dropdownlist runat="server" id="drpTimeSlot" AppendDataBoundItems="True" 
                    Width="150px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td>
            </td>
            <td>
            </td>
             <td>
                    &nbsp;</td>   
                    <td>

                        &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:button runat="server" text="Get Appointment" id="btnAppointment" 
                    onclick="btnAppointment_Click" />
                <asp:button runat="server" text="Cancel" id="btnCancel" />
            </td>
        </tr>
    </table>
</asp:Content>
