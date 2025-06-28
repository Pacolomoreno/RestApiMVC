namespace RestApiMVC.Controller;

using System.Collections;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using RestApiMVC.Model;
using RestApiMVC.View;

public static class NoMatch
{

    public static void Start()
    {   // PREPARATIONS
        CardDeck GameDeck = new CardDeck();
        CardDeck UserDeck = new CardDeck();


        bool Busted;
        int Score = 0;
        int MaxScore = 0;
        String ResultMsg = "";

        // ASK IF INSTRUCTIONS IS NEEDED
        GameTitle();
        if (UserInput.userChooseYN("Instructions Needed ? "))
            Game.ShowInstuctions("./Data/NoMatch.txt");

        // MAIN LOOP
        do
        {
            UserDeck.Empty();
            Score = 0;
            Busted = false;

            do
            {
                GameDeck.Empty();
                GameDeck.SetFullDeck();

                CardTable.Clean();
                GameTitle();
                Console.WriteLine($"     Today's RECORD = [ {MaxScore} ]");
                for (int round = 1; round < 5; round++)
                {
                    Console.WriteLine($"\nSEQUENCE {round}");
                    foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
                    {
                        Card Carta = GameDeck.GetCard();
                        UserDeck.SetCard(Carta);
                        Console.Write($"\n{rank} - ");
                        CardStack.ShowCard(Carta);
                        UserInput.PauseTilKeyPresed();
                        if (Carta.Rank == rank)
                        {
                            Console.Write(" --BUSTED");
                            Busted = true;
                            Score += UserDeck.Count;
                            ResultMsg = $"Your Score was {Score}";
                            if (Score > MaxScore)
                            {
                                MaxScore = Score;
                                ResultMsg = $"Congratulationns the new record is {MaxScore}";
                            }
                            goto EndSequence;
                        }
                    }
                }
            } while (!Busted);

        EndSequence:;
            Console.WriteLine();
            CardTable.Banner(ResultMsg);

        }
        while (UserInput.userChooseYN("Play More ? "));

        Console.WriteLine("\nEnd of Game");
    }

    public static void GameTitle()
    {
        CardTable.Clean();
        CardTable.Banner("NO MATCH");
    }



}


