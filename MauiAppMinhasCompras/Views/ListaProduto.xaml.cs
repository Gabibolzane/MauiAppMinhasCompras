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
        try
        {
            lista.Clear(); 

            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));

        } catch(Exception ex)
        {
           await DisplayAlert("Ops", ex.Message, "OK");
        }
       
    }

    // Botão ADICIONAR
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
      
            Navigation.PushAsync(new Views.NovoProduto());
        
    }

    // Busca de produtos
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e) //TextChanged, SearchBar
    {
        try { 
            string q = e.NewTextValue; //Filtrar dados

            lista.Clear(); //ObservableCollection

            List<Produto> tmp = await App.Db.Seanch(q); //Filtrar dados

            tmp.ForEach(i => lista.Add(i));//ObservableCollection
        } catch(Exception ex)
        {
           await DisplayAlert("Ops", ex.Message, "OK");
}
    }

    // Botão SOMAR
    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try { 
            double soma = lista.Sum(i => i.Total);

            string msg = $"O total é {soma:C}";

            await DisplayAlert("Total de Produtos", msg, "OK");

        } 
        catch(Exception ex){
           await DisplayAlert("Ops", ex.Message, "OK");
        }
        
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try {
            MenuItem selecionado = sender as MenuItem;

            Produto p = selecionado.BindingContext as Produto;

            bool confirm = await DisplayAlert("Confirma?", $"Remover {p.Descricao}?", "Sim", "Não");
            if (confirm)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }

        }
        catch(Exception ex){
           await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try {
            Produto p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
                {
            BindingContext = p,
            });

        } 
        catch(Exception ex){
           await DisplayAlert("Ops", ex.Message, "OK");
        }

    }
}