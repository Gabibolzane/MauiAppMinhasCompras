namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    // Construtor da página
    public ListaProduto()
    {
         InitializeComponent();
    }

    // Método executado quando o botão da Toolbar é clicado
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Navega para a tela NovoProduto
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            // Caso aconteça algum erro, mostra uma mensagem de alerta para o usuário
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}