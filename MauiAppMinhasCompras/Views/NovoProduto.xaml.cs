using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;


public partial class NovoProduto : ContentPage
{
    // Construtor da página
    public NovoProduto()
    {

        InitializeComponent();
    }

    // Método executado quando o botão "Salvar" da Toolbar é clicado
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria um novo objeto Produto
            Produto p = new Produto
            {
                // Recebe o texto no campo de descrição
                Descricao = txt_descricao.Text,

                // Converte o valor digitado no campo quantidade para número
                Quantidade = Convert.ToDouble(txt_quantidade.Text),

                // Converte o valor digitado no campo preço para número
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Insere o produto no banco de dados usando o helper
            App.Db.Insert(p);

            // Mostra uma mensagem informando que o registro foi salvo
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

        }
        catch (Exception ex)
        {
            // Caso aconteça algum erro, exibe uma mensagem de alerta com o erro
            await DisplayAlert("ops", ex.Message, "OK");
        }
    }
}