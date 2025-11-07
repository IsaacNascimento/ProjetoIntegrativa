using FrontEnd.Models;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace FrontEnd
{
    public partial class ProdutoCriar : System.Web.UI.Page
    {
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(SalvarProdutoAsync));
        }

        private async Task SalvarProdutoAsync()
        {
            try
            {
                var nome = txtNome.Text.Trim();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    lblMensagem.Text = "Informe o nome do produto.";
                    return;
                }

                // envia apenas o campo Nome
                var payload = new ProdutoDTO { Nome = nome };

                await ApiClient.CreateProdutoAsync(payload);

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Produto cadastrado com sucesso!";

                string script = "setTimeout(function(){ window.location='Produtos.aspx'; }, 2000);";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = ex.Message;
            }
        }
    }
}
