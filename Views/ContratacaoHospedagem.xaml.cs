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
        Saida.MinimumDate = Entrada.Date.AddDays(1);
        Saida.MaximumDate = Entrada.Date.AddMonths(6);

        if (Saida.Date < Saida.MinimumDate || Saida.Date > Saida.MaximumDate)
            Saida.Date = Saida.MinimumDate;
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

        if (Saida.Date <= Entrada.Date)
        {
            await DisplayAlert("Atenção", "O check-out deve ser depois do check-in.", "OK");
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
