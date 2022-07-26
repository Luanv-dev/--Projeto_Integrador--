namespace MEtechnology.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string nome { get; set; } // celular m31
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public ClasseProdutos? ClasseProduto { get; set; }

    }
}
