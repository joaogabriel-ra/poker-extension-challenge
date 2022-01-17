using Poker.Interfaces;
using System;
using System.Collections.Generic;
using static Poker.Enums.Enums;

namespace Poker.Classes
{
    public class HandParser
    {
        private readonly AToBConverter<char, Rank> _rankConverter = new AToBConverter<char, Rank>(_rankConversions);
        private readonly AToBConverter<char, Suit> _suitConverter = new AToBConverter<char, Suit>(_suitConversions);

        private static readonly IDictionary<char, Rank> _rankConversions = new Dictionary<char, Rank>()
        {
            {'A', Rank.Ace},
            {'2', Rank.Two},
            {'3', Rank.Three},
            {'4', Rank.Four},
            {'5', Rank.Five},
            {'6', Rank.Six},
            {'7', Rank.Seven},
            {'8', Rank.Eight},
            {'9', Rank.Nine},
            {'T', Rank.Ten},
            {'t', Rank.Ten},
            {'J', Rank.Jack},
            {'Q', Rank.Queen},
            {'O', Rank.Queen},
            {'K', Rank.King},
        };

        private static readonly IDictionary<char, Suit> _suitConversions = new Dictionary<char, Suit>()
        {
            {'H', Suit.Hearts},
            {'S', Suit.Spades},
            {'D', Suit.Diamonds},
            {'C', Suit.Clubs},
        };

        private Rank? ConvertRank(char input)
        {
            return _rankConverter.Convert(input);
        }

        private Suit? ConvertSuit(char input)
        {
            return _suitConverter.Convert(input);
        }

        private List<Card<Suit,Rank>> ReturnCards(IEnumerable<string> tokens)
        {
            List<Card<Suit, Rank>> cards = new List<Card<Suit, Rank>>();

            foreach (var token in tokens)
            {
                var rank = Convert.ToChar(token.Substring(0, 1));
                var suit = Convert.ToChar(token.Substring(1, 1));

                cards.Add(new Card<Suit, Rank>(ConvertSuit(suit).Value, ConvertRank(rank).Value));
            }

            return cards;
        }

        public string GetHandName(string input)
        {
            try
            {
                var splitter = new StringSplitter();

                splitter.AddCharacterToSplitOn(',');

                IEnumerable<string> tokens = splitter.Split(input);
                List<Card<Suit, Rank>> cards = ReturnCards(tokens);
                IPokerHandEvaluator<Suit, Rank> pokerHandEvaluator = new PokerHandEvaluator<Suit, Rank>();

                if (!pokerHandEvaluator.IsValid(cards))
                {
                    return "Invalid";
                }

                if (pokerHandEvaluator.IsFlush(cards))
                {
                    return "Flush";
                }
                //What happens if the input is "2D,2C,2H,2S,2D,2C"?
                //Do I have 3 pairs or 2 three of a kind?
                //What is the priority?
                else if (pokerHandEvaluator.IsPair(cards) && !pokerHandEvaluator.IsThreeOfAKind(cards)) 
                {
                    return "Pair";
                }
                else if (pokerHandEvaluator.IsThreeOfAKind(cards))
                {
                    return "Three of a kind";
                }
                else
                {
                    return "Not implemented";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }

    }
}
