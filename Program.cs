using RestApiMVC.Model;

namespace RestApiMVC;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Repartiendo cartas!");
        CardDeck Baraja = new CardDeck();
        List<Card> Mano = new List<Card>();
        Baraja.SetFullDeck();
        while (Baraja.Count > 0)
        {
            Card Carta = Baraja.GetCard();
            Mano.Add(Carta);
            Console.Write(char.ConvertFromUtf32(Carta.symbol) + Carta.Rank + " | ");
        }

    }
}
