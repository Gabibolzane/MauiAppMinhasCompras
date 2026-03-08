namespace MauiAppMinhasCompras
{

    public partial class MainPage : ContentPage
    {
        // Variável que armazena quantas vezes o botão foi clicado
        int count = 0;

        // Construtor da página
        public MainPage()
        {
            InitializeComponent();
        }

        // Método executado quando o botão é clicado
        private void OnCounterClicked(object? sender, EventArgs e)
        {
            // Incrementa o contador em 1 a cada clique
            count++;

            // Verifica se o botão foi clicado apenas uma vez
            if (count == 1)
                // Mostra no botão "Clicked 1 time"
                CounterBtn.Text = $"Clicked {count} time";
            else
                // Caso tenha mais de um clique, mostra "Clicked X times"
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}