namespace HotelBraga.Models;

public class Quarto
{
    public string Descricao { get; set; } = string.Empty;
    public decimal ValorDiariaAdulto { get; set; }
    public decimal ValorDiariaCrianca { get; set; }

    public override string ToString() => Descricao;
}
