namespace RestApiMVC.Controller;

using System.Security.Cryptography.X509Certificates;
using RestApiMVC.Model;
using RestApiMVC.View;

public static class BlackJack
{
    const int BustLimit = 21;

    public static void Start()
    {
        CardDeck GameDeck = new CardDeck();
        CardDeck UserDeck = new CardDeck();
        GameDeck.SetFullDeck();
        bool Busted = false;
        Wellcome();
        if (UserInput.userChooseYN("Instructions Needed ? "))
            Game.ShowInstuctions("./Data/Rules.txt");

        // GAME STARTS
        do
        {
            Wellcome();
            CardTable.Banner("LETS  PLAY!");
            Card Carta = GameDeck.GetCard();
            UserDeck.SetCard(Carta);
            CardStack.ShowCards(UserDeck);
            Console.Write($"Actual Score : {ScoreAceAdjust(UserDeck)}\n\n");
            Busted = (ScoreAceAdjust(UserDeck) > BustLimit);
        }
        while (!Busted && UserInput.userChooseByInitial("What do you want ?", "hit,stand") == 'h');
        if (Busted) CardTable.Banner("BUSTED! YOU LOST");


        if (GameDeck.Count == 0) { Console.WriteLine("\nYou Finished all the cards in the stack"); }
        else { Console.WriteLine("\nEnd of Game"); }


    }

    public static void Wellcome()
    {
        CardTable.Clean();
        CardTable.Banner("BLACK  JACK");
    }

    public static int ScoreAceAdjust(CardDeck CardStacktoAdjust)
    {
        int AdjustedScore = CardStacktoAdjust.Score;
        for (int i = 1; i <= CardStacktoAdjust.Aces; i++)
        {
            if (AdjustedScore > BustLimit) AdjustedScore -= 9;
        }
        return AdjustedScore;
    }

}


