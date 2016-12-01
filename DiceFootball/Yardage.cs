using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball
{
    public static class Yardage
    {
        // Comparison of GAME yards and NFL yards
        //-10  0  10  20  30  40  50  60  70  80  90  100 110   (GAME)
        // |   |  Player 0        |  Player 1         |   |
        // |   0  10  20  30  40  50  40  30  20  10  0   |     (NFL)
        // |   |                  |                   |   |
        
        /// <summary>
        /// Change an NFL yard number for a given team (like player1's 40 yard) into a game yard number (
        /// </summary>
        /// <param name="nflYard"></param>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        public static int YardNumberForTeam(int nflYard, int playerNumber)
        {
            if (playerNumber == 0)
            {
                return nflYard;
            }
            else
            {
                return (100 - nflYard);
            }
        }
        
        public static string YardName(int ballOn, Team activeTeam, Team otherTeam)
        {
            string own = "OWN ";
            string other = otherTeam.Code + " ";

            if (ballOn == 50)
            {
                return ballOn.ToString();
            }
            else if (ballOn < 50)
            {
                if (activeTeam.Number == 0)
                {
                    return own + ballOn;
                }
                else
                {
                    return other + ballOn;
                }
            }
            else if (ballOn > 50)
            {
                ballOn = 100 - ballOn;
                if (activeTeam.Number == 0)
                {
                    return other + ballOn;
                }
                else
                {
                    return own + ballOn;
                }
            }

            throw new ApplicationException("Where's the ball?");

        }
    }
}
