using HotelBraga.Models;
using System.Globalization;

namespace HotelBraga.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(Reserva reserva)
    {
        InitializeComponent();

        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        QuartoTexto.Text = reserva.Quarto.Descricao;
        HospedesTexto.Text = $"Adultos: {reserva.Adultos} | Crianças: {reserva.Criancas}";
        DatasTexto.Text = $"Check-in: {reserva.Entrada:dd/MM/yyyy} | Check-out: {reserva.Saida:dd/MM/yyyy}";
        DiariasTexto.Text = $"Diárias: {reserva.Diarias}";
        DescontoTexto.IsVisible = reserva.Desconto > 0;
        DescontoTexto.Text = $"Desconto da suíte: {reserva.Desconto.ToString("C", cultura)}";
        TotalTexto.Text = $"Total: {reserva.Total.ToString("C", cultura)}";
    }

    private async void Voltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
