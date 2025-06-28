using RestApiMVC.Model;

namespace RestApiMVC.View;

public static class CardStack
{
    public static void ShowCards(CardDeck stack)
    {
        foreach (Card myCard in stack)
        {
            Console.Write(char.ConvertFromUtf32(myCard.symbol) + myCard.Rank + "\t");
        }
        Console.WriteLine("\n______________________________________________\n");
    }

    public static void ShowCard(Card myCard)
    {

        Console.Write(char.ConvertFromUtf32(myCard.symbol) + myCard.Rank);

    }


}