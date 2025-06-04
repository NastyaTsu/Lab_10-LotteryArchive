using Model.Core.Lottery;
using Model.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Lottery : ILotteryService
    {
        public int Price {  get;  private set; }
        public TicetBase Buy(LotteryParticipant person)
        {
            return person.Buy(this);
        }
    }
}
