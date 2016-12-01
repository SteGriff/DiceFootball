using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball
{
    class Dice
    {
        private Random _random;
        private Random Randomiser
        {
            get
            {
                if (_random == null)
                {
                    _random = new Random();
                }
                return _random;
            }
        }

        private int _type;
        private int _multiplier;

        public Dice(int type, int multiplier)
        {
            _type = type;
            _multiplier = multiplier;
        }

        public int Roll(out string message)
        {
            int faceValue = Randomiser.Next(1, _type);
            int totalValue = faceValue * _multiplier;
            message = string.Format("Rolling d{0}{1}... {2}",
                _type,
                _multiplier > 1 ? " x " + _multiplier : "",
                totalValue);

            return totalValue;
        }
        
    }
}
