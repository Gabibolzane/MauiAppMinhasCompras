using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {

        // Mostra este campo é a chave primária da tabela
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Propriedade que armazena a descrição do produto
        public string Descricao { get; set; }

        // Propriedade que armazena a quantidade do produto
        public double Quantidade { get; set; }

        // Propriedade que armazena o preço do produto
        public double Preco { get; set; }

        public Produto() { }
    }
}
