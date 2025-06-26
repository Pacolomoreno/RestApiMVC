using RestApiMVC.Model;

namespace RestApiMVC.Model;

public class Card(Suits suit, Ranks rank, int cardValue)
{
    public Suits Suit { get; set; } = suit;
    public Ranks Rank { get; set; } = rank;
    public int CardValue { get; set; } = cardValue;
    public char symbol => GetSuitSymbol();

    private char GetSuitSymbol()
    {
        return Suit switch
        {
            Suits.Hearts => '♥',
            Suits.Diamonds => '♦',
            Suits.Clubs => '♣',
            Suits.Spades => '♠',
            _ => ' '
        };
    }




}