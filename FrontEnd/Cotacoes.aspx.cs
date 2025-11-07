using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;

namespace FrontEnd
{
    public partial class Cotacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMenor.Visible = false;
                Page.RegisterAsyncTask(new PageAsyncTask(CarregarCotacoesAsync));
            }
        }

        private async Task CarregarCotacoesAsync()
        {
            try
            {
                var lista = await ApiClient.GetCotacoesAsync();
                gvCotacoes.DataSource = lista ?? new List<CotacaoDTO>();
                gvCotacoes.DataBind();
                lblErro.Text = "";
            }
            catch (Exception ex)
            {
                lblErro.Text = "Erro ao carregar cotações: " + ex.Message;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(CarregarCotacoesAsync));
        }

        protected void btnMenor_Click(object sender, EventArgs e)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(ObterMenorCotacaoAsync));
        }

        private async Task ObterMenorCotacaoAsync()
        {
            try
            {
                var menor = await ApiClient.ObterCotacaoDeMenorValorAsync();
                if (menor == null)
                {
                    pnlMenor.Visible = false;
                    lblErro.Text = "Nenhuma cotação disponível.";
                    return;
                }

                pnlMenor.Visible = true;
                lblMenor.Text = $"Menor: ID {menor.Id} - Produto: {menor.NomeProduto ?? menor.ProdutoId.ToString()} - Fornecedor: {menor.NomeFornecedor ?? menor.FornecedorId.ToString()} - Valor: {menor.Preco:N2} - Data: {menor.Data:yyyy-MM-dd}";
                lblErro.Text = "";
            }
            catch (Exception ex)
            {
                pnlMenor.Visible = false;
                lblErro.Text = "Erro ao obter menor cotação: " + ex.Message;
            }
        }

        protected void gvCotacoes_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvCotacoes.PageIndex = e.NewPageIndex;
            Page.RegisterAsyncTask(new PageAsyncTask(CarregarCotacoesAsync));
        }
    }
}
