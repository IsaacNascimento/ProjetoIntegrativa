using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace FrontEnd
{
    public partial class FornecedorCriar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Page.RegisterAsyncTask(new PageAsyncTask(SalvarFornecedorAsync));
        }

        private bool CnpjValido(string cnpj)
        {
            // Remove caracteres especiais
            cnpj = cnpj?.Replace(".", "").Replace("-", "").Replace("/", "");

            // Verifica tamanho e se todos os dígitos são iguais (ex: 111111...)
            if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14 || new string(cnpj[0], 14) == cnpj)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCnpj, digito;
            int soma, resto;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }


        private async Task SalvarFornecedorAsync()
        {
            try
            {
                var nome = txtNome.Text?.Trim();
                var cnpj = textCnpj.Text?.Trim();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Text = "Nome obrigatório.";
                    return;
                }

                if (!CnpjValido(cnpj))
                {
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Text = "CNPJ inválido.";
                    return;
                }

                var payload = new Models.FornecedorDTO { Nome = nome, Cnpj = cnpj };
                await ApiClient.CreateFornecedorAsync(payload);

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Fornecedor criado com sucesso!";

                // Redirecionar após 2s (opcional)
                string script = "setTimeout(function(){ window.location='Fornecedores.aspx'; }, 2000);";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao salvar: " + ex.Message;
            }
        }
    }
}
