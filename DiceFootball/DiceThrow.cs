using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball
{
    static class DiceThrow
    {
        public static int KickYards(List<string> messages)
        {
            var dice = new List<Dice>()
            {
                new Dice(6, 10)
            };

            return Roll(dice, messages);
        }

        private static int Roll(List<Dice> dice, List<string> messages)
        {
            int total = 0;

            foreach (var d in dice)
            {
                string thisMessage = "";
                total += d.Roll(out thisMessage);
                messages.Add(thisMessage);
            }

            return total;
        }
    }
}
