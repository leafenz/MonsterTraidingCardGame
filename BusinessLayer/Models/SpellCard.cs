using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonsterTraidingCardGame.Classes.Card;

namespace MonsterTraidingCardGame.Classes
{
    internal class SpellCard : Card
    {
        public SpellCard(string name, int damage, ElementType element)
        : base(name, damage, element) { }
    }
}
