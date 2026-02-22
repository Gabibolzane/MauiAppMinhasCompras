using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.helpers
{
    internal class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public int Insert(Produto p)
        {
            return _conn.InsertAsync(p).Result;
        }
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET descricao=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }
        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Seanch(string q) 
        {
            string sql = "SELECT * Produto WHERE descricao like '%" + q + "%'";
            return _conn.QueryAsync<Produto>(sql);
        }


    }
}
