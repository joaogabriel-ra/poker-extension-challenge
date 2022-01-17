using Poker.Classes;
using System.Collections.Generic;

namespace Poker.Interfaces
{
    public interface IPokerHandEvaluator<TSuit, TRank>
    {
        bool IsPair(IEnumerable<Card<TSuit, TRank>> cards);
        bool IsThreeOfAKind(IEnumerable<Card<TSuit, TRank>> cards);
        bool IsFlush(IEnumerable<Card<TSuit, TRank>> cards);
        bool IsValid(IEnumerable<Card<TSuit, TRank>> cards);
    }
}
