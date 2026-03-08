using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.helpers
{
    // Faz a comunicacao com o banco de dados
    public class SQLiteDatabaseHelper
    {
        // Cria a conexão com o banco de dados
        readonly SQLiteAsyncConnection _conn;

        // recebe o caminho onde o banco será salvo
        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        //responsável por inserir um produto no banco de dados
        public int Insert(Produto p)
        {
            // insere o produto e retorna o resultado
            return _conn.InsertAsync(p).Result;
        }

        //Public responsável por atualizar os dados de um produto existente
        public Task<List<Produto>> Update(Produto p)
        {
            // comando que atualiza os dados do produto com base no Id
            string sql = "UPDATE Produto SET descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            // Executa o comando passando os valores do objeto Produto
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }

        //responsável por deletar um produto pelo Id
        public Task<int> Delete(int id)
        {
            //procura na tabela Produto um item com o Id informado e remove ele
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        //retorna todos os produtos cadastrados no banco
        public Task<List<Produto>> GetAll()
        {
            // busca os produtos e retorna em uma lista
            return _conn.Table<Produto>().ToListAsync();
        }

        //responsável por pesquisar produtos
        public Task<List<Produto>> Seanch(string q)
        {
            string sql = "SELECT * Produto WHERE descricao like '%" + q + "%'";

            //retorna os resultados encontrados
            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
