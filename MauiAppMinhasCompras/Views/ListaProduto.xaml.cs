using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    // Lista que será exibida na tela
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

    // Construtor da página
    public ListaProduto()
    {
        InitializeComponent();

        
        lst_produtos.ItemsSource = lista;
    }

    protected override async void OnAppearing()
    {
        
            lista.Clear(); // LIMPA A LISTA PARA NÃO DUPLICAR

            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
       
    }

    // Botão ADICIONAR
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
      
            Navigation.PushAsync(new Views.NovoProduto());
        
    }

    // Busca de produtos
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e) //TextChanged, SearchBar
    {
            string q = e.NewTextValue; //Filtrar dados

            lista.Clear(); //ObservableCollection

            List<Produto> tmp = await App.Db.Seanch(q); //Filtrar dados

            tmp.ForEach(i => lista.Add(i));//ObservableCollection
    }

    // Botão SOMAR
    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        
            double soma = lista.Sum(i => i.Total);

            string msg = $"O total é {soma:C}";

            await DisplayAlert("Total de Produtos", msg, "OK");
        
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}