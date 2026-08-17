using SQLite;

namespace MauiAppMinhasCompras.Models;

public class Produto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public double Preco { get; set; }

    [Ignore]
    public double Total => Quantidade * Preco;
}
