namespace Poker.Classes
{
    public class Card<TSuit, TRank>
    {
        public Card(TSuit suit, TRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public TSuit Suit { get; private set; }
        public TRank Rank { get; private set; }
    }
}
