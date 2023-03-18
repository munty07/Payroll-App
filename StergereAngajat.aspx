<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StergereAngajat.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StergereAngajat" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" Font-Size="Large" ForeColor="#CC0000"></asp:Label>
        <br />
        <br />
        <table class="auto-style2">
            <tr>
                <td colspan="2"><strong>Angajatul Cautat<br />
                    <br />
                    </strong>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNume" ErrorMessage="Numele trebuie sa contina doar litere" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Nume</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtNume" runat="server"></asp:TextBox>
                    &nbsp; <asp:Button ID="btnCauta" runat="server" OnClick="btnCauta_Click" Text="Cauta Angajat" Width="165px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtID" runat="server" Enabled="False"></asp:TextBox>
                &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="btnRenuntare" runat="server" OnClick="btnRenuntare_Click" Text="Renuntare Stergere" Width="165px" />
                </td>
                <td class="auto-style9">
                    <asp:Button ID="btnStergere" runat="server" Text="Sterge Angajat" Width="165px" OnClick="btnStergere_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>