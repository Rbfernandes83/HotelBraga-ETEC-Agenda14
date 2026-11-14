using HotelBraga.Models;
using HotelBraga.Services;

namespace HotelBraga.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();
        Quartos.ItemsSource = QuartoService.Listar();

        Entrada.MinimumDate = DateTime.Today;
        Entrada.MaximumDate = DateTime.Today.AddMonths(6);
        Entrada.Date = DateTime.Today;
        AtualizarSaida();
    }

    private void AtualizarSaida()
    {
        DateTime minima = Entrada.Date.AddDays(1);
        DateTime maxima = Entrada.Date.AddMonths(6);

        // Ajusta a data atual antes de alterar os limites do controle.
        if (Saida.Date < minima || Saida.Date > maxima)
            Saida.Date = minima;

        // Ajustar o máximo primeiro evita um intervalo temporário inválido.
        Saida.MaximumDate = maxima;
        Saida.MinimumDate = minima;
    }

    private void EntradaAlterada(object sender, DateChangedEventArgs e)
    {
        AtualizarSaida();
    }

    private async void Confirmar(object sender, EventArgs e)
    {
        if (Quartos.SelectedItem is not Quarto quarto)
        {
            await DisplayAlert("Atenção", "Escolha uma acomodação.", "OK");
            return;
        }

        if (Entrada.Date.Date < DateTime.Today || Saida.Date <= Entrada.Date)
        {
            await DisplayAlert("Atenção", "Confira as datas de check-in e check-out.", "OK");
            return;
        }

        var reserva = new Reserva
        {
            Quarto = quarto,
            Adultos = (int)Adultos.Value,
            Criancas = (int)Criancas.Value,
            Entrada = Entrada.Date,
            Saida = Saida.Date
        };

        await Navigation.PushAsync(new HospedagemContratada(reserva));
    }

    private async void AbrirSobre(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}
