namespace HotelBraga.Models;

// Classe base: as suítes compartilham estes dados e este cálculo.
public class Quarto
{
    private decimal valorDiariaAdulto;
    private decimal valorDiariaCrianca;

    public string Descricao { get; set; } = string.Empty;
    public string Detalhes { get; set; } = string.Empty;
    public string Imagem { get; set; } = string.Empty;
    public string ValoresFormatados => $"Adulto: {ValorDiariaAdulto:C}  •  Criança: {ValorDiariaCrianca:C} / diária";

    public decimal ValorDiariaAdulto
    {
        get => valorDiariaAdulto;
        set => valorDiariaAdulto = value >= 0
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), "A diária não pode ser negativa.");
    }

    public decimal ValorDiariaCrianca
    {
        get => valorDiariaCrianca;
        set => valorDiariaCrianca = value >= 0
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), "A diária não pode ser negativa.");
    }

    // virtual: tipos específicos de quarto podem mudar o cálculo.
    public virtual decimal CalcularTotal(int adultos, int criancas, int diarias)
    {
        if (adultos < 1 || criancas < 0 || diarias < 1)
            throw new ArgumentException("Confira os hóspedes e o período da reserva.");

        return (adultos * ValorDiariaAdulto + criancas * ValorDiariaCrianca) * diarias;
    }
}
