using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public class WinningTicket : Ticket
    {
        private Lottery lot;
        public WinningTicket(Lottery lottery, LotteryParticipant person) : base(lottery, person)
        {
            lot = lottery;
        }
        public WinningTicket()
        {

        }

        public int Prize { get; private set; }
        private static readonly Random random = new Random();

        public Ticket Winningticket
        {
            get
            {
                if (lot == null || lot.Massivticket.Count == 0)
                    return null;

                int randomIndex = random.Next(lot.Massivticket.Count);
                return lot.Massivticket[randomIndex];
            }
        }
        public void NewPrice(int prize)
        {
            Prize = prize;
        }

    }
}
