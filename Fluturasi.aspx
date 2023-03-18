<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fluturasi.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Fluturasi" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
        &nbsp;&nbsp;Pentru a genera flutarasii tuturor angajatilor apasati pe urmatorul buton!
        <asp:Button ID="btnGenereaza" runat="server" OnClick="btnGenereaza_Click" Text="Genereaza" />
        <br />
        <br />
&nbsp;&nbsp;Introduceti numele pentru a genera fluturasul unui anumit angajat<br />
        <br />
        &nbsp; Nume:&nbsp;
        <asp:TextBox ID="txtNume" runat="server"></asp:TextBox>
        <asp:Button ID="btnCauta" runat="server" OnClick="btnCauta_Click" Text="Cauta" />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        &nbsp;
        <asp:Button ID="btnRaport" runat="server" OnClick="btnRaport_Click" Text="Generare Raport Individual" Width="280px" />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="True" ToolPanelView="None" />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

</asp:Content>