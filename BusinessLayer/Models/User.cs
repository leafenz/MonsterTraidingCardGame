using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonsterTraidingCardGame.Classes.Card;
using System.Xml.Linq;

namespace MonsterTraidingCardGame.Classes
{
    internal class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        private string Username { get; set; }
        private string Password { get; set; }
        private int Elo { get; set; } = 100;
        private int Coins { get; set; } = 20;
        private List<Card> Stack { get; set; }
        private List<Card> Deck { get; set; }

        public void AddElo(int amount)
        {
            Elo += amount;
        }
        public void SubtractElo(int amount)
        {
            Elo -= amount;
        }

        public void AddCardtoDeck(Card card) { }
        public void BuyPackage()
        {
            if (Coins < 5)
            {
                Console.WriteLine("nicht genügend Münzen");
                return;
            }

            Coins -= 5;
            List<Card> newCards = GenerateRandomCards(5);

            Stack.AddRange(newCards);

            Console.WriteLine("Paket wurde gekauft");
        }

        private List<Card> GenerateRandomCards(int count)
        {
            var cardList = new List<Card>();
            return cardList;
        }
    }
}
