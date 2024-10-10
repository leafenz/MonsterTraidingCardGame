using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTraidingCardGame.Classes
{
    internal class Traiding
    {
        public enum TradeStatus
        {
            Pending,
            Completed
        }

        public string CardType { get; set; }
        public int MinDamage { get; set; }
        public Card OfferedCard { get; set; }
        public User OfferingPlayer { get; set; }
        public User AcceptingPlayer { get; set; }
        public TradeStatus Status { get; set; }

        public Traiding(User offeringPlayer, Card offeredCard, string cardType, int minDamage)
        {
            OfferingPlayer = offeringPlayer;
            OfferedCard = offeredCard;
            CardType = cardType;
            MinDamage = minDamage;
            Status = TradeStatus.Pending;
        }

        public void AcceptTrade() { }
    }
}
