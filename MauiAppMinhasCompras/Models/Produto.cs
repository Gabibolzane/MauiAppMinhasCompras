using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        internal static object anexado;
        string _descricao;

        // Mostra este campo é a chave primária da tabela
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Propriedade que armazena a descrição do produto
        public string Descricao {
            get => _descricao; 
            set
            {
                if(value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                    _descricao = value;
                }
            }
        }

        // Propriedade que armazena a quantidade do produto
        public double Quantidade { get; set; }

        // Propriedade que armazena o preço do produto
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }

        public Produto() { }
    }
}
