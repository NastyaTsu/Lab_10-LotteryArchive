using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class LotteryParticipant : Person
    {
        public List<Ticket> Tickets { get; } = new List<Ticket>();
        public List<int> Winnings { get; } = new List<int>();

        public void AddWinning(int amount)
        {
            Winnings.Add(amount);
            Balance += amount;
        }
        public LotteryParticipant(string firstname, string lastname, int balance, int zhadnost) : base(firstname, lastname)
        {
            Balance = balance;
            Zhadnost = zhadnost;
        }
        public Ticket Buy(Lottery lottery)
        {
            var ticket = new Ticket(lottery, this);
            if (ticket.Cost > Balance)
            {
                return null;
            }
            else
            {
                Balance -= ticket.Cost;
                Tickets.Add(ticket);
                return ticket;
            }

        }
    }
}
