namespace HotelBraga.Models;

// Herança: SuiteLuxo é um tipo de Quarto.
// Polimorfismo: aplica desconto de 5% em reservas de 3 ou mais diárias.
public class SuiteLuxo : Quarto
{
    public override decimal CalcularTotal(int adultos, int criancas, int diarias)
    {
        decimal valor = base.CalcularTotal(adultos, criancas, diarias);

        if (diarias >= 3)
            return decimal.Round(valor * 0.95m, 2, MidpointRounding.AwayFromZero);

        return valor;
    }
}
