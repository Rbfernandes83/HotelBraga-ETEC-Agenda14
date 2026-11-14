namespace HotelBraga.Models;

public class Reserva
{
    public Quarto Quarto { get; set; } = new();
    public int Adultos { get; set; }
    public int Criancas { get; set; }
    public DateTime Entrada { get; set; }
    public DateTime Saida { get; set; }

    public int Diarias => (Saida.Date - Entrada.Date).Days;

    // A classe Quarto decide o cálculo: se for SuiteLuxo, aplica a regra própria.
    public decimal Total => Quarto.CalcularTotal(Adultos, Criancas, Diarias);

    public decimal TotalSemDesconto =>
        (Adultos * Quarto.ValorDiariaAdulto + Criancas * Quarto.ValorDiariaCrianca) * Diarias;

    public decimal Desconto => TotalSemDesconto - Total;
}
