using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTraidingCardGame.Classes
{
    internal class Scoreboard
    {
        public List<User> Scores { get; private set; }
        public void AddPlayer(User player)
        {
            Scores.Add(player);
        }
        public void PrintScoreboard() { }
    }
}
