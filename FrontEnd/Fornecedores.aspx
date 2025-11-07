<%@ Page Async="true" Title="Fornecedores" Language="C#"AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Fornecedores.aspx.cs" Inherits="FrontEnd.Fornecedores" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Fornecedores</h2>

    <asp:Label ID="lblErro" runat="server" ForeColor="Red" />

    <asp:GridView ID="gvFornecedores" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped" EmptyDataText="Nenhum fornecedor encontrado">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
        </Columns>
    </asp:GridView>

</asp:Content>
