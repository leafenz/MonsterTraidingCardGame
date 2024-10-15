using System;
using System.Collections.Generic;
using BusinessLayer.Models;

namespace BusinessLayer.Models
{
    public class User
    {
        public User(string username, string password)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Stack = new List<Card>();
            Deck = new List<Card>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Elo { get; set; } = 100;
        public int Coins { get; set; } = 20;
        public List<Card> Stack { get; set; }
        public List<Card> Deck { get; set; }
        public string? Token { get; set; }

        public void AddElo(int amount)
        {
            Elo += amount;
        }

        public void SubtractElo(int amount)
        {
            Elo -= amount;
        }

        public void AddCardToDeck(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            Deck.Add(card);
        }

        public void BuyPackage()
        {
            if (Coins < 5)
            {
                Console.WriteLine("Nicht genügend Münzen");
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
