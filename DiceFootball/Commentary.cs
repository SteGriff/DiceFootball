using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball
{
    public static class Commentary
    {
        public static string CommentForPhase(Phase phase)
        {
            switch(phase)
            {
                case Phase.Kickoff:
                    return "There goes the kickoff";
                default:
                    return phase.ToString();
            }
        }

        public static void CommentForTeams(Team active, Team other)
        {
            Console.WriteLine("{0} {1}", active.Name, active.Role);
            Console.WriteLine("{0} {1}", other.Name, other.Role);
        }
    }
}
