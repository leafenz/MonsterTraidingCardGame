using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Models
{
    internal class SpellCard : Card
    {
        public SpellCard(string name, int damage, ElementType element)
        : base(name, damage, element) { }
    }
}
