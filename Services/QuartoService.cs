using HotelBraga.Models;

namespace HotelBraga.Services;

public static class QuartoService
{
    public static List<Quarto> Listar() => new()
    {
        new SuiteLuxo { Descricao = "Suíte Super Luxo", ValorDiariaAdulto = 110m, ValorDiariaCrianca = 55m },
        new SuiteLuxo { Descricao = "Suíte Luxo", ValorDiariaAdulto = 80m, ValorDiariaCrianca = 40m },
        new Quarto { Descricao = "Suíte Single", ValorDiariaAdulto = 50m, ValorDiariaCrianca = 25m },
        new Quarto { Descricao = "Suíte Econômica", ValorDiariaAdulto = 25m, ValorDiariaCrianca = 12.5m }
    };
}
