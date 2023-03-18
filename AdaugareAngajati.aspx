<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdaugareAngajati.aspx.cs" MasterPageFile="~/Site.Master" Inherits="AdaugareAngajati" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    &nbsp;&nbsp;<br />
        <asp:Image ID="Image1" runat="server" BorderColor="White" Height="139px" ImageAlign="Middle" Width="152px" ImageUrl="~/img/profile.jpg" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" Font-Size="Large"></asp:Label>
        <br />
        <table border="1" class="auto-style2">
            <tr>
                <td class="auto-style1">Nume*</td>
                <td>
                    <asp:TextBox ID="txtNume" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNume" ErrorMessage="Numele trebuie sa contina doar litere" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z \-\s]{1,40}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Prenume*</td>
                <td>
                    <asp:TextBox ID="txtPrenume" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPrenume" ErrorMessage="Prenumele trebuie sa contina doar litere" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z \-\s]{1,40}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Functie*</td>
                <td>
                    <asp:TextBox ID="txtFunctie" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFunctie" ErrorMessage="Functia trebuie sa contina doar litere" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z \-\s]{1,40}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Salar Baza*</td>
                <td>
                    <asp:TextBox ID="txtSalarBaza" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSalarBaza" ErrorMessage="Salariul trebuie sa fie un numar &gt;= 0" ForeColor="#CC0000" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Spor %*</td>
                <td>
                    <asp:TextBox ID="txtSpor" runat="server">0</asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSpor" ErrorMessage="Sporul trebuie sa fie &gt;=0" ForeColor="#CC0000" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Premii Brute*</td>
                <td>
                    <asp:TextBox ID="txtPremiiBrute" runat="server">0</asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPremiiBrute" ErrorMessage="Premiile trebuie sa fie &gt;=0" ForeColor="#CC0000" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Retineri*</td>
                <td>
                    <asp:TextBox ID="txtRetineri" runat="server">0</asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtRetineri" ErrorMessage="Retinerile trebuie sa fie &gt;=0" ForeColor="#CC0000" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Poza</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Total Brut</td>
                <td>
                    <asp:TextBox ID="txtTotalBrut" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">CAS %</td>
                <td>
                    <asp:TextBox ID="txtCAS" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">CASS %</td>
                <td>
                    <asp:TextBox ID="txtCASS" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Brut Impozabil</td>
                <td>
                    <asp:TextBox ID="txtBrutImpozabil" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Impozit %</td>
                <td>
                    <asp:TextBox ID="txtImpozit" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Virat Card</td>
                <td>
                    <asp:TextBox ID="txtViratCard" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Adauga Angajat" Width="260px" />
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Resetare Date Introduse" Width="265px" />
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />

</asp:Content>