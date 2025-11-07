<%@ Page Async="true" Title="Cotações" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cotacoes.aspx.cs" Inherits="FrontEnd.Cotacoes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cotações</h2>

    <asp:Label ID="lblErro" runat="server" ForeColor="Red" />

    <div style="margin-bottom: 10px;">
        <asp:Button ID="btnRefresh" runat="server" Text="Atualizar" OnClick="btnRefresh_Click" CssClass="btn btn-secondary" />
        &nbsp;
        <asp:Button ID="btnMenor" runat="server" Text="Menor Cotação" OnClick="btnMenor_Click" CssClass="btn btn-primary" />
    </div>

    <asp:GridView ID="gvCotacoes" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped" EmptyDataText="Nenhuma cotação encontrada" AllowPaging="true" PageSize="10"
        OnPageIndexChanging="gvCotacoes_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Preco" HeaderText="Preço" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="FornecedorId" HeaderText="FornecedorId" />
            <asp:BoundField DataField="NomeFornecedor" HeaderText="Fornecedor" />
            <asp:BoundField DataField="NomeProduto" HeaderText="Produto" />
        </Columns>
    </asp:GridView>

    <br />

    <asp:Panel ID="pnlMenor" runat="server" Visible="false" CssClass="alert alert-success">
        <asp:Label ID="lblMenor" runat="server" CssClass="fw-bold" />
    </asp:Panel>
</asp:Content>
