using System.Collections.Generic;

namespace Poker.Classes
{
    public class AToBConverter<TA, TB> where TB : struct
    {
        private readonly IDictionary<TA, TB> _conversions;

        public AToBConverter(IDictionary<TA, TB> conversions)
        {
            _conversions = conversions;
        }

        public TB? Convert(TA input)
        {
            TB output;

            if (_conversions.TryGetValue(input, out output))
            {
                return output;
            }

            return null;
        }
    }
}
