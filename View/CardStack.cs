using RestApiMVC.Model;

namespace RestApiMVC.View;

public static class CardStack
{
    public static void ShowCards(List<Card> stack)
    {
        foreach (Card myCard in stack)
        {
            Console.Write(char.ConvertFromUtf32(myCard.symbol) + myCard.Rank + "\t");
        }
        Console.WriteLine("\n______________________________________________\n");
    }


}