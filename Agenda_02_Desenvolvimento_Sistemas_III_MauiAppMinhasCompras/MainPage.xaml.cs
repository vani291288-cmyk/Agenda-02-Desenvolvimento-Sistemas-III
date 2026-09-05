using MauiAppMinhasCompras.Data;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        Loaded += async (_, _) => await CarregarProdutos();
    }

    private async Task CarregarProdutos(string? busca = null)
    {
        List<Produto> produtos;

        if (string.IsNullOrWhiteSpace(busca))
            produtos = await Database.Current.GetAll();
        else
            produtos = await Database.Current.Search(busca.Trim());

        ProdutosCollection.ItemsSource = produtos;
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(DescricaoEntry.Text))
        {
            await DisplayAlert("Atenção", "Informe a descrição do produto.", "OK");
            return;
        }

        if (!int.TryParse(QuantidadeEntry.Text, out int quantidade) || quantidade <= 0)
        {
            await DisplayAlert("Atenção", "Informe uma quantidade válida.", "OK");
            return;
        }

        if (!double.TryParse(PrecoEntry.Text, out double preco) || preco < 0)
        {
            await DisplayAlert("Atenção", "Informe um preço válido.", "OK");
            return;
        }

        var produto = new Produto
        {
            Descricao = DescricaoEntry.Text.Trim(),
            Quantidade = quantidade,
            Preco = preco
        };

        await Database.Current.Insert(produto);

        DescricaoEntry.Text = string.Empty;
        QuantidadeEntry.Text = string.Empty;
        PrecoEntry.Text = string.Empty;

        await CarregarProdutos();
        await DisplayAlert("Sucesso", "Produto cadastrado.", "OK");
    }

    private async void OnBuscaTextChanged(object sender, TextChangedEventArgs e)
    {
        await CarregarProdutos(e.NewTextValue);
    }
}
