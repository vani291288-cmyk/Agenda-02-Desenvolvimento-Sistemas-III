using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;
using System.Net.Http;

namespace MauiAppTempoAgora;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(txt_cidade.Text))
            {
                Tempo? t = await DataService.GetPrevisao(txt_cidade.Text.Trim());

                if (t != null)
                {
                    string dados_previsao =
                        $"Descrição: {t.description}\n" +
                        $"Latitude: {t.lat}\n" +
                        $"Longitude: {t.lon}\n" +
                        $"Nascer do Sol: {t.sunrise}\n" +
                        $"Pôr do Sol: {t.sunset}\n" +
                        $"Temp. Máxima: {t.temp_max} °C\n" +
                        $"Temp. Mínima: {t.temp_min} °C\n" +
                        $"Velocidade do vento: {t.speed} m/s\n" +
                        $"Visibilidade: {t.visibility} metros";

                    lbl_res.Text = dados_previsao;
                }
                else
                {
                    lbl_res.Text = "Sem dados de previsão.";
                }
            }
            else
            {
                lbl_res.Text = "Preencha a cidade.";
            }
        }
        catch (HttpRequestException)
        {
            await DisplayAlert(
                "Sem conexão",
                "Não foi possível acessar a internet. Verifique sua conexão e tente novamente.",
                "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
