namespace HotelBraga.Models;

public class Reserva
{
    public Quarto Quarto { get; set; } = new();
    public int Adultos { get; set; }
    public int Criancas { get; set; }
    public DateTime Entrada { get; set; }
    public DateTime Saida { get; set; }

    public int Diarias => (Saida.Date - Entrada.Date).Days;

    public decimal Total => Diarias *
        (Adultos * Quarto.ValorDiariaAdulto + Criancas * Quarto.ValorDiariaCrianca);
}
