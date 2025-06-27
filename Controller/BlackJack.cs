namespace RestApiMVC.Controller;

using System.Security.Cryptography.X509Certificates;
using RestApiMVC.Model;
using RestApiMVC.View;

public static class BlackJack
{

    public static void Start()
    {
        CardDeck Baraja = new CardDeck();
        List<Card> Mano = new List<Card>();
        Baraja.SetFullDeck();
        Wellcome();
        if (UserInput.userChooseYN("Instructions Needed ? "))
            Game.ShowInstuctions("./Data/Rules.txt");

        // GAME STARTS
        do
        {
            Wellcome();
            CardTable.Banner("LETS  PLAY!");
            Card Carta = Baraja.GetCard();
            Mano.Add(Carta);
            CardStack.ShowCards(Mano);
        }
        while (Baraja.Count > 0 && UserInput.userChooseByInitial("What do you want ?", "hit,stand") == 'h');

        if (Baraja.Count == 0) { Console.WriteLine("\nYou Finished all the cards in the stack"); }
        else { Console.WriteLine("\nEnd of Game"); }


    }

    public static void Wellcome()
    {
        CardTable.Clean();
        CardTable.Banner("BLACK  JACK");
    }
}


