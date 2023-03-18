<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualizareDate.aspx.cs" MasterPageFile="~/Site.Master" Inherits="ActualizareDate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
        &nbsp;&nbsp;&nbsp;
        Introduceti Numele Angajatului<br />
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNumeCautat" runat="server" Width="204px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCauta" runat="server" OnClick="btnCauta_Click" Text="Cauta Angajat" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" Font-Size="Large" ForeColor="#CC0000"></asp:Label>
        &nbsp;<br />
        &nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
        </asp:GridView>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Panel ID="Panel1" runat="server" Height="297px" Width="1239px">
            &nbsp;&nbsp;&nbsp;
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblNume" runat="server" Text="Nume"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNume" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNume" ErrorMessage="Numele trebuie sa contina doar litere" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z \-\s]{1,40}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblPrenume" runat="server" Text="Prenume"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrenume" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPrenume" ErrorMessage="Prenumele trebuie sa contina doar litere" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z \-\s]{1,40}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblFunctie" runat="server" Text="Functie"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFunctie" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFunctie" ErrorMessage="Functia trebuie sa contina doar litere" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z \-\s]{1,40}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblSalarBaza" runat="server" Text="Salar Baza"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalar" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSalar" ErrorMessage="Salariul trebuie sa fie un numar &gt;= 0" ForeColor="#CC0000" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblSpor" runat="server" Text="Spor"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSpor" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSpor" ErrorMessage="Sporul trebuie sa fie &gt;=0" ForeColor="#CC0000" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblPremii" runat="server" Text="Premii Brute"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPremii" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPremii" ErrorMessage="Premiile trebuie sa fie &gt;=0" ForeColor="#CC0000" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblRetineri" runat="server" Text="Retineri"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRetineri" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtRetineri" ErrorMessage="Retinerile trebuie sa fie &gt;=0" ForeColor="#CC0000" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Actualizare Date" Width="128px" />
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Renuntare" Width="175px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
</asp:Content>