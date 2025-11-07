using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace FrontEnd
{
    public partial class Fornecedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.RegisterAsyncTask(new PageAsyncTask(CarregarFornecedoresAsync));
            }
        }

        private async Task CarregarFornecedoresAsync()
        {
            try
            {
                var lista = await ApiClient.GetFornecedoresAsync();
                gvFornecedores.DataSource = lista;
                gvFornecedores.DataBind();
                lblErro.Text = "";
            }
            catch (Exception ex)
            {
                lblErro.Text = "Erro ao carregar fornecedores: " + ex.Message;
            }
        }
    }
}
