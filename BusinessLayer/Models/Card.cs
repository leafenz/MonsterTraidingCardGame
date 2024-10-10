using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace MonsterTraidingCardGame.Classes
{
    internal abstract class Card
    {
        protected Card(string name, int damage, ElementType element)
        {
            Name = name;
            Damage = damage;
            Element = element;
        }
        private string Name { get; set; }
        private int Damage { get; set; }
        private ElementType Element { get; set; }
        public enum ElementType
        {
            Fire,
            Water,
            Normal
        }
    }
}
