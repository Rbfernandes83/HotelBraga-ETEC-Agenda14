using HotelBraga.Models;
using System.Globalization;

namespace HotelBraga.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(Reserva reserva)
    {
        InitializeComponent();

        QuartoTexto.Text = reserva.Quarto.Descricao;
        HospedesTexto.Text = $"Adultos: {reserva.Adultos} | Crianças: {reserva.Criancas}";
        DatasTexto.Text = $"Check-in: {reserva.Entrada:dd/MM/yyyy} | Check-out: {reserva.Saida:dd/MM/yyyy}";
        DiariasTexto.Text = $"Diárias: {reserva.Diarias}";
        TotalTexto.Text = $"Total: {reserva.Total.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}";
    }

    private async void Voltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
