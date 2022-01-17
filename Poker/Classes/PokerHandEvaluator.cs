using Poker.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Classes
{
    public class PokerHandEvaluator<TSuit, TRank> : IPokerHandEvaluator<TSuit, TRank>
    {
        bool IPokerHandEvaluator<TSuit, TRank>.IsPair(IEnumerable<Card<TSuit, TRank>> cards)
        {
            return cards.GroupBy(c => c.Rank).Any(g => g.Count() >= 2);
        }

        bool IPokerHandEvaluator<TSuit, TRank>.IsThreeOfAKind(IEnumerable<Card<TSuit, TRank>> cards)
        {
            return cards.GroupBy(c => c.Rank).Any(g => g.Count() >= 3);
        }

        bool IPokerHandEvaluator<TSuit, TRank>.IsFlush(IEnumerable<Card<TSuit, TRank>> cards)
        {
            string suit = cards.FirstOrDefault().Suit.ToString();

            return cards.All(x => x.Suit.ToString() == suit);
        }

        bool IPokerHandEvaluator<TSuit, TRank>.IsValid(IEnumerable<Card<TSuit, TRank>> cards)
        {
            return cards.Count() >= 2 ? true : false;
        }
    }
}
