<%@ Page Title="Criar Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FornecedorCriar.aspx.cs" Inherits="FrontEnd.FornecedorCriar" Async="true" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Criar Fornecedor</h2>

    <div class="form-group">
        <label>Nome do Fornecedor:</label>
        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        <br />
        <label>CNPJ do Fornecedor:</label>
        <asp:TextBox ID="textCnpj" runat="server" CssClass="form-control" />
    </div>

    <br />


    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />

    <br /><br />

    <asp:Label ID="lblMensagem" runat="server" ForeColor="Red" />
</asp:Content>

