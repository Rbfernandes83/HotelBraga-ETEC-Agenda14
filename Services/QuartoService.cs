using HotelBraga.Models;

namespace HotelBraga.Services;

public static class QuartoService
{
    public static List<Quarto> Listar() => new()
    {
        new() { Descricao = "Suíte Super Luxo", ValorDiariaAdulto = 110m, ValorDiariaCrianca = 55m },
        new() { Descricao = "Suíte Luxo", ValorDiariaAdulto = 80m, ValorDiariaCrianca = 40m },
        new() { Descricao = "Suíte Single", ValorDiariaAdulto = 50m, ValorDiariaCrianca = 25m },
        new() { Descricao = "Suíte Econômica", ValorDiariaAdulto = 25m, ValorDiariaCrianca = 12.5m }
    };
}
