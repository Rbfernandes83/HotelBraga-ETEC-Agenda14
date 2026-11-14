# Hotel Braga — Agenda 14

Projeto de Desenvolvimento de Sistemas II da ETEC, feito em C# e .NET MAUI.

## O que o aplicativo faz
- Escolhe a suíte e a quantidade de adultos e crianças
- Valida check-in e check-out
- Calcula o valor da hospedagem conforme o número de diárias
- Mostra um resumo com os dados da reserva

## Conceitos da Agenda 14
- **Encapsulamento:** propriedades de valor da diária validam preços negativos em `Models/Quarto.cs`
- **Herança:** `SuiteLuxo : Quarto` em `Models/SuiteLuxo.cs`
- **Polimorfismo:** `SuiteLuxo` redefine `CalcularTotal` e aplica 5% de desconto em reservas de 3 ou mais diárias
- **Orientação a objetos:** `Reserva` concentra os dados e usa o método do tipo de quarto selecionado
- **Validação da interface:** `Picker`, `Stepper` e `DatePicker`

## Organização
- `Models`: Quarto, SuiteLuxo e Reserva
- `Services`: QuartoService
- `Views`: telas em XAML e C#
- `.github/workflows`: compilação Android pelo GitHub Actions

## Referência
Atividade baseada no AppHotel do material da ETEC:
https://github.com/tiagotas/MauiAppHotel/tree/4e655cb68610572865b83fc420655601b1a5f1ff

Projeto educacional. Compilação e testes no celular devem ser conferidos antes da entrega.
