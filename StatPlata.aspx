<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatPlata.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StatPlata" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="Apasati pe urmatorul buton pentru a genera statul de plata!"></asp:Label>
    &nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGenereaza" runat="server" OnClick="btnGenereaza_Click" Text="Genereaza" />
        
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" />
        <asp:Label ID="lblError" runat="server"></asp:Label>

</asp:Content>