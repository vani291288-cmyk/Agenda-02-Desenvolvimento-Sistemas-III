using MauiAppMinhasCompras.Data;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class MainPage : ContentPage
{
    private readonly List<string> _categorias = new()
    {
        "Alimentos",
        "Higiene",
        "Limpeza",
        "Eletrônicos",
        "Vestuário",
        "Outros"
    };

    public MainPage()
    {
        InitializeComponent();
        CategoriaPicker.ItemsSource = _categorias;
        FiltroCategoriaPicker.ItemsSource = new List<string> { "Todas" }.Concat(_categorias).ToList();
        FiltroCategoriaPicker.SelectedIndex = 0;
        Loaded += async (_, _) => await CarregarProdutos();
    }

    private async Task CarregarProdutos(string? busca = null, string? categoria = null)
    {
        var produtos = await Database.Current.GetAll();

        if (!string.IsNullOrWhiteSpace(busca))
        {
            produtos = produtos
                .Where(p => p.Descricao.Contains(busca.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(categoria) && categoria != "Todas")
        {
            produtos = produtos
                .Where(p => string.Equals(p.Categoria, categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

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

        if (CategoriaPicker.SelectedItem is not string categoria || string.IsNullOrWhiteSpace(categoria))
        {
            await DisplayAlert("Atenção", "Escolha uma categoria.", "OK");
            return;
        }

        var produto = new Produto
        {
            Descricao = DescricaoEntry.Text.Trim(),
            Quantidade = quantidade,
            Preco = preco,
            Categoria = categoria
        };

        await Database.Current.Insert(produto);

        DescricaoEntry.Text = string.Empty;
        QuantidadeEntry.Text = string.Empty;
        PrecoEntry.Text = string.Empty;
        CategoriaPicker.SelectedItem = null;

        await CarregarProdutos(BuscaEntry.Text, FiltroCategoriaPicker.SelectedItem?.ToString());
        await DisplayAlert("Sucesso", "Produto cadastrado.", "OK");
    }

    private async void OnBuscaTextChanged(object sender, TextChangedEventArgs e)
    {
        await CarregarProdutos(e.NewTextValue, FiltroCategoriaPicker.SelectedItem?.ToString());
    }

    private async void OnFiltroCategoriaChanged(object sender, EventArgs e)
    {
        await CarregarProdutos(BuscaEntry.Text, FiltroCategoriaPicker.SelectedItem?.ToString());
    }

    private async void OnRelatorioClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RelatorioPage));
    }
}
