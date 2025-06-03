using LotteryArchive.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Lottery
{
    internal interface ILotteryService
    {
        WinningTicket DetermineWinner();

        void CancelLottery();
        bool SellAdditionalTickets(LotteryParticipant participant, int count);
        Ticket Buy(LotteryParticipant person);
        void DistributeTickets(List<LotteryParticipant> participants);
    }
}
