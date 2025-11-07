<%@ Page Async="true" Title="Nova Cotação" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CotacaoCriar.aspx.cs" Inherits="FrontEnd.CotacaoCriar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Nova Cotação</h2>

    <asp:Label ID="lblMensagem" runat="server" ForeColor="Red" />

    <div class="mb-3">
        <asp:Label ID="lblProduto" runat="server" Text="Produto:" AssociatedControlID="ddlProduto" />
        <asp:DropDownList ID="ddlProduto" runat="server" CssClass="form-select" />
    </div>

    <div class="mb-3">
        <asp:Label ID="lblFornecedor" runat="server" Text="Fornecedor:" AssociatedControlID="ddlFornecedor" />
        <asp:DropDownList ID="ddlFornecedor" runat="server" CssClass="form-select" />
    </div>

    <div class="mb-3">
        <asp:Label ID="lblPreco" runat="server" Text="Preço:" AssociatedControlID="txtPreco" />
        <asp:TextBox ID="txtPreco" runat="server" CssClass="form-control" />
    </div>

    <div class="mb-3">
        <asp:Label ID="lblData" runat="server" Text="Data:" AssociatedControlID="txtData" />
        <asp:TextBox ID="txtData" runat="server" CssClass="form-control" TextMode="Date" />
    </div>

    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
</asp:Content>
