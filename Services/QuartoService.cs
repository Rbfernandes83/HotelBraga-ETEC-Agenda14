using HotelBraga.Models;

namespace HotelBraga.Services;

public static class QuartoService
{
    public static List<Quarto> Listar() => new()
    {
        new SuiteLuxo { Descricao = "Suíte Super Luxo", Detalhes = "Ambiente sofisticado, cama ampla, decoração elegante e experiência premium.", Imagem = "quarto_casal.jpg", ValorDiariaAdulto = 110m, ValorDiariaCrianca = 55m },
        new SuiteLuxo { Descricao = "Suíte Luxo", Detalhes = "Conforto superior, iluminação acolhedora e acabamento contemporâneo.", Imagem = "quarto_duplo.jpg", ValorDiariaAdulto = 80m, ValorDiariaCrianca = 40m },
        new Quarto { Descricao = "Suíte Single", Detalhes = "Acomodação prática e aconchegante para quem busca tranquilidade.", Imagem = "quarto_individual.jpg", ValorDiariaAdulto = 50m, ValorDiariaCrianca = 25m },
        new Quarto { Descricao = "Suíte Econômica", Detalhes = "Uma opção funcional e confortável com excelente custo-benefício.", Imagem = "quarto_familia.jpg", ValorDiariaAdulto = 25m, ValorDiariaCrianca = 12.5m }
    };
}
