namespace RestApiMVC.Controller;

using System.Collections;
using System.Security.Cryptography.X509Certificates;
using RestApiMVC.Model;
using RestApiMVC.View;

public static class BlackJack
{
    const int BustLimit = 21;
    const int DealerRisk = 4;

    public static void Start()
    {   // PREPARATIONS
        CardDeck GameDeck = new CardDeck();
        CardDeck UserDeck = new CardDeck();
        CardDeck DealerDeck = new CardDeck();


        bool Busted;
        bool DealerBusted;
        bool Stand;
        bool EOG;
        int Wallet = 500;
        int Bet = 50;
        bool PlayerLost;
        String ResultMsg = "";

        // ASK IF INSTRUCTIONS IS NEEDED
        GameTitle();
        if (UserInput.userChooseYN("Instructions Needed ? "))
            Game.ShowInstuctions("./Data/BlackJack.txt");
        do
        {
            // GAME STARTS
            GameDeck.Empty();
            GameDeck.SetFullDeck();
            UserDeck.Empty();
            DealerDeck.Empty();
            EOG = false;
            Busted = false;
            Stand = false;
            PlayerLost = false;

            DealerBusted = false;

            //PLAYER HAND
            do
            {
                GameTitle();

                // CardStack.ShowCards(GameDeck);
                CardTable.ShowWallet(Wallet, Bet);
                CardTable.Banner("USER  PLAYS");
                Card Carta = GameDeck.GetCard();
                UserDeck.SetCard(Carta);
                CardStack.ShowCards(UserDeck);
                Console.Write($"Actual Score : {ScoreAceAdjust(UserDeck)}\n\n");
                if (ScoreAceAdjust(UserDeck) > BustLimit) { Busted = true; break; }
                Stand = UserInput.userChooseByInitial("What do you want ?", "hit,stand") == 's';
            }
            while (!Busted && !Stand);
            if (Busted)
            {
                ResultMsg = "BUSTED! YOU LOST";
                PlayerLost = true;
            }
            else
            {

                // DEALER HAND
                if (Stand)
                {
                    do
                    {
                        //Shows also user hand on top
                        GameTitle();
                        CardTable.ShowWallet(Wallet, Bet); GameTitle();
                        CardTable.ShowWallet(Wallet, Bet);
                        CardTable.Banner("USER  HAND");
                        CardStack.ShowCards(UserDeck);
                        Console.Write($"User Score : {ScoreAceAdjust(UserDeck)}\n\n");

                        // Dealer gets cards
                        CardTable.Banner("DEALER  PLAYS!");
                        Card Carta = GameDeck.GetCard();
                        DealerDeck.SetCard(Carta);
                        CardStack.ShowCards(DealerDeck);
                        Console.Write($"Dealer Score : {ScoreAceAdjust(DealerDeck)}\n\n");
                        DealerBusted = ScoreAceAdjust(DealerDeck) > BustLimit;
                        UserInput.PauseTilKeyPresed();
                    }
                    while (!DealerBusted && (Math.Abs(BustLimit - ScoreAceAdjust(DealerDeck)) > DealerRisk));

                    if (!DealerBusted)
                    {
                        Console.WriteLine($"Dealer Holds with {ScoreAceAdjust(DealerDeck)}");
                        if (ScoreAceAdjust(DealerDeck) < ScoreAceAdjust(UserDeck))
                        {
                            // User Wins
                            ResultMsg = "YOU WIN !";

                        }
                        else
                        {
                            //Dealer Wins
                            PlayerLost = true;
                            ResultMsg = "YOU LOOSE !";
                        }
                    }
                    else
                    {
                        ResultMsg = " DEALER BOOSTED ";
                    }

                }
            }

            // GAME RESULTS
            Console.WriteLine();
            CardTable.Banner(ResultMsg);


            // MONEY TALKS
            if (PlayerLost) Wallet -= Bet; else Wallet += Bet;

            if (Wallet < 1) EOG = true;

            switch (UserInput.userChooseByInitial("What now?", "playMore,doubleBet,splitBet,endGame"))
            {
                case 'p':
                    break;
                case 'd':
                    Bet *= 2;
                    break;
                case 's':
                    Bet /= 2;
                    break;
                case 'e':
                    EOG = true;
                    break;
            }

        } while (!EOG);



        Console.WriteLine("\nEnd of Game");


    }

    public static void GameTitle()
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


