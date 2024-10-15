using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Models
{

    internal class MonsterCard : Card
    {
        public MonsterCard(string name, int damage, ElementType element, MonsterType type)
        : base(name, damage, element)
        {
            MonsterType = type;
        }
        private MonsterType MonsterType { get; set; }
    }


    public enum MonsterType
    {
        Goblin,
        Dragon,
        Wizard,
        Ork,
        Knight,
        Kraken,
        FireElf
    }
}
