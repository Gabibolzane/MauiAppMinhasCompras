using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

// Define a página de edição 
public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();
    }

    // Método executado quando o botão "Salvar" da Toolbar é clicado
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Recupera o produto que foi enviado para essa tela (BindingContext)
            Produto produto_anexado = BindingContext as Produto;

            // Cria um novo objeto Produto com os dados atualizados
            Produto p = new Produto
            {
                // Mantém o mesmo Id (importante para atualizar no banco)
                Id = produto_anexado.Id,

                // Pega os valores digitados nos campos da tela
                Descricao = txt_descricao.Text,

                // Converte o texto digitado para número (double)
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Atualiza o produto no banco de dados
            App.Db.Update(p);

            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync(); // Volta para pagina
        }
        catch (Exception ex)
        {
            await DisplayAlert("ops", ex.Message, "OK");
        }
    }
}