using System;

namespace RestApiMVC.Model
{
    public class CardDeck
    {

        public const int TotalCards = 52;
        public int Count { get; set; } = 0;
        private List<Card> _deck { get; init; } = new List<Card>();


        public CardDeck()
        {
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
                {
                    _deck.Add(new Card(suit, rank, (int)rank));
                    Count++;
                }
            }
        }

        public Card GetCard()
        {
            if (Count == 0) throw new InvalidOperationException("Deck is empty");
            Random rnd = new Random();
            int RandomIndex = rnd.Next(Count);
            Card card = _deck[RandomIndex];
            _deck.RemoveAt(RandomIndex);
            Count--;
            return card;
        }
    }




}
