using HotelBraga.Models;
using HotelBraga.Services;
using System.Globalization;

namespace HotelBraga.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private readonly CultureInfo cultura = CultureInfo.GetCultureInfo("pt-BR");
    private bool carregando = true;

    public ContratacaoHospedagem()
    {
        InitializeComponent();
        Quartos.ItemsSource = QuartoService.Listar();

        Entrada.MinimumDate = DateTime.Today;
        Entrada.MaximumDate = DateTime.Today.AddMonths(6);
        Entrada.Date = DateTime.Today;

        AtualizarSaida();
        carregando = false;
        AtualizarPrevia();
    }

    private void AtualizarSaida()
    {
        DateTime entrada = Entrada.Date?.Date ?? DateTime.Today;
        DateTime minima = entrada.AddDays(1);
        DateTime maxima = entrada.AddMonths(6);

        Saida.MaximumDate = maxima;
        if (Saida.Date is null || Saida.Date < minima || Saida.Date > maxima)
            Saida.Date = minima;
        Saida.MinimumDate = minima;
    }

    private void EntradaAlterada(object sender, DateChangedEventArgs e)
    {
        if (carregando) return;
        AtualizarSaida();
        AtualizarPrevia();
    }

    private void SaidaAlterada(object sender, DateChangedEventArgs e)
    {
        if (!carregando) AtualizarPrevia();
    }

    private void AtualizarPrevia(object sender, EventArgs e) => AtualizarPrevia();

    private void AtualizarPrevia()
    {
        if (carregando || EstimativaTexto is null) return;

        if (Quartos.SelectedItem is not Quarto quarto)
        {
            PrecoTexto.Text = "Selecione uma suíte para consultar os valores.";
            EstimativaTexto.Text = "Selecione uma suíte";
            BeneficioTexto.Text = string.Empty;
            return;
        }

        PrecoTexto.Text = $"Adulto: {quarto.ValorDiariaAdulto.ToString("C", cultura)}  •  Criança: {quarto.ValorDiariaCrianca.ToString("C", cultura)} / diária";

        DateTime? entrada = Entrada.Date?.Date;
        DateTime? saida = Saida.Date?.Date;
        if (entrada is null || saida is null || saida <= entrada)
        {
            EstimativaTexto.Text = "Confira as datas";
            BeneficioTexto.Text = string.Empty;
            return;
        }

        var reserva = CriarReserva(quarto, entrada.Value, saida.Value);
        EstimativaTexto.Text = reserva.Total.ToString("C", cultura);
        BeneficioTexto.Text = reserva.Desconto > 0
            ? $"Desconto especial: {reserva.Desconto.ToString("C", cultura)}"
            : $"{reserva.Diarias} diária(s) para {reserva.Adultos + reserva.Criancas} hóspede(s)";
    }

    private Reserva CriarReserva(Quarto quarto, DateTime entrada, DateTime saida) => new()
    {
        Quarto = quarto,
        Adultos = (int)Adultos.Value,
        Criancas = (int)Criancas.Value,
        Entrada = entrada,
        Saida = saida
    };

    private async void Confirmar(object sender, EventArgs e)
    {
        if (Quartos.SelectedItem is not Quarto quarto)
        {
            await DisplayAlertAsync("Atenção", "Escolha uma acomodação.", "OK");
            return;
        }

        DateTime? entrada = Entrada.Date?.Date;
        DateTime? saida = Saida.Date?.Date;

        if (entrada is null || saida is null ||
            entrada < DateTime.Today || saida <= entrada)
        {
            await DisplayAlertAsync("Atenção", "Confira as datas de check-in e check-out.", "OK");
            return;
        }

        await Navigation.PushAsync(new HospedagemContratada(CriarReserva(quarto, entrada.Value, saida.Value)));
    }

    private async void AbrirSobre(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}
