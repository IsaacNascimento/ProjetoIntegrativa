using FrontEnd.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.UI;

namespace FrontEnd
{
    public partial class CotacaoCriar : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await CarregarDropdownsAsync();
                txtData.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        private async Task CarregarDropdownsAsync()
        {
            try
            {
                var produtos = await ApiClient.GetProdutosAsync();
                ddlProduto.DataSource = produtos;
                ddlProduto.DataTextField = "Nome";
                ddlProduto.DataValueField = "Id";
                ddlProduto.DataBind();

                var fornecedores = await ApiClient.GetFornecedoresAsync();
                ddlFornecedor.DataSource = fornecedores;
                ddlFornecedor.DataTextField = "Nome";
                ddlFornecedor.DataValueField = "Id";
                ddlFornecedor.DataBind();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao carregar produtos/fornecedores: " + ex.Message;
            }
        }

        protected async void btnSalvar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = "";
            try
            {
                string precoText = txtPreco.Text.Replace(",", "."); 
                if (!decimal.TryParse(precoText, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal preco))
                {
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Text = "Preço inválido. Use formato 10.50";
                    return;
                }

                var cotacao = new CotacaoCreate
                {
                    Produto = new ProdutoDTO { Id = int.Parse(ddlProduto.SelectedValue), Nome = ddlProduto.SelectedItem.Text },
                    Fornecedor = new FornecedorDTO { Id = int.Parse(ddlFornecedor.SelectedValue), Nome = ddlFornecedor.SelectedItem.Text },
                    Preco = preco,
                    Data = DateTime.Parse(txtData.Text)
                };

                await ApiClient.CreateCotacaoAsync(cotacao);

   
                Response.Redirect("~/Cotacoes.aspx");
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao criar cotação: " + ex.Message;
            }
        }
    }
}
