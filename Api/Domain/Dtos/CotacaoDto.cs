namespace Cotacao.Domain.Dtos
{
    public class CotacaoDTO
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public string NomeFornecedor { get; set; }
        public string NomeProduto { get; set; }
    }
}
