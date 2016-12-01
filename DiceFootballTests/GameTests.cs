using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceFootball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceFootball.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void ballOnOwn10()
        {
            var game = new Game();

            string expected = "OWN 10";
            string actual = Yardage.YardName(10, getTestActiveTeam, getTestOtherTeam);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ballOnOwn49()
        {
            var game = new Game();

            string expected = "OWN 49";
            string actual = Yardage.YardName(49, getTestActiveTeam, getTestOtherTeam);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ballOnOther10()
        {
            var game = new Game();

            string expected = "DAL 10";
            string actual = Yardage.YardName(90, getTestActiveTeam, getTestOtherTeam);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ballOnOther49()
        {
            var game = new Game();

            string expected = "DAL 49";
            string actual = Yardage.YardName(51, getTestActiveTeam, getTestOtherTeam);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ballOn50()
        {
            var game = new Game();

            string expected = "50";
            string actual = Yardage.YardName(50, getTestActiveTeam, getTestOtherTeam);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void nextTeamIsAlwaysOneOrZero()
        {
            var game = new Game();

            Assert.AreEqual(game.nextTeam(0), 1);
            Assert.AreEqual(game.nextTeam(1), 0);
        }

        [TestMethod()]
        public void player0NflYard10()
        {
            var game = new Game();

            int expected = 10;
            int actual = Yardage.YardNumberForTeam(10, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void player1NflYard10()
        {
            var game = new Game();

            int expected = 90;
            int actual = Yardage.YardNumberForTeam(10, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void playerBothNflYard50()
        {
            var game = new Game();

            int expected = 50;
            int actual0 = Yardage.YardNumberForTeam(50, 0);
            int actual1 = Yardage.YardNumberForTeam(50, 1);

            Assert.AreEqual(expected, actual0);
            Assert.AreEqual(expected, actual1);
        }
        
        [TestMethod()]
        public void coinIsFair()
        {
            var results = new List<bool>();
            for(int i = 0; i < 10000; i++)
            {
                bool result = Coin.Flip();
                results.Add(result);
            }

            var heads = results.Count(r => r == true);
            var tails = results.Count(r => r == false);

            int countDiff = Math.Abs(heads - tails);
            Assert.IsTrue(countDiff < 400);
        }


        private Team testActiveTeam;
        private Team getTestActiveTeam
        {
            get
            {
                if (testActiveTeam == null)
                {
                    testActiveTeam = new Team()
                    {
                        Code = "ARI",
                        IsCPU = false,
                        Name = "Arizona Cardinals",
                        Number = 0
                    };
                }
                return testActiveTeam;
            }
        }

        private Team testOtherTeam;
        private Team getTestOtherTeam
        {
            get
            {
                if (testOtherTeam == null)
                {
                    testOtherTeam = new Team()
                    {
                        Code = "DAL",
                        IsCPU = true,
                        Name = "Dallas Cowboys",
                        Number = 1
                    };
                }
                return testOtherTeam;
            }
        }
    }
}