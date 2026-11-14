using HotelBraga.Models;
using HotelBraga.Services;

namespace HotelBraga.Views;

public partial class AcomodacoesPage : ContentPage
{
    private readonly Action<Quarto> selecionar;

    public AcomodacoesPage(Action<Quarto> selecionar)
    {
        InitializeComponent();
        this.selecionar = selecionar;
        ListaQuartos.ItemsSource = QuartoService.Listar();
    }

    private async void SelecionarSuite(object sender, EventArgs e)
    {
        if (sender is Button { CommandParameter: Quarto quarto })
        {
            selecionar(quarto);
            await Navigation.PopAsync();
        }
    }
}
