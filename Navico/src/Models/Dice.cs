using System;

namespace Navico.Models
{
    public class Dice : IDice
    {
        private static readonly Random Random = new Random();
        private int _minimumValue { get; set; }
        private int _maximumValue { get; set; }

        public Dice(int MinimumValue, int MaximumValue)
        {
            _maximumValue = MinimumValue;
            _maximumValue = MaximumValue;
        }

        public int Roll()
        {
            return Random.Next(_minimumValue, _maximumValue);
        }
    }
}
