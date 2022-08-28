namespace MEtechnology.Models
{
    public class ClasseProdutos
    {
        public int Id { get; set; }
        public string classe { get; set; } 
        public List<Produtos> Produtos { get; set; } = new List<Produtos>();

    }
}
