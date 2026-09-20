using MauiAppTempoAgora.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace MauiAppTempoAgora.Services;

public class DataService
{
    public static async Task<Tempo?> GetPrevisao(string cidade)
    {
        const string chave = "6135072afe7f6cec1537d5cb08a5a1a2";

        string url =
            $"https://api.openweathermap.org/data/2.5/weather?" +
            $"q={Uri.EscapeDataString(cidade)}&units=metric&appid={chave}";

        using HttpClient client = new HttpClient();

        HttpResponseMessage resp = await client.GetAsync(url);

        if (resp.StatusCode == HttpStatusCode.NotFound)
        {
            throw new Exception("Cidade não encontrada. Verifique o nome informado.");
        }

        if (!resp.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Não foi possível consultar o clima. Código do servidor: {(int)resp.StatusCode}.");
        }

        string json = await resp.Content.ReadAsStringAsync();
        var rascunho = JObject.Parse(json);

        DateTime time = new();

        DateTime sunrise =
            time.AddSeconds((double)rascunho["sys"]["sunrise"])
                .ToLocalTime();

        DateTime sunset =
            time.AddSeconds((double)rascunho["sys"]["sunset"])
                .ToLocalTime();

        return new Tempo
        {
            lat = (double)rascunho["coord"]["lat"],
            lon = (double)rascunho["coord"]["lon"],
            description = (string)rascunho["weather"][0]["description"],
            main = (string)rascunho["weather"][0]["main"],
            temp_min = (double)rascunho["main"]["temp_min"],
            temp_max = (double)rascunho["main"]["temp_max"],
            speed = (double)rascunho["wind"]["speed"],
            visibility = (int)rascunho["visibility"],
            sunrise = sunrise.ToString(),
            sunset = sunset.ToString()
        };
    }
}
