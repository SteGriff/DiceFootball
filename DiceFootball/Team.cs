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
        public string DefenceGuess { get; set; }

        public void SetOffenseStrategy()
        {
            if (IsCPU)
            {
                //CPU chooses randomly PASS or RUSH play
                OffenseStrategy = Coin.Flip()
                    ? OffensiveStrategy.PASS
                    : OffensiveStrategy.RUSH;
            }
            else
            {
                //Human player types in pass (p) or rush (r)

                string response = "";
                var responseMap = new Dictionary<string, string>()
                {
                    { "pass", OffensiveStrategy.PASS },
                    { "p", OffensiveStrategy.PASS },
                    { "rush", OffensiveStrategy.RUSH },
                    { "r", OffensiveStrategy.RUSH }
                };

                while (!responseMap.ContainsKey(response.ToLower()))
                {
                    Console.WriteLine("Pass or rush? (p or r): ");
                    response = Console.ReadLine();
                }

                OffenseStrategy = GetStrategyInput();
            }
        }

        public void SetDefenceGuess()
        {
            if (IsCPU)
            {
                //CPU guesses randomly whether the opposing offense will PASS or RUSH
                DefenceGuess = Coin.Flip()
                    ? OffensiveStrategy.PASS
                    : OffensiveStrategy.RUSH;
            }
            else
            {
                //Human player types in their guess

                DefenceGuess = GetStrategyInput();
            }
        }

        private string GetStrategyInput()
        {
            string response = "";
            var responseMap = new Dictionary<string, string>()
                {
                    { "pass", OffensiveStrategy.PASS },
                    { "p", OffensiveStrategy.PASS },
                    { "rush", OffensiveStrategy.RUSH },
                    { "r", OffensiveStrategy.RUSH }
                };

            while (!responseMap.ContainsKey(response.ToLower()))
            {
                Console.WriteLine("Pass or rush? (p or r): ");
                response = Console.ReadLine();
            }

            return responseMap[response.ToLower()];
        }

        public int MoveBall(int yards)
        {
            if (Number == 0)
            {
                return yards;
            }
            return -yards;
        }
    }
}
