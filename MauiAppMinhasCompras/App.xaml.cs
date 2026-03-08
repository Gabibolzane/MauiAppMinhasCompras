using MauiAppMinhasCompras.helpers;

namespace MauiAppMinhasCompras
{

    public partial class App : Application
    {
        // Cria uma variável estática para armazenar o banco de dados
        static SQLiteDatabaseHelper _db;

        // Propriedade para acessar o banco de dados em qualquer parte do app
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                // Verifica se a conexão com o banco ainda não foi criada
                if (_db == null)
                {
                    // Define o caminho onde o banco SQLite será salvo no dispositivo
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    // Cria a instância do banco de dados
                    _db = new SQLiteDatabaseHelper(".... db3");
                }

                // Retorna a conexão com o banco
                return _db;
            }
        }

        // Construtor da aplicação
        public App()
        {
            InitializeComponent();
        }

        // Método responsável por criar a janela principal do aplicativo
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new Views.ListaProduto()));
        }
    }
}