<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificareProcente.aspx.cs" MasterPageFile="~/Site.Master" Inherits="ModificareProcente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
        <asp:Label ID="lblPass" runat="server" Text="Introduceti parola"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txtParola" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnPass" runat="server" OnClick="btnPass_Click" Text="Conectare" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblEroare" runat="server"></asp:Label>
        <br />
        <table class="auto-style7">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblCAS" runat="server" Text="CAS"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtCAS" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCAS" ErrorMessage="CAS-ul trebuie sa fie un nr: 0-100" ForeColor="#CC0000" ValidationExpression="^([0-9]|[1-9][0-9]|100)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblCASS" runat="server" Text="CASS"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCASS" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCASS" ErrorMessage="CASS-ul trebuie sa fie un nr: 0-100" ForeColor="#CC0000" ValidationExpression="^([0-9]|[1-9][0-9]|100)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblImp" runat="server" Text="Impozit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtImpozit" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtImpozit" ErrorMessage="Impozitul trebuie sa fie un nr: 0-100" ForeColor="#CC0000" ValidationExpression="^([0-9]|[1-9][0-9]|100)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnActualizare" runat="server" Text="Actualizare procente" OnClick="btnActualizare_Click" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Renuntare" Width="208px" />
        <br />
        <br />

</asp:Content>