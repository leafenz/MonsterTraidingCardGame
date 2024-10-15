using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using BusinessLayer.Models;

namespace BusinessLayer.Models
{
    public abstract class Card
    {
        protected Card(string name, int damage, ElementType element)
        {
            Name = name;
            Damage = damage;
            Element = element;
        }
        public string Name { get; set; }
        public int Damage { get; set; }
        public ElementType Element { get; set; }
        public enum ElementType
        {
            Fire,
            Water,
            Normal
        }
    }
}
