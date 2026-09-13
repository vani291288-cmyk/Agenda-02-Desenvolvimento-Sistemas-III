using MauiAppMinhasCompras.Data;

namespace MauiAppMinhasCompras.Views;

public partial class RelatorioPage : ContentPage
{
    private sealed class CategoriaRelatorio
    {
        public string Categoria { get; set; } = string.Empty;
        public double Total { get; set; }
    }

    public RelatorioPage()
    {
        InitializeComponent();
        Loaded += async (_, _) => await CarregarRelatorio();
    }

    private async Task CarregarRelatorio()
    {
        var produtos = await Database.Current.GetAll();

        var relatorio = produtos
            .GroupBy(p => string.IsNullOrWhiteSpace(p.Categoria) ? "Sem categoria" : p.Categoria)
            .Select(g => new CategoriaRelatorio
            {
                Categoria = g.Key,
                Total = g.Sum(p => p.Total)
            })
            .OrderBy(r => r.Categoria)
            .ToList();

        RelatorioCollection.ItemsSource = relatorio;
        TotalGeralLabel.Text = $"TOTAL GERAL: R$ {relatorio.Sum(r => r.Total):F2}";
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
