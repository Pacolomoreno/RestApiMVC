using RestApiMVC.Model;

namespace RestApiMVC;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        CardDeck Baraja = new CardDeck();
        while (Baraja.Count > 0)
        {
            Card Carta = Baraja.GetCard();
            Console.Write(char.ConvertFromUtf32(Carta.symbol) + Carta.Rank + " | ");
        }

    }
}
