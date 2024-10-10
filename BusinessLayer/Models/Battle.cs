using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTraidingCardGame.Classes
{
    internal class Battle
    {
        private User Player1 { get; set; }
        private User Player2 { get; set; }
        private int Round { get; set; } = 0;

        public Battle(User player1, User player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public void Fight() {}

        public void UpdateElo(User winner, User loser)
        {
            winner.AddElo(3);
            loser.SubtractElo(5);
        }

    }
}
