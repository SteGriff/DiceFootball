using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball
{
    public class Game
    {

        //-10 to 0 is player0 endzone, 50 is the 50 line, 100 to 110 is player1 endzone
        //See getYardName
        int ballOn = 50;

        int activeTeamNumber = 1;

        Phase phase = Phase.Kickoff;
        int down = 1;
        int yardsToGo = 10;

        private List<Team> Teams;

        private Team activeTeam
        {
            get
            {
                return Teams[activeTeamNumber];
            }
        }

        private Team otherTeam
        {
            get
            {
                return Teams[nextTeam(activeTeamNumber)];
            }
        }

        public void Setup()
        {
            Teams = new List<Team>()
            {
                new Team()
                {
                    Number = 0,
                    Name = "Arizona Cardinals",
                    Code = "ARI",
                    IsCPU = false
                },
                new Team()
                {
                    Number = 1,
                    Name = "Dallas Cowboys",
                    Code = "DAL",
                    IsCPU = true
                }
            };
        }

        public void Play()
        {
            while (true)
            {
                var messages = new List<string>();

                Console.WriteLine(Commentary.CommentForPhase(phase));

                switch (phase)
                {
                    case Phase.Kickoff:
                        activeTeam.Role = TeamRole.Kicking;
                        otherTeam.Role = TeamRole.Receiving;
                        Commentary.CommentForTeams(activeTeam, otherTeam);
                        int kickYards = DiceThrow.KickYards(messages);
                        NextTeam();
                        phase = Phase.Drive;
                        break;

                    case Phase.Drive:
                        activeTeam.Role = TeamRole.Offense;
                        otherTeam.Role = TeamRole.Defense;
                        Commentary.CommentForTeams(activeTeam, otherTeam);
                        break;
                }
            }

        }

        private void NextTeam()
        {
            activeTeamNumber = nextTeam(activeTeamNumber);
        }

        public int nextTeam(int thisTeam)
        {
            return (thisTeam + 1) % 2;
        }

    }
}
