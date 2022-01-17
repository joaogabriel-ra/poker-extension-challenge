using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Classes
{
    public class StringSplitter
    {
        IList<char> _splitChars = new List<char>();

        public void AddCharacterToSplitOn(char splitCharacter)
        {
            _splitChars.Add(splitCharacter);
        }

        public IEnumerable<string> Split(string input)
        {
            return input.Split(_splitChars.ToArray()).Where(c => !String.IsNullOrEmpty(c));
        }
    }
}
