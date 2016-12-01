using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball
{
    public class Team
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Code { get; set; }
        public bool IsCPU { get; set; }
        public TeamRole Role { get; set; }
        public string OffenseStrategy { get; set; }

        public void SetOffenseStrategy()
        {
            if (IsCPU)
            {
                OffenseStrategy = Coin.Flip()
                    ? OffensiveStrategy.PASS
                    : OffensiveStrategy.RUSH;
            }
            else
            {
                string response = "";
                
                //while ()
                Console.WriteLine("Pass or rush? (p or r): ");
                response = Console.ReadLine();

            }
        }
    }
}
