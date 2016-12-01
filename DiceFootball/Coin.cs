using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball
{
    public static class Coin
    {
        private static Random _random;
        private static Random Randomiser
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

        public static bool Flip()
        {
            int face = Randomiser.Next(0, 2);
            return face == 0;
        }
    }
}
