using System;
using System.Collections;

namespace RestApiMVC.Model
{
    public class CardDeck : IEnumerable<Card>
    {

        public const int TotalCards = 52;
        public int Count { get; set; } = 0;
        private List<Card> _deck { get; init; } = new List<Card>();

        // Indexing [i]
        public Card? this[int index]
        {
            get => _deck[index];
            set => _deck[index] = value!;
        }

        public void SetFullDeck()
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

        public void SetCard(Card newCard)
        {
            _deck.Add(newCard);
            Count++;
        }


        public int Total => _deck.Sum(card => card.CardValue);

        public int Aces => _deck.Count(card => card.Rank == Ranks._1);

        public int Score => _deck.Sum(card => card.CardValue);



        // Ienumerator methods
        public IEnumerator<Card> GetEnumerator()
        {
            foreach (var card in _deck)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }




}
